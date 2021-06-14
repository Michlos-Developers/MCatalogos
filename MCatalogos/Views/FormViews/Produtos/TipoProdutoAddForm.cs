using CommonComponents;

using DomainLayer.Models.Catalogos;
using DomainLayer.Models.Produtos;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Specific.Catalogo;
using InfrastructureLayer.DataAccess.Repositories.Specific.Produto;

using MCatalogos.Views.FormViews.Catalogos;
using MCatalogos.Views.UserControls.Catalogos;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.CatalogoServices;
using ServiceLayer.Services.ProdutoServices;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCatalogos.Views.FormViews.Produtos
{
    public partial class TipoProdutoAddForm : Form
    {
        CatalogoForm CatalogoForm;
        TiposProdutosListUC TiposProdutosListUC;
        CamposTiposProdutosListUC camposAdicionais;

        QueryStringServices _queryString;
        private TipoProdutoServices _tipoProdutoServices;
        private CampoTipoProdutoServices _campoTipoProdutoServices;

        public CatalogoModel CatalogoModel; //JÁ RECEBE O MODEL NO CHAMADO DO FORM
        public TipoProdutoModel TipoProdutoModel;//JÁ RECEBE O MODEL NO CHAMADO DO FORM
        public CampoTipoProdutoModel CampoTipoProdutoModel;
        public List<CampoTipoProdutoModel> ListaCamposAdicionais;

        public TipoProdutoAddForm(CatalogoForm catalogoForm, TiposProdutosListUC tiposProdutosListUC)
        {
            _queryString = new QueryStringServices(new QueryString());
            _tipoProdutoServices = new TipoProdutoServices(new TipoProdutoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _campoTipoProdutoServices = new CampoTipoProdutoServices(new CampoTipoProdutoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());

            InitializeComponent();
            this.CatalogoForm = catalogoForm;  //necessário para devoler o campo adicionado e atualizar o form
            this.TiposProdutosListUC = tiposProdutosListUC; //necessário para devolver o campo adicionado e atualizar a datagrid
        }

        private void FillFields()
        {
            this.textCatalogo.Text = this.CatalogoModel.Nome;
            if (TipoProdutoModel != null)
            {
                this.textTipoProduto.Text = TipoProdutoModel.Descricao;
                this.textTipoProdutoId.Text = TipoProdutoModel.TipoProdutoId.ToString();
            }
        }
        private void LoadUserControlCamposAdicionais()
        {
            camposAdicionais = new CamposTiposProdutosListUC(this);
            camposAdicionais.TipoProdutoModel = this.TipoProdutoModel;
            panelCampos.Controls.Clear();
            panelCampos.Controls.Add(camposAdicionais);
            camposAdicionais.Dock = DockStyle.Fill;
        }

        private void TipoProdutoAddForm_Load(object sender, EventArgs e)
        {
            FillFields();
            LoadUserControlCamposAdicionais();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                if (this.TipoProdutoModel.TipoProdutoId != 0)
                {
                    try
                    {

                        TipoProdutoUpdate();
                        CampotipoUpdate();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Não foi possível atualizar o Tipo de Produto", "Atualizando Tipo de Produto");
                    }
                }
                else
                {
                    try
                    {
                        this.TipoProdutoModel = TipoProdutoAdd();
                        this.ListaCamposAdicionais = CampoTipoAdd();
                        MessageBox.Show($"Tipo de Produto Adicionado com sucesso", "Adicionando Tipo de Produto");

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Não foi possível adicionar o Tipo de Produto");
                    }
                }


            }
        }

        private void CampotipoUpdate()
        {
            throw new NotImplementedException();
        }

        private List<CampoTipoProdutoModel> CampoTipoAdd() //que que eu vou fazer com a lista retornada???
        {
            List<CampoTipoProdutoModel> modelList = new List<CampoTipoProdutoModel>();
            DataGridViewRowCollection rowsCamposAdicionais;
            rowsCamposAdicionais = this.camposAdicionais.dgvCampos.Rows; //peguei as linhas do DATAGRID
                                                                         //modelList = camposAdicionais.dgvCampos.Columns.

            bool operationSucceeded = false;
            string dataAccesStatusJsonStr = string.Empty;
            string formattedJsonStr = string.Empty;

            foreach (DataGridViewRow row in rowsCamposAdicionais)
            {
                if (row.Cells["ColumnNome"].Value != null)
                {
                    CampoTipoProdutoModel model = new CampoTipoProdutoModel();
                    model.Nome = row.Cells["ColumnNome"].Value.ToString();
                    model.FormatoId = int.Parse(row.Cells["ColumnFormato"].Value.ToString());
                    model.TipoProdutoId = this.TipoProdutoModel.TipoProdutoId;
                    modelList.Add(model);
                }
            }

            if (modelList.Count != 0)
            {
                foreach (CampoTipoProdutoModel model in modelList)
                {
                    try
                    {
                        _campoTipoProdutoServices.Add(model);

                    }
                    catch (DataAccessException e)
                    {
                        operationSucceeded = e.DataAccessStatusInfo.OperationSucceeded;
                        dataAccesStatusJsonStr = JsonConvert.SerializeObject(e.DataAccessStatusInfo);
                        formattedJsonStr = JToken.Parse(dataAccesStatusJsonStr).ToString();
                        MessageBox.Show(formattedJsonStr, "Não foi possível adicionar o Tipo de Produto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            return modelList;

        }

        private TipoProdutoModel TipoProdutoAdd()
        {
            TipoProdutoModel returnedModel = new TipoProdutoModel();

            this.TipoProdutoModel = new TipoProdutoModel()
            {
                CatalogoId = this.CatalogoModel.CatalogoId,
                Descricao = this.textTipoProduto.Text
            };

            bool operationSucceeded = false;
            string dataAccesStatusJsonStr = string.Empty;
            string formattedJsonStr = string.Empty;

            try
            {
                returnedModel = _tipoProdutoServices.Add(this.TipoProdutoModel);

            }
            catch (DataAccessException e)
            {
                operationSucceeded = e.DataAccessStatusInfo.OperationSucceeded;
                dataAccesStatusJsonStr = JsonConvert.SerializeObject(e.DataAccessStatusInfo);
                formattedJsonStr = JToken.Parse(dataAccesStatusJsonStr).ToString();
                MessageBox.Show(formattedJsonStr, "Não foi possível adicionar o Tipo de Produto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            if (operationSucceeded)
            {
                MessageBox.Show("Registro Salvo com sucesso", "Salvando Tipo  do Distribuidor", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            return returnedModel;
        }

        private void TipoProdutoUpdate()
        {
            throw new NotImplementedException();
        }

        private void textTipoProduto_Enter(object sender, EventArgs e)
        {
            SetBGColorFocused(textTipoProduto);
        }

        private bool ValidaCampo(Control control)
        {
            bool eventArgs = false;
            if (string.IsNullOrEmpty(control.Text))
            {
                eventArgs = true;
                control.BackColor = Color.Red;
                errorProvider.SetError(control, "Campo Obrigatório");
            }
            else
            {
                eventArgs = false;
                errorProvider.SetError(control, null);
            }
            return eventArgs;
        }

        private void textTipoProduto_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ValidaCampo(textTipoProduto);
        }

        private void SetBGColorFocused(Control control)
        {

            control.BackColor = SystemColors.GradientActiveCaption;
        }

        private void SetBgColorUnfocused(Control control)
        {
            control.BackColor = SystemColors.Window;
        }

        private void textTipoProduto_Leave(object sender, EventArgs e)
        {
            SetBgColorUnfocused(textTipoProduto);
            ValidaCampo(textTipoProduto);
        }

        private void TipoProdutoAddForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.TiposProdutosListUC.TiposProdutosListUC_Load(sender, e);
        }
    }
}
