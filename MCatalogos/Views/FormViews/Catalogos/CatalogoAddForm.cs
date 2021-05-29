using CommonComponents;

using DomainLayer.Models.Catalogos;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Specific.Catalogo;
using InfrastructureLayer.DataAccess.Repositories.Specific.Fornecedor;

using MCatalogos.Views.FormViews.Fornecedores;
using MCatalogos.Views.UserControls.Fornecedores;

using Microsoft.SqlServer.Server;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.CatalogoServices;
using ServiceLayer.Services.FornecedorServices;

using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace MCatalogos.Views.FormViews.Catalogos
{
    public partial class CatalogoAddForm : Form
    {
        FornecedorForm FornecedorForm;
        CatalogosFornecedorListUc CatalogosFornecedorListUc;

        private QueryStringServices _queryString;
        private CatalogoServices _catalogoServices;
        private FornecedorServices _fornecedorServices;

        public int catalogoId = 0;
        public int fornecedorId = 0;

        public CatalogoAddForm(FornecedorForm fornecedorForm, CatalogosFornecedorListUc catalogosFornecedorListUc)
        {
            _queryString = new QueryStringServices(new QueryString());
            _catalogoServices = new CatalogoServices(new CatalogoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _fornecedorServices = new FornecedorServices(new FornecedorRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());

            InitializeComponent();
            this.FornecedorForm = fornecedorForm;
            this.CatalogosFornecedorListUc = catalogosFornecedorListUc;

        }



        //REPOSITORIES CALLERS
        private CatalogoModel CatalogoAdd()
        {
            bool operationSucceeded = false;
            string dataAccessStatusJsonStr = string.Empty;
            string formattedJsonStr = string.Empty;
            bool status = GetStatus(cbStatus.Text);

            CatalogoModel returnedModel = new CatalogoModel();

            CatalogoModel model = new CatalogoModel()
            {
                Ativo = status,
                Nome = textNome.Text,
                MargemPadraoVendedora = float.Parse(textMargemVendedora.Text),
                MargemPadraoDistribuidor = float.Parse(textMargemDistribuidor.Text),
                TaxaPedido = bool.Parse(checkBoxTaxaPedido.Checked.ToString()),
                ValorTaxaPedido = (string.IsNullOrEmpty(textValorTaxaPedido.Text.Trim()) && !checkBoxTaxaPedido.Checked) ? 0 : float.Parse(textValorTaxaPedido.Text),
                TaxaProduto = bool.Parse(checkBoxTaxaProduto.Checked.ToString()),
                ValorTaxaProduto = (string.IsNullOrEmpty(textValorTaxaProduto.Text.Trim()) && !checkBoxTaxaProduto.Checked) ? 0 : float.Parse(textValorTaxaProduto.Text),

                FornecedorId = fornecedorId

            };

            try
            {
                returnedModel = _catalogoServices.Add(model);
                operationSucceeded = true;
            }
            catch (DataAccessException e)
            {
                operationSucceeded = e.DataAccessStatusInfo.OperationSucceeded;
                dataAccessStatusJsonStr = JsonConvert.SerializeObject(e.DataAccessStatusInfo);
                formattedJsonStr = JToken.Parse(dataAccessStatusJsonStr).ToString();
                MessageBox.Show(formattedJsonStr, "Não foi possível adicionar Catálogo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            if (operationSucceeded)
            {
                MessageBox.Show("Catálogo adicionado com sucesso", "Adicionar Catálogo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return returnedModel;


        }
        private void CatalogoUpdate()
        {
            bool operationSucceeded = false;
            string dataAcessStatusJsonStr = string.Empty;
            string formattedJsonStr = string.Empty;

            CatalogoModel model = new CatalogoModel()
            {
                CatalogoId = int.Parse(textCatalogoId.Text),
                Ativo = GetStatus(cbStatus.Text),
                Nome = textNome.Text,
                MargemPadraoVendedora = float.Parse(textMargemVendedora.Text),
                MargemPadraoDistribuidor = float.Parse(textMargemDistribuidor.Text),
                TaxaPedido = checkBoxTaxaPedido.Checked,
                ValorTaxaPedido = (string.IsNullOrEmpty(textValorTaxaPedido.Text.Trim()) && !checkBoxTaxaPedido.Checked) ? 0 : float.Parse(textValorTaxaPedido.Text),
                TaxaProduto = checkBoxTaxaProduto.Checked,
                ValorTaxaProduto = (string.IsNullOrEmpty(textValorTaxaProduto.Text.Trim()) && !checkBoxTaxaProduto.Checked) ? 0 : float.Parse(textValorTaxaProduto.Text),

                FornecedorId = fornecedorId
            };
            try
            {
                _catalogoServices.Update(model);
                operationSucceeded = true;
            }
            catch (DataAccessException e)
            {
                operationSucceeded = e.DataAccessStatusInfo.OperationSucceeded;
                dataAcessStatusJsonStr = JsonConvert.SerializeObject(e.DataAccessStatusInfo);
                formattedJsonStr = JToken.Parse(dataAcessStatusJsonStr).ToString();
                MessageBox.Show(formattedJsonStr, "Não foi possível atualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (operationSucceeded)
            {
                MessageBox.Show("Registro Atualizado com sucesso!", "Alterar Catálogo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        //SETTINGS AND GETTINGS
        public void PreencheCamposForUpdate()
        {
            CatalogoModel model = null;
            if (catalogoId != 0)
            {

                try
                {
                    model = _catalogoServices.GetById(catalogoId);
                }
                catch (DataAccessException e)
                {
                    MessageBox.Show($"Não foi possível recuperar dados do Catálogo solicitado.\nMessage: " +
                        $"{e.DataAccessStatusInfo.getFormattedValues()}", "Error");

                }

                if (model != null)
                {
                    textCatalogoId.Text = model.CatalogoId.ToString();
                    textNome.Text = model.Nome.ToString();
                    textMargemVendedora.Text = model.MargemPadraoVendedora.ToString();
                    textMargemDistribuidor.Text = model.MargemPadraoDistribuidor.ToString();
                    checkBoxTaxaPedido.Checked = model.TaxaPedido;
                    textValorTaxaPedido.Text = model.ValorTaxaPedido.ToString("0.00");
                    checkBoxTaxaProduto.Checked = model.TaxaProduto;
                    textValorTaxaProduto.Text = model.ValorTaxaProduto.ToString("0.00");
                   
                    cbFornecedor.Text = _fornecedorServices.GetById(fornecedorId).NomeFantasia;

                    VerificaAtivo(model);
                }

            }
            else
            {
                cbFornecedor.Text = _fornecedorServices.GetById(fornecedorId).NomeFantasia;

            }

        }
        private void VerificaAtivo(CatalogoModel model)
        {
            if (model.Ativo)
            {
                cbStatus.Text = "Ativo";
                cbStatus.BackColor = Color.LimeGreen;
                cbStatus.Font = new Font("Calibri", 9F, FontStyle.Bold);
            }
            else if (!model.Ativo)
            {
                cbStatus.Text = "Inativo";
                cbStatus.BackColor = Color.Red;
                cbStatus.Font = new Font("Calibri", 9F, FontStyle.Bold);
            }
            else
            {
                cbStatus.Text = "";
                cbStatus.BackColor = Color.White;
                cbStatus.Font = new Font("Calibri", 9F, FontStyle.Bold);
            }
        }
        private bool GetStatus(string status)
        {
            if (status == "Ativo")
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //EVENTS FORM
        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbStatus.SelectedIndex == 1)
            {
                cbStatus.BackColor = Color.LimeGreen;
                cbStatus.ForeColor = Color.White;
                cbStatus.Font = new Font("Calibri", 9F, FontStyle.Bold);
            }
            else if (cbStatus.SelectedIndex == 2)
            {
                cbStatus.BackColor = Color.Red;
                cbStatus.ForeColor = Color.White;
                cbStatus.Font = new Font("Calibri", 9F, FontStyle.Bold);
            }
            else
            {
                cbStatus.BackColor = Color.White;
                cbStatus.ForeColor = Color.Black;
                cbStatus.Font = new Font("Calibri", 9F, FontStyle.Bold);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            CatalogoModel model = new CatalogoModel();
            if (catalogoId == 0)
            {
                model = CatalogoAdd();
                catalogoId = int.Parse(model.CatalogoId.ToString());
            }
            else
            {
                {
                    CatalogoUpdate();
                }

            }
            FornecedorForm.PreencheCampos();
            this.CatalogosFornecedorListUc.LoadCatalogos();
            PreencheCamposForUpdate();
            this.Close();
        }
        private void CatalogoAddForm_Load(object sender, EventArgs e)
        {
            this.fornecedorId = int.Parse(this.FornecedorForm.textFornecedorId.Text);
            PreencheCamposForUpdate();
        }

        private void checkBoxTaxaProduto_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxTaxaProduto.Checked)
            {
                textValorTaxaProduto.Enabled = true;
            }
            else
            {
                textValorTaxaProduto.Enabled = false;
            }
        }

        private void checkBoxTaxaPedido_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxTaxaPedido.Checked)
            {
                textValorTaxaPedido.Enabled = true;
            }
            else
            {
                textValorTaxaPedido.Enabled = false;
            }
        }
    }
}
