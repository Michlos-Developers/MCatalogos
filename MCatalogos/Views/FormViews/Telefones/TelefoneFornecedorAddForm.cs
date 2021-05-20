using CommonComponents;

using DomainLayer.Models.CommonModels.Enums;
using DomainLayer.Models.Fornecedores;

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
        FornecedorForm FornecedorForm;
        TelefonesFornecedorListUC TelefonesFornecedorListUC;

        private FornecedorServices _fornecedorServices;
        private TelefoneFornecedorServices _telefoneService;
        private TipoTelefoneServices _tipoTelefoneServices;

        private static string _connectionString = @"SERVER=.\SQLEXPRESS;DATABASE=MCatalogoDB;INTEGRATED SECURITY=SSPI";
        public TelefoneFornecedorAddForm(FornecedorForm fornecedorForm, TelefonesFornecedorListUC telefonesFornecedorListUC)
        {
            _fornecedorServices = new FornecedorServices(new FornecedorRepository(_connectionString), new ModelDataAnnotationCheck());
            _tipoTelefoneServices = new TipoTelefoneServices(new TipoTelefoneRepository(_connectionString), new ModelDataAnnotationCheck());
            _telefoneService = new TelefoneFornecedorServices(new TelefoneFornecedorRepository(_connectionString), new ModelDataAnnotationCheck());

            InitializeComponent();
            this.FornecedorForm = fornecedorForm;
            this.TelefonesFornecedorListUC = telefonesFornecedorListUC;
        }

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
                FornecedorId = int.Parse(this.FornecedorForm.textFornecedorId.Text)
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

        private void TelefoneFornecedorAddForm_Load(object sender, EventArgs e)
        {
            LoadTiposTelefonesToComboBox();
            cbTipoTelefone.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var addResult = TelefoneAdd();
            if (addResult == true)
            {
                var result = MessageBox.Show("DEseja adicionar outro telefone?", "Continuar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    cbTipoTelefone.Text = "-";
                    mTextNumero.Text = string.Empty;
                    textContato.Text = string.Empty;
                    textDepartamento.Text = string.Empty;
                    textRamal.Text = string.Empty;
                    textRamal.Enabled = false;
                }
                else
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
    }
}
