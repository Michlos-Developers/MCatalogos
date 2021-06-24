using DomainLayer.Models.Catalogos;
using DomainLayer.Models.Produtos;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Specific.Catalogo;
using InfrastructureLayer.DataAccess.Repositories.Specific.Produto;

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

namespace MCatalogos.Views.FormViews.Produtos
{
    public partial class ProdutoAddForm : Form
    {
        private CatalogoModel CatalogoModel;
        private CampanhaModel CampanhaModel;
        private ProdutoModel ProdutoModel;

        private QueryStringServices _queryString;
        private CatalogoServices _catalogoServices;
        private CampanhaServices _campanhaServices;
        private ProdutoServices _produtoServices;

        public ProdutoAddForm(CatalogoModel catalogoModel, CampanhaModel campanhaModel, ProdutoModel produtoModel)
        {
            _queryString = new QueryStringServices(new QueryString());
            _catalogoServices = new CatalogoServices(new CatalogoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _campanhaServices = new CampanhaServices(new CampanhaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _produtoServices = new ProdutoServices(new ProdutoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());



            InitializeComponent();
            this.CatalogoModel = catalogoModel;
            this.CampanhaModel = campanhaModel;
            this.ProdutoModel = produtoModel;
        }
        private void ProdutoAddForm_Load(object sender, EventArgs e)
        {
            LoadComboBoxTipoProduto();
            LoadCampoAdicionail();
            FillFields();
        }


        public void FillFields()
        {
            
        }

        private void LoadComboBoxTipoProduto()
        {
           

        }
        private void LoadCampoAdicionail()
        {
           
        }

    }
}
