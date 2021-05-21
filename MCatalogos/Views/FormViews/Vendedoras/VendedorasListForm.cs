using DomainLayer.Models.Vendedora;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Specific.Vendedora;

using MCatalogos.Commons;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.TelefoneVendedoraServices;
using ServiceLayer.Services.VendedoraServices;

using System;
using System.CodeDom;
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
        QueryString _queryString;
        MainView MainView;
        
        private VendedoraServices _vendedoraServices;
        private TelefoneVendedoraServices _telefoneVendedoraServices;
        private int? id = null;
        private static VendedorasListForm aForm = null;
        public static VendedorasListForm Instance(MainView mainView)
        {
            if (aForm== null)
            {
                aForm = new VendedorasListForm(mainView);
            }
            return aForm;
        }
        public VendedorasListForm(MainView mainView)
        {
            
            _vendedoraServices = new VendedoraServices(new VendedoraRepository(_queryString.GetQuery()), new ModelDataAnnotationCheck());
            _telefoneVendedoraServices = new TelefoneVendedoraServices(new TelefoneVendedoraRepository(_queryString.GetQuery()), new ModelDataAnnotationCheck());


            InitializeComponent();
            this.MainView = mainView;
        }

        
        public void VendedorasListForm_Load(object sender, EventArgs e)
        {

            
            //STRING DE CONEXÃO COM O BANCO DE DADOS
            SqlConnection connection = new SqlConnection(_queryString.GetQuery());

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
        //private void SetMaskTextBox()
        //{
        //    TextBoxHelper tbh = new TextBoxHelper();
        //    if (radioButtonCpf.Checked)
        //        tbh.SetMaskedTextBox(textSearch);
        //    else
        //        tbh.SetUnmaskedTextBox(textSearch);
        //}
        //private void radioButtonCpf_CheckedChanged(object sender, EventArgs e)
        //{
        //    SetMaskTextBox();
        //    textSearch.Focus();
        //}
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


        private void dgvVendedoras_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            VendedoraForm vf = new VendedoraForm(this);
            vf.textVendedoraId.Text = this.dgvVendedoras.CurrentRow.Cells[0].Value.ToString();
            vf.ShowDialog();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show($"CUIDADO!!\nVocê está prestes a apagar a vendedora " +
                $"\n{dgvVendedoras.CurrentRow.Cells[1].Value.ToString()}.\nTem certeza disso?", 
                "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); 
            if (result == DialogResult.Yes)
            {
                VendedoraModel model = new VendedoraModel();
                model = _vendedoraServices.GetById(int.Parse(dgvVendedoras.CurrentRow.Cells[0].Value.ToString()));
                
                List<TelefoneVendedoraModel> telefonesList = (List<TelefoneVendedoraModel>)_telefoneVendedoraServices.GetByVendedoraId(model.VendedoraId);
                try
                {
                    if (telefonesList.Count > 0)
                    {
                        foreach (TelefoneVendedoraModel telModel  in telefonesList)
                        {
                            _telefoneVendedoraServices.Delete(telModel);
                        }
                    }
                    _vendedoraServices.Delete(model);
                    MessageBox.Show($"Vendedora {model.Nome} apagada com sucesso.");

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Falha ao tentar apagar a vendedora\nErrorMessage: \n{ex.Message}", "Error");
                }
                this.VendedorasListForm_Load(sender, e);
            }
        }

        private void VendedorasListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            this.MainView.SetUnselectedButtons();
            base.Dispose(Disposing);
            aForm = null;
        }

        private void dgvVendedoras_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.ColumnIndex == 2) && (e.RowIndex != dgvVendedoras.NewRowIndex))
            {
                e.Value = string.Format(@"{0:###\.###\.###\-##}", Int64.Parse(e.Value.ToString()));
            }
        }
    }
    
}
