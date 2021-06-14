using DomainLayer.Models.Catalogos;
using DomainLayer.Models.Produtos;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Specific.Catalogo;
using InfrastructureLayer.DataAccess.Repositories.Specific.Produto;

using MCatalogos.Views.FormViews.Catalogos;
using MCatalogos.Views.FormViews.Produtos;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.CatalogoServices;
using ServiceLayer.Services.ProdutoServices;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.ComponentModel.Com2Interop;

namespace MCatalogos.Views.UserControls.Catalogos
{
    public partial class TiposProdutosListUC : UserControl
    {
        QueryStringServices _queryString;
        CatalogoForm CatalogoForm;

        private TipoProdutoServices _tipoProdutoServices;
        private CatalogoServices _catalogoServices;

        public CatalogoModel CatalogoModel; //recebe o model na chamada do form
        public TipoProdutoModel TipoProdutoModel = new TipoProdutoModel();

        public int? idTipoProdutoDgv = null;

        public TiposProdutosListUC(CatalogoForm catalogoForm)
        {
            _queryString = new QueryStringServices(new QueryString());
            _tipoProdutoServices = new TipoProdutoServices(new TipoProdutoRepository(_queryString.GetQueryApp()),new  ModelDataAnnotationCheck());
            _catalogoServices = new CatalogoServices(new CatalogoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());

            InitializeComponent();
            this.CatalogoForm = catalogoForm;
            //this.CatalogoModel = _catalogoServices.GetById(int.Parse(this.CatalogoForm.textCatalogoId.Text));

            
        }

        private void LoadTiposProdutosToGridView()
        {
            List<TipoProdutoModel> modelList = new List<TipoProdutoModel>();
            try
            {
                if (this.CatalogoModel != null)
                {
                    if (this.CatalogoModel.CatalogoId != 0)
                    {
                        modelList = (List<TipoProdutoModel>)_tipoProdutoServices.GetByCatalogo(this.CatalogoModel);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Não foi possível trazer a lista de Tipos de Produtos deste Catálogo\nErrorMessage: {e.Message}", "Error");
            }

            DataTable tableTiposProdutos = new DataTable();
            DataColumn column;
            DataRow row;

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "TipoProdutoId";
            tableTiposProdutos.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Descricao";
            tableTiposProdutos.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "CatalogoId";
            tableTiposProdutos.Columns.Add(column);

            foreach (TipoProdutoModel model in modelList)
            {
                row = tableTiposProdutos.NewRow();
                row["TipoProdutoId"] = int.Parse(model.TipoProdutoId.ToString());
                row["Descricao"] = model.Descricao.ToString();
                row["CatalogoId"] = int.Parse(model.CatalogoId.ToString());

                tableTiposProdutos.Rows.Add(row);
            }

            dgvTiposProdutos.DataSource = tableTiposProdutos;
            ConfiguraDgv();
        }

        private void ConfiguraDgv()
        {
            dgvTiposProdutos.ForeColor = Color.Black;

            dgvTiposProdutos.Columns[0].Visible = false;

            dgvTiposProdutos.Columns[1].HeaderText = "Tipos de Produtos";
            dgvTiposProdutos.Columns[1].Width = 180;

            dgvTiposProdutos.Columns[2].Visible = false;
        }

        private void SetEnableButtons()
        {
            if (this.CatalogoModel != null)
            {
                if (this.CatalogoModel.CatalogoId != 0)
                {
                    btnAdd.Enabled = true;
                    if (CheckTiposProdutosExistInCatalogos())
                    {
                        btnDelete.Enabled = true;
                        btnEdit.Enabled = true;
                    }
                    else
                    {
                        btnEdit.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                }
            }
        }

        private bool CheckTiposProdutosExistInCatalogos()
        {
            bool result = false;
            List<TipoProdutoModel> modelList = null;

            try
            {
                modelList = (List<TipoProdutoModel>)_tipoProdutoServices.GetByCatalogo(this.CatalogoModel);
            }
            finally
            {
                if (modelList.Count != 0)
                {
                    result = true;
                }
            }

            return result;
        }

        public void TiposProdutosListUC_Load(object sender, EventArgs e)
        {
            LoadTiposProdutosToGridView();
            SetEnableButtons();
        }

        private void dgvTiposProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idTipoProdutoDgv = e.RowIndex;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.TipoProdutoModel = _tipoProdutoServices.GetById(int.Parse(dgvTiposProdutos.CurrentRow.Cells[0].Value.ToString()));

            var result = MessageBox.Show($"Você está prestes a APAGAR o Tipo de Produto do Catálogo {this.CatalogoModel.Nome}. Tem certeza disso?",
                "Exclusão de Tipo de Produto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                //TODO: Checar se tem produto cadastrado com esse tipo de produto. Se tiver o tipo não pode apagar.
                try
                {
                    _tipoProdutoServices.Delete(this.TipoProdutoModel);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Não foi possível apagar o registro de Tipo de Produto.\nErrorMessage: {ex.Message}", "Error");
                }
                finally
                {
                    LoadTiposProdutosToGridView();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TipoProdutoAddForm tipoProdutoForm = new TipoProdutoAddForm(this.CatalogoForm, this);
            tipoProdutoForm.Text = "Adicionar Tipo de Produto";
            tipoProdutoForm.TipoProdutoModel = this.TipoProdutoModel;
            tipoProdutoForm.CatalogoModel = this.CatalogoModel;
            tipoProdutoForm.StartPosition = FormStartPosition.CenterScreen;
            tipoProdutoForm.ShowDialog();
            this.TiposProdutosListUC_Load(sender, e);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.TipoProdutoModel = _tipoProdutoServices.GetById(int.Parse(this.dgvTiposProdutos.CurrentRow.Cells[0].Value.ToString()));
            TipoProdutoAddForm tipoProdutoForm = new TipoProdutoAddForm(this.CatalogoForm, this);
            tipoProdutoForm.Text = "Editando Tipo de Produto";
            tipoProdutoForm.TipoProdutoModel = this.TipoProdutoModel;
            tipoProdutoForm.CatalogoModel = this.CatalogoModel;
            tipoProdutoForm.StartPosition = FormStartPosition.CenterScreen;
            tipoProdutoForm.ShowDialog();
            this.TiposProdutosListUC_Load(sender, e);
        }
    }
}
