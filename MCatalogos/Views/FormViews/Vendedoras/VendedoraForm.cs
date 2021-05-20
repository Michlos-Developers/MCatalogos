using CommonComponents;

using DomainLayer.Models.CommonModels.Address;
using DomainLayer.Models.Validations;
using DomainLayer.Models.Vendedora;

using InfrastructureLayer.DataAccess.Repositories.Commons;
using InfrastructureLayer.DataAccess.Repositories.Specific.Vendedora;
using InfrastructureLayer.Validations;

using MCatalogos.Views.UserControls;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.BairroServices;
using ServiceLayer.Services.CidadeServices;
using ServiceLayer.Services.EstadoCivilServices;
using ServiceLayer.Services.EstadosServices;
using ServiceLayer.Services.RotaServices;
using ServiceLayer.Services.ValidationServices;
using ServiceLayer.Services.VendedoraServices;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Security.AccessControl;
using System.Windows.Forms;

namespace MCatalogos.Views.FormViews.Vendedoras
{
    public partial class VendedoraForm : Form
    {
        VendedorasListForm VendedorasListForm;

        private VendedoraServices _vendedoraServices;
        private EstadoCivilServices _estadoCivilServices;
        private BairroServices _bairroServices;
        private CidadeServices _cidadeServices;
        private EstadoServices _estadoServices;
        private RotaLetraServices _rotaLetraServices;
        private RotaServices _rotaServices;
        private ValidationCpfServices _validationCpfServices;

        private static string _connectionString = @"SERVER=.\SQLEXPRESS;DATABASE=MCatalogoDB;INTEGRATED SECURITY=SSPI";

        public VendedoraForm(VendedorasListForm vendedorasListForm)
        {
            _rotaLetraServices = new RotaLetraServices(new RotaLetraRepository(_connectionString), new ModelDataAnnotationCheck());
            _rotaServices = new RotaServices(new RotaRepository(_connectionString), new ModelDataAnnotationCheck());
            _estadoServices = new EstadoServices(new EstadoRepository(_connectionString), new ModelDataAnnotationCheck());
            _cidadeServices = new CidadeServices(new CidadeRepository(_connectionString), new ModelDataAnnotationCheck());
            _bairroServices = new BairroServices(new BairroRepository(_connectionString), new ModelDataAnnotationCheck());
            _estadoCivilServices = new EstadoCivilServices(new EstadoCivilRepository(_connectionString), new ModelDataAnnotationCheck());
            _vendedoraServices = new VendedoraServices(new VendedoraRepository(_connectionString), new ModelDataAnnotationCheck());
            _validationCpfServices = new ValidationCpfServices(new CpfRepository());
            InitializeComponent();
            this.VendedorasListForm = vendedorasListForm;

        }


