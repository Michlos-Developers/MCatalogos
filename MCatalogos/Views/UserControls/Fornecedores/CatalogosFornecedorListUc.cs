using DomainLayer.Models.Catalogos;
using DomainLayer.Models.Estoques;
using DomainLayer.Models.PedidosVendedoras;
using DomainLayer.Models.Produtos;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Specific.Catalogo;
using InfrastructureLayer.DataAccess.Repositories.Specific.Estoque;
using InfrastructureLayer.DataAccess.Repositories.Specific.Fornecedor;
using InfrastructureLayer.DataAccess.Repositories.Specific.PedidoVendedora;
using InfrastructureLayer.DataAccess.Repositories.Specific.Produto;

using MCatalogos.Views.FormViews.Catalogos;
using MCatalogos.Views.FormViews.Fornecedores;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.CatalogoServices;
using ServiceLayer.Services.DetalhePedidoServices;
using ServiceLayer.Services.EstoqueServices;
using ServiceLayer.Services.FornecedorServices;
using ServiceLayer.Services.ProdutoServices;

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Windows.Forms;

namespace MCatalogos.Views.UserControls.Fornecedores
{
    public partial class CatalogosFornecedorListUc : UserControl
    {
        QueryStringServices _queryString;
        FornecedorForm FornecedorForm;
        private CatalogoServices _catalogoServices;
        private FornecedorServices _fornecedorServices;

        private CampanhaServices _campanhaServices;
        private DetalhePedidoSerivces _detalhePedidoSerivces;
        private EstoqueServices _estoqueServices;
        private ProdutoServices _produtoServices;

        IEnumerable<CampanhaModel> CampanhasList;
        IEnumerable<DetalhePedidoModel> DetalhesPedidosList;
        IEnumerable<EstoqueModel> EstoqueList;
        IEnumerable<ProdutoModel> ProdutosList;


        private int? idCatalogo = null;
        public int fornecedorId = 0;


