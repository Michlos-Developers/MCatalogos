using DomainLayer.Models.Vendedora;

using InfrastructureLayer.DataAccess.Repositories.Specific.Vendedora;

using MCatalogos.Commons;

using ServiceLayer.CommonServices;
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

namespace MCatalogos.Views.FormViews.Vendedoras
{
    public partial class VendedorasListForm : Form
    {
        private VendedoraServices _vendedoraServices;
        private string _connectionString;
        private int? id = null;
        public VendedorasListForm()
        {
            _connectionString = @"SERVER=.\SQLEXPRESS;DATABASE=MCatalogoDB;INTEGRATED SECURITY=SSPI";
            _vendedoraServices = new VendedoraServices(new VendedoraRepository(_connectionString), new ModelDataAnnotationCheck());
            InitializeComponent();
        }

        
        public void VendedorasListForm_Load(object sender, EventArgs e)
        {

            
            //STRING DE CONEXÃO COM O BANCO DE DADOS
            SqlConnection connection = new SqlConnection(_connectionString);

            //STRING DE INSTRUÇÃO DE QUERY
            string sql = "SELECT VendedoraId, Nome, Cpf FROM Vendedoras";

            //DEFINE O COMMAND DO BANCO DE DADOS
            SqlCommand cmd = new SqlCommand(sql, connection);

            try
            {
                connection.Open();
                
                //DATA ADAPTER
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                //Objeto DataTAble
                DataTable vendedoras = new DataTable();

                da.Fill(vendedoras);
                dgvVendedoras.DataSource = vendedoras;
                ConfiguraDataGridView();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao acessar o banco de dados; " + ex.Message, "Erro ao tentar preencher Dados");
            }
            finally
            {
                connection.Close();
            }

           
        }

        public void ConfiguraDataGridView()
        {
            dgvVendedoras.Columns[0].HeaderText = "Código";
            dgvVendedoras.Columns[0].Width = 50;
            
            dgvVendedoras.Columns[1].HeaderText = "Nome";
            dgvVendedoras.Columns[1].Width = 555;
            
            dgvVendedoras.Columns[2].HeaderText = "CPF";
            dgvVendedoras.Columns[2].Width = 108;

        }


        #region BARRA DE BUSCA
        private void SetMaskTextBox()
        {
            TextBoxHelper tbh = new TextBoxHelper();
            if (radioButtonCpf.Checked)
                tbh.SetMaskedTextBox(textSearch);
            else
                tbh.SetUnmaskedTextBox(textSearch);
        }
        private void radioButtonCpf_CheckedChanged(object sender, EventArgs e)
        {
            SetMaskTextBox();
            textSearch.Focus();
        }
        private void pictureSearch_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //SetUnselectedButtons();
            this.Close();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            VendedoraForm vendedoraForm = new VendedoraForm(this);
            vendedoraForm.ShowDialog();
        }

        private void pictureSearch_Click_1(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            VendedoraForm vendedoraForm = new VendedoraForm(this);
            vendedoraForm.textVendedoraId.Text = this.dgvVendedoras.CurrentRow.Cells[0].Value.ToString();
            vendedoraForm.ShowDialog();
        }

        private void dgvVendedoras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = e.RowIndex;
            //VendedoraModel vm = dgvVendedoras.Columns["VendedoraId"].Selected();
        }

        private void Update(int vendedoraId)
        {

        }

        private void dgvVendedoras_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            VendedoraForm vf = new VendedoraForm(this);
            vf.textVendedoraId.Text = this.dgvVendedoras.CurrentRow.Cells[0].Value.ToString();
            vf.ShowDialog();

        }
    }
}