        //REPOSITORIES CALLERS
        private void VendedoraUpdate()
        {
            var cpf = maskedTextCpf.Text;
            cpf = cpf.Replace(".", "");
            cpf = cpf.Replace(".", "");
            cpf = cpf.Replace("-", "");

            var cep = maskedTextCep.Text;
            cep = cep.Replace("-", "");
            int estadoId = _estadoServices.GetByUf(comboBoxUfEndereco.Text).EstadoId;

            int cidadeId = _cidadeServices.GetByNomeAndEstadoId(comboBoxCidade.Text,
                           _estadoServices.GetByUf(comboBoxUfEndereco.Text).EstadoId).CidadeId;

            int bairroId = _bairroServices.GetByNomeAndCidadeId(comboBoxBairro.Text,
                           _cidadeServices.GetByNomeAndEstadoId(comboBoxCidade.Text,
                           _estadoServices.GetByUf(comboBoxUfEndereco.Text).EstadoId).CidadeId).BairroId;

            VendedoraModel vendedoraModel = new VendedoraModel()
            {
                VendedoraId = int.Parse(textVendedoraId.Text),
                Nome = textNome.Text,
                Cpf = cpf,
                Rg = textRg.Text,
                RgEmissor = textEmissorRg.Text,
                DataNascimento = DateTime.Parse(datePickerNascimento.Text),
                Email = textEmail.Text,
                NomePai = textNomePai.Text,
                NomeMae = textNomeMae.Text,
                NomeConjuge = textConjuge.Text,
                Logradouro = textLogradouro.Text,
                Numero = textNumero.Text,
                Complemento = textComplemento.Text,
                Cep = cep,
                EstadoCivilId = _estadoCivilServices.GetByEstadoCivil(comboBoxEstadoCivil.Text).EstadoCivilId,
                UfRgId = _estadoServices.GetByUf(comboBoxUfRg.Text).EstadoId,
                EstadoId = estadoId,
                CidadeId = cidadeId,
                BairroId = bairroId,
                RotaLetraId = _rotaLetraServices.GetByLetra(comboBoxRotaLetra.Text).RotaLetraId

            };

            bool operationSucceeded = false;
            string dataAccessStatusJsonStr = string.Empty;
            string formattedJsonStr = string.Empty;

            try
            {
                _vendedoraServices.Update(vendedoraModel);
                operationSucceeded = true;

            }
            catch (DataAccessException e)
            {
                operationSucceeded = e.DataAccessStatusInfo.OperationSucceeded;
                dataAccessStatusJsonStr = JsonConvert.SerializeObject(e.DataAccessStatusInfo);
                formattedJsonStr = JToken.Parse(dataAccessStatusJsonStr).ToString();
                MessageBox.Show(formattedJsonStr, "Erro ao tentar atualizar os dados da vendedora", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                if (operationSucceeded)
                {
                    MessageBox.Show("Registro atualizado com sucesso", "Salvar dados de Vendedora", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            finally
            {
                //TODO: LER DADOS DA VENDEDORA
            }
        }
        public VendedoraModel VendedoraAdd()
        {

            VendedoraModel returnModel = new VendedoraModel();
            var cpf = ReplaceCpf(maskedTextCpf.Text);
            var cep = ReplaceCep(maskedTextCep.Text);


            int estadoId = _estadoServices.GetByUf(comboBoxUfEndereco.Text).EstadoId;

            int cidadeId = _cidadeServices.GetByNomeAndEstadoId(comboBoxCidade.Text,
                           _estadoServices.GetByUf(comboBoxUfEndereco.Text).EstadoId).CidadeId;

            int bairroId = _bairroServices.GetByNomeAndCidadeId(comboBoxBairro.Text,
                           _cidadeServices.GetByNomeAndEstadoId(comboBoxCidade.Text,
                           _estadoServices.GetByUf(comboBoxUfEndereco.Text).EstadoId).CidadeId).BairroId;

            VendedoraModel vendedoraModel = new VendedoraModel()
            {
                Nome = textNome.Text,
                Cpf = cpf,
                Rg = textRg.Text,
                RgEmissor = textEmissorRg.Text,
                DataNascimento = DateTime.Parse(datePickerNascimento.Text),
                Email = textEmail.Text,
                NomePai = textNomePai.Text,
                NomeMae = textNomeMae.Text,
                NomeConjuge = textConjuge.Text,
                Logradouro = textLogradouro.Text,
                Numero = textNumero.Text,
                Complemento = textComplemento.Text,
                Cep = cep,
                EstadoCivilId = _estadoCivilServices.GetByEstadoCivil(comboBoxEstadoCivil.Text).EstadoCivilId,
                UfRgId = _estadoServices.GetByUf(comboBoxUfRg.Text).EstadoId,
                EstadoId = estadoId,
                CidadeId = cidadeId,
                BairroId = bairroId,
                RotaLetraId = _rotaLetraServices.GetByLetra(comboBoxRotaLetra.Text).RotaLetraId

            };

            bool operationSucceeded = false;
            string dataAccessStatusJsonStr = string.Empty;
            string formattedJsonStr = string.Empty;

            try
            {
                returnModel = _vendedoraServices.Add(vendedoraModel);
                operationSucceeded = true;

            }
            catch (DataAccessException e)
            {
                operationSucceeded = e.DataAccessStatusInfo.OperationSucceeded;
                dataAccessStatusJsonStr = JsonConvert.SerializeObject(e.DataAccessStatusInfo);
                formattedJsonStr = JToken.Parse(dataAccessStatusJsonStr).ToString();
                MessageBox.Show(formattedJsonStr, "Erro ao tentar adicionar a vendedora", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (operationSucceeded)
            {
                MessageBox.Show("Registro adicionado com sucesso", "Adicionar Vendedora", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return returnModel;

        }
        private void AddRotaLetra(string nextLetra)
        {
            RotaLetraModel model = new RotaLetraModel();
            try
            {
                model.RotaLetra = nextLetra;
                _rotaLetraServices.Add(model);
            }
            catch (DataAccessException e)
            {
                MessageBox.Show("Falha ao tentar adicionar uma nova letra na rota", e.Message);
            }
        }
        private void AddNumeroRota(int rotaLetraId, string vendedoraIdStr)
        {
            int vendedoraId = int.Parse(vendedoraIdStr);
            int lastNumero = _rotaServices.GetLastNumero(rotaLetraId).Numero;
            int nextNumero = lastNumero + 1;
            DialogResult result = DialogResult.Yes;

            if (ChecaRotaVendedora(vendedoraId))
            {
                result = MessageBox.Show("Essa já vendedora já possui uma rota cadastrada.\nCaso continue as rotas serão reindexadas.\nDeseja continuar?",
                    "Reindexação de Rotas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            }
            if (result == DialogResult.Yes)
            {
                RotaModel model = new RotaModel()
                {
                    RotaLetraId = rotaLetraId,
                    VendedoraId = vendedoraId,
                    Numero = nextNumero
                };

                try
                {
                    _rotaServices.Add(model);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Falha ao adicionar novo número de Rota para a Vendedora.", e.Message);
                    throw e;
                }
                MessageBox.Show($"Rota adicionada com sucesso: \nNúmero:{nextNumero}");
                //TODO: REINDEXAR ROTAS
            }
        }


        //GETTINGNS AND SETTINGS VALUES
        private void PreencheCampos()
        {
            if (textVendedoraId.Text != "")
            {
                VendedoraModel vm = null;
                try
                {
                    vm = _vendedoraServices.GetById(int.Parse(textVendedoraId.Text));
                }
                catch (DataAccessException e)
                {
                    MessageBox.Show($"Falha ao tentar recuperar dados da vendedora\n ErrorMessage: {e.DataAccessStatusInfo.getFormattedValues()}", "Error");
                }

                if (vm != null)
                {

                    EstadoModel em = null;
                    EstadoCivilModel ecm = null;
                    CidadeModel cm = null;
                    BairroModel bm = null;
                    RotaLetraModel rlm = null;
                    RotaModel rm = null;

                    textNome.Text = vm.Nome.ToString();
                    maskedTextCpf.Text = vm.Cpf;
                    textRg.Text = vm.Rg;
                    textEmissorRg.Text = vm.RgEmissor;
                    datePickerNascimento.Text = vm.DataNascimento.ToString();
                    textEmail.Text = vm.Email;
                    textNomePai.Text = vm.NomePai;
                    textNomeMae.Text = vm.NomeMae;
                    textConjuge.Text = vm.NomeConjuge;
                    textLogradouro.Text = vm.Logradouro;
                    textNumero.Text = vm.Numero;
                    textComplemento.Text = vm.Complemento;
                    maskedTextCep.Text = vm.Cep;
                    comboBoxUfRg.Text = (em = _estadoServices.GetById(vm.UfRgId)).Uf;
                    comboBoxEstadoCivil.Text = (ecm = _estadoCivilServices.GetById(vm.EstadoCivilId)).EstadoCivil;
                    comboBoxUfEndereco.Text = (em = _estadoServices.GetById(vm.EstadoId)).Uf;
                    comboBoxCidade.Text = (cm = _cidadeServices.GetById(vm.CidadeId)).Nome;
                    comboBoxBairro.Text = (bm = _bairroServices.GetById(vm.BairroId)).Nome;
                    comboBoxRotaLetra.Text = (rlm = _rotaLetraServices.GetById(vm.RotaLetraId)).RotaLetra.ToString();
                    comboBoxRotaNumero.Text = (rm = _rotaServices.GetByVendedoraId(vm.VendedoraId)).Numero.ToString();
                }

            }

        }
        private string ReplaceCpf(string cpf)
        {

            cpf = cpf.Replace(".", "");
            cpf = cpf.Replace("-", "");
            cpf = cpf.Replace(" ", "");

            return cpf;
        }
        private string ReplaceCep(string cep)
        {
            cep = cep.Replace("-", "");
            return cep;
        }
        private string GetNextLetra(string lastLetra)
        {
            string alfabeto = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int pos = alfabeto.IndexOf(lastLetra);
            string nextLetra = string.Empty;
            pos++;
            nextLetra = alfabeto[pos].ToString();
            return nextLetra;
        }
        private bool ChecaRotaVendedora(int vendedoraId)
        {
            bool result = false;
            int rotaId = 0;
            rotaId = _rotaServices.GetByVendedoraId(vendedoraId).RotaLetraId;
            if (rotaId != 0)
            {
                result = true;
            }
            return result;

        }
        private void LoadRotasLetrasToComboBox()
        {
            List<RotaLetraModel> rotaLetraModelList = (List<RotaLetraModel>)_rotaLetraServices.GetAll();

            comboBoxRotaLetra.DisplayMember = "RotaLetra";
            comboBoxRotaLetra.SelectedIndex = -1;
            comboBoxRotaLetra.Items.Clear();
            foreach (RotaLetraModel model in rotaLetraModelList)
            {
                comboBoxRotaLetra.Items.Add(model);
            }
        }
        private void LoadRotaNumeroToComboBox(int id)
        {
            List<RotaModel> modelList = (List<RotaModel>)_rotaServices.GetAllByLetraId(id);

            comboBoxRotaNumero.DisplayMember = "Numero";
            comboBoxRotaNumero.Items.Clear();
            foreach (RotaModel model in modelList)
            {
                comboBoxRotaNumero.Items.Add(model);
            }
        }
        private void LoadEstadosToComboBox()
        {
            List<EstadoModel> estadoModelList = (List<EstadoModel>)_estadoServices.GetAll();

            comboBoxUfEndereco.DisplayMember = "Uf";
            comboBoxUfEndereco.SelectedIndex = 0;
            comboBoxUfEndereco.Items.Clear();
            foreach (EstadoModel em in estadoModelList)
            {
                comboBoxUfEndereco.Items.Add(em);
            }

        }
        private void LoadBairrosToComboBox(int cidade)
        {

            List<BairroModel> bairroModelList = (List<BairroModel>)_bairroServices.GetByCidadeId(cidade);

            comboBoxBairro.DisplayMember = "Nome";
            comboBoxBairro.Items.Clear();
            foreach (BairroModel bm in bairroModelList)
            {
                comboBoxBairro.Items.Add(bm);
            }


        }
        private void LoadCidadeToComboBox(string uf)
        {
            List<CidadeModel> cidadeModelList = (List<CidadeModel>)_cidadeServices.GetAllByUf(uf);

            comboBoxCidade.DisplayMember = "Nome";
            comboBoxCidade.Items.Clear();
            foreach (var item in cidadeModelList)
            {
                comboBoxCidade.Items.Add(item);
            }


        }
        private void LoadUfRgToComboBox()
        {
            List<EstadoModel> estadoModelList = (List<EstadoModel>)_estadoServices.GetAll();

            comboBoxUfRg.DisplayMember = "Uf";
            comboBoxUfRg.DataSource = estadoModelList;
            comboBoxUfRg.SelectedIndex = -1;

        }
        private void LoadEstadoCivilToComboBox()
        {
            List<EstadoCivilModel> estadoCivilModelList = (List<EstadoCivilModel>)_estadoCivilServices.GetAll();

            comboBoxEstadoCivil.DisplayMember = "EstadoCivil";
            comboBoxEstadoCivil.DataSource = estadoCivilModelList;
            comboBoxEstadoCivil.SelectedIndex = -1;


        }


        //EVENTS FORM
        private void VendedoraForm_Load(object sender, EventArgs e)
        {
            LoadRotasLetrasToComboBox();
            LoadEstadosToComboBox();
            LoadUfRgToComboBox();
            LoadEstadoCivilToComboBox();
            PreencheCampos();

            TelefonesVendedoraListUC telefones = new TelefonesVendedoraListUC(this);
            panelTelefonesList.Controls.Clear();
            panelTelefonesList.Controls.Add(telefones);
            telefones.Dock = DockStyle.Fill;

            maskedTextCpf.Focus();
            if (textVendedoraId.Text == "")
            {
                btnAddNumeroRota.Enabled = false;
                comboBoxRotaNumero.Enabled = false;
            }
            else
            {
                btnAddNumeroRota.Enabled = true;
                comboBoxRotaNumero.Enabled = true;
            }

        }
        private void comboBoxRotaLetra_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxRotaLetra.SelectedIndex > -1)
            {

                LoadRotaNumeroToComboBox(_rotaLetraServices.GetByLetra(comboBoxRotaLetra.Text).RotaLetraId);
            }
        }
        private void comboBoxUfEndereco_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxUfEndereco.SelectedIndex > 0)
            {

                string uf = comboBoxUfEndereco.Text;
                LoadCidadeToComboBox(uf);
            }

        }
        private void comboBoxCidade_SelectedIndexChanged(object sender, EventArgs e)
        {

            string cidade = comboBoxCidade.Text;
            int estadoId = _estadoServices.GetByUf(comboBoxUfEndereco.Text).EstadoId;
            int cidadeId = _cidadeServices.GetByNomeAndEstadoId(cidade, estadoId).CidadeId;
            LoadBairrosToComboBox(cidadeId);
        }
        private void comboBoxRotaNumero_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TODO: Fazer a reindexação das rotas
        }
        private void btnAddRotaLetra_Click(object sender, EventArgs e)
        {
            string lastLetra = _rotaLetraServices.GetLastLetra().RotaLetra;
            string nextLetra = GetNextLetra(lastLetra);
            if (lastLetra == "Z")
            {
                MessageBox.Show("Já foram adicionadas todas as letras para Rota.\nEntre em contato com o Administrador.");
            }
            else
            {
                try
                {
                    AddRotaLetra(nextLetra);

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Erro ao tentar adicionar uma nova letra à lista de Rotas", ex.Message);
                }
                MessageBox.Show($"Letra {nextLetra} adicionada com suceddo.", "Adicionado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRotasLetrasToComboBox();
            }


        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                VendedoraModel model = new VendedoraModel();
                if (textVendedoraId.Text == "")
                {

                    model = VendedoraAdd();
                    this.textVendedoraId.Text = model.VendedoraId.ToString();
                }
                else
                {
                    VendedoraUpdate();
                }
                VendedorasListForm.VendedorasListForm_Load(sender, e);
                this.VendedoraForm_Load(sender, e);
            }



        }
        private void btnAddNumeroRota_Click(object sender, EventArgs e)
        {
            int rotaLetraId = _rotaLetraServices.GetByLetra(comboBoxRotaLetra.Text).RotaLetraId;
            AddNumeroRota(rotaLetraId, textVendedoraId.Text);
            comboBoxRotaNumero.Text = _rotaServices.GetByVendedoraId(int.Parse(textVendedoraId.Text)).Numero.ToString();
            VendedoraUpdate();
            VendedoraForm_Load(sender, e);
        }


        
        
        //VALIDATIONS
        private bool ValidaCampo(Control control)
        {
            bool eventArgs = false;
            if (string.IsNullOrEmpty(control.Text))
            {

                eventArgs = true;
                control.Focus();
                errorProvider.SetError(control, "Campo Obrigatório!");

            }
            else
            {
                eventArgs = false;
                errorProvider.SetError(control, null);
            }

            return eventArgs;
        }
        private void maskedTextCpf_Validating(object sender, CancelEventArgs e)
        {
            CpfModel model = new CpfModel() { Cpf = maskedTextCpf.Text };
            string cpfReplaced = ReplaceCpf(maskedTextCpf.Text);
            //cpfReplaced = cpfReplaced.Replace(" ", "");
            if (string.IsNullOrEmpty(cpfReplaced))
            {
                e.Cancel = true;
                maskedTextCpf.Focus();
                errorProvider.SetError(maskedTextCpf, "Campo obrigatório!");
            }
            else if (!_validationCpfServices.ValidaCpf(model))
            {
                e.Cancel = true;
                maskedTextCpf.Focus();
                errorProvider.SetError(maskedTextCpf, "CPF Inválido!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(maskedTextCpf, null);
            }
        }
        private void comboBoxRotaLetra_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ValidaCampo(comboBoxRotaLetra);
        }
        private void textNome_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ValidaCampo(textNome);
        }
        private void textRg_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ValidaCampo(textRg);
        }
        private void textEmissorRg_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ValidaCampo(textEmissorRg);
        }
        private void comboBoxUfRg_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ValidaCampo(comboBoxUfRg);
        }
        private void comboBoxEstadoCivil_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ValidaCampo(comboBoxEstadoCivil);
        }
        private void textConjuge_Validating(object sender, CancelEventArgs e)
        {
            if (comboBoxEstadoCivil.Text == "Casado")
            {
                e.Cancel = ValidaCampo(textConjuge);
            }
        }
        private void textLogradouro_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ValidaCampo(textLogradouro);
        }
        private void textNumero_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ValidaCampo(textNumero);
        }
        private void comboBoxUfEndereco_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ValidaCampo(comboBoxUfEndereco);
        }
        private void comboBoxCidade_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ValidaCampo(comboBoxCidade);
        }
        private void comboBoxBairro_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ValidaCampo(comboBoxBairro);
        }




        //FOCUSED
        private void maskedTextCpf_Enter(object sender, EventArgs e)
        {
            maskedTextCpf.BackColor = SystemColors.ActiveCaption;
        }
        private void maskedTextCpf_Leave(object sender, EventArgs e)
        {
            maskedTextCpf.BackColor = SystemColors.Window;
        }
        private void comboBoxRotaLetra_Enter(object sender, EventArgs e)
        {
            comboBoxRotaLetra.BackColor = SystemColors.ActiveCaption;
        }
        private void comboBoxRotaLetra_Leave(object sender, EventArgs e)
        {
            comboBoxRotaLetra.BackColor = SystemColors.Window;
        }
        private void comboBoxRotaNumero_Enter(object sender, EventArgs e)
        {
            comboBoxRotaNumero.BackColor = SystemColors.ActiveCaption;
        }
        private void comboBoxRotaNumero_Leave(object sender, EventArgs e)
        {
            comboBoxRotaNumero.BackColor = SystemColors.Window;
        }
        private void textRg_Enter(object sender, EventArgs e)
        {
            textRg.BackColor = SystemColors.ActiveCaption;
        }
        private void textRg_Leave(object sender, EventArgs e)
        {
            textRg.BackColor = SystemColors.Window;
        }
        private void textEmissorRg_Enter(object sender, EventArgs e)
        {
            textEmissorRg.BackColor = SystemColors.ActiveCaption;
        }
        private void textEmissorRg_Leave(object sender, EventArgs e)
        {
            textEmissorRg.BackColor = SystemColors.Window;
        }
        private void comboBoxUfRg_Enter(object sender, EventArgs e)
        {
            comboBoxUfRg.BackColor = SystemColors.ActiveCaption;
        }
        private void comboBoxUfRg_Leave(object sender, EventArgs e)
        {
            comboBoxUfRg.BackColor = SystemColors.Window;
        }
        private void textEmail_Enter(object sender, EventArgs e)
        {
            textEmail.BackColor = SystemColors.ActiveCaption;
        }
        private void textEmail_Leave(object sender, EventArgs e)
        {
            textEmail.BackColor = SystemColors.Window;
        }
        private void textNomePai_Enter(object sender, EventArgs e)
        {
            textNomePai.BackColor = SystemColors.ActiveCaption;
        }
        private void textNomePai_Leave(object sender, EventArgs e)
        {
            textNomePai.BackColor = SystemColors.Window;
        }
        private void textNomeMae_Enter(object sender, EventArgs e)
        {
            textNomeMae.BackColor = SystemColors.ActiveCaption;
        }
        private void textNomeMae_Leave(object sender, EventArgs e)
        {
            textNomeMae.BackColor = SystemColors.Window;
        }
        private void comboBoxEstadoCivil_Enter(object sender, EventArgs e)
        {
            comboBoxEstadoCivil.BackColor = SystemColors.ActiveCaption;
        }
        private void comboBoxEstadoCivil_Leave(object sender, EventArgs e)
        {
            comboBoxEstadoCivil.BackColor = SystemColors.Window;
        }
        private void textConjuge_Enter(object sender, EventArgs e)
        {
            textConjuge.BackColor = SystemColors.ActiveCaption;
        }
        private void textConjuge_Leave(object sender, EventArgs e)
        {
            textConjuge.BackColor = SystemColors.Window;
        }
        private void textLogradouro_Enter(object sender, EventArgs e)
        {
            textLogradouro.BackColor = SystemColors.ActiveCaption;
        }
        private void textLogradouro_Leave(object sender, EventArgs e)
        {
            textLogradouro.BackColor = SystemColors.Window;
        }
        private void textNumero_Enter(object sender, EventArgs e)
        {
            textNumero.BackColor = SystemColors.ActiveCaption;
        }
        private void textNumero_Leave(object sender, EventArgs e)
        {
            textNumero.BackColor = SystemColors.Window;
        }
        private void maskedTextCep_Enter(object sender, EventArgs e)
        {
            maskedTextCep.BackColor = SystemColors.ActiveCaption;
        }
        private void maskedTextCep_Leave(object sender, EventArgs e)
        {
            maskedTextCep.BackColor = SystemColors.Window;
        }
        private void textComplemento_Enter(object sender, EventArgs e)
        {
            textComplemento.BackColor = SystemColors.ActiveCaption;
        }
        private void textComplemento_Leave(object sender, EventArgs e)
        {
            textComplemento.BackColor = SystemColors.Window;
        }
        private void comboBoxUfEndereco_Enter(object sender, EventArgs e)
        {
            comboBoxUfEndereco.BackColor = SystemColors.ActiveCaption;
            
        }
        private void comboBoxUfEndereco_Leave(object sender, EventArgs e)
        {
            comboBoxUfEndereco.BackColor = SystemColors.Window;
        }
        private void comboBoxCidade_Enter(object sender, EventArgs e)
        {
            comboBoxCidade.BackColor = SystemColors.ActiveCaption;
        }
        private void comboBoxCidade_Leave(object sender, EventArgs e)
        {
            comboBoxCidade.BackColor = SystemColors.Window;
        }
        private void comboBoxBairro_Enter(object sender, EventArgs e)
        {
            comboBoxBairro.BackColor = SystemColors.ActiveCaption;
        }
        private void comboBoxBairro_Leave(object sender, EventArgs e)
        {
            comboBoxBairro.BackColor = SystemColors.Window;
        }
        private void textNome_Enter(object sender, EventArgs e)
        {
            textNome.BackColor = SystemColors.ActiveCaption;
        }
        private void textNome_Leave(object sender, EventArgs e)
        {
            textNome.BackColor = SystemColors.Window;
        }
    }
}
