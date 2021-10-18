using CommonComponents;

using DomainLayer.Models.CommonModels.Enums;
using DomainLayer.Models.Vendedora;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Commons;
using InfrastructureLayer.DataAccess.Repositories.Specific.Vendedora;

using MCatalogos.Views.FormViews.Vendedoras;
using MCatalogos.Views.UserControls;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.TelefoneVendedoraServices;
using ServiceLayer.Services.TipoTelefoneServices;
using ServiceLayer.Services.VendedoraServices;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCatalogos.Views.FormViews.Telefones
{
    public partial class TelefoneVendedoraAddForm : Form
    {
        QueryStringServices _queryString;
        VendedoraForm VendedoraForm;
        TelefonesVendedoraListUC TelefonesVendedoraUc;

        private VendedoraServices _vendedoraServices;
        private TelefoneVendedoraServices _telefoneVendedoraServices;
        private TipoTelefoneServices _tipoTelefoneServices;

        public TelefoneVendedoraAddForm(VendedoraForm vendedoraForm, TelefonesVendedoraListUC telefonesVendedoraListUC)
        {
            _queryString = new QueryStringServices(new QueryString());
            _vendedoraServices = new VendedoraServices(new VendedoraRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _telefoneVendedoraServices = new TelefoneVendedoraServices(new TelefoneVendedoraRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _tipoTelefoneServices = new TipoTelefoneServices(new TipoTelefoneRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());

            InitializeComponent();
            this.VendedoraForm = vendedoraForm;
            this.TelefonesVendedoraUc = telefonesVendedoraListUC;
        }

        private void TelefoneVendedoraAddForm_Load(object sender, EventArgs e)
        {
            LoadTiposTelefonesToComboBox();

            comboBoxOperadora.Focus();
        }

        private bool TelefoneAdd()
        {
            bool operationSucceeded = false;
            var num = maskedTextNumero.Text;
            if (comboBoxOperadora.Text == "Fixo")
            {
                num = num.Replace("(", "");
                num = num.Replace(")", "");
                num = num.Replace(" ", "");
                num = num.Replace("-", "");
            }
            else
            {
                num = num.Replace("(", "");
                num = num.Replace(")", "");
                num = num.Replace(" ", "");
                num = num.Replace(" ", "");
                num = num.Replace("-", "");
            }

            if (comboBoxOperadora.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione o tipo de telefone");
                comboBoxOperadora.Focus();
            }
            else if (num == "")
            {
                MessageBox.Show("O número do telefone deve ser informado");
                maskedTextNumero.Focus();
            }
            else if (num.Length < 10)
            {
                MessageBox.Show("O número do telefone informado está errado. Favor verificar");
                maskedTextNumero.Focus();
            }
            else
            {
                operationSucceeded = false;
                string dataAccessStatusJsonStr = string.Empty;
                string formattedJsonStr = string.Empty;

                TelefoneVendedoraModel model = new TelefoneVendedoraModel()
                {
                    Numero = num,
                    TipoTelefoneId = _tipoTelefoneServices.GetByTipo(comboBoxOperadora.Text.ToString()).TipoId,
                    VendedoraId = int.Parse(this.VendedoraForm.textVendedoraId.Text),
                };
                try
                {
                    _telefoneVendedoraServices.Add(model);
                    operationSucceeded = true;
                }
                catch (DataAccessException e)
                {
                    operationSucceeded = e.DataAccessStatusInfo.OperationSucceeded;
                    dataAccessStatusJsonStr = JsonConvert.SerializeObject(e.DataAccessStatusInfo);
                    formattedJsonStr = JToken.Parse(dataAccessStatusJsonStr).ToString();
                    MessageBox.Show(formattedJsonStr, "Erro ao tentar adicionar telefone", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (operationSucceeded)
                {
                    MessageBox.Show("Telefone adicionado com sucesso", "Adicionar Telefone", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            return operationSucceeded;
        }

        private void LoadTiposTelefonesToComboBox()
        {
            List<TipoTelefoneModel> modelList = (List<TipoTelefoneModel>)_tipoTelefoneServices.GetAll();

            comboBoxOperadora.DisplayMember = "TipoTelefone";
            comboBoxOperadora.SelectedIndex = 0;
            comboBoxOperadora.Items.Clear();
            foreach (TipoTelefoneModel model in modelList)
            {
                comboBoxOperadora.Items.Add(model);
            }
        }

        private void comboBoxOperadora_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxOperadora.SelectedIndex >= 0)
            {
                string tipo = comboBoxOperadora.Text;
                SetMaskTelefoneNumero(tipo);
            }
        }

        private void SetMaskTelefoneNumero(string tipo)
        {
            if (tipo == "Fixo")
            {
                maskedTextNumero.Mask = "(99) 9999-9999";
            }
            else
            {
                maskedTextNumero.Mask = "(99) 9 9999-9999";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var addResult = TelefoneAdd();
            if (addResult == true)
            {
                var result = MessageBox.Show("Deseja adicionar novo telefone?", "Continuar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    comboBoxOperadora.Text = "-";
                    maskedTextNumero.Text = string.Empty;
                }
                else
                {
                    this.TelefonesVendedoraUc.TelefonesVendedoraListUC_Load(sender, e);
                    this.Close();

                }


            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void maskedTextNumero_MouseClick(object sender, MouseEventArgs e)
        {
            maskedTextNumero.SelectionStart = 0;
        }
    }
}
