using CommonComponents;

using DomainLayer.Models.Catalogos;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Specific.Catalogo;

using MCatalogos.Views.UserControls.Catalogos;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.CatalogoServices;

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
    public partial class CampanhaAddForm : Form
    {
        QueryStringServices _queryString;
        CatalogoForm CatalogoForm;
        CampanhaCatalogoListUC CampanhaCatalogoListUC;

        private CampanhaServices _campanhaServices;
        private CatalogoServices _catalogoServices;

        public int catalogoId = 0;
        public int campanhaId = 0;


        public CampanhaAddForm(CatalogoForm catalogoForm, CampanhaCatalogoListUC campanhaCatalogoListUC)
        {
            _queryString = new QueryStringServices(new QueryString());
            _campanhaServices = new CampanhaServices(new CampanhaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _catalogoServices = new CatalogoServices(new CatalogoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());

            InitializeComponent();
            this.CatalogoForm = catalogoForm;
            this.CampanhaCatalogoListUC = campanhaCatalogoListUC;
        }

        //REPOSITORIES CALLERS
        private CampanhaModel CampanhaAdd()
        {
            bool operationSucceeded = false;
            string dataAccessStatusJsonStr = string.Empty;
            string formattedJsonStr = string.Empty;
            bool status = GetStatus(cbStatus.Text);

            CampanhaModel returnedModel = new CampanhaModel();

            CampanhaModel model = new CampanhaModel()
            {
                Ativa = status,
                DataLancamento = DateTime.Parse(dateInicio.Text),
                DataEncerramento = DateTime.Parse(dateFim.Text),
                Nome = textCampanha.Text,
                CatalogoId = catalogoId
            };

            try
            {
                returnedModel = _campanhaServices.Add(model);
                operationSucceeded = true;
            }
            catch (DataAccessException e)
            {

                operationSucceeded = e.DataAccessStatusInfo.OperationSucceeded;
                dataAccessStatusJsonStr = JsonConvert.SerializeObject(e.DataAccessStatusInfo);
                formattedJsonStr = JToken.Parse(dataAccessStatusJsonStr).ToString();
                MessageBox.Show(formattedJsonStr, "Não foi possível adicionar Campanha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return returnedModel;
        }

        private void CampanhaUpdate()
        {
            bool operationSucceeded = false;
            string dataAccessStatusJsonStr = string.Empty;
            string formattedJsonStr = string.Empty;

            CampanhaModel model = new CampanhaModel()
            {
                CampanhaId = campanhaId,
                Ativa = GetStatus(cbStatus.Text),
                Nome = textCampanha.Text,
                DataLancamento = DateTime.Parse(dateInicio.Text),
                DataEncerramento = DateTime.Parse(dateFim.Text),
                CatalogoId = catalogoId

            };

            try
            {
                _campanhaServices.Update(model);
                operationSucceeded = true;
            }
            catch (DataAccessException e)
            {
                operationSucceeded = e.DataAccessStatusInfo.OperationSucceeded;
                dataAccessStatusJsonStr = JsonConvert.SerializeObject(e.DataAccessStatusInfo);
                formattedJsonStr = JToken.Parse(dataAccessStatusJsonStr).ToString();
                MessageBox.Show(formattedJsonStr, "Não foi possívle atualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (operationSucceeded)
            {
                MessageBox.Show("Registro atualizado com suceddo!", "Atualizar Campanha", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //OWN METHODS

        public void LoadCampanhaForUpdate()
        {
            CampanhaModel model = null;
            if (campanhaId != 0)
            {
                try
                {
                    model = _campanhaServices.GetById(campanhaId);
                }
                catch (DataAccessException e)
                {
                    MessageBox.Show($"Não foi possível recuperar dados da Campanha solicitada." +
                        $"\nMessage: {e.DataAccessStatusInfo.getFormattedValues()}", "Error");
                }

                if (model != null)
                {
                    textCampanhaId.Text = model.CampanhaId.ToString();
                    textCampanha.Text = model.Nome.ToString();
                    textCatalogo.Text = _catalogoServices.GetById(model.CatalogoId).Nome.ToString();
                    dateInicio.Text = model.DataLancamento.ToString();
                    dateFim.Text = model.DataEncerramento.ToString();

                    VErificaAtivo(model);
                }
            }
            else
            {
                textCatalogo.Text = _catalogoServices.GetById(catalogoId).Nome;
                VErificaAtivo(null);
            }
        }

        private void VErificaAtivo(CampanhaModel model)
        {
            if (model != null)
            {
                if (model.Ativa)
                {
                    cbStatus.Text = "Ativo";
                    cbStatus.BackColor = Color.LimeGreen;
                    cbStatus.Font = new Font("Calibri", 9F, FontStyle.Bold);

                }
                else if (!model.Ativa)
                {
                    cbStatus.Text = "Inativo";
                    cbStatus.BackColor = Color.Red;
                    cbStatus.Font = new Font("Calibri", 9F, FontStyle.Bold);
                }
            }
            else
            {
                cbStatus.Text = "Ativo";
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
            CampanhaModel model = new CampanhaModel();
            if (campanhaId == 0)
            {
                model = CampanhaAdd();
                campanhaId = int.Parse(model.CampanhaId.ToString());
            }
            else
            {
                CampanhaUpdate();
            }

            //CatalogoForm.PreencheCamposForUpdate();
            //this.CampanhaCatalogoListUC.CampanhaCatalogoListUC_Load(sender, e);
            this.Close();
        }

        private void CampanhaAddForm_Load(object sender, EventArgs e)
        {
            LoadCampanhaForUpdate();
        }
    }
}
