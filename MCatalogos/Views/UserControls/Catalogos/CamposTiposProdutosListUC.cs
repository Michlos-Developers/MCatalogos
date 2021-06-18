using DomainLayer.Models.Produtos;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Specific.Produto;

using MCatalogos.Views.FormViews.Produtos;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.ProdutoServices;

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MCatalogos.Views.UserControls.Catalogos
{
    public partial class CamposTiposProdutosListUC : UserControl
    {

        QueryStringServices _queryString;
        TipoProdutoAddForm TipoProdutoAddForm;

        private CampoTipoProdutoServices _camposServices;
        private FormatoCampoServices _formatoServices;

        public TipoProdutoModel TipoProdutoModel;
        public CampoTipoProdutoModel CampoTipoProdutoModel;
        public FormatoCampoModel FormatoCampoModel;

        public List<CampoTipoProdutoModel> ListaCampos;
        public List<FormatoCampoModel> ListaFormatos;

        public CamposTiposProdutosListUC(TipoProdutoAddForm tipoProdutoAddForm)
        {
            _queryString = new QueryStringServices(new QueryString());
            _camposServices = new CampoTipoProdutoServices(new CampoTipoProdutoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _formatoServices = new FormatoCampoServices(new FormatoCampoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());

            InitializeComponent();
            this.TipoProdutoAddForm = tipoProdutoAddForm;

        }

        private void CamposTiposProdutosListUC_Load(object sender, EventArgs e)
        {
            this.ListaCampos = PopulaModelListCampos();
            ConfiguraPopulaDGV();
        }

        private void ConfiguraPopulaDGV()
        {
            PopulaComboBoxFormatos();
            if (this.ListaCampos != null)
            {
                if (this.ListaCampos.Count > 0)
                {
                    dgvCampos.AutoSize = true;
                    dgvCampos.AutoGenerateColumns = false;

                    foreach (CampoTipoProdutoModel modelCampo in this.ListaCampos)
                    {
                        string[] stringRow =
                        {
                            modelCampo.CampoTipoId.ToString(),
                            modelCampo.Nome.ToString(),
                            _formatoServices.GetById(modelCampo.FormatoId).Nome.ToString()
                         };
                        dgvCampos.Rows.Add(stringRow);

                    }
                }
            }
        }

        public void PopulaComboBoxFormatos()
        {
            List<FormatoCampoModel> modelsFormatos = new List<FormatoCampoModel>();
            modelsFormatos = (List<FormatoCampoModel>)_formatoServices.GetAll();

            ColumnFormato.DataPropertyName = "FormatoId";
            ColumnFormato.ValueMember = "Nome";
            ColumnFormato.DisplayMember = "Nome";
            ColumnFormato.Items.Clear();

            foreach (var model in modelsFormatos)
            {
                ColumnFormato.Items.Add(model);
            }

        }

        private List<CampoTipoProdutoModel> PopulaModelListCampos()
        {
            List<CampoTipoProdutoModel> modelsCampos = new List<CampoTipoProdutoModel>();

            if (this.TipoProdutoModel != null)
            {
                if (this.TipoProdutoModel.TipoProdutoId != 0)
                {
                    modelsCampos = (List<CampoTipoProdutoModel>)_camposServices.GetAllByTipoProdutoId(this.TipoProdutoModel.TipoProdutoId);
                }
            }

            return modelsCampos;
        }
    }
}
