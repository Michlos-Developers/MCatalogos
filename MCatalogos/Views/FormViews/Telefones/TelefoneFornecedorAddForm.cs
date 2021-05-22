using CommonComponents;

using DomainLayer.Models.CommonModels.Enums;
using DomainLayer.Models.Fornecedores;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Commons;
using InfrastructureLayer.DataAccess.Repositories.Specific.Fornecedor;

using MCatalogos.Views.FormViews.Fornecedores;
using MCatalogos.Views.UserControls.Fornecedores;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.FornecedorServices;
using ServiceLayer.Services.TelefoneFornecedorServices;
using ServiceLayer.Services.TipoTelefoneServices;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCatalogos.Views.FormViews.Telefones
{
    public partial class TelefoneFornecedorAddForm : Form
    {
        QueryStringServices _queryString;
        FornecedorForm FornecedorForm;
        TelefonesFornecedorListUC TelefonesFornecedorListUC;

        private TelefoneFornecedorServices _telefoneService;
        private TipoTelefoneServices _tipoTelefoneServices;

        public int telefoneId = 0;
        public int fornecedorId = 0;

        public TelefoneFornecedorAddForm(FornecedorForm fornecedorForm, TelefonesFornecedorListUC telefonesFornecedorListUC)
        {
            _queryString = new QueryStringServices(new QueryString());
            _tipoTelefoneServices = new TipoTelefoneServices(new TipoTelefoneRepository(_queryString.GetQuery()), new ModelDataAnnotationCheck());
            _telefoneService = new TelefoneFornecedorServices(new TelefoneFornecedorRepository(_queryString.GetQuery()), new ModelDataAnnotationCheck());


            InitializeComponent();
            this.FornecedorForm = fornecedorForm;
            this.TelefonesFornecedorListUC = telefonesFornecedorListUC;
            this.fornecedorId = int.Parse(this.FornecedorForm.textFornecedorId.Text);
        }


        //REPOSITORIES CALLERS
        private bool TelefoneAdd()
        {
            bool operationSucceeded = false;
            string dataAccessStatusJsonStr = string.Empty;
            string formattedJsonStr = string.Empty;



            var numeroTelefone = ReplaceNumeroTelefone(mTextNumero.Text);

            TelefoneFornecedorModel model = new TelefoneFornecedorModel()
            {
                Numero = numeroTelefone,
                Ramal = textRamal.Text,
                Contato = textContato.Text,
                Departamento = textDepartamento.Text,
                TipoTelefoneId = _tipoTelefoneServices.GetByTipo(cbTipoTelefone.Text.ToString()).TipoId,
                FornecedorId = fornecedorId
            };

            try
            {
                _telefoneService.Add(model);
                operationSucceeded = true;
            }
            catch (DataAccessException e)
            {
                operationSucceeded = e.DataAccessStatusInfo.OperationSucceeded;
                dataAccessStatusJsonStr = JsonConvert.SerializeObject(e.DataAccessStatusInfo);
                formattedJsonStr = JToken.Parse(dataAccessStatusJsonStr).ToString();
                MessageBox.Show(formattedJsonStr, "Erro ao tentar adicioanr telefone ao fornecedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (operationSucceeded)
            {
                MessageBox.Show("Telefone adicionado com suceddo", "Adicionar Telefone", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return operationSucceeded;

        }
        private void TelefoneUpdate()
        {
            bool operationSucceeded = false;
            string dataAccessStatusJsonStr = string.Empty;
            string formattedJsonStr = string.Empty;

            var numeroTelefone = ReplaceNumeroTelefone(mTextNumero.Text);

            TelefoneFornecedorModel model = new TelefoneFornecedorModel()
            {
                TelefoneId = this.telefoneId,
                Numero = numeroTelefone,
                Ramal = textRamal.Text,
                Contato = textContato.Text,
                Departamento = textDepartamento.Text,
                TipoTelefoneId = _tipoTelefoneServices.GetByTipo(cbTipoTelefone.Text.ToString()).TipoId,
                FornecedorId = this.fornecedorId
            };

            try
            {
                _telefoneService.Update(model);
                operationSucceeded = true;
            }
            catch (DataAccessException e)
            {
                operationSucceeded = e.DataAccessStatusInfo.OperationSucceeded;
                dataAccessStatusJsonStr = JsonConvert.SerializeObject(e.DataAccessStatusInfo);
                formattedJsonStr = JToken.Parse(dataAccessStatusJsonStr).ToString();
                MessageBox.Show(formattedJsonStr, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            if (operationSucceeded)
            {
                MessageBox.Show("Telefone atualizado com sucesso", "Atualizar Telefone", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }


        //SETTING AND GETTINS
        private void PreencheCamposForUpdate()
        {
            if (telefoneId != 0)
            {
                TelefoneFornecedorModel model = null;
                try
                {
                    model = _telefoneService.GetById(telefoneId);
                }
                catch (DataAccessException e)
                {
                    MessageBox.Show($"Não foi possível recuperar o telefone para edição.\nMessage: {e.DataAccessStatusInfo.getFormattedValues()}", "Error");
                }

                if (model != null)
                {
                    mTextNumero.Text = model.Numero;
                    textRamal.Text = model.Ramal != null || model.Ramal != "" ? model.Ramal : "";
                    textContato.Text = model.Contato != null || model.Contato != "" ? model.Contato : "";
                    textDepartamento.Text = model.Departamento;
                    cbTipoTelefone.Text = _tipoTelefoneServices.GetById(model.TipoTelefoneId).TipoTelefone;

                }
            }
        }
        private void LoadTiposTelefonesToComboBox()
        {
            List<TipoTelefoneModel> modelList = (List<TipoTelefoneModel>)_tipoTelefoneServices.GetAll();

            cbTipoTelefone.DisplayMember = "TipoTelefone";
            cbTipoTelefone.SelectedIndex = -1;
            cbTipoTelefone.Items.Clear();
            foreach (TipoTelefoneModel model in modelList)
            {
                cbTipoTelefone.Items.Add(model);
            }
        }
        private void SEtMaskTelefoneNumero(string tipo)
        {
            if (tipo == "Fixo")
            {
                mTextNumero.Mask = "(99) 9999-9999";
                textRamal.Enabled = true;
            }
            else
            {
                mTextNumero.Mask = "(99) 9 9999-9999";
                textRamal.Enabled = false;

            }
        }
        private string ReplaceNumeroTelefone(string numero)
        {
            numero = numero.Replace("(", "");
            numero = numero.Replace(")", "");
            numero = numero.Replace("-", "");
            numero = numero.Replace(" ", "");

            return numero;
        }
        private void ClearControls()
        {
            cbTipoTelefone.Text = "-";
            mTextNumero.Text = string.Empty;
            textContato.Text = string.Empty;
            textDepartamento.Text = string.Empty;
            textRamal.Text = string.Empty;
            textRamal.Enabled = false;
        }


        //EVENTS FORM
        private void TelefoneFornecedorAddForm_Load(object sender, EventArgs e)
        {
            PreencheCamposForUpdate();
            LoadTiposTelefonesToComboBox();
            cbTipoTelefone.Focus();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (telefoneId == 0)
            {
                var addResult = TelefoneAdd();
                if (addResult == true)
                {
                    var result = MessageBox.Show("Deseja adicionar outro telefone?", "Continuar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        ClearControls();
                    }

                    this.TelefonesFornecedorListUC.LoadTelefones();
                    this.Close();

                }
            }
            else
            {
                try
                {
                    TelefoneUpdate();
                }
                catch (DataAccessException ex)
                {
                    MessageBox.Show($"Não foi possível atualizar os dados de contato.\nMessageError: {ex.Message}", "Error");
                }
                finally
                {
                    this.TelefonesFornecedorListUC.LoadTelefones();
                    this.Close();
                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cbTipoTelefone_SelectedIndexChanged(object sender, EventArgs e)
        {
            SEtMaskTelefoneNumero(cbTipoTelefone.Text);
        }



        //FOCUSED ENTER
        private void cbTipoTelefone_Enter(object sender, EventArgs e)
        {
            cbTipoTelefone.BackColor = SystemColors.ActiveCaption;
        }
        private void textContato_Enter(object sender, EventArgs e)
        {
            textContato.BackColor = SystemColors.ActiveCaption;
        }
        private void textDepartamento_Enter(object sender, EventArgs e)
        {
            textDepartamento.BackColor = SystemColors.ActiveCaption;
        }
        private void mTextNumero_Enter(object sender, EventArgs e)
        {
            mTextNumero.BackColor = SystemColors.ActiveCaption;
        }
        private void textRamal_Enter(object sender, EventArgs e)
        {
            textRamal.BackColor = SystemColors.ActiveCaption;
        }
        
        
        //FOCUSED LEAVE
        private void cbTipoTelefone_Leave(object sender, EventArgs e)
        {
            cbTipoTelefone.BackColor = SystemColors.Window;
        }
        private void textContato_Leave(object sender, EventArgs e)
        {
            textContato.BackColor = SystemColors.Window;
        }
        private void textDepartamento_Leave(object sender, EventArgs e)
        {
            textDepartamento.BackColor = SystemColors.Window;
        }
        private void mTextNumero_Leave(object sender, EventArgs e)
        {
            mTextNumero.BackColor = SystemColors.Window;
        }
        private void textRamal_Leave(object sender, EventArgs e)
        {
            textRamal.BackColor = SystemColors.Window;
        }
    }
}
