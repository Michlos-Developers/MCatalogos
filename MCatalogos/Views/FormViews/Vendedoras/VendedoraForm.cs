using CommonComponents;

using DomainLayer.Models.CommonModels.Address;
using DomainLayer.Models.Vendedora;

using InfrastructureLayer.DataAccess.Repositories.Commons;
using InfrastructureLayer.DataAccess.Repositories.Specific.Vendedora;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.BairroServices;
using ServiceLayer.Services.CidadeServices;
using ServiceLayer.Services.EstadoCivilServices;
using ServiceLayer.Services.EstadosServices;
using ServiceLayer.Services.RotaServices;
using ServiceLayer.Services.VendedoraServices;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MCatalogos.Views.FormViews.Vendedoras
{
    public partial class VendedoraForm : Form
    {
        private VendedoraServices _vendedoraServices;
        private EstadoCivilServices _estadoCivilServices;
        private BairroServices _bairroServices;
        private CidadeServices _cidadeServices;
        private EstadoServices _estadoServices;
        private RotaServices _rotaServices;
        VendedorasListForm VendedorasListForm;
        //private ConnectionStringServices _connectionStringServices;
        //private static string _connectionString;




        private static string _connectionString = @"SERVER=.\SQLEXPRESS;DATABASE=MCatalogoDB;INTEGRATED SECURITY=SSPI";

        //private string _connectionString = _connectionStringServices.GetConnection();
        private SqlConnection connection = new SqlConnection(_connectionString);


        public VendedoraForm(VendedorasListForm vendedorasListForm)
        {
            _estadoServices = new EstadoServices(new EstadoRepository(_connectionString), new ModelDataAnnotationCheck());
            _cidadeServices = new CidadeServices(new CidadeRepository(_connectionString), new ModelDataAnnotationCheck());
            _bairroServices = new BairroServices(new BairroRepository(_connectionString), new ModelDataAnnotationCheck());
            _estadoCivilServices = new EstadoCivilServices(new EstadoCivilRepository(_connectionString), new ModelDataAnnotationCheck());
            _rotaServices = new RotaServices(new RotaRepository(_connectionString), new ModelDataAnnotationCheck());
            _vendedoraServices = new VendedoraServices(new VendedoraRepository(_connectionString), new ModelDataAnnotationCheck());

            InitializeComponent();
            this.VendedorasListForm = vendedorasListForm;

        }

        private void VendedoraForm_Load(object sender, EventArgs e)
        {

            LoadEstadosToComboBox();
            LoadUfRgToComboBox();
            LoadEstadoCivilToComboBox();
            PreencheCampos();
            maskedTextCpf.Focus();

        }

        private void PreencheCampos()
        {
            if(textVendedoraId.Text != string.Empty)
            {
                VendedoraModel vm = null;
                try
                {
                    vm = _vendedoraServices.GetById(int.Parse(textVendedoraId.Text));
                }
                catch (DataAccessException e)
                {
                    MessageBox.Show($"Falha ao tentar recuperar dados da vendedora\n ErrorMessage: {e.DataAccessStatusInfo.getFormattedValues()}", "Error" );
                }
                
                if (vm != null)
                {

                    EstadoModel em = null;
                    EstadoCivilModel ecm = null;
                    CidadeModel cm = null;
                    BairroModel bm = null;

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
                }

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
            int estadoId = GetEstadoId(comboBoxUfEndereco.Text);
            int cidadeId = GetCidadeId(cidade, estadoId);
            LoadBairrosToComboBox(cidadeId);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (textVendedoraId.Text == string.Empty)
            {
                VendedoraAdd();
            }
            else
            {
                VendedoraUpdate();
            }
            VendedorasListForm.VendedorasListForm_Load(sender, e);


        }

        private void VendedoraUpdate()
        {
            var cpf = maskedTextCpf.Text;
            cpf = cpf.Replace(".", "");
            cpf = cpf.Replace(".", "");
            cpf = cpf.Replace("-", "");

            var cep = maskedTextCep.Text;
            cep = cep.Replace("-", "");
            int estadoId = GetEstadoId(comboBoxUfEndereco.Text);
            int cidadeId = GetCidadeId(comboBoxCidade.Text, estadoId);
            int bairroId = GetBairroId(comboBoxBairro.Text, cidadeId);

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
                EstadoCivilId = GetEstadoCivilId(comboBoxEstadoCivil.Text),
                UfRgId = GetEstadoId(comboBoxUfRg.Text),
                EstadoId = estadoId,
                CidadeId = cidadeId,
                BairroId = bairroId

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
                MessageBox.Show(formattedJsonStr, "Erro ao tentar adicionar a vendedora", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void VendedoraAdd()
        {
            var cpf = maskedTextCpf.Text;
            cpf = cpf.Replace(".", "");
            cpf = cpf.Replace(".", "");
            cpf = cpf.Replace("-", "");

            var cep = maskedTextCep.Text;
            cep = cep.Replace("-", "");
            int estadoId = GetEstadoId(comboBoxUfEndereco.Text);
            int cidadeId = GetCidadeId(comboBoxCidade.Text, estadoId);
            int bairroId = GetBairroId(comboBoxBairro.Text, cidadeId);

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
                EstadoCivilId = GetEstadoCivilId(comboBoxEstadoCivil.Text),
                UfRgId = GetEstadoId(comboBoxUfRg.Text),
                EstadoId = estadoId,
                CidadeId = cidadeId,
                BairroId = bairroId

            };

            bool operationSucceeded = false;
            string dataAccessStatusJsonStr = string.Empty;
            string formattedJsonStr = string.Empty;

            try
            {
                _vendedoraServices.Add(vendedoraModel);
                operationSucceeded = true;

            }
            catch (DataAccessException e)
            {
                operationSucceeded = e.DataAccessStatusInfo.OperationSucceeded;
                dataAccessStatusJsonStr = JsonConvert.SerializeObject(e.DataAccessStatusInfo);
                formattedJsonStr = JToken.Parse(dataAccessStatusJsonStr).ToString();
                MessageBox.Show(formattedJsonStr, "Erro ao tentar adicionar a vendedora", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                if (operationSucceeded)
                {
                    MessageBox.Show("Registro adicionado com sucesso", "Adicionar Vendedora", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            finally
            {
                //TODO: LER DADOS DA VENDEDORA
            }
        }

        private int GetBairroId(string nomeBairro, int cidadeId)
        {
            BairroModel bairroModel = null;
            try
            {
                bairroModel = _bairroServices.GetByNomeAndCidadeId(nomeBairro, cidadeId);
            }
            catch (DataAccessException e)
            {
                MessageBox.Show(e.Message, "Erro ao checar BairroId");
            }
            return bairroModel.BairroId;
        }

        private int GetCidadeId(string nomeCidade, int estadoId)
        {
            CidadeModel cidadeModel = null;
            try
            {
                cidadeModel = _cidadeServices.GetByNomeAndEstadoId(nomeCidade, estadoId);
            }
            catch (DataAccessException e)
            {
                MessageBox.Show("Erro ao tentar chegar CidadeId", e.Message);
            }
            return cidadeModel.CidadeId;
        }

        private int GetEstadoId(string uf)
        {
            EstadoModel estadoModel = null;
            try
            {
                estadoModel = _estadoServices.GetByUf(uf);
            }
            catch (DataAccessException e)
            {
                MessageBox.Show("Erro ao tentar checar a UFRG", e.Message);
            }
            return estadoModel.EstadoId;
        }

        public int GetEstadoCivilId(string estadoCivil)
        {
            EstadoCivilModel estadoCivilModel = null;
            try
            {
                estadoCivilModel = _estadoCivilServices.GetByEstadoCivil(estadoCivil);
            }
            catch (DataAccessException dae)
            {
                MessageBox.Show("Erro ao tentar acessar o banco de dados ESTADOCIVIL", dae.Message);
            }
            return estadoCivilModel.EstadoCivilId;

        }

        private void btnAddRota_Click(object sender, EventArgs e)
        {
            RotaForm rotaForm = new RotaForm(this);
        }
    }
}
