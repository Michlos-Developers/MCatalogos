using DomainLayer.Models.PedidosVendedoras;
using DomainLayer.Models.Vendedora;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Specific.PedidoVendedora;
using InfrastructureLayer.DataAccess.Repositories.Specific.Vendedora;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.PedidosVendedorasServices;
using ServiceLayer.Services.VendedoraServices;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCatalogos.Views.FormViews.PedidoVendedora
{
    enum Status
    {
        Aberto,
        Enviado,
        Separado,
        Conferido,
        Finalizado,
        Despachado,
        Entregue,
        Cancelado
    }
    public partial class PedidosListForm : Form
    {
        #region PROPRIEDADES PARA MOVER A JANELA

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        #endregion

        MainView MainView;
        private List<PedidosVendedorasModel> PedidosList = new List<PedidosVendedorasModel>();
        private List<VendedoraModel> VendedorasList = new List<VendedoraModel>();

        private VendedoraModel VendedoraFilter = new VendedoraModel();
        private PedidosVendedorasModel Pedido = new PedidosVendedorasModel();

        private QueryStringServices _queryString;
        private PedidosVendedorasServices _pedidosServices;
        private VendedoraServices _vendedoraServices;

        private IEnumerable<PedidosVendedorasModel> pedidoVendedoraDGV;

        public PedidosListForm(MainView mainView)
        {
            _queryString = new QueryStringServices(new QueryString());
            _pedidosServices = new PedidosVendedorasServices(new PedidoVendedoraRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _vendedoraServices = new VendedoraServices(new VendedoraRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());

            InitializeComponent();
            MainView = mainView;
        }
        private void PedidosListForm_Load(object sender, EventArgs e)
        {
            DefineDataInicial();
            DefineDataFinal();
            ReadModels();
            LoadComboBoxVendedoras();
            


        }

        private void LoadDataGridView()
        {
            VendedoraModel vendedora = cbNomeVendedora.SelectedIndex != -1 ? cbNomeVendedora.SelectedItem as VendedoraModel : null;

            DateTime? dataRegistroIni = ReceiveDate(dateDataInicio.Text.ToString());
            DateTime? dataRegistroFim = ReceiveDate(dateDataFim.Text.ToString());
            bool enviado    =   false;
            bool separado   =   false;
            bool conferido  =   false;
            bool despachado =   false;
            bool entregue   =   false;
            bool cancelado  =   false;

            pedidoVendedoraDGV = PedidosList;

            if (vendedora != null)
            {
                pedidoVendedoraDGV = pedidoVendedoraDGV.Where(pedido => pedido.VendedoraId == vendedora.VendedoraId);

            }

            if (dataRegistroIni != null && dataRegistroFim != null)
            {
                pedidoVendedoraDGV = pedidoVendedoraDGV.Where(pedido => pedido.DataRegistro >= dataRegistroIni && pedido.DataRegistro <= dataRegistroFim);
            }

            if (cancelado)
            {
                pedidoVendedoraDGV = pedidoVendedoraDGV.Where(pedido => pedido.StatusPed == ((int)Status.Cancelado));
            }

            if (enviado)
            {
                pedidoVendedoraDGV = pedidoVendedoraDGV.Where(pedido => pedido.StatusPed == ((int)Status.Enviado));
            }

            if (separado)
            {
                pedidoVendedoraDGV = pedidoVendedoraDGV.Where(pedido => pedido.StatusPed == ((int)Status.Separado));
            }

            if (conferido)
            {
                pedidoVendedoraDGV = pedidoVendedoraDGV.Where(pedido => pedido.StatusPed == ((int)Status.Conferido));
            }

            if (despachado)
            {
                pedidoVendedoraDGV = pedidoVendedoraDGV.Where(pedido => pedido.StatusPed == ((int)Status.Despachado));
            }

            if (entregue)
            {
                pedidoVendedoraDGV = pedidoVendedoraDGV.Where(pedido => pedido.StatusPed == ((int)Status.Entregue));
            }

            DataTable tablePedidos = new DataTable();
            DataColumn column;
            DataRow row;

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "Código";
            tablePedidos.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Vendedora";
            tablePedidos.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.DateTime");
            column.ColumnName = "Data Registro";
            tablePedidos.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "Qtd.Cat.";
            tablePedidos.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Double");
            column.ColumnName = "Valor Total";
            tablePedidos.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Status";
            tablePedidos.Columns.Add(column);

            if (pedidoVendedoraDGV.Any())
            {
                foreach (PedidosVendedorasModel model in pedidoVendedoraDGV)
                {
                    row = tablePedidos.NewRow();
                    row["Código"] = int.Parse(model.PedidoId.ToString());
                    row["Vendedora"] = _vendedoraServices.GetById(model.VendedoraId).Nome;
                    row["Data Registro"] = model.DataRegistro;
                    row["Qtd.Cat."] = 0; //TODO: FAZER O COUNT DE DETALHES PARA REGISTRAR ESSE VALOR;
                    row["Valor Total"] = model.ValotTotalPedido;
                    row["Status"] = GetStatusPedido(model.StatusPed);
                    
                }
            }




        }

        private object GetStatusPedido(int statusPed)
        {
            
            switch (statusPed)
            {
                case 0:
                    return Status.Aberto;
                case 1:
                    return Status.Enviado;
                case 2:
                    return Status.Separado;
                case 3:
                    return Status.Conferido;
                case 4:
                    return Status.Finalizado;
                case 5:
                    return Status.Despachado;
                case 6:
                    return Status.Entregue;
                case 7:
                    return Status.Cancelado;
                default:
                    return Status.Aberto;
            }
        }

        private DateTime? ReceiveDate(string date)
        {
            DateTime? dateReturn = null;
            if (date.Replace("/", "").Trim() != "")
            {
                dateReturn = DateTime.Parse(date);
            }

            return dateReturn;
        }

        private void LoadComboBoxVendedoras()
        {
            cbNomeVendedora.DataSource = VendedorasList;
            cbNomeVendedora.DisplayMember = "Nome";

            cbNomeVendedora.SelectedIndex = -1;
        }

        private void pictureClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private static PedidosListForm aForm = null;

        internal static PedidosListForm Instance(MainView mainView)
        {
            if (aForm == null)
            {
                aForm = new PedidosListForm(mainView);
            }
            else
            {
                aForm.BringToFront();
            }
            return aForm;
        }

        private void PedidosListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }

            MainView.SetUnselectedButtons();
            base.Dispose(Disposing);
            aForm = null;


        }


        private void ReadModels()
        {
            List<VendedoraModel> listVendedoras = new List<VendedoraModel>();
            listVendedoras = (List<VendedoraModel>)_vendedoraServices.GetAll();
            VendedorasList = listVendedoras;

            List<PedidosVendedorasModel> listPedidos = new List<PedidosVendedorasModel>();
            listPedidos = (List<PedidosVendedorasModel>)_pedidosServices.GetAll();
            PedidosList = listPedidos;

        }

        private void DefineDataFinal()
        {
            DateTime dataFim = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            dateDataFim.Text = dataFim.ToString();
        }

        private void DefineDataInicial()
        {
            DateTime dataIni = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            dateDataInicio.Text = dataIni.ToString();
        }

        private void cbNomeVendedora_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNomeVendedora.SelectedIndex > -1)
            {
                VendedoraFilter = cbNomeVendedora.SelectedItem as VendedoraModel;
                mTextCpf.Text = VendedoraFilter.Cpf;
            }
            else
            {
                mTextCpf.Text = string.Empty;
            }
        }

        private void cbNomeVendedora_Leave(object sender, EventArgs e)
        {
            if (cbNomeVendedora.Text == string.Empty)
            {
                mTextCpf.Text = string.Empty;
            }
        }

        private void btnClearDate_Click(object sender, EventArgs e)
        {
            dateDataFim.Text = string.Empty;
            dateDataInicio.Text = string.Empty;
        }

        private void btlClearFilter_Click(object sender, EventArgs e)
        {
            cbNomeVendedora.SelectedIndex = -1;
            UncheckRadiosButtons();
            
        }

        private void UncheckRadiosButtons()
        {
            rbAberto.Checked = true;
            rbSeparado.Checked = false;
            rbFinalizado.Checked = false;
            rbEntregue.Checked = false;
            rbEnviado.Checked = false;
            rbConferido.Checked = false;
            rbDespachado.Checked = false;
            rbCancelado.Checked = false;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {

        }
    }
}
