using CommonComponents;

using DomainLayer.Models.CommonModels.Address;
using DomainLayer.Models.Fornecedores;
using DomainLayer.Models.Validations;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Commons;
using InfrastructureLayer.DataAccess.Repositories.Specific.Fornecedor;
using InfrastructureLayer.Validations;

using MCatalogos.Views.FormViews.Bairros;
using MCatalogos.Views.UserControls.Fornecedores;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.BairroServices;
using ServiceLayer.Services.CidadeServices;
using ServiceLayer.Services.EstadosServices;
using ServiceLayer.Services.FornecedorServices;
using ServiceLayer.Services.ValidationServices;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MCatalogos.Views.FormViews.Fornecedores
{
    public partial class FornecedorForm : Form
    {
        #region PROPRIEDADES PARA MOVER A JANELA

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        #endregion

        /// <summary>
        /// Utilizado para manter as conexaões com o banco de dados
        /// em um único método separado.
        /// Origens:
        /// -> ServiceLayer/QueryStringServices
        /// -> InfrastructureLayer/QueryString
        /// </summary>
        QueryStringServices _queryString;


        FornecedoresListForm FornecedoresListForm;

        private FornecedorServices _fornecedorServices;
        private EstadoServices _estadoServices;
        private CidadeServices _cidadeServices;
        private BairroServices _bairroServices;
        private ValidationCnpjServices _validationCnpjServices;

        /// <summary>
        /// Variável utilizada na validação de campos. 
        /// Se campos válidos recebe true, senão recebe false;
        /// </summary>
        bool permiteAddOrUpdate = false;



        public FornecedorForm(FornecedoresListForm fornecedoresListForm)
        {
            _queryString = new QueryStringServices(new QueryString());
            _fornecedorServices = new FornecedorServices(new FornecedorRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _estadoServices = new EstadoServices(new EstadoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _cidadeServices = new CidadeServices(new CidadeRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _bairroServices = new BairroServices(new BairroRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _validationCnpjServices = new ValidationCnpjServices(new CnpjRepository());

            InitializeComponent();
            this.FornecedoresListForm = fornecedoresListForm;
        }

        private void SetBGColorFocused(Control control)
        {

            control.BackColor = SystemColors.GradientActiveCaption;
        }

        private void SetBgColorUnfocused(Control control)
        {
            control.BackColor = SystemColors.Window;
        }

        //REPOSITORY CALLERS
        private FornecedorModel FornecedorAdd()
        {
            FornecedorModel returnModel = new FornecedorModel();
            string cnpj = ReplaceCnpj(mTextCnpj.Text);
            string cep = ReplaceCep(mTextCep.Text);
            string ie = ReplaceIe(mTextInscricaoEstadual.Text);

            FornecedorModel model = new FornecedorModel()
            {
                BairroId = _bairroServices.GetByNomeAndCidadeId(cbBairro.Text,
                           _cidadeServices.GetByNomeAndEstadoId(cbCidade.Text,
                           _estadoServices.GetByUf(cbUf.Text).EstadoId).CidadeId).BairroId,
                Cep = cep,
                CidadeId = _cidadeServices.GetByNomeAndEstadoId(cbCidade.Text,
                           _estadoServices.GetByUf(cbUf.Text).EstadoId).CidadeId,
                Cnpj = cnpj,
                Complemento = textComplemento.Text,
                Email = textEmail.Text,
                InscricaoEstadual = ie,
                Logradouro = textLogradouro.Text,
                NomeFantasia = textNomeFantasia.Text,
                Numero = textNumero.Text,
                RazaoSocial = textRazaoSocial.Text,
                UfId = _estadoServices.GetByUf(cbUf.Text).EstadoId,
                WebSite = textSite.Text,
                ContatoPrincipal = "",
                Ativo = true

            };

            bool operationSucceeded = false;
            string dataAccessStatusJsonStr = string.Empty;
            string formattedJsonStr = string.Empty;

            try
            {
                returnModel = _fornecedorServices.Add(model);
                operationSucceeded = true;
            }
            catch (DataAccessException e)
            {
                operationSucceeded = e.DataAccessStatusInfo.OperationSucceeded;
                dataAccessStatusJsonStr = JsonConvert.SerializeObject(e.DataAccessStatusInfo);
                formattedJsonStr = JToken.Parse(dataAccessStatusJsonStr).ToString();
                MessageBox.Show(formattedJsonStr, "Erro ao tentar adicionar Fornecedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (operationSucceeded)
            {
                MessageBox.Show("Registro adicionar dom suceddo!", "Adicionar Fornecedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return returnModel;
        }
        private void FornecedorUpdate()
        {
            FornecedorModel model = new FornecedorModel()
            {
                FornecedorId = int.Parse(textFornecedorId.Text),
                Cnpj = ReplaceCnpj(mTextCnpj.Text),
                InscricaoEstadual = ReplaceIe(mTextInscricaoEstadual.Text),
                RazaoSocial = textRazaoSocial.Text,
                NomeFantasia = textNomeFantasia.Text,
                Logradouro = textLogradouro.Text,
                Numero = textNumero.Text,
                Cep = ReplaceCep(mTextCep.Text),
                UfId = _estadoServices.GetByUf(cbUf.Text).EstadoId,
                Complemento = textComplemento.Text,
                CidadeId = _cidadeServices.GetByNomeAndEstadoId(cbCidade.Text,
                           _estadoServices.GetByUf(cbUf.Text).EstadoId).CidadeId,
                BairroId = _bairroServices.GetByNomeAndCidadeId(cbBairro.Text,
                           _cidadeServices.GetByNomeAndEstadoId(cbCidade.Text,
                           _estadoServices.GetByUf(cbUf.Text).EstadoId).CidadeId).BairroId,
                Email = textEmail.Text,
                WebSite = textSite.Text,
                ContatoPrincipal = "",
                Ativo = true
            };

            bool operationSucceeded = false;
            string dataAccessStatusJsonStr = string.Empty;
            string formattedJsonStr = string.Empty;

            try
            {
                _fornecedorServices.Update(model);
                operationSucceeded = true;
            }
            catch (DataAccessException e)
            {
                operationSucceeded = e.DataAccessStatusInfo.OperationSucceeded;
                dataAccessStatusJsonStr = JsonConvert.SerializeObject(e.DataAccessStatusInfo);
                formattedJsonStr = JToken.Parse(dataAccessStatusJsonStr).ToString();
                MessageBox.Show(formattedJsonStr, "Não foi possível atualizar os dados do Forencedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (operationSucceeded)
            {
                MessageBox.Show("Registro atualizado com sucesso!", "Alterar dados de Fornecedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        //LOAD USER CONTROLS
        private void LoadUserControlCatalogos()
        {
            CatalogosFornecedorListUc catalogos = new CatalogosFornecedorListUc(this);
            if (textFornecedorId.Text != "")
            {
                catalogos.fornecedorId = int.Parse(this.textFornecedorId.Text);
            }
            panelCatalogosList.Controls.Clear();
            panelCatalogosList.Controls.Add(catalogos);
            catalogos.Dock = DockStyle.Fill;
        }
        private void LoadUserControlTelefones()
        {
            TelefonesFornecedorListUC telefone = new TelefonesFornecedorListUC(this);
            if (textFornecedorId.Text != "")
            {
                telefone.fornecedorId = int.Parse(this.textFornecedorId.Text);

            }

            panelContatosList.Controls.Clear();
            panelContatosList.Controls.Add(telefone);
            telefone.Dock = DockStyle.Fill;
        }


        //LOAD COMBOBOXES
        private void LoadEstadosToComboBox()
        {
            List<EstadoModel> modelList = (List<EstadoModel>)_estadoServices.GetAll();

            cbUf.DisplayMember = "Uf";
            cbUf.SelectedIndex = 0;
            cbUf.Items.Clear();
            foreach (EstadoModel model in modelList)
            {
                cbUf.Items.Add(model);
            }
        }
        private void LoadCidadesToComboBox(string uf)
        {
            List<CidadeModel> modelList = (List<CidadeModel>)_cidadeServices.GetAllByUf(uf);

            cbCidade.DisplayMember = "Nome";
            cbCidade.Items.Clear();
            foreach (CidadeModel model in modelList)
            {
                cbCidade.Items.Add(model);
            }
        }
        private void LoadBairrosToComboBox(string text)
        {
            List<BairroModel> modelList = (List<BairroModel>)_bairroServices.GetByCidadeId(
                    _cidadeServices.GetByNomeAndEstadoId(
                    cbCidade.Text,
                    _estadoServices.GetByUf(cbUf.Text).EstadoId).CidadeId);

            if (modelList != null)
            {
                cbBairro.DisplayMember = "Nome";
                cbBairro.Items.Clear();
                foreach (BairroModel model in modelList)
                {
                    cbBairro.Items.Add(model);
                }
            }
        }


        //SETTING AND GETTING VALUES
        public void PreencheCampos()
        {
            if (textFornecedorId.Text != "")
            {
                FornecedorModel model = null;
                try
                {
                    model = _fornecedorServices.GetById(int.Parse(textFornecedorId.Text));
                }
                catch (DataAccessException e)
                {
                    MessageBox.Show($"Falha ao tentar recuparar dados do Fornecedor.\nErrorMessage: {e.DataAccessStatusInfo.getFormattedValues()}", "Error");
                }

                if (model != null)
                {

                    textFornecedorId.Text = model.FornecedorId.ToString();
                    textNomeFantasia.Text = model.NomeFantasia.ToString();
                    textRazaoSocial.Text = model.RazaoSocial.ToString();
                    mTextCnpj.Text = model.Cnpj.ToString();
                    mTextInscricaoEstadual.Text = model.InscricaoEstadual.ToString();
                    textLogradouro.Text = model.Logradouro.ToString();
                    textNumero.Text = model.Numero.ToString();

                    cbUf.Text = _estadoServices.GetById(int.Parse(model.UfId.ToString())).Uf;
                    cbCidade.Text = _cidadeServices.GetById(int.Parse(model.CidadeId.ToString())).Nome;
                    cbBairro.Text = _bairroServices.GetById(int.Parse(model.BairroId.ToString())).Nome;

                    textComplemento.Text = model.Complemento.ToString() != null || model.Complemento.ToString() != "" ? model.Complemento.ToString() : "";
                    textEmail.Text = model.Email.ToString() != null || model.Email.ToString() != "" ? model.Email.ToString() : "";
                    textSite.Text = model.WebSite.ToString() != null || model.WebSite.ToString() != "" ? model.WebSite.ToString() : "";
                    mTextCep.Text = model.Cep.ToString() != null || model.Cep.ToString() != "" ? model.Cep.ToString() : "";


                }
            }
        }
        private void SetMaskInscricaoEstadual(string uf)
        {
            switch (uf)
            {
                case "AC":
                    mTextInscricaoEstadual.Mask = "00,000,000/000-00";
                    break;
                case "AL":
                    mTextInscricaoEstadual.Mask = "00000000#";
                    break;
                case "AP":
                    mTextInscricaoEstadual.Mask = "000000000";
                    break;
                case "AM":
                    mTextInscricaoEstadual.Mask = "00,000,000-0";
                    break;
                case "BA":
                    if (mTextInscricaoEstadual.Text.Length == 8)
                    {
                        mTextInscricaoEstadual.Mask = "000000-00";
                    }
                    else
                    {
                        mTextInscricaoEstadual.Mask = "0000000-00";
                    }
                    break;
                case "CE":
                    mTextInscricaoEstadual.Mask = "00000000-0";
                    break;
                case "DF":
                    mTextInscricaoEstadual.Mask = "00000000000-00";
                    break;
                case "ES":
                    mTextInscricaoEstadual.Mask = "00000000-0";
                    break;
                case "GO":
                    mTextInscricaoEstadual.Mask = "00,000,000-0";
                    break;
                case "MA":
                    mTextInscricaoEstadual.Mask = "00000000-0";
                    break;
                case "MT":
                    mTextInscricaoEstadual.Mask = "0000000000-0";
                    break;
                case "MS":
                    mTextInscricaoEstadual.Mask = "00000000-0";
                    break;
                case "MG":
                    mTextInscricaoEstadual.Mask = "000,000,000/0000";
                    break;
                case "PA":
                    mTextInscricaoEstadual.Mask = "00-000000-0";
                    break;
                case "PB":
                    mTextInscricaoEstadual.Mask = "00000000-0";
                    break;
                case "PE":
                    mTextInscricaoEstadual.Mask = "0000000-00";
                    break;
                case "PI":
                    mTextInscricaoEstadual.Mask = "0000000-00";
                    break;
                case "PR":
                    mTextInscricaoEstadual.Mask = "000,00000-00";
                    break;
                case "RJ":
                    mTextInscricaoEstadual.Mask = "00,000,00-0";
                    break;
                case "RN":
                    mTextInscricaoEstadual.Mask = "00,000,000-0";
                    break;
                case "RS":
                    mTextInscricaoEstadual.Mask = "000/0000000";
                    break;
                case "SP":
                    mTextInscricaoEstadual.Mask = "000,000,000,000";
                    break;
                case "SC":
                    mTextInscricaoEstadual.Mask = "000,000,000";
                    break;
                case "SE":
                    mTextInscricaoEstadual.Mask = "00000000-0";
                    break;
                case "TO":
                    mTextInscricaoEstadual.Mask = "0000000000-0";
                    break;
                default:
                    mTextInscricaoEstadual.Mask = "";
                    break;
            }
        }
        private string ReplaceCnpj(string cnpj)
        {
            cnpj = cnpj.Replace(".", "");
            cnpj = cnpj.Replace("-", "");
            cnpj = cnpj.Replace("/", "");
            cnpj = cnpj.Replace(",", "");
            cnpj = cnpj.Replace(" ", "");

            return cnpj;
        }
        private string ReplaceIe(string ie)
        {
            ie = ie.Replace(".", "");
            ie = ie.Replace("-", "");
            ie = ie.Replace("/", "");
            ie = ie.Replace(" ", "");

            return ie;
        }
        private string ReplaceCep(string cep)
        {
            cep = cep.Replace(".", "");
            cep = cep.Replace("-", "");
            cep = cep.Replace(" ", "");

            return cep;
        }


        //EVENTS FORM
        private void FornecedorForm_Load(object sender, EventArgs e)
        {
            LoadEstadosToComboBox();
            PreencheCampos();
            LoadUserControlTelefones();
            LoadUserControlCatalogos();
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                if (permiteAddOrUpdate)
                {

                    FornecedorModel model = new FornecedorModel();
                    if (textFornecedorId.Text == "")
                    {
                        model = FornecedorAdd();
                        this.textFornecedorId.Text = model.FornecedorId.ToString();
                    }
                    else
                    {
                        FornecedorUpdate();
                    }
                    FornecedoresListForm.FornecedoresListForm_Load(sender, e);
                    this.FornecedorForm_Load(sender, e);
                }
            }


        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cbUf_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbUf.SelectedIndex > 0)
            {
                LoadCidadesToComboBox(cbUf.Text);
                SetMaskInscricaoEstadual(cbUf.Text);
            }
        }
        private void cbCidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBairrosToComboBox(cbCidade.Text);
            if (cbCidade.Text != string.Empty)
            {
                btnAddBairro.Enabled = true;
            }
        }


        //VALIDATIONS
        private bool ValidaCampos(Control control)
        {
            bool eventArgs = false;
            if (string.IsNullOrEmpty(control.Text))
            {
                eventArgs = true;
                control.Focus();
                errorProvider.SetError(control, "Campo Obrigatório!");
                permiteAddOrUpdate = false;

            }
            else
            {
                eventArgs = false;
                errorProvider.SetError(control, null);
                permiteAddOrUpdate = true;
            }
            return eventArgs;
        }
        private void mTextCnpj_Validating(object sender, CancelEventArgs e)
        {
            CnpjModel model = new CnpjModel() { Cnpj = mTextCnpj.Text };
            string cnpjReplaced = ReplaceCnpj(mTextCnpj.Text);
            if (string.IsNullOrEmpty(cnpjReplaced))
            {
                e.Cancel = true;
                mTextCnpj.Focus();
                errorProvider.SetError(mTextCnpj, "Campo Obrigatório");
                permiteAddOrUpdate = false;

            }
            else if (!_validationCnpjServices.ValidaCnpj(model))
            {
                e.Cancel = true;
                mTextCnpj.Focus();
                errorProvider.SetError(mTextCnpj, "CNPJ Inválido");
                permiteAddOrUpdate = false;

            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(mTextCnpj, null);
                permiteAddOrUpdate = true;
            }

        }
        private void textRazaoSocial_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ValidaCampos(textRazaoSocial);
        }
        private void textNomeFantasia_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ValidaCampos(textNomeFantasia);
        }
        private void textLogradouro_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ValidaCampos(textLogradouro);
        }
        private void textNumero_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ValidaCampos(textNumero);
        }
        private void cbUf_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ValidaCampos(cbUf);
        }
        private void cbCidade_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ValidaCampos(cbCidade);

        }
        private void cbBairro_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ValidaCampos(cbBairro);
        }

        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnAddBairro_Click(object sender, EventArgs e)
        {
            EstadoModel estadoModel = new EstadoModel();
            CidadeModel cidadeModel = new CidadeModel();
            BairroModel bairroModel = new BairroModel();
            estadoModel = _estadoServices.GetByUf(this.cbUf.Text);
            cidadeModel = _cidadeServices.GetByNomeAndEstadoId(this.cbCidade.Text, estadoModel.EstadoId);




            try
            {
                if (cbCidade.Text != string.Empty)
                {

                    BairroAddForm bairroAddForm = new BairroAddForm(cidadeModel, bairroModel);
                    bairroAddForm.Text = "Adicionando Novo Bairro";
                    bairroAddForm.StartPosition = FormStartPosition.CenterScreen;
                    bairroAddForm.ShowDialog();
                    LoadBairrosToComboBox(cbCidade.Text);
                    bairroModel = bairroAddForm.BairroModel;
                    cbBairro.Text = bairroModel.Nome;
                    MessageBox.Show($"Bairro {bairroModel.Nome} foi adicionado à cidade {cbCidade.Text}.", "Adicionando Bairro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Para adicionar um bairro você deve selecionar uma Cidade.", "Adicionando Bairro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    throw new Exception();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível adicionar um novo bairro à cidade");
            }
        }


        #region METHOD CONTROL ENTER SET BGCOLOR

        private void mTextCnpj_Enter(object sender, EventArgs e)
        {
            SetBGColorFocused(mTextCnpj);
        }

        private void textRazaoSocial_Enter(object sender, EventArgs e)
        {
            SetBGColorFocused(textRazaoSocial);

        }

        private void mTextInscricaoEstadual_Enter(object sender, EventArgs e)
        {
            SetBGColorFocused(mTextInscricaoEstadual);

        }

        private void textNomeFantasia_Enter(object sender, EventArgs e)
        {
            SetBGColorFocused(textNomeFantasia);

        }

        private void textLogradouro_Enter(object sender, EventArgs e)
        {
            SetBGColorFocused(textLogradouro);

        }

        private void textNumero_Enter(object sender, EventArgs e)
        {
            SetBGColorFocused(textNumero);

        }

        private void mTextCep_Enter(object sender, EventArgs e)
        {
            SetBGColorFocused(mTextCep);

        }

        private void cbUf_Enter(object sender, EventArgs e)
        {
            SetBGColorFocused(cbUf);

        }

        private void textComplemento_Enter(object sender, EventArgs e)
        {
            SetBGColorFocused(textComplemento);

        }

        private void cbCidade_Enter(object sender, EventArgs e)
        {
            SetBGColorFocused(cbCidade);

        }

        private void cbBairro_Enter(object sender, EventArgs e)
        {
            SetBGColorFocused(cbBairro);

        }

        private void textEmail_Enter(object sender, EventArgs e)
        {
            SetBGColorFocused(textEmail);

        }

        private void textSite_Enter(object sender, EventArgs e)
        {
            SetBGColorFocused(textSite);
        }

        private void mTextCnpj_Leave(object sender, EventArgs e)
        {
            SetBgColorUnfocused(mTextCnpj);
        }

        private void textRazaoSocial_Leave(object sender, EventArgs e)
        {
            SetBgColorUnfocused(textRazaoSocial);

        }

        private void mTextInscricaoEstadual_Leave(object sender, EventArgs e)
        {
            SetBgColorUnfocused(mTextInscricaoEstadual);

        }

        private void textNomeFantasia_Leave(object sender, EventArgs e)
        {
            SetBgColorUnfocused(textNomeFantasia);

        }

        private void textLogradouro_Leave(object sender, EventArgs e)
        {
            SetBgColorUnfocused(textLogradouro);

        }

        private void textNumero_Leave(object sender, EventArgs e)
        {
            SetBgColorUnfocused(textNumero);

        }

        private void mTextCep_Leave(object sender, EventArgs e)
        {
            SetBgColorUnfocused(mTextCep);

        }

        private void cbUf_Leave(object sender, EventArgs e)
        {
            SetBgColorUnfocused(cbUf);

        }

        private void textComplemento_Leave(object sender, EventArgs e)
        {
            SetBgColorUnfocused(textComplemento);

        }

        private void cbCidade_Leave(object sender, EventArgs e)
        {
            SetBgColorUnfocused(cbCidade);

        }

        private void cbBairro_Leave(object sender, EventArgs e)
        {
            SetBgColorUnfocused(cbBairro);

        }

        private void textEmail_Leave(object sender, EventArgs e)
        {
            SetBgColorUnfocused(textEmail);

        }

        private void textSite_Leave(object sender, EventArgs e)
        {
            SetBgColorUnfocused(textSite);

        }

        #endregion

        private void mTextCnpj_MouseClick(object sender, MouseEventArgs e)
        {
            string textoCnpj = mTextCnpj.Text.Replace("/", "");
            textoCnpj = textoCnpj.Replace("_", "");
            textoCnpj = textoCnpj.Replace(".", "");
            textoCnpj = textoCnpj.Replace("-", "");



            if (string.IsNullOrEmpty(textoCnpj.Trim()))
            {

                mTextCnpj.SelectionStart = 0;
            }
        }

        private void mTextInscricaoEstadual_MouseClick(object sender, MouseEventArgs e)
        {
            string textoIncricaoEstadual = mTextInscricaoEstadual.Text.Replace("/", "");
            textoIncricaoEstadual = textoIncricaoEstadual.Replace("_", "");
            textoIncricaoEstadual = textoIncricaoEstadual.Replace(".", "");
            textoIncricaoEstadual = textoIncricaoEstadual.Replace("-", "");

            if (string.IsNullOrEmpty(textoIncricaoEstadual.Trim()))
            {

                mTextInscricaoEstadual.SelectionStart = 0;
            }
        }

        private void mTextCep_MouseClick(object sender, MouseEventArgs e)
        {
            string textoCep = mTextCep.Text.Replace("/", "");
            textoCep = textoCep.Replace("_", "");
            textoCep = textoCep.Replace(".", "");
            textoCep = textoCep.Replace("-", "");


            if (string.IsNullOrEmpty(textoCep.Trim()))
            {

                mTextCep.SelectionStart = 0;
            }
        }
    }
}
