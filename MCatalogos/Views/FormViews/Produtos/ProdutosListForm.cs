using DomainLayer.Models.Catalogos;
using DomainLayer.Models.Estoques;
using DomainLayer.Models.PedidosVendedoras;
using DomainLayer.Models.Produtos;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Specific.Catalogo;
using InfrastructureLayer.DataAccess.Repositories.Specific.Estoque;
using InfrastructureLayer.DataAccess.Repositories.Specific.PedidoVendedora;
using InfrastructureLayer.DataAccess.Repositories.Specific.Produto;

using MCatalogos.Views.FormViews.Bairros;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.CatalogoServices;
using ServiceLayer.Services.DetalhePedidoServices;
using ServiceLayer.Services.EstoqueServices;
using ServiceLayer.Services.PedidosVendedorasServices;
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
        private DetalhePedidoSerivces _detalhePedidoServices;
        private EstoqueServices _estoqueServices;

        private List<CatalogoModel> catalogoModelList;
        private List<CampanhaModel> campanhaModelList;
        private List<ProdutoModel> produtoModelList = null;
        
        private IEnumerable<DetalhePedidoModel> DetalhePedidosList;
        private IEnumerable<EstoqueModel> EstoqueList;
        private IEnumerable<CampanhaModel> CampanhasList;

        private CatalogoModel CatalogoModel;
        private CampanhaModel CampanhaModel;
        private ProdutoModel ProdutoModel;

        private int indexDGV = 0;

        public ProdutosListForm(MainView mainView)
        {
            _queryString = new QueryStringServices(new QueryString());
            _catalogoServices = new CatalogoServices(new CatalogoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _campanhaService = new CampanhaServices(new CampanhaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _produtosServices = new ProdutoServices(new ProdutoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _detalhePedidoServices = new DetalhePedidoSerivces(new DetalhePedidoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _estoqueServices = new EstoqueServices(new EstoqueRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            

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

            //this.MainView.SetUnselectedButtons();
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

            if (catalogoModelList.Count > 1)
            {
                cbCatalogo.SelectedItem = "== Todos ==";
            }
            else
            {
                cbCatalogo.SelectedIndex = 1;
            }
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

            DataTable tableProdutos = ModelaTableGrid();
            DataRow row = ModelaRowTable(tableProdutos, produtoModelList);
            dgvProdutos.DataSource = tableProdutos;
            ConfiguraDataGridView();

        }

        private DataRow ModelaRowTable(DataTable tableProdutos, List<ProdutoModel> listaProdutos)
        {
            DataRow row = null;
            if (listaProdutos.Count != 0)
            {
                foreach (var model in listaProdutos)
                {
                    row = tableProdutos.NewRow();
                    row["ProdutoId"] = model.ProdutoId;
                    row["Catalogo"] = _catalogoServices.GetById(model.CatalogoId).Nome;
                    row["Referencia"] = model.Referencia.ToString();
                    row["Descricao"] = model.Descricao.ToString();
                    row["ValorCatalogo"] = double.Parse(model.ValorCatalogo.ToString()).ToString("C2");
                    row["Pagina"] = int.Parse(model.Pagina.ToString());
                    row["MargemVendedora"] = string.IsNullOrEmpty(model.MargemVendedora.ToString()) ? "" : double.Parse(model.MargemVendedora.ToString()).ToString("C2");
                    row["MargemDistribuidor"] = string.IsNullOrEmpty(model.MargemDistribuidor.ToString()) ? "" : double.Parse(model.MargemDistribuidor.ToString()).ToString("C2");
                    row["CatalogoId"] = model.CatalogoId;
                    row["CampanhaId"] = model.CampanhaId;

                    tableProdutos.Rows.Add(row);

                }
            }
            return row;
        }

        private DataTable ModelaTableGrid()
        {
            DataTable table = new DataTable();


            table.Columns.Add("ProdutoId", typeof(int));
            table.Columns.Add("Catalogo", typeof(string));
            table.Columns.Add("Referencia", typeof(string));
            table.Columns.Add("Descricao", typeof(string));
            table.Columns.Add("ValorCatalogo", typeof(string));
            table.Columns.Add("Pagina", typeof(int));
            table.Columns.Add("MargemVendedora", typeof(string));
            table.Columns.Add("MargemDistribuidor", typeof(string));
            table.Columns.Add("CatalogoId", typeof(int));
            table.Columns.Add("CampanhaId", typeof(int));

            return table;
        }

        private void cbCatalogo_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbCatalogo.SelectedIndex <= 0)
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

            if (indexDGV != 0)
            {
                dgvProdutos.Rows[0].Selected = false;
                dgvProdutos.Rows[indexDGV].Selected = true;
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
                ProdutoAddForm produtoAddForm = new ProdutoAddForm(null, this.CatalogoModel, this.CampanhaModel, this);
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

                ProdutoAddForm produtoEditForm = new ProdutoAddForm(this.ProdutoModel, this.CatalogoModel, this.CampanhaModel, this);
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //ESTÁGIOS DO PRODO QUE NÃO PODEM SER APGADOS
            var result = MessageBox.Show($"Cuidado!!\nVocê está prestes a apgar um produto do sistema.\nProduto: {dgvProdutos.CurrentRow.Cells[3].Value}.\nReferência: {dgvProdutos.CurrentRow.Cells[2].Value}" +
                $"\nDeseja continuar?", "Cuidado!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                //GET PRODUCT FOR DELETE FROM GRID
                ProdutoModel produtoForDelete = new ProdutoModel();
                produtoForDelete = _produtosServices.GetById(int.Parse(dgvProdutos.CurrentRow.Cells[0].Value.ToString()));

                //GET DETALHEPEDIDOSLIST WHERE CATALOG LIKE SELECTED PRODUCT CATALOG
                DetalhePedidosList = (List<DetalhePedidoModel>)_detalhePedidoServices.GetAll();
                DetalhePedidosList = DetalhePedidosList.Where(produto => produto.ProdutoId == produtoForDelete.ProdutoId);

                //GET ESTOQUE WHERE CATALOGO LIKE SELECTED PRODUCT
                EstoqueList = (List<EstoqueModel>)_estoqueServices.GetAll();
                EstoqueList = EstoqueList.Where(produto => produto.ProdutoId == produtoForDelete.ProdutoId);

                //GET CAMPANHAS WITH DATA ENCERRAMENTO > TODAY
                CampanhasList = (List<CampanhaModel>)_campanhaService.GetByCatalogoId(produtoForDelete.CampanhaId);
                CampanhasList = CampanhasList.Where(dataVenc => dataVenc.DataEncerramento > DateTime.Today);
                


                try
                {
                    if (DetalhePedidosList.Any() && DetalhePedidosList != null)
                    {
                        throw new Exception($"Produto está registrado em um pedido.\nPedido: {(DetalhePedidosList.Select(ped => ped.PedidoId)).First()}");
                    }
                    else if (EstoqueList.Any() && EstoqueList != null)
                    {
                        throw new Exception("Produto está registrado em estoque.");
                    }
                    else if (CampanhasList.Any() && CampanhasList != null)
                    {
                        throw new Exception($"Produto pertence a uma campanha em vigor.\nCampanha: {CampanhasList.Select(camp => camp.Nome).First()}");
                    }
                    else
                    {
                        _produtosServices.Delete(produtoForDelete);
                        MessageBox.Show("Produto removido com sucesso.");
                        indexDGV = 0;
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show($"Não foi possível pagar o Produto \n\"{produtoForDelete.Descricao}\".\nMessage: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                PopulaComboBoxCatalogos();

                
                
            }

        }

        private void dgvProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProdutos.CurrentRow != null)
            {
                indexDGV = dgvProdutos.CurrentRow.Index;

            }
        }
    }
}
