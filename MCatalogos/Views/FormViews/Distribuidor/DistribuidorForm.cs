using CommonComponents;

using DomainLayer.Models.CommonModels.Address;
using DomainLayer.Models.Distribuidor;
using DomainLayer.Models.Validations;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Commons;
using InfrastructureLayer.DataAccess.Repositories.Specific.Distribuidor;
using InfrastructureLayer.Validations;

using MCatalogos.Views.FormViews.Bairros;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.BairroServices;
using ServiceLayer.Services.CidadeServices;
using ServiceLayer.Services.DistribuidorServices;
using ServiceLayer.Services.EstadosServices;
using ServiceLayer.Services.ValidationServices;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCatalogos.Views.FormViews.Distribuidor
{
    public partial class DistribuidorForm : Form
    {
        #region PROPRIEDADES PARA MOVER A JANELA

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        #endregion
        private QueryStringServices _queryString;
        private DistribuidorServices _distribuidorServices;
        private EstadoServices _estadoServices;
        private CidadeServices _cidadeServices;
        private BairroServices _bairroServices;
        private ValidationCnpjServices _validationCnpjServices;

        DistribuidorModel DistribuidorModel = null;
        CnpjModel CnpjModel = null;
        public DistribuidorForm()
        {
            _validationCnpjServices = new ValidationCnpjServices(new CnpjRepository());
            _queryString = new QueryStringServices(new QueryString());
            _distribuidorServices = new DistribuidorServices(new DistribuidorRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _estadoServices = new EstadoServices(new EstadoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _cidadeServices = new CidadeServices(new CidadeRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _bairroServices = new BairroServices(new BairroRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());

            InitializeComponent();
            this.DistribuidorModel = _distribuidorServices.GetModel();

        }

        private void DistribuidorForm_Load(object sender, EventArgs e)
        {
            LoadEstaodsToComboBox();
            FillFields();

        }


        private void LoadEstaodsToComboBox()
        {
            List<EstadoModel> modelList = (List<EstadoModel>)_estadoServices.GetAll();
            cbUf.DisplayMember = "Uf";
            cbUf.SelectedIndex = -1;
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

        private void LoadBairrosToComboBox()
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

        public void FillFields()
        {
            if (this.DistribuidorModel != null)
                if (this.DistribuidorModel.DistribuidorId != 0)
                {
                    DistribuidorModel model = this.DistribuidorModel as DistribuidorModel;
                    EstadoModel estadoModel = _estadoServices.GetById(this.DistribuidorModel.UfId);
                    CidadeModel cidadeModel = _cidadeServices.GetById(this.DistribuidorModel.CidadeId);
                    BairroModel bairroModel = _bairroServices.GetById(this.DistribuidorModel.BairroId);
                    this.CnpjModel = new CnpjModel { Cnpj = model.Cnpj };


                    this.textNomeFantasia.Text = model.NomeFantasia;
                    this.textRazaoSocial.Text = model.RazaoSocial;
                    this.textResponsavel.Text = model.NomeResponsavel;
                    this.textEmail.Text = model.Email;
                    this.textSite.Text = model.WebSite;
                    this.mTextTelefone.Text = model.TelefoneContato;
                    this.mTextCnpj.Text = model.Cnpj;
                    this.mTextInscricaoEstadual.Text = model.InscricaoEstadual;
                    this.textLogradouro.Text = model.Logradouro;
                    this.textNumero.Text = model.Numero;
                    this.textComplemento.Text = model.Complemento;
                    this.mTextCep.Text = model.Cep;
                    this.cbUf.SelectedItem = estadoModel;
                    this.cbUf.Text = estadoModel.Uf;
                    this.cbCidade.SelectedItem = cidadeModel;
                    this.cbCidade.Text = cidadeModel.Nome;
                    this.cbBairro.SelectedItem = bairroModel;
                    this.cbBairro.Text = bairroModel.Nome;

                }
        }


        private DistribuidorModel DistribuidorAdd()
        {
            DistribuidorModel returnedModel = new DistribuidorModel();


            DistribuidorModel model = new DistribuidorModel()
            {
                BairroId = _bairroServices.GetByNomeAndCidadeId(cbBairro.Text,
                           _cidadeServices.GetByNomeAndEstadoId(cbCidade.Text,
                           _estadoServices.GetByUf(cbUf.Text).EstadoId).CidadeId).BairroId,
                CidadeId = _cidadeServices.GetByNomeAndEstadoId(cbCidade.Text,
                           _estadoServices.GetByUf(cbUf.Text).EstadoId).CidadeId,
                UfId = _estadoServices.GetByUf(cbUf.Text).EstadoId,

                NomeFantasia = textNomeFantasia.Text,
                Cnpj = ReplaceString(mTextCnpj.Text),
                RazaoSocial = textRazaoSocial.Text,
                InscricaoEstadual = ReplaceString(mTextInscricaoEstadual.Text),
                NomeResponsavel = textResponsavel.Text,
                Email = textEmail.Text,
                WebSite = textSite.Text,
                TelefoneContato = ReplaceString(mTextTelefone.Text),
                Logradouro = textLogradouro.Text,
                Numero = textNumero.Text,
                Complemento = textComplemento.Text,
                Cep = ReplaceString(mTextCep.Text),


            };

            bool operationSucceeded = false;
            string dataAcessStatussJsonStr = string.Empty;
            string formattedJsonStr = string.Empty;

            try
            {
                returnedModel = _distribuidorServices.Add(model);
                operationSucceeded = true;
            }
            catch (DataAccessException e)
            {
                operationSucceeded = e.DataAccessStatusInfo.OperationSucceeded;
                dataAcessStatussJsonStr = JsonConvert.SerializeObject(e.DataAccessStatusInfo);
                formattedJsonStr = JToken.Parse(dataAcessStatussJsonStr).ToString();
                MessageBox.Show(formattedJsonStr, "Não foi possível adicioanr Distribuidor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (operationSucceeded)
            {
                MessageBox.Show("Registro Salvo com sucesso", "Salvando Dados do Distribuidor", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            return returnedModel;

        }

        private void DistribuidorUpdate()
        {
            DistribuidorModel model = new DistribuidorModel()
            {
                BairroId = _bairroServices.GetByNomeAndCidadeId(cbBairro.Text,
                           _cidadeServices.GetByNomeAndEstadoId(cbCidade.Text,
                           _estadoServices.GetByUf(cbUf.Text).EstadoId).CidadeId).BairroId,
                CidadeId = _cidadeServices.GetByNomeAndEstadoId(cbCidade.Text,
                           _estadoServices.GetByUf(cbUf.Text).EstadoId).CidadeId,
                UfId = _estadoServices.GetByUf(cbUf.Text).EstadoId,

                NomeFantasia = textNomeFantasia.Text,
                Cnpj = ReplaceString(mTextCnpj.Text),
                RazaoSocial = textRazaoSocial.Text,
                InscricaoEstadual = ReplaceString(mTextInscricaoEstadual.Text),
                NomeResponsavel = textResponsavel.Text,
                Email = textEmail.Text,
                WebSite = textSite.Text,
                TelefoneContato = ReplaceString(mTextTelefone.Text),
                Logradouro = textLogradouro.Text,
                Numero = textNumero.Text,
                Complemento = textComplemento.Text,
                Cep = ReplaceString(mTextCep.Text),
                DistribuidorId = this.DistribuidorModel.DistribuidorId


            };

            bool operationSucceeded = false;
            string dataAccessStatusJsonStr = string.Empty;
            string formattedJsonStr = string.Empty;

            try
            {
                _distribuidorServices.Update(model);
                operationSucceeded = true;
            }
            catch (DataAccessException e)
            {
                operationSucceeded = e.DataAccessStatusInfo.OperationSucceeded;
                dataAccessStatusJsonStr = JsonConvert.SerializeObject(e.DataAccessStatusInfo);
                formattedJsonStr = JToken.Parse(dataAccessStatusJsonStr).ToString();
                MessageBox.Show(formattedJsonStr, "Não foi possível atualizar os dados do Distribuidor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (operationSucceeded)
            {
                MessageBox.Show("Registro atualizado com sucesso!", "Alterando dados do Distribuidor", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private string ReplaceString(string text)
        {
            text = text.Replace(".", "");
            text = text.Replace("-", "");
            text = text.Replace(",", "");
            text = text.Replace("/", "");
            text = text.Replace("(", "");
            text = text.Replace(")", "");
            text = text.Replace(" ", "");
            text = text.Trim();
            return text;
        }

        private void SetBGColorFocused(Control control)
        {

            control.BackColor = SystemColors.GradientActiveCaption;
        }

        private void SetBgColorUnfocused(Control control)
        {
            control.BackColor = SystemColors.Window;
        }


        #region EVENTS ENTER CONTROLS
        private void textNomeFantasia_Enter(object sender, EventArgs e)
        {
            SetBGColorFocused(textNomeFantasia);
        }

        private void textRazaoSocial_Enter(object sender, EventArgs e)
        {
            SetBGColorFocused(textRazaoSocial);
        }

        private void textResponsavel_Enter(object sender, EventArgs e)
        {
            SetBGColorFocused(textResponsavel);
        }

        private void textEmail_Enter(object sender, EventArgs e)
        {
            SetBGColorFocused(textEmail);
        }

        private void textSite_Enter(object sender, EventArgs e)
        {
            SetBGColorFocused(textSite);
        }

        private void mTextTelefone_Enter(object sender, EventArgs e)
        {
            SetBGColorFocused(mTextTelefone);
            if (mTextTelefone.Text == "(99) 9 9999-9999")
            {
                mTextTelefone.Text = string.Empty;
            }

        }

        private void mTextCnpj_Enter(object sender, EventArgs e)
        {
            SetBGColorFocused(mTextCnpj);
        }

        private void mTextInscricaoEstadual_Enter(object sender, EventArgs e)
        {
            SetBGColorFocused(mTextInscricaoEstadual);
        }

        private void textLogradouro_Enter(object sender, EventArgs e)
        {
            SetBGColorFocused(textLogradouro);
        }

        private void textNumero_Enter(object sender, EventArgs e)
        {
            SetBGColorFocused(textNumero);
        }

        private void textComplemento_Enter(object sender, EventArgs e)
        {
            SetBGColorFocused(textComplemento);
        }

        private void mTextCep_Enter(object sender, EventArgs e)
        {
            SetBGColorFocused(mTextCep);
        }

        private void cbUf_Enter(object sender, EventArgs e)
        {
            SetBGColorFocused(cbUf);
        }

        private void cbCidade_Enter(object sender, EventArgs e)
        {
            SetBGColorFocused(cbCidade);
        }

        private void cbBairro_Enter(object sender, EventArgs e)
        {
            SetBGColorFocused(cbBairro);
        }

        #endregion


        private bool ValidaCampo(Control control)
        {
            bool eventArgs = false;
            if (string.IsNullOrEmpty(control.Text))
            {
                eventArgs = true;
                control.BackColor = Color.Red;
                formError.SetError(control, "Campo obrigatório!");
            }
            else if (control.GetType() == typeof(MaskedTextBox))
            {
                if (string.IsNullOrEmpty(ReplaceString(control.Text)))
                {
                    eventArgs = true;
                    control.BackColor = Color.Red;
                    formError.SetError(control, "Campo Obrigatório!");
                }
                else if (control.Name == "mTextCnpj")
                {
                    if (!_validationCnpjServices.ValidaCnpj(this.CnpjModel))
                    {
                        eventArgs = true;
                        control.BackColor = Color.Red;
                        formError.SetError(control, "CNPJ Inválido!");
                    }
                    else
                    {
                        eventArgs = false;
                        formError.SetError(control, null);
                    }
                }
                else
                {
                    eventArgs = false;
                    formError.SetError(control, null);
                }

            }
            else
            {
                eventArgs = false;
                formError.SetError(control, null);
            }
            return eventArgs;
        }

        #region EVENTS LEAVE CONTROLS
        private void textNomeFantasia_Leave(object sender, EventArgs e)
        {
            SetBgColorUnfocused(textNomeFantasia);
            ValidaCampo(textNomeFantasia);

        }

        private void textRazaoSocial_Leave(object sender, EventArgs e)
        {
            SetBgColorUnfocused(textRazaoSocial);
            ValidaCampo(textRazaoSocial);
        }

        private void textResponsavel_Leave(object sender, EventArgs e)
        {
            SetBgColorUnfocused(textResponsavel);
            ValidaCampo(textResponsavel);
        }

        private void mTextCnpj_Leave(object sender, EventArgs e)
        {
            SetBgColorUnfocused(mTextCnpj);
            this.CnpjModel = new CnpjModel() { Cnpj = mTextCnpj.Text };
            ValidaCampo(mTextCnpj);

        }

        private void mTextInscricaoEstadual_Leave(object sender, EventArgs e)
        {
            SetBgColorUnfocused(mTextInscricaoEstadual);
            //ValidaCampo(mTextInscricaoEstadual);
        }

        private void textEmail_Leave(object sender, EventArgs e)
        {
            SetBgColorUnfocused(textEmail);
        }

        private void textSite_Leave(object sender, EventArgs e)
        {
            SetBgColorUnfocused(textSite);
        }

        private void mTextTelefone_Leave(object sender, EventArgs e)
        {
            SetBgColorUnfocused(mTextTelefone);
            SetMaskTelefone();
            ValidaCampo(mTextTelefone);
        }

        private void SetMaskTelefone()
        {
            string telefone = ReplaceString(mTextTelefone.Text);
            if (telefone.Length == 11 || telefone == string.Empty)
            {
                mTextTelefone.Mask = "(00) 0 0000-0000";
            }
            else if (telefone.Length == 10)
            {

                mTextTelefone.Mask = "(00) 0000-0000";
            }
        }

        private void textLogradouro_Leave(object sender, EventArgs e)
        {
            SetBgColorUnfocused(textLogradouro);
            ValidaCampo(textLogradouro);
        }

        private void textNumero_Leave(object sender, EventArgs e)
        {
            SetBgColorUnfocused(textNumero);
            ValidaCampo(textNumero);
        }

        private void textComplemento_Leave(object sender, EventArgs e)
        {
            SetBgColorUnfocused(textComplemento);
        }

        private void mTextCep_Leave(object sender, EventArgs e)
        {
            SetBgColorUnfocused(mTextCep);
        }

        private void cbUf_Leave(object sender, EventArgs e)
        {
            SetBgColorUnfocused(cbUf);
            ValidaCampo(cbUf);
        }

        private void cbCidade_Leave(object sender, EventArgs e)
        {
            SetBgColorUnfocused(cbCidade);
            ValidaCampo(cbCidade);
        }

        private void cbBairro_Leave(object sender, EventArgs e)
        {
            SetBgColorUnfocused(cbBairro);
            ValidaCampo(cbBairro);
        }

        #endregion

        private void pictureClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbUf_SelectedIndexChanged(object sender, EventArgs e)
        {
            EstadoModel uf = cbUf.SelectedItem as EstadoModel;
            if (cbUf.SelectedIndex > -1)
            {
                SetMaskInscricaoEstadual(uf.Uf);
                LoadCidadesToComboBox(uf.Uf);
            }
        }

        private void cbCidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            CidadeModel cidade = cbCidade.SelectedItem as CidadeModel;
            LoadBairrosToComboBox();
            if (cbCidade.Text != string.Empty)
            {
                btnAddBairro.Enabled = true;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                if (this.DistribuidorModel.DistribuidorId != 0)
                {
                    DistribuidorUpdate();
                }
                else
                {
                    this.DistribuidorModel = DistribuidorAdd();
                }
            }
        }


        #region EVENTS VALIDATING CONTROLS
        private void textNomeFantasia_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ValidaCampo(textNomeFantasia);
        }

        private void textRazaoSocial_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ValidaCampo(textRazaoSocial);
        }

        private void textResponsavel_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ValidaCampo(textResponsavel);
        }

        private void mTextCnpj_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ValidaCampo(mTextCnpj);
        }

        private void mTextTelefone_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ValidaCampo(mTextTelefone);
        }

        private void textLogradouro_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ValidaCampo(textLogradouro);
        }

        private void textNumero_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ValidaCampo(textNumero);
        }

        private void cbUf_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ValidaCampo(cbUf);
        }

        private void cbCidade_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ValidaCampo(cbCidade);
        }

        private void cbBairro_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ValidaCampo(cbBairro);
        }
        #endregion

        private void DistribuidorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Disposing)
            {
                if (components != null)
                    components.Dispose();
            }
            this.DistribuidorModel = null;
            base.Dispose(Disposing);

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
            cidadeModel = _cidadeServices.GetByNomeAndEstadoId(cbCidade.Text, estadoModel.EstadoId);

            try
            {
                if (cbCidade.Text != string.Empty)
                {
                    BairroAddForm bairroAddForm = new BairroAddForm(cidadeModel, bairroModel);
                    bairroAddForm.Text = "Adicionando Novo Bairro";
                    bairroAddForm.StartPosition = FormStartPosition.CenterScreen;
                    bairroAddForm.ShowDialog();
                    LoadBairrosToComboBox();
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
                MessageBox.Show("Não foi possível adicioanr um novo bairro à cidade");
            }
        }

        private void mTextTelefone_MouseClick(object sender, MouseEventArgs e)
        {
            string textoTelefone = mTextTelefone.Text.Replace("/", "");
            textoTelefone = textoTelefone.Replace("_", "");
            textoTelefone = textoTelefone.Replace("(", "");
            textoTelefone = textoTelefone.Replace(")", "");
            textoTelefone = textoTelefone.Replace(".", "");
            textoTelefone = textoTelefone.Replace("-", "");

            if (string.IsNullOrEmpty(textoTelefone.Trim()))
            {

                mTextTelefone.SelectionStart = 0;
            }

        }

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
