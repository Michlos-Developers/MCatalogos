using DomainLayer.Models.Catalogos;
using DomainLayer.Models.Produtos;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Specific.Catalogo;
using InfrastructureLayer.DataAccess.Repositories.Specific.Produto;

using MCatalogos.Views.FormViews.Bairros;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.CatalogoServices;
using ServiceLayer.Services.ProdutoServices;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Net.Configuration;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCatalogos.Views.FormViews.Produtos
{
    public partial class ProdutosListForm : Form
    {
        #region PROPRIEDADES PARA MOVER A JANELA

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        #endregion
        QueryStringServices _queryString;
        MainView MainView;

        private ProdutoServices _produtosServices;
        private CatalogoServices _catalogoServices;
        private CampanhaServices _campanhaService;

        private List<CatalogoModel> catalogoModelList;
        private List<CampanhaModel> campanhaModelList;
        private List<ProdutoModel> produtoModelList = null;

        private CatalogoModel CatalogoModel;
        private CampanhaModel CampanhaModel;
        private ProdutoModel ProdutoModel;

        public ProdutosListForm(MainView mainView)
        {
            _queryString = new QueryStringServices(new QueryString());
            _catalogoServices = new CatalogoServices(new CatalogoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _campanhaService = new CampanhaServices(new CampanhaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _produtosServices = new ProdutoServices(new ProdutoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());

            InitializeComponent();
            this.MainView = mainView;
        }

        private static ProdutosListForm aForm = null;
        internal static ProdutosListForm Instance(MainView mainView)
        {
            if (aForm == null)
            {
                aForm = new ProdutosListForm(mainView);
            }
            else
            {
                aForm.BringToFront();
            }

            return aForm;
        }

        private void eventClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void ProdutosListForm_FormClosing(object sender, FormClosingEventArgs e)
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

        public void PopulaComboBoxCatalogos()
        {
            this.catalogoModelList = (List<CatalogoModel>)_catalogoServices.GetAll();

            cbCatalogo.ValueMember = "Nome";
            cbCatalogo.DisplayMember = "Nome";
            cbCatalogo.Items.Clear();
            cbCatalogo.Items.Add("== Todos ==");
            foreach (var model in catalogoModelList)
            {
                if (model.Ativo == true)
                    cbCatalogo.Items.Add(model);
            }
            cbCatalogo.SelectedItem = "== Todos ==";
        }

        public void PopulaComboBoxCampanhas(CatalogoModel catalogoModel)
        {
            this.campanhaModelList = (List<CampanhaModel>)_campanhaService.GetByCatalogoId(catalogoModel.CatalogoId);

            cbCampanha.ValueMember = "Nome";
            cbCampanha.DisplayMember = "Nome";
            cbCampanha.Items.Clear();
            foreach (var model in this.campanhaModelList)
            {
                if (model.Ativa == true)
                    cbCampanha.Items.Add(model);


            }
            if (cbCampanha.Items.Count == 1)
            {
                cbCampanha.SelectedIndex = 0;
            }

        }

        private void ProdutosListForm_Load(object sender, EventArgs e)
        {
            PopulaComboBoxCatalogos();


        }

        private void LoadProdutosToDataGrid(CatalogoModel catalogoModel, CampanhaModel campanhaModel)
        {
            if (catalogoModel != null)
            {
                if (campanhaModel != null)
                {
                    this.produtoModelList = (List<ProdutoModel>)_produtosServices.GetAllByCampanhaId(campanhaModel.CampanhaId);
                }
                else
                {
                    this.produtoModelList = (List<ProdutoModel>)_produtosServices.GetAll();
                }
            }
            else
            {
                this.produtoModelList = (List<ProdutoModel>)_produtosServices.GetAll();

            }

            DataTable tableProdutos = new DataTable();
            DataColumn column;
            DataRow row;

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "ProdutoId";
            tableProdutos.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Catalogo";
            tableProdutos.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Referencia";
            tableProdutos.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Descricao";
            tableProdutos.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Double");
            column.ColumnName = "ValorCatalogo";
            tableProdutos.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "Pagina";
            tableProdutos.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "MargemVendedora";
            tableProdutos.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "MargemDistribuidor";
            tableProdutos.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "CatalogoId";
            tableProdutos.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "CampanhaId";
            tableProdutos.Columns.Add(column);

            if (this.produtoModelList.Count != 0)
            {
                foreach (var model in this.produtoModelList)
                {
                    row = tableProdutos.NewRow();
                    row["ProdutoId"] = model.ProdutoId;
                    row["Catalogo"] = _catalogoServices.GetById(model.CatalogoId).Nome;
                    row["Referencia"] = model.Referencia.ToString();
                    row["Descricao"] = model.Descricao.ToString();
                    row["ValorCatalogo"] = double.Parse(model.ValorCatalogo.ToString());
                    row["MargemVendedora"] = model.MargemVendedora.ToString();
                    row["MargemDistribuidor"] = model.MargemDistribuidor.ToString();
                    row["CatalogoId"] = model.CatalogoId;
                    row["CampanhaId"] = model.CampanhaId;

                    tableProdutos.Rows.Add(row);

                }
            }

            dgvProdutos.DataSource = tableProdutos;
            ConfiguraDataGridView();

        }

        private void cbCatalogo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.catalogoModelList.Contains(cbCatalogo.SelectedItem))
            {
                cbCampanha.Items.Clear();
                cbCampanha.Text = string.Empty;
                cbCampanha.Enabled = false;
                btnImportProduto.Enabled = false;
                btnAdd.Enabled = false;
                LoadProdutosToDataGrid(null, null);
            }
            else
            {
                cbCampanha.Enabled = true;
                btnImportProduto.Enabled = true;
                //btnAdd.Enabled = true;
                this.CatalogoModel = _catalogoServices.GetById((cbCatalogo.SelectedItem as CatalogoModel).CatalogoId);
                //this.campanhaModelList = (List<CampanhaModel>)_campanhaService.GetByCatalogoModel(this.CatalogoModel);
                PopulaComboBoxCampanhas(this.CatalogoModel);

            }

        }

        public void ConfiguraDataGridView()
        {
            dgvProdutos.ForeColor = Color.Black;

            dgvProdutos.Columns[0].HeaderText = "ProdutoId";
            dgvProdutos.Columns[1].HeaderText = "Catálogo";
            dgvProdutos.Columns[2].HeaderText = "Referência";
            dgvProdutos.Columns[3].HeaderText = "Descrição";
            dgvProdutos.Columns[4].HeaderText = "Valor";
            dgvProdutos.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProdutos.Columns[5].HeaderText = "Pág.";
            dgvProdutos.Columns[5].Width = 50;
            dgvProdutos.Columns[6].HeaderText = "% Vend.";
            dgvProdutos.Columns[6].Width = 55;
            dgvProdutos.Columns[7].HeaderText = "% Dist.";
            dgvProdutos.Columns[7].Width = 50;
            dgvProdutos.Columns[8].HeaderText = "CatalogoId";
            dgvProdutos.Columns[9].HeaderText = "CampanhaId";

            dgvProdutos.Columns[0].Visible = false;
            dgvProdutos.Columns[8].Visible = false;
            dgvProdutos.Columns[9].Visible = false;




            if (cbCatalogo.SelectedIndex != 0)
            {
                dgvProdutos.Columns[1].Visible = false;
                dgvProdutos.Columns[3].Width = 405;
            }
            else
            {
                dgvProdutos.Columns[1].Visible = true;
                dgvProdutos.Columns[3].Width = 305;

            }


        }

        private void cbCampanha_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCampanha.SelectedIndex >= 0)
            {
                this.CatalogoModel = _catalogoServices.GetById((cbCatalogo.SelectedItem as CatalogoModel).CatalogoId);
                this.CampanhaModel = _campanhaService.GetById((cbCampanha.SelectedItem as CampanhaModel).CampanhaId);
                btnAdd.Enabled = true;
                LoadProdutosToDataGrid(this.CatalogoModel, this.CampanhaModel);
            }
            else
            {
                this.CampanhaModel = null;
                btnAdd.Enabled = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ProdutoAddForm produtoAddForm = new ProdutoAddForm(null, this.CatalogoModel, this.CampanhaModel);
                produtoAddForm.Text = "Adicionando Novo Produto - " + this.CatalogoModel.Nome;
                produtoAddForm.StartPosition = FormStartPosition.CenterScreen;
                produtoAddForm.ShowDialog();
                LoadProdutosToDataGrid(this.CatalogoModel, this.CampanhaModel);
                if (produtoAddForm.ProdutoModel != null)
                    MessageBox.Show($"Produto {produtoAddForm.ProdutoModel.Referencia} adcionado à Campanha {this.CampanhaModel.Nome}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possível adicionar um novo Produto à Campanha\nMessageError: {ex.Message}\nStackTrace: {ex.StackTrace}\nInnerException: {ex.InnerException}");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                this.ProdutoModel = _produtosServices.GetById(int.Parse(this.dgvProdutos.CurrentRow.Cells[0].Value.ToString()));
                this.CatalogoModel = _catalogoServices.GetById(int.Parse(this.dgvProdutos.CurrentRow.Cells[8].Value.ToString()));
                this.CampanhaModel = _campanhaService.GetById(int.Parse(this.dgvProdutos.CurrentRow.Cells[9].Value.ToString()));

                ProdutoAddForm produtoEditForm = new ProdutoAddForm(this.ProdutoModel, this.CatalogoModel, this.CampanhaModel);
                produtoEditForm.Text = "Editando Produto - " + this.ProdutoModel.Referencia + " - " + this.CatalogoModel.Nome;
                produtoEditForm.StartPosition = FormStartPosition.CenterScreen;
                produtoEditForm.ShowDialog();
                LoadProdutosToDataGrid(null, null);
                if (produtoEditForm.ProdutoModel != null)
                {
                    if (produtoEditForm.ProdutoModel != this.ProdutoModel)
                    {
                        MessageBox.Show($"Produto {produtoEditForm.ProdutoModel.Referencia} atualizado com sucesso");

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possível atualizar o registro do produto {this.ProdutoModel.Referencia}.\nMessageError: {ex.Message}\nStackTrace: {ex.StackTrace}\nInnerException: {ex.InnerException}");
            }
        }

        private void dgvProdutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit_Click(sender, e);
        }
    }
}
