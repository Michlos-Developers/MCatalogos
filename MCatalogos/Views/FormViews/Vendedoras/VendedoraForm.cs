using CommonComponents;

using DomainLayer.Models.CommonModels.Address;
using DomainLayer.Models.CommonModels.Enums;
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
        VendedorasListForm VendedorasListForm;

        private VendedoraServices _vendedoraServices;
        private EstadoCivilServices _estadoCivilServices;
        private BairroServices _bairroServices;
        private CidadeServices _cidadeServices;
        private EstadoServices _estadoServices;
        private RotaLetraServices _rotaLetraServices;
        private RotaServices _rotaServices;

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

            InitializeComponent();
            this.VendedorasListForm = vendedorasListForm;

        }

        private void VendedoraForm_Load(object sender, EventArgs e)
        {

            LoadRotasLetrasToComboBox();
            LoadEstadosToComboBox();
            LoadUfRgToComboBox();
            LoadEstadoCivilToComboBox();
            PreencheCampos();
            maskedTextCpf.Focus();

        }

        private void PreencheCampos()
        {
            if (textVendedoraId.Text != string.Empty)
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
                BairroId = bairroId,
                RotaLetraId = GetRotaLetraId(comboBoxRotaLetra.Text)

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
        private int GetRotaLetraId(string rotaLetra)
        {
            RotaLetraModel model = null;
            try
            {
                model = _rotaLetraServices.GetByLetra(rotaLetra);
            }
            catch (DataAccessException e)
            {
                MessageBox.Show("Erro ao tentar checar LetraId", e.Message);
            }
            return model.RotaLetraId;
        }
        private string GetRotaLastLetra()
        {
            RotaLetraModel model = null;
            try
            {
                model = _rotaLetraServices.GetLastLetra();
            }
            catch (DataAccessException e)
            {
                MessageBox.Show("Erro ao tetar buscar a última letra do banco de dados", e.Message);
            }
            return model.RotaLetra;
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
        private string GetNextLetra(string lastLetra)
        {
            string alfabeto = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int pos = alfabeto.IndexOf(lastLetra);
            string nextLetra = string.Empty;
            pos++;
            nextLetra = alfabeto[pos].ToString();
            return nextLetra;
        }
        private int GetRotaLastNumero(int rotaLetraId)
        {
            RotaModel model = null;
            try
            {
                model = _rotaServices.GetLastNumero(rotaLetraId);
            }
            catch (DataAccessException e)
            {
                MessageBox.Show("Erro ao buscar a última rota no banco de dados", e.Message);
            }
            return model.Numero;
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
            int lastNumero = GetRotaLastNumero(rotaLetraId);
            int nextNumero = lastNumero + 1;

            if (ChecaRotaVendedora(vendedoraId))
            {
                var result = MessageBox.Show("Essa já vendedora já possui uma rota cadastrada.\nCaso continue as rotas serão reindexadas.\nDeseja continuar?",
                    "Reindexação de Rotas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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


        private void comboBoxRotaLetra_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxRotaLetra.SelectedIndex > -1)
            {
                LoadRotaNumeroToComboBox(GetRotaLetraId(comboBoxRotaLetra.Text));
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
            int estadoId = GetEstadoId(comboBoxUfEndereco.Text);
            int cidadeId = GetCidadeId(cidade, estadoId);
            LoadBairrosToComboBox(cidadeId);
        }
        private void comboBoxRotaNumero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void btnAddRotaLetra_Click(object sender, EventArgs e)
        {
            string lastLetra = GetRotaLastLetra();
            string nextLetra = string.Empty;
            if (lastLetra == "Z")
            {
                MessageBox.Show("Já foram adicionadas todas as letras para Rota.\nEntre em contato com o Administrador.");
            }
            else
            {
                try
                {

                    GetNextLetra(lastLetra);
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
        private void btnAddNumeroRota_Click(object sender, EventArgs e)
        {
            int rotaLetraId = GetRotaLetraId(comboBoxRotaLetra.Text);
            AddNumeroRota(rotaLetraId, textVendedoraId.Text);
            VendedoraUpdate();
            VendedoraForm_Load(sender, e);
        }

        private bool ChecaRotaVendedora(int vendedoraId)
        {
            bool result = false;
            RotaModel model = _rotaServices.GetByVendedoraId(vendedoraId);
            if (model != null)
            {
                result = true;
            }
            return result;

        }




    }
}
