using DomainLayer.Models.Produtos;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Specific.Produto;

using MCatalogos.Views.FormViews.Produtos;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.ProdutoServices;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCatalogos.Views.UserControls.Catalogos
{
    public partial class CamposTiposProdutosListUC : UserControl
    {



        /// <summary>
        /// VAMOS TRABALHAR SEM ADICIONAR O TIPOPRODUTO. ELE SERÁ ADICIONADO DEPOIS.
        /// </summary>
        QueryStringServices _queryString;
        TipoProdutoAddForm TipoProdutoAddForm; //UTILIZADO PARA DEVOLVER CAMPOS ADICIONADOS

        private CampoTipoProdutoServices _camposServices;
        private FormatoCampoServices _formatoServices;

        public TipoProdutoModel TipoProdutoModel;  //RECEBE NO CHAMADO DO FORM
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
            try
            {

                if (this.TipoProdutoModel != null)
                {
                    if (this.TipoProdutoModel.TipoProdutoId != 0)
                    {
                        ListaCampos = (List<CampoTipoProdutoModel>)_camposServices.GetAllByTipoProdutoId(TipoProdutoModel.TipoProdutoId);
                    }
                }
                ConfiguraDGV();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ConfiguraDGV()
        {

            PopulaComboBoxFormatos();
            if (ListaCampos != null)
            {
            if (ListaCampos.Count > 0)
            {
                this.ListaCampos = PopulaDgv();
                    //dgvCampos.VirtualMode = true;
                dgvCampos.AutoSize = true;
                dgvCampos.AutoGenerateColumns = false;
                    //dgvCampos.DataSource = this.ListaCampos;
                

                //pra cada linha adiciona um model da lista
                foreach (CampoTipoProdutoModel modelCampo in this.ListaCampos)
                {
                        //para cada registro da LIsta de Campos adiciona um array à linha do DGV.
                        for (int i = 0; i < ListaCampos.Count; i++)
                    {
                            string[] stringRow =
                            {
                                modelCampo.CampoTipoId.ToString(),
                                modelCampo.Nome.ToString(),
                                //O Nome do Formato vem de outro Model, mas busquei do Repository diretamente.
                                //TODO: Melhorar isso
                                _formatoServices.GetById(modelCampo.FormatoId).Nome.ToString()
                            };
                            dgvCampos.Rows.Add(stringRow);
                         }

                    }
                }





            }


        }
        public void PopulaComboBoxFormatos()
        {
            List<FormatoCampoModel> modelsFormatos = new List<FormatoCampoModel>();
            try
            {

                modelsFormatos = (List<FormatoCampoModel>)_formatoServices.GetAll();

            }
            catch (Exception)
            {

                throw;
            }

            ColumnFormato.DataPropertyName = "FormatoId";
            ColumnFormato.ValueMember = "Nome";
            ColumnFormato.DisplayMember = "Nome";
            ColumnFormato.Items.Clear();
            foreach (var model in modelsFormatos)
            {
                ColumnFormato.Items.Add(model);
            }

        }

        private List<CampoTipoProdutoModel> PopulaDgv()
        {

            List<CampoTipoProdutoModel> modelsCampos = new List<CampoTipoProdutoModel>();
            try
            {
                if (this.TipoProdutoModel != null)
                {
                    if (this.TipoProdutoModel.TipoProdutoId != 0)
                    {
                        modelsCampos = (List<CampoTipoProdutoModel>)_camposServices.GetAllByTipoProdutoId(this.TipoProdutoModel.TipoProdutoId);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            //DataTable dataTable = new DataTable();
            //dataTable.Columns.Add("CampoTipoId", typeof(int));
            //dataTable.Columns.Add("Nome");
            //dataTable.Columns.Add("FormatoId", typeof(int));
            //dataTable.Columns.Add("TipoProdutoId", typeof(int));
            //foreach (CampoTipoProdutoModel model in modelsCampos)
            //{
            //    dataTable.Rows.Add(model);
            //}

            //return dataTable;
            return modelsCampos;

        }


    }
}
