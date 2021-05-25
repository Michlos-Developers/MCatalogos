using DomainLayer.Models.Catalogos;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Specific.Catalogo;
using InfrastructureLayer.DataAccess.Repositories.Specific.Fornecedor;

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
        #region PROPRIEDADES PARA MOVER A JANELA

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        #endregion

        QueryStringServices _queryString;
        MainView MainView;

        private CatalogoServices _catalogoServices;
        private CampanhaServices _campanhaServices;
        private FornecedorServices _fornecedorServices;


        //Instancia a janela como um objeto para não abrir mais de uma janela da mesma instância.
        private static CatalogosListForm aForm = null;
        public int catalogoId = 0;

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
        //TODO: CRIAR CHECKBOX PARA MOSTRAR INATIVOS

        public void LoadCatalogosToDataGridView()
        {
            List<CatalogoModel> modelList = null;

            try
            {
                modelList = (List<CatalogoModel>)_catalogoServices.GetAll();
            }
            catch (Exception e)
            {
                MessageBox.Show($"Não foi possível trazer a lista de Catálogos.\nMessage: {e.Message}", "Error Access List");
            }

            //MODELANDO DATA GRID VIEW
            DataTable tableCatalogos = new DataTable();
            DataColumn column;
            DataRow row;

            //1ª COLUNA = CatalogoId
            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "CatalogoId";
            tableCatalogos.Columns.Add(column);

            //2ª COLUNA = Nome Catálogo
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Nome";
            tableCatalogos.Columns.Add(column);

            //3ª COLUNA = Fornecedor (Nome Fantasia)
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Fornecedor";
            tableCatalogos.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Status";
            tableCatalogos.Columns.Add(column);

            //TODO: 4ª COLUNA = CAMPANHAATUAL

            if (modelList.Count != 0)
            {
                foreach (CatalogoModel model in modelList)
                {
                    row = tableCatalogos.NewRow();
                    row["CatalogoId"] = int.Parse(model.CatalogoId.ToString());
                    row["Nome"] = model.Nome.ToString();
                    row["Fornecedor"] = _fornecedorServices.GetById(model.FornecedorId).NomeFantasia.ToString();
                    row["Status"] = model.Ativo ? "Ativo" : "Inativo";

                    tableCatalogos.Rows.Add(row);

                }
            }
            dgvCatalogos.DataSource = tableCatalogos;
            ConfiguraDataGridView();

        }

        private void ConfiguraDataGridView()
        {
            dgvCatalogos.Columns["CatalogoId"].Width = 50;
            dgvCatalogos.Columns["CatalogoId"].HeaderText = "Código";
            dgvCatalogos.Columns["Nome"].Width = 200;
            dgvCatalogos.Columns["Nome"].HeaderText = "Catálogo";
            dgvCatalogos.Columns["Fornecedor"].Width = 422;
            dgvCatalogos.Columns["Status"].Width = 50;


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
            catalogoId = e.RowIndex;
        }

        private void CatalogosListForm_Load(object sender, EventArgs e)
        {
            LoadCatalogosToDataGridView();
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
            this.MainView.SetUnselectedButtons();
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
            CatalogoForm catalogoForm = new CatalogoForm(this);
            catalogoForm.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            CatalogoForm catalogoForm = new CatalogoForm(this);
            catalogoForm.catalogoId = int.Parse(this.dgvCatalogos.CurrentRow.Cells[0].Value.ToString());
            catalogoForm.fornecedorId = _catalogoServices.GetById(int.Parse(dgvCatalogos.CurrentRow.Cells[0].Value.ToString())).FornecedorId;
            catalogoForm.textCatalogoId.Text = this.dgvCatalogos.CurrentRow.Cells[0].Value.ToString();
            catalogoForm.ShowDialog();
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
                    LoadCatalogosToDataGridView();
                }
            }
        }

        private void dgvCatalogos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CatalogoForm catalogoForm = new CatalogoForm(this);
            catalogoForm.catalogoId = int.Parse(dgvCatalogos.CurrentRow.Cells[0].Value.ToString());
            catalogoForm.fornecedorId = _catalogoServices.GetById(int.Parse(dgvCatalogos.CurrentRow.Cells[0].Value.ToString())).FornecedorId;
            catalogoForm.textCatalogoId.Text = dgvCatalogos.CurrentRow.Cells[0].Value.ToString();
            catalogoForm.ShowDialog();
        }
    }
}
