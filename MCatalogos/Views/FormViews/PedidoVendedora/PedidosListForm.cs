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

        private bool aberto = false;
        private bool enviado = false;
        private bool separado = false;
        private bool conferido = false;
        private bool despachado = false;
        private bool entregue = false;
        private bool cancelado = false;
        private bool finalizado = false;


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
            LoadDataGridView();


        }

        private void LoadDataGridView()
        {
            VendedoraModel vendedora = cbNomeVendedora.SelectedIndex != -1 ? cbNomeVendedora.SelectedItem as VendedoraModel : null;

            DateTime? dataRegistroIni = ReceiveDate(dateDataInicio.Text.ToString());
            DateTime? dataRegistroFim = ReceiveDate(dateDataFim.Text.ToString());
            

            pedidoVendedoraDGV = PedidosList;

            if (vendedora != null)
            {
                pedidoVendedoraDGV = pedidoVendedoraDGV.Where(pedido => pedido.VendedoraId == vendedora.VendedoraId);

            }

            if (dataRegistroIni != null && dataRegistroFim != null)
            {
                pedidoVendedoraDGV = pedidoVendedoraDGV.Where(pedido => pedido.DataRegistro >= dataRegistroIni && pedido.DataRegistro <= dataRegistroFim);
            }

            if (aberto)
            {
                pedidoVendedoraDGV = pedidoVendedoraDGV.Where(pedido => pedido.StatusPed == ((int)Status.Aberto));
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

            if (finalizado)
            {
                pedidoVendedoraDGV = pedidoVendedoraDGV.Where(pedido => pedido.StatusPed == ((int)Status.Finalizado));
            }

            DataTable tablePedidos = new DataTable();
            DataColumn column;
            DataRow row;

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "CodigoColumn";
            tablePedidos.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "VendedoraNameColumn";
            tablePedidos.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.DateTime");
            column.ColumnName = "DataRegColumn";
            tablePedidos.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "QtdCatalogoColumn";
            tablePedidos.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Double");
            column.ColumnName = "ValorTotalColumn";
            tablePedidos.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "StatusColumn";
            tablePedidos.Columns.Add(column);

            if (pedidoVendedoraDGV.Any())
            {
                foreach (PedidosVendedorasModel model in pedidoVendedoraDGV)
                {
                    row = tablePedidos.NewRow();
                    row["CodigoColumn"] = int.Parse(model.PedidoId.ToString());
                    row["VendedoraNameColumn"] = _vendedoraServices.GetById(model.VendedoraId).Nome;
                    row["DataRegColumn"] = model.DataRegistro;
                    row["QtdCatalogoColumn"] = 0; //TODO: FAZER O COUNT DE DETALHES PARA REGISTRAR ESSE VALOR;
                    row["ValorTotalColumn"] = model.ValotTotalPedido;
                    row["StatusColumn"] = GetStatusPedido(model.StatusPed);

                    tablePedidos.Rows.Add(row);
                    
                }
            }

            dgvPedidos.DataSource = tablePedidos;

            dgvPedidos.Columns[0].HeaderText = "Código";
            dgvPedidos.Columns[0].Width = 80;
            dgvPedidos.Columns[1].HeaderText = "Vendedora";
            dgvPedidos.Columns[1].Width = 346;
            dgvPedidos.Columns[2].HeaderText = "Data Reg.";
            dgvPedidos.Columns[3].HeaderText = "Qtd.Cat.";
            dgvPedidos.Columns[3].Width = 60;
            dgvPedidos.Columns[4].HeaderText = "Val. Total";
            dgvPedidos.Columns[5].HeaderText = "Status";
            


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
                LoadDataGridView();
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
            rbAberto.Checked = false;
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

        private void rbAberto_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAberto.Checked)
            {
                aberto = true;
            }
            else
            {
                aberto = false;
            }
            LoadDataGridView();
        }

        private void rbSeparado_CheckedChanged(object sender, EventArgs e)
        {

            if (rbSeparado.Checked)
            {
                separado = true;
            }
            else
            {
                separado = false;
            }
            LoadDataGridView();
        }

        private void rbFinalizado_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFinalizado.Checked)
            {
                finalizado = true;
            }
            else
            {
                finalizado = false;
            }
            LoadDataGridView();
        }

        private void rbEntregue_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEntregue.Checked)
            {
                entregue = true;
            }
            else
            {
                entregue = false;
            }
            LoadDataGridView();
        }

        private void rbEnviado_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEnviado.Checked)
            {
                enviado = true;
            }
            else
            {
                enviado = false;
            }
            LoadDataGridView();
        }

        private void rbConferido_CheckedChanged(object sender, EventArgs e)
        {
            if (rbConferido.Checked)
            {
                conferido = true;
            }
            else
            {
                conferido = false;
            }
            LoadDataGridView();
        }

        private void rbDespachado_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDespachado.Checked)
            {
                despachado = true;
            }
            else
            {
                despachado = false;
            }
            LoadDataGridView();
        }

        private void rbCancelado_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCancelado.Checked)
            {
                cancelado = true;
            }
            else
            {
                cancelado = false;
            }
            LoadDataGridView();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
