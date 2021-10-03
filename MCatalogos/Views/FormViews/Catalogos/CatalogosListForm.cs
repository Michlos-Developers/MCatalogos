using DomainLayer.Models.Catalogos;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Specific.Catalogo;
using InfrastructureLayer.DataAccess.Repositories.Specific.Fornecedor;

using MCatalogos.Commons;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.CatalogoServices;
using ServiceLayer.Services.FornecedorServices;

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

namespace MCatalogos.Views.FormViews.Catalogos
{
    public partial class CatalogosListForm : Form
    {
        enum StatusCatalogo
        {
            Ativo,
            Inativo,
            Todos
        }
        enum ModeRequestForm
        {
            Add,
            Edit
        }


        #region PROPRIEDADES PARA MOVER A JANELA

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        #endregion

        QueryStringServices _queryString;
        MainView MainView;

        private List<CatalogoModel> ListCatalogos = new List<CatalogoModel>();

        private CatalogoServices _catalogoServices;
        private CampanhaServices _campanhaServices;
        private FornecedorServices _fornecedorServices;

        private IEnumerable<CatalogoModel> catalogosDGV;

        private StatusCatalogo status = StatusCatalogo.Ativo;

        private ButtonHelper buttonHelper = new ButtonHelper();


        //Instancia a janela como um objeto para não abrir mais de uma janela da mesma instância.
        private static CatalogosListForm aForm = null;
        public int catalogoId = 0;
        private int indexDGV = 0;

        public static CatalogosListForm Instance(MainView mainView)
        {
            if (aForm == null)
            {
                aForm = new CatalogosListForm(mainView);
            }
            else
            {
                aForm.BringToFront();
            }
            return aForm;
        }

        public CatalogosListForm(MainView mainView)
        {
            _queryString = new QueryStringServices(new QueryString());
            _catalogoServices = new CatalogoServices(new CatalogoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _campanhaServices = new CampanhaServices(new CampanhaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _fornecedorServices = new FornecedorServices(new FornecedorRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());

            InitializeComponent();
            this.MainView = mainView;
        }

        //OWN METHODS
        //CÓDIGO / NOME DO CATÁLOGO/ FORNECEDOR (NOME FANTASIA)  / CAMPANHA ATUAL /ATIVO

        public void LoadCatalogosToDataGridView()
        {
            catalogosDGV = ListCatalogos;

            catalogosDGV = ConfiguraDGVByStatus(status, catalogosDGV);

            DataTable tableCatalogos = ModelaDataTableCatalogos();
            ModelaDataRowTableCatalogos(tableCatalogos, catalogosDGV);

            ConfiguraDataGridView(tableCatalogos);

        }

        private void ModelaDataRowTableCatalogos(DataTable tableCatalogos, IEnumerable<CatalogoModel> catalogosDGV)
        {
            DataRow row = null;
            if (catalogosDGV.Any())
            {
                foreach (CatalogoModel model in catalogosDGV)
                {
                    row = tableCatalogos.NewRow();
                    row["CatalogoId"] = int.Parse(model.CatalogoId.ToString());
                    row["Nome"] = model.Nome.ToString();
                    row["Fornecedor"] = _fornecedorServices.GetById(model.FornecedorId).NomeFantasia.ToString();
                    row["Status"] = model.Ativo ? "Ativo" : "Inativo";

                    tableCatalogos.Rows.Add(row);

                }
            }

        }

        private DataTable ModelaDataTableCatalogos()
        {
            DataTable table = new DataTable();

            table.Columns.Add("CatalogoId", typeof(int));
            table.Columns.Add("Nome", typeof(string));
            table.Columns.Add("Fornecedor", typeof(string));
            table.Columns.Add("Status", typeof(string));


            return table;
        }

        private IEnumerable<CatalogoModel> ConfiguraDGVByStatus(StatusCatalogo status, IEnumerable<CatalogoModel> catalogosDGV)
        {
            switch (status)
            {
                case StatusCatalogo.Ativo:
                    catalogosDGV = catalogosDGV.Where(stat => stat.Ativo);
                    break;
                case StatusCatalogo.Inativo:
                    catalogosDGV = catalogosDGV.Where(stat => stat.Ativo == false);
                    break;
                default:
                    break;

            }

            return catalogosDGV;
        }

        private void ConfiguraDataGridView(DataTable tableCatalogos)
        {
            dgvCatalogos.DataSource = tableCatalogos;

            dgvCatalogos.Columns["CatalogoId"].Width = 50;
            dgvCatalogos.Columns["CatalogoId"].HeaderText = "Código";
            dgvCatalogos.Columns["Nome"].Width = 200;
            dgvCatalogos.Columns["Nome"].HeaderText = "Catálogo";
            dgvCatalogos.Columns["Fornecedor"].Width = 422;
            dgvCatalogos.Columns["Status"].Width = 50;

            if (indexDGV != 0)
            {
                dgvCatalogos.Rows[0].Selected = false;
                dgvCatalogos.Rows[indexDGV].Selected = true;
            }


        }


        //EVENTS FORM
        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCatalogos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCatalogos.CurrentRow != null)
            {

                indexDGV = e.RowIndex;
            }
        }

