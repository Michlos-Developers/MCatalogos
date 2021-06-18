using CommonComponents;

using DomainLayer.Models.Catalogos;
using DomainLayer.Models.Produtos;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Specific.Produto;

using MCatalogos.Views.FormViews.Catalogos;
using MCatalogos.Views.UserControls.Catalogos;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.ProdutoServices;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MCatalogos.Views.FormViews.Produtos
{
    public partial class TipoProdutoAddForm : Form
    {
        CatalogoForm CatalogoForm;
        TiposProdutosListUC TiposProdutosListUC;
        CamposTiposProdutosListUC camposAdicionaisUC;

        QueryStringServices _queryString;
        private TipoProdutoServices _tipoProdutoServices;
        private CampoTipoProdutoServices _campoTipoProdutoServices;
        private FormatoCampoServices _formatoServices;

        public CatalogoModel CatalogoModel; //JÁ RECEBE O MODEL NO CHAMADO DO FORM
        public TipoProdutoModel TipoProdutoModel;//JÁ RECEBE O MODEL NO CHAMADO DO FORM
        public CampoTipoProdutoModel CampoTipoProdutoModel;
        public List<CampoTipoProdutoModel> ListaCamposAdicionais;

        public TipoProdutoAddForm(CatalogoForm catalogoForm, TiposProdutosListUC tiposProdutosListUC)
        {
            _queryString = new QueryStringServices(new QueryString());
            _tipoProdutoServices = new TipoProdutoServices(new TipoProdutoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _campoTipoProdutoServices = new CampoTipoProdutoServices(new CampoTipoProdutoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _formatoServices = new FormatoCampoServices(new FormatoCampoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());

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
                this.ListaCamposAdicionais = (List<CampoTipoProdutoModel>)_campoTipoProdutoServices.GetAllByTipoProdutoId(this.TipoProdutoModel.TipoProdutoId);
            }
        }

        private void LoadUserControlCamposAdicionais()
        {
            camposAdicionaisUC = new CamposTiposProdutosListUC(this);
            camposAdicionaisUC.TipoProdutoModel = this.TipoProdutoModel;
            panelCampos.Controls.Clear();
            panelCampos.Controls.Add(camposAdicionaisUC);
            camposAdicionaisUC.Dock = DockStyle.Fill;
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
                if (this.TipoProdutoModel != null)
                {
                    if (this.TipoProdutoModel.TipoProdutoId != 0) //UPDATE
                    {
                        try
                        {

                            UpdateTipoProduto(this.TipoProdutoModel);
                            //verificar se tem campo se tiver atualiza o que tem
                            DataGridViewRowCollection rowsCamposAdicionais = this.camposAdicionaisUC.dgvCampos.Rows;

                            if (this.ListaCamposAdicionais != null)
                            {
                                if (this.ListaCamposAdicionais.Count > 0)
                                {
                                    SaveCamposAdicionais(this.ListaCamposAdicionais, rowsCamposAdicionais);
                                }
                                else
                                {
                                    InsertNewCamposAdicionais(rowsCamposAdicionais);
                                }
                            }
                            MessageBox.Show("Tipo de Produto alterado com sucesso", "Atualizando Tipo de Produto");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Não foi possível atualizar o Tipo de Produto", "Atualizando Tipo de Produto");
                        }
                    }
                }
                else //INSERT
                {
                    try
                    {

                        this.TipoProdutoModel = InsertTipoProduto();

                        DataGridViewRowCollection rowsCamposAdicionais = this.camposAdicionaisUC.dgvCampos.Rows;
                        this.ListaCamposAdicionais = InsertNewCamposAdicionais(rowsCamposAdicionais);

                        MessageBox.Show($"Tipo de Produto Adicionado com sucesso", "Adicionando Tipo de Produto");

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Não foi possível adicionar o Tipo de Produto");
                    }
                }


            }
        }

        private void SaveCamposAdicionais(List<CampoTipoProdutoModel> campoListModels, DataGridViewRowCollection rowsCamposAdicionais)
        {


            //checa se a lista de tipos atual é do mesmo tamanho da linha da dgv
            if (campoListModels.Count == rowsCamposAdicionais.Count - 1) //-1 pq tem a linha de adição habilitada.
            {
                UpdateCamposAdicionais(campoListModels, rowsCamposAdicionais);


            }
            else if (campoListModels.Count < rowsCamposAdicionais.Count - 1)
            {
                //adiciona os demais da linha
                InsertCamposAdicionais(campoListModels, rowsCamposAdicionais);
            }
            else if (campoListModels.Count > rowsCamposAdicionais.Count - 1)
            {
                DeleteCamposAdicionais(campoListModels, rowsCamposAdicionais);
            }
        }

        private void DeleteCamposAdicionais(List<CampoTipoProdutoModel> campoListModels, DataGridViewRowCollection rowsCamposAdicionais)
        {
            List<CampoTipoProdutoModel> modelsForUpdate = new List<CampoTipoProdutoModel>();
            List<CampoTipoProdutoModel> modelsForDelete = new List<CampoTipoProdutoModel>();

            int indexCampos = campoListModels.Count - 1;
            int indexRows = rowsCamposAdicionais.Count - 2;

            for (int c = indexCampos; c >= 0; c--)
            {
                if (c > indexRows)
                {
                    modelsForDelete.Add(campoListModels[c]);
                }
                else if (indexRows >= 0)
                {
                    modelsForUpdate.Add(campoListModels[c]);
                }
            }

            try
            {
                foreach (var model in modelsForDelete)
                {
                    _campoTipoProdutoServices.Delete(model);
                }

                foreach (var model in modelsForUpdate)
                {
                    _campoTipoProdutoServices.Update(model);
                }
            }
            catch (Exception)
            {

                throw;
            }


        }

        private void InsertCamposAdicionais(List<CampoTipoProdutoModel> campoListModels, DataGridViewRowCollection rowsCamposAdicionais)
        {
            List<CampoTipoProdutoModel> listaCamposForAdd = new List<CampoTipoProdutoModel>();

            for (int c = 0; c < campoListModels.Count; c++)
            {
                for (int r = 0; r < rowsCamposAdicionais.Count - 1; r++)
                {
                    if (r <= c)
                    {
                        campoListModels[c].Nome = rowsCamposAdicionais[c].Cells["ColumnNome"].Value.ToString();
                        int formatoId = _formatoServices.GetByNome(rowsCamposAdicionais[c].Cells["ColumnFormato"].Value.ToString()).FormatoId;
                        campoListModels[c].FormatoId = formatoId;
                    }

                    if (r > c)
                    {
                        CampoTipoProdutoModel campoModel = new CampoTipoProdutoModel();

                        campoModel.Nome = rowsCamposAdicionais[r].Cells["ColumnNome"].Value.ToString();
                        int formatoId = _formatoServices.GetByNome(rowsCamposAdicionais[r].Cells["ColumnFormato"].Value.ToString()).FormatoId;
                        campoModel.FormatoId = formatoId;
                        campoModel.TipoProdutoId = this.TipoProdutoModel.TipoProdutoId;
                        listaCamposForAdd.Add(campoModel);
                    }
                }
            }
            try
            {
                foreach (var model in campoListModels)
                {
                    _campoTipoProdutoServices.Update(model); //UPDATE
                }

                foreach (var model in listaCamposForAdd)
                {

                    CampoTipoProdutoModel addedModel = _campoTipoProdutoServices.Add(model);  //INSERT
                    this.ListaCamposAdicionais.Add(addedModel);

                }
            }
            catch (Exception)
            {

                throw;
            }



        }

        private void UpdateCamposAdicionais(List<CampoTipoProdutoModel> campoListModels, DataGridViewRowCollection rowsCamposAdicionais)
        {
            bool operationSucceeded = false;
            string dataAccessStatusJsonStr = string.Empty;
            string formattedJsonStr = string.Empty;

            for (int c = 0; c < campoListModels.Count; c++)
            {
                campoListModels[c].Nome = rowsCamposAdicionais[c].Cells["ColumnNome"].Value.ToString();
                int formatoId = _formatoServices.GetByNome(rowsCamposAdicionais[c].Cells["ColumnFormato"].Value.ToString()).FormatoId;
                campoListModels[c].FormatoId = formatoId;
            }

            foreach (var model in campoListModels)
            {
                try
                {
                    _campoTipoProdutoServices.Update(model);
                }
                catch (DataAccessException e)
                {
                    operationSucceeded = e.DataAccessStatusInfo.OperationSucceeded;
                    dataAccessStatusJsonStr = JsonConvert.SerializeObject(e.DataAccessStatusInfo);
                    formattedJsonStr = JToken.Parse(dataAccessStatusJsonStr).ToString();
                    MessageBox.Show(formattedJsonStr, "Não foi possível atualizar o Tipo de Produto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private List<CampoTipoProdutoModel> InsertNewCamposAdicionais(DataGridViewRowCollection rowsCamposAdicionais) //que que eu vou fazer com a lista retornada???
        {
            List<CampoTipoProdutoModel> modelList = new List<CampoTipoProdutoModel>();

            bool operationSucceeded = false;
            string dataAccesStatusJsonStr = string.Empty;
            string formattedJsonStr = string.Empty;

            foreach (DataGridViewRow row in rowsCamposAdicionais)
            {
                if (row.Cells["ColumnNome"].Value != null)
                {
                    CampoTipoProdutoModel model = new CampoTipoProdutoModel();
                    model.Nome = row.Cells["ColumnNome"].Value.ToString();
                    int formatoId = _formatoServices.GetByNome(row.Cells["ColumnFormato"].Value.ToString()).FormatoId;
                    model.FormatoId = formatoId;
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

        private TipoProdutoModel InsertTipoProduto()
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
                operationSucceeded = true;
            }
            catch (DataAccessException e)
            {
                operationSucceeded = e.DataAccessStatusInfo.OperationSucceeded;
                dataAccesStatusJsonStr = JsonConvert.SerializeObject(e.DataAccessStatusInfo);
                formattedJsonStr = JToken.Parse(dataAccesStatusJsonStr).ToString();
                MessageBox.Show(formattedJsonStr, "Não foi possível adicionar o Tipo de Produto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            return returnedModel;
        }

        private void UpdateTipoProduto(TipoProdutoModel tipoProdutoModel)
        {
            this.TipoProdutoModel.Descricao = textTipoProduto.Text;

            bool operationSucceeded = false;
            string dataAccessStatusJsonStr = string.Empty;
            string formattedJsonStr = string.Empty;

            try
            {
                _tipoProdutoServices.Update(this.TipoProdutoModel);
                operationSucceeded = true;
            }
            catch (DataAccessException e)
            {
                operationSucceeded = e.DataAccessStatusInfo.OperationSucceeded;
                dataAccessStatusJsonStr = JsonConvert.SerializeObject(e.DataAccessStatusInfo);
                formattedJsonStr = JToken.Parse(dataAccessStatusJsonStr).ToString();
                MessageBox.Show(formattedJsonStr, "Não foi possível atualizar o Tipo de Produto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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

        private void textTipoProduto_Enter(object sender, EventArgs e)
        {
            SetBGColorFocused(textTipoProduto);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
