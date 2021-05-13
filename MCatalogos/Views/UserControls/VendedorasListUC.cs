using CommonComponents;

using DomainLayer.Models.Vendedora;

using InfrastructureLayer.DataAccess.Repositories.Specific.Vendedora;

using MCatalogos.Commons;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCatalogos.UserControls
{
    public partial class VendedorasListUC : BaseUserControlUC
    {
        
        
        public VendedorasListUC()
        {
            InitializeComponent();
        }

        private void VendedorasListUC_Load(object sender, EventArgs e)
        {
            //STRING DE CONEXÃO COM O BANCO DE DADOS
            SqlConnection connection = new SqlConnection(@"SERVER=.\SQLEXPRESS; DATABASE=MCatalogoDB; INTEGRATED SECURITY=SSPI;");
            
            //STRING DE INSTRUÇÃO DE QUERY
            string sql = "SELECT VendedoraId, Nome, Cpf FROM Vendedoras";

            //DEFINE O COMMAND DO BANCO DE DADOS
            SqlCommand cmd = new SqlCommand(sql, connection);

            try
            {
                connection.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao acessar o banco de dados; " + ex.Message, "Erro acesso aos Dados");
            }

            //DATA ADAPTER
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            //Objeto DataTAble
            DataTable vendedoras = new DataTable();

            da.Fill(vendedoras);
            dataGridViewVendedoras.DataSource = vendedoras;

            connection.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            

            ButtonHelper bh = new ButtonHelper();
            bh.PictureBoxVisibilityEventArgs(false);
            Parent.Controls["HomeUC"].BringToFront();
            Parent.Refresh();
            Controls.Remove(this);

        }



        private void SetMaskTextBox()
        {
            TextBoxHelper tbh = new TextBoxHelper();
            if (radioButtonCpf.Checked)
            {
                tbh.SetMaskedTextBox(textSearch);
            }
            else
            {
                tbh.SetUnmaskedTextBox(textSearch);
            }
        }

        private void textSearch_Enter(object sender, EventArgs e)
        {
            SetMaskTextBox();
        }

        private void radioButtonCpf_CheckedChanged(object sender, EventArgs e)
        {
            SetMaskTextBox();
            textSearch.Focus();
        }

        private void pictureSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