        public CatalogosFornecedorListUc(FornecedorForm fornecedorForm)
        {
            _queryString = new QueryStringServices(new QueryString());
            
            _fornecedorServices = new FornecedorServices(new FornecedorRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _catalogoServices = new CatalogoServices(new CatalogoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _campanhaServices = new CampanhaServices(new CampanhaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _detalhePedidoSerivces = new DetalhePedidoSerivces(new DetalhePedidoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _estoqueServices = new EstoqueServices(new EstoqueRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _produtoServices = new ProdutoServices(new ProdutoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());

            InitializeComponent();
            this.FornecedorForm = fornecedorForm;
        }


        //SETTING AND GETTINGS
        public void LoadCatalogos()
        {
            List<CatalogoModel> modelList = new List<CatalogoModel>();
            try
            {
                if (fornecedorId != 0)
                {
                    modelList = (List<CatalogoModel>)_catalogoServices.GetByFornecedorId(fornecedorId);
                }
                else
                {
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Não foi possível trazer a lista de Catálogos do fornecedor!\nMessage: {e.Message}", "Error");
            }

            DataTable tableCatalogos = new DataTable();
            DataColumn column;
            DataRow row;

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "CatalogoId";
            tableCatalogos.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Nome";
            column.Caption = "Catálogo";
            tableCatalogos.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Status";
            tableCatalogos.Columns.Add(column);

            foreach (CatalogoModel model in modelList)
            {
                row = tableCatalogos.NewRow();
                row["CatalogoId"] = int.Parse(model.CatalogoId.ToString());
                row["Nome"] = model.Nome.ToString();
                row["Status"] = model.Ativo ? "Ativo" : "Inativo";

                tableCatalogos.Rows.Add(row);

            }

            dgvCatalogos.DataSource = tableCatalogos;
            ConfiguraDGV();


        }
        private bool CheckCatalogosExistInForneceddor(int fornecedorId)
        {
            bool result = false;
            List<CatalogoModel> modelList = null;

            try
            {
                modelList = (List<CatalogoModel>)_catalogoServices.GetByFornecedorId(fornecedorId);
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
        private void ConfiguraDGV()
        {
            dgvCatalogos.ForeColor = Color.Black;

            dgvCatalogos.Columns[0].Visible = false;
            dgvCatalogos.Columns[0].HeaderText = "CatalogoId";

            dgvCatalogos.Columns[1].HeaderText = "Catálogo";
            dgvCatalogos.Columns[1].Width = 165;
            dgvCatalogos.Columns[2].HeaderText = "Status";
            dgvCatalogos.Columns[2].Width = 50;


        }
        private void SetEnableButtons()
        {
            int fornecedorId = 0;
            if (this.FornecedorForm.textFornecedorId.Text != "")
            {
                fornecedorId = int.Parse(this.FornecedorForm.textFornecedorId.Text);
                btnAdd.Enabled = true;
                if (CheckCatalogosExistInForneceddor(fornecedorId))
                {
                    btnDelete.Enabled = true;
                    btnEdit.Enabled = true;
                }
                else
                {
                    btnDelete.Enabled = false;
                    btnEdit.Enabled = false;
                }
            }

            

        }


        //EVENTS FORM
        private void CatalogosFornecedorListUc_Load(object sender, EventArgs e)
        {
            LoadCatalogos();
            SetEnableButtons();
        }
        private void dgvCatalogos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idCatalogo = e.RowIndex;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            CatalogoModel catalogoModel = _catalogoServices.GetById(int.Parse(dgvCatalogos.CurrentRow.Cells[0].Value.ToString()));
            CampanhasList = (List<CampanhaModel>)_campanhaServices.GetByCatalogoId(catalogoModel.CatalogoId);
            DetalhesPedidosList = (List<DetalhePedidoModel>)_detalhePedidoSerivces.GetAll();
            DetalhesPedidosList = DetalhesPedidosList.Where(catalogo => catalogo.CatalogoId == catalogoModel.CatalogoId);
            EstoqueList = (List<EstoqueModel>)_estoqueServices.GetAllByCatalogo(catalogoModel);
            ProdutosList = (List<ProdutoModel>)_produtoServices.GetAllByCatalogoId(catalogoModel.CatalogoId);

            var result = MessageBox.Show("Você está preste a APGAR o Catálogo do Fornecedor. Tem certeza disso?", "Exclusão de Catálogo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (DetalhesPedidosList.Any() && DetalhesPedidosList != null)
                    {
                        throw new Exception("Existe pedido cadastrado desse catálogo.");
                    }
                    else if (EstoqueList.Any() && EstoqueList != null)
                    {
                        throw new Exception("Existem produtos cadastrados no estoque para esse catálogo.");
                    }
                    else
                    {
                        foreach (var produto in ProdutosList)
                        {
                            _produtoServices.Delete(produto);
                        }

                        foreach (var campanha in CampanhasList)
                        {
                            _campanhaServices.Delete(campanha);
                        }
                        
                        _catalogoServices.Delete(catalogoModel);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Não foi possível apagar o Catálogo do sistema. \nMessage: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                
            }
            LoadCatalogos();
            SetEnableButtons();

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            CatalogoAddForm catalogoForm = new CatalogoAddForm(this.FornecedorForm, this);
            catalogoForm.Text = "Adicionar Catálogo";
            catalogoForm.fornecedorId = int.Parse(this.FornecedorForm.textFornecedorId.Text);
            catalogoForm.ShowDialog();
            LoadCatalogos();
            SetEnableButtons();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            CatalogoAddForm catalogoForm = new CatalogoAddForm(this.FornecedorForm, this);
            catalogoForm.Text = "Editar Catálogo";
            catalogoForm.catalogoId = int.Parse(this.dgvCatalogos.CurrentRow.Cells[0].Value.ToString());
            catalogoForm.ShowDialog();
            LoadCatalogos();
            SetEnableButtons();
        }
        private void dgvCatalogos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex != dgvCatalogos.NewRowIndex)
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

    }
}