        private void CatalogosListForm_Load(object sender, EventArgs e)
        {
            LoadListCatalogos();
            LoadCatalogosToDataGridView();
        }

        private void LoadListCatalogos()
        {
            ListCatalogos = (List<CatalogoModel>)_catalogoServices.GetAll();
        }

        private void CatalogosListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            
            base.Dispose(Disposing);
            aForm = null;
        }

        private void dgvCatalogos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.RowIndex != dgvCatalogos.NewRowIndex)
            {
                if (dgvCatalogos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Ativo")
                {
                    dgvCatalogos.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.LimeGreen;
                }
                else
                {
                    dgvCatalogos.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Red;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AbrirEdicaoCatalogo(ModeRequestForm.Add);
            LoadListCatalogos();
            LoadCatalogosToDataGridView();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            AbrirEdicaoCatalogo(ModeRequestForm.Edit);
            LoadListCatalogos();
            LoadCatalogosToDataGridView();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show($"CUIDADO!!\nVocê está prestes a apagar o cadastro do Catálogo\n{dgvCatalogos.CurrentRow.Cells[1].Value.ToString()}." +
                $"\nTem certeza disso?", "CUIDADO!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                CatalogoModel model = new CatalogoModel();
                model = _catalogoServices.GetById(int.Parse(dgvCatalogos.CurrentRow.Cells[0].Value.ToString()));

                List<CampanhaModel> campanhasList = (List<CampanhaModel>)_campanhaServices.GetByCatalogoId(model.CatalogoId);
                if (campanhasList.Count > 0)
                {
                    MessageBox.Show("Este catálogos possui campanhas cadastradas e NÃO PODE ser apagado.\nPor favor, desative o catálogo para reduzir os inconvenientes.", "Possui Campanhas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    try
                    {
                        _catalogoServices.Delete(model);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Não foi possível apagar o registro do Catálogo.\nErrorMessage: \n{ex.Message}", "Error");
                    }
                    LoadListCatalogos();
                    LoadCatalogosToDataGridView();
                }
            }
        }

        private void dgvCatalogos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirEdicaoCatalogo(ModeRequestForm.Edit);
            LoadListCatalogos();
            LoadCatalogosToDataGridView();

        }

        private void AbrirEdicaoCatalogo(ModeRequestForm modeRequest)
        {
            CatalogoForm catalogoForm = new CatalogoForm(this);
            if (modeRequest == ModeRequestForm.Edit)
            {
                catalogoForm.catalogoId = int.Parse(dgvCatalogos.CurrentRow.Cells[0].Value.ToString());
                catalogoForm.fornecedorId = _catalogoServices.GetById(int.Parse(dgvCatalogos.CurrentRow.Cells[0].Value.ToString())).FornecedorId;
                catalogoForm.textCatalogoId.Text = dgvCatalogos.CurrentRow.Cells[0].Value.ToString();
            }
            catalogoForm.ShowDialog();
        }

        private void chkExibeInativos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExibeInativos.Checked)
                status = StatusCatalogo.Todos;
            else
                status = StatusCatalogo.Ativo;
            LoadCatalogosToDataGridView();
        }
    }
}
