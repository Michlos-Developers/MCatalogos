using DomainLayer.Models.Vendedora;

using InfrastructureLayer.DataAccess.Repositories.Commons;
using InfrastructureLayer.DataAccess.Repositories.Specific.Vendedora;

using MCatalogos.Views.FormViews.Vendedoras;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.TelefoneVendedoraServices;
using ServiceLayer.Services.TipoTelefoneServices;
using ServiceLayer.Services.VendedoraServices;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCatalogos.Views.UserControls
{
    public partial class TelefonesVendedoraListUC : UserControl
    {
        VendedoraForm VendedoraForm;


        private TelefoneVendedoraServices _telefoneServices;
        private TipoTelefoneServices _tipoServices;
        private VendedoraServices _vendedoraServices;

        private int? idTelefone = null;

        private static string _connectionString = @"SERVER=.\SQLEXPRESS;DATABASE=MCatalogoDB;INTEGRATED SECURITY=SSPI";

        public TelefonesVendedoraListUC(VendedoraForm vendedoraForm)
        {
            _tipoServices = new TipoTelefoneServices(new TipoTelefoneRepository(_connectionString), new ModelDataAnnotationCheck());
            _telefoneServices = new TelefoneVendedoraServices(new TelefoneVendedoraRepository(_connectionString), new ModelDataAnnotationCheck());
            _vendedoraServices = new VendedoraServices(new VendedoraRepository(_connectionString), new ModelDataAnnotationCheck());

            InitializeComponent();
            this.VendedoraForm = vendedoraForm;
        }

        private void TelefonesVendedoraListUC_Load(object sender, EventArgs e)
        {
            //ConfiguraDGV();
            VendedoraModel vm = new VendedoraModel();
            //var vendModel;
            int vendedoraId = int.Parse(this.VendedoraForm.textVendedoraId.Text);

            string query = "SELECT TiposTelefones.TipoTelefone, TelefonesVendedoras.Numero " +
                " FROM(TelefonesVendedoras INNER JOIN TiposTelefones ON TiposTelefones.TipoId = TelefonesVendedoras.TipoTelefoneId) " +
                " WHERE TelefonesVendedoras.VendedoraId = @VendedoraId ";

            vm = _vendedoraServices.GetById(vendedoraId);
            if (CheckTelefonesExistVendedora(vm.VendedoraId))
            {
                MessageBox.Show("Vendedora tem telfone");
                //List<TelefoneVendedoraModel> modelList = (List<TelefoneVendedoraModel>)_telefoneServices.GetByVendedoraId(vendedoraId);
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    try
                    {

                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Prepare();
                            cmd.Parameters.Add(new SqlParameter("@VendedoraId", vendedoraId));

                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            {
                                DataTable dt = new DataTable();

                                da.Fill(dt);
                                dgvTelefonesVendedora.DataSource = dt;
                                ConfiguraDGV();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Falha ao tentar buscar telefones da vendedora.\n{ex.Message}", "Error");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }


            }
            else
            {
                MessageBox.Show("Vendedora não tem telefone");
            }

        }

        private void ConfiguraDGV()
        {
            dgvTelefonesVendedora.ForeColor = Color.Black;
            dgvTelefonesVendedora.Columns[0].HeaderText = "Operadora";
            dgvTelefonesVendedora.Columns[0].Width = 100;
            dgvTelefonesVendedora.Columns[1].HeaderText = "Número";
            dgvTelefonesVendedora.Columns[1].Width = 100;
        }

        private bool CheckTelefonesExistVendedora(int vendedoraId)
        {
            bool result = false;
            List<TelefoneVendedoraModel> modelList = null;

            try
            {
                modelList = (List<TelefoneVendedoraModel>)_telefoneServices.GetByVendedoraId(vendedoraId);
            }
            finally
            {
                if (modelList.Count != 0)
                {
                    result = true;
                }
            }
            return result;

        }
    }
}
