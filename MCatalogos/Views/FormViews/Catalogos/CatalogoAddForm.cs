using CommonComponents;

using DomainLayer.Models.Catalogos;

using InfrastructureLayer.DataAccess.Repositories.Specific.Catalogo;
using InfrastructureLayer.DataAccess.Repositories.Specific.Fornecedor;

using MCatalogos.Views.FormViews.Fornecedores;
using MCatalogos.Views.UserControls.Fornecedores;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.CatalogoServices;
using ServiceLayer.Services.FornecedorServices;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCatalogos.Views.FormViews.Catalogos
{
    public partial class CatalogoAddForm : Form
    {
        FornecedorForm FornecedorForm;
        CatalogosFornecedorListUc CatalogosFornecedorListUc;

        private CatalogoServices _catalogoServices;
        //TODO: CampanhaServices _campanhaServices;
        private FornecedorServices _fornecedorServices;

        public int catalogoId = 0;
        public int fornecedorId = 0;

        private static string _connectionString = @"SERVER=.\SQLEXPRESS;DATABASE=MCatalogoDB;INTEGRATED SECURITY=SSPI";
        public CatalogoAddForm(FornecedorForm fornecedorForm, CatalogosFornecedorListUc catalogosFornecedorListUc)
        {
            _catalogoServices = new CatalogoServices(new CatalogoRepository(_connectionString), new ModelDataAnnotationCheck());
            _fornecedorServices = new FornecedorServices(new FornecedorRepository(_connectionString), new ModelDataAnnotationCheck());

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
        }

        private void CatalogoAddForm_Load(object sender, EventArgs e)
        {
            this.fornecedorId = int.Parse(this.FornecedorForm.textFornecedorId.Text);
            PreencheCamposForUpdate();
        }
    }
}
