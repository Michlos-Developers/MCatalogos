using CommonComponents;

using DomainLayer.Models.Vendedora;

using InfrastructureLayer.DataAccess.Repositories.Specific.Vendedora;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.RotaServices;
using ServiceLayer.Services.VendedoraServices;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MCatalogos.Views.FormViews.Vendedoras
{
    public partial class RotaForm : Form
    {
        private RotaServices _rotaServices;
        private VendedoraServices _vendedoraServices;
        VendedoraForm _vendedoraForm;

        private static string _connectionString = @"SERVER=.\SQLEXPRESS;DATABASE=MCatalogoDB;INTEGRATED SECURITY=SSPI";
        private SqlConnection connection = new SqlConnection(_connectionString);
        public RotaForm(VendedoraForm vendedoraForm)
        {

            _vendedoraServices = new VendedoraServices(new VendedoraRepository(_connectionString), new ModelDataAnnotationCheck());
            _rotaServices = new RotaServices(new RotaRepository(_connectionString), new ModelDataAnnotationCheck());

            InitializeComponent();
            _vendedoraForm = vendedoraForm;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RotaForm_Load(object sender, EventArgs e)
        {
            PreencheCampos();
            LoadLetraRotaToComboBox();
        }

        private void LoadLetraRotaToComboBox()
        {
            List<RotaModel> rotaModelList = (List<RotaModel>)_rotaServices.GetAll();

            comboBoxLetraRota.DisplayMember = "Letra";
            comboBoxLetraRota.SelectedIndex = 0;
            comboBoxLetraRota.Items.Clear();
            foreach (RotaModel rm in rotaModelList)
            {
                comboBoxLetraRota.Items.Add(rm);
            }
        }

        private void PreencheCampos()
        {
            VendedoraModel vm = null;
            try
            {
                vm = _vendedoraServices.GetById(int.Parse(_vendedoraForm.textVendedoraId.Text));
            }
            catch (DataAccessException e)
            {
                MessageBox.Show($"Falha ao tentar recuperar dados da vendedora na Rota\n ErrorMessage: {e.DataAccessStatusInfo.getFormattedValues()}", "Error");
            }

            if (vm!=null)
            {
                textVendedoraNome.Text = vm.Nome.ToString();
            }
        }

        private void comboBoxLetraRota_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLetraRota.SelectedIndex > 0)
            {
                string letra = comboBoxLetraRota.Text;
                LoadNumerosRotaToComboBox(letra);
            }
        }

        private void LoadNumerosRotaToComboBox(string letra)
        {
            //List<RotaModel> rotaModelList = (List<RotaModel>)_rotaServices.GetAllByLetra();
        }
    }
}
