using DomainLayer.Models.Vendedora;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Commons;
using InfrastructureLayer.DataAccess.Repositories.Specific.Vendedora;

using MCatalogos.Views.UserControls.Rotas;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.BairroServices;
using ServiceLayer.Services.RotaServices;
using ServiceLayer.Services.VendedoraServices;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCatalogos.Views.FormViews.Rotas
{
    public partial class RotasFormView : Form
    {
        #region PROPRIEDADES PARA MOVER A JANELA

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        #endregion

        MainView MainView;

        bool isClosing = false;

        private QueryStringServices _queryString;


        private RotaServices _rotaServices;
        private RotaLetraServices _rotaLetraServices;
        private VendedoraServices _vendedoraServices;
        private BairroServices _bairroServices;
        public int idGrid;

        private VendedoraModel vendedoraModel = null;
        private RotaModel rotaNumeroModel = null;
        private RotaLetraModel rotaLetraModel = null;


        //DADOS DO USER CONTROL DE EDIÇÃO DE ROTAS.
        private RotasEditUC rotasEdit;
        private RotaModel rotaNumeroAtualNaEdicao;
        private RotaLetraModel rotaLetraAtualNaEdicao;


        private static RotasFormView aForm = null;

        public static RotasFormView Instance(MainView mainView)
        {
            if (aForm == null)
            {
                aForm = new RotasFormView(mainView);
            }
            else
            {
                aForm.BringToFront();
            }
            return aForm;
        }

        public RotasFormView(MainView mainView)
        {
            _queryString = new QueryStringServices(new QueryString());
            _rotaServices = new RotaServices(new RotaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _rotaLetraServices = new RotaLetraServices(new RotaLetraRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _vendedoraServices = new VendedoraServices(new VendedoraRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _bairroServices = new BairroServices(new BairroRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());

            InitializeComponent();
            this.MainView = mainView;
        }

        //OWNER METHODS LOADS
        public void LoadRotasToDataGrid()
        {
            List<RotaModel> modelList = null;
            try
            {
                modelList = (List<RotaModel>)_rotaServices.GetAll();
            }
            catch (Exception e)
            {
                MessageBox.Show($"Não foi possível carregar a lista de Rotas.\nMessage:{e.Message}", "Error Access List");

            }

            DataTable tableRotas = ModelaTableGrid();
            //DataColumn column;
            DataRow row = ModelaRowTable(tableRotas, modelList);

            dgvRotas.DataSource = tableRotas;

        }

        private DataRow ModelaRowTable(DataTable tableRotas, List<RotaModel> modelList)
        {
            DataRow row = null;

            if (modelList.Count != 0)
            {
                foreach (RotaModel model in modelList)
                {

                    row = tableRotas.NewRow();
                    row["RotaId"] = int.Parse(model.RotaId.ToString());
                    row["Vendedora"] = _vendedoraServices.GetById(model.VendedoraId).Nome.ToString();
                    row["Bairro"] = _bairroServices.GetById(_vendedoraServices.GetById(model.VendedoraId).BairroId).Nome.ToString();
                    row["Logradouro"] = _vendedoraServices.GetById(model.VendedoraId).Logradouro.ToString();
                    row["Letra"] = _rotaLetraServices.GetById(model.RotaLetraId).RotaLetra.ToString();
                    row["Numero"] = int.Parse(model.Numero.ToString());

                    tableRotas.Rows.Add(row);
                }
            }

            return row;
        }

        private DataTable ModelaTableGrid()
        {
            DataTable tableRotas = new DataTable();
            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "RotaId";
            tableRotas.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Vendedora";
            tableRotas.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Bairro";
            tableRotas.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Logradouro";
            tableRotas.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Letra";
            tableRotas.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "Numero";
            tableRotas.Columns.Add(column);

            return tableRotas;
        }

        public void LoadVendedorasSemRotasToDataGrid()
        {

            List<VendedoraModel> vendedoraModel = GetVendedorasSemRota();
            List<VendedoraModel> modelList = vendedoraModel;
            DataTable tableVendedoras = ModelaTableVendedora();
            DataRow row = ModelaRowVendedora(tableVendedoras, vendedoraModel, modelList);

           
            dgvVendedoraSemRota.DataSource = tableVendedoras;

        }

        private DataRow ModelaRowVendedora(DataTable tableVendedoras, List<VendedoraModel> vendedoraModel, List<VendedoraModel> modelList)
        {
            DataRow row = null;
            if (vendedoraModel != null)
            {
                foreach (VendedoraModel model in modelList)
                {
                    row = tableVendedoras.NewRow();
                    row["VendedoraId"] = int.Parse(model.VendedoraId.ToString());
                    row["Nome"] = model.Nome;
                    row["Letra"] = _rotaLetraServices.GetById(model.RotaLetraId).RotaLetra.ToString();

                    tableVendedoras.Rows.Add(row);
                }
            }

            return row;
        }

        private DataTable ModelaTableVendedora()
        {
            DataTable tableVendedoras = new DataTable();
            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "VendedoraId";
            tableVendedoras.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Nome";
            tableVendedoras.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Letra";
            tableVendedoras.Columns.Add(column);

            return tableVendedoras;
        }

        private void ConfiguraDataGridRotas()
        {
            dgvRotas.Columns["RotaId"].Visible = false;
            dgvRotas.Columns["Vendedora"].Width = 200;
            dgvRotas.Columns["Bairro"].Width = 200;
            dgvRotas.Columns["Logradouro"].Width = 100;
            dgvRotas.Columns["Letra"].Width = 50;
            dgvRotas.Columns["Numero"].HeaderText = "Nº";
            dgvRotas.Columns["Numero"].Width = 30;
            dgvRotas.ForeColor = Color.Black;

        }
        private void ConfiguraDataGridVendedoras()
        {
            dgvVendedoraSemRota.Columns["VendedoraId"].Visible = false;
            dgvVendedoraSemRota.Columns["Nome"].Width = 250;
            dgvVendedoraSemRota.Columns["Letra"].Width = 50;
            dgvVendedoraSemRota.ForeColor = Color.Black;
        }


        /// <summary>
        /// CARREGA O USER CONTROL DE EDIÇÃO DE ROTAS.
        /// DEVE SER ACIONADO SOMENTE QUANDO ALGUMA DATAGRID FOR CLICADA.
        /// </summary>
        private void LoadUserControlRotasEdit()
        {
            this.rotasEdit = new RotasEditUC(this.vendedoraModel, this);
            panelRotasEdit.Controls.Clear();
            panelRotasEdit.Controls.Add(rotasEdit);
            rotasEdit.Dock = DockStyle.Fill;
        }


        private List<VendedoraModel> GetVendedorasSemRota()
        {
            List<RotaModel> rotaList = (List<RotaModel>)_rotaServices.GetAll();
            List<VendedoraModel> vendedoraList = (List<VendedoraModel>)_vendedoraServices.GetAll();
            List<VendedoraModel> vendedoraSemRotaList = new List<VendedoraModel>();

            foreach (VendedoraModel modelVendededora in vendedoraList)
            {
                bool temRota = false;
                foreach (RotaModel modelRota in rotaList)
                {
                    if (modelRota.VendedoraId == modelVendededora.VendedoraId)
                    {
                        temRota = true;
                    }
                }
                if (!temRota)
                {
                    vendedoraSemRotaList.Add(modelVendededora);
                }
            }

            return vendedoraSemRotaList;
        }


        //EVENTS DATAGRIDS
        private void dgvRotas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvVendedoraSemRota.ClearSelection();
            this.pictureArrowUp.Visible = false;
            this.pictureArrowRight.Visible = true;
            idGrid = e.RowIndex;

            this.rotaNumeroModel = _rotaServices.GetById(int.Parse(dgvRotas.CurrentRow.Cells["RotaId"].Value.ToString()));
            this.vendedoraModel = _vendedoraServices.GetById(rotaNumeroModel.VendedoraId);
            this.rotaLetraModel = _rotaLetraServices.GetById(rotaNumeroModel.RotaLetraId);

            LoadUserControlRotasEdit();
            this.gboxEditRotas.Enabled = true;
        }
        private void dgvVendedoraSemRota_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvRotas.ClearSelection();
            this.pictureArrowRight.Visible = false;
            this.pictureArrowUp.Visible = true;
            idGrid = e.RowIndex;
            this.vendedoraModel = _vendedoraServices.GetById(int.Parse(dgvVendedoraSemRota.CurrentRow.Cells["VendedoraId"].Value.ToString()));
            this.rotaLetraModel = _rotaLetraServices.GetById(vendedoraModel.RotaLetraId);

            LoadUserControlRotasEdit();
            this.gboxEditRotas.Enabled = true;
        }


        //EVENTS FORM
        private void RotasFormView_Load(object sender, EventArgs e)
        {
            LoadRotasToDataGrid();
            ConfiguraDataGridRotas();
            LoadVendedorasSemRotasToDataGrid();
            ConfiguraDataGridVendedoras();
            LoadUserControlRotasEdit();


        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            isClosing = true;
            this.Close();
        }
        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void RotasFormView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            //this.MainView.SetUnselectedButtons();
            base.Dispose(Disposing);
            aForm = null;
        }
    }
}
