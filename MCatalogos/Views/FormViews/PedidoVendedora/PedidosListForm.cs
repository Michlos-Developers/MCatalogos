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
        private PedidosVendedorasModel SelectedPedido = new PedidosVendedorasModel();
        private VendedoraModel SelectedVendedora = new VendedoraModel();


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
                pedidoVendedoraDGV = pedidoVendedoraDGV.Where(pedido => pedido.StatusPed == ((int)StatusPedido.Aberto));
            }

            if (cancelado)
            {
                pedidoVendedoraDGV = pedidoVendedoraDGV.Where(pedido => pedido.StatusPed == ((int)StatusPedido.Cancelado));
            }

            if (enviado)
            {
                pedidoVendedoraDGV = pedidoVendedoraDGV.Where(pedido => pedido.StatusPed == ((int)StatusPedido.Enviado));
            }

            if (separado)
            {
                pedidoVendedoraDGV = pedidoVendedoraDGV.Where(pedido => pedido.StatusPed == ((int)StatusPedido.Separado));
            }

            if (conferido)
            {
                pedidoVendedoraDGV = pedidoVendedoraDGV.Where(pedido => pedido.StatusPed == ((int)StatusPedido.Conferido));
            }

            if (despachado)
            {
                pedidoVendedoraDGV = pedidoVendedoraDGV.Where(pedido => pedido.StatusPed == ((int)StatusPedido.Despachado));
            }

            if (entregue)
            {
                pedidoVendedoraDGV = pedidoVendedoraDGV.Where(pedido => pedido.StatusPed == ((int)StatusPedido.Entregue));
            }

            if (finalizado)
            {
                pedidoVendedoraDGV = pedidoVendedoraDGV.Where(pedido => pedido.StatusPed == ((int)StatusPedido.Finalizado));
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
                    row["QtdCatalogoColumn"] = model.QtdCatalogos != null ? model.QtdCatalogos : 0;
                    row["ValorTotalColumn"] = model.ValorTotalPedido;
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

            dgvPedidos.ForeColor = Color.Black;


        }

        private object GetStatusPedido(int statusPed)
        {
            
            switch (statusPed)
            {
                case 0:
                    return StatusPedido.Aberto;
                case 1:
                    return StatusPedido.Enviado;
                case 2:
                    return StatusPedido.Separado;
                case 3:
                    return StatusPedido.Conferido;
                case 4:
                    return StatusPedido.Finalizado;
                case 5:
                    return StatusPedido.Despachado;
                case 6:
                    return StatusPedido.Entregue;
                case 7:
                    return StatusPedido.Cancelado;
                default:
                    return StatusPedido.Aberto;
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
            PedidoAddForm pedidoAddForm = PedidoAddForm.Instance(null, null, this, RequestType.Add);
            pedidoAddForm.Show();
            ReadModels();
            LoadDataGridView();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditarPedido();
        }

        private void EditarPedido()
        {
            SelectedPedido = (PedidosVendedorasModel)_pedidosServices.GetById(int.Parse(dgvPedidos.CurrentRow.Cells[0].Value.ToString()));
            SelectedVendedora = _vendedoraServices.GetById(SelectedPedido.VendedoraId);
            PedidoAddForm pedidoAddForm = PedidoAddForm.Instance(SelectedVendedora, SelectedPedido, this, RequestType.Edit);
            pedidoAddForm.Text = $"Editando Pedido - Vendedora: {SelectedVendedora.Nome}";
            pedidoAddForm.Show();
        }

        private void dgvPedidos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditarPedido();
        }

        public void AtualizaDGV()
        {
            ReadModels();
            LoadDataGridView();
        }

        private void btnConferir_Click(object sender, EventArgs e)
        {
            SelectedPedido = (PedidosVendedorasModel)_pedidosServices.GetById(int.Parse(dgvPedidos.CurrentRow.Cells[0].Value.ToString()));
            SelectedVendedora = _vendedoraServices.GetById(SelectedPedido.VendedoraId);
            PedidoAddForm pedidoAddForm = PedidoAddForm.Instance(SelectedVendedora, SelectedPedido, this, RequestType.Confere);
            pedidoAddForm.Text = $"Editando Pedido - Vendedora: {SelectedVendedora.Nome}";
            pedidoAddForm.Show();
        }
    }
}
