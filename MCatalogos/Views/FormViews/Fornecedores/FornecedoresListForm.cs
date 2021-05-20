using DomainLayer.Models.Fornecedores;

using InfrastructureLayer.DataAccess.Repositories.Specific.Fornecedor;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.FornecedorServices;
using ServiceLayer.Services.TelefoneFornecedorServices;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MCatalogos.Views.FormViews.Fornecedores
{
    public partial class FornecedoresListForm : Form
    {
        MainView MainView;
        private static FornecedoresListForm aForm = null;
        public static FornecedoresListForm Instance(MainView mainView)
        {
            if (aForm == null)
            {
                aForm = new FornecedoresListForm(mainView);
            }
            return aForm;
        }

        private FornecedorServices _fornecedorServices;
        private TelefoneFornecedorServices _telefoneFornecedorServices;
        private string _connectionString;
        private int? id = null;

        public FornecedoresListForm(MainView mainView)
        {
            _connectionString = @"SERVER=.\SQLEXPRESS;DATABASE=MCatalogoDB;INTEGRATED SECURITY=SSPI";

            _fornecedorServices = new FornecedorServices(new FornecedorRepository(_connectionString), new ModelDataAnnotationCheck());
            _telefoneFornecedorServices = new TelefoneFornecedorServices(new TelefoneFornecedorRepository(_connectionString), new ModelDataAnnotationCheck());

            InitializeComponent();
            this.MainView = mainView;
        }


        public void ConfigraDataGridView()
        {
            dgvFornecedores.Columns[0].HeaderText = "Código";
            dgvFornecedores.Columns[0].Width = 50;

            dgvFornecedores.Columns[1].HeaderText = "Razao Social";
            dgvFornecedores.Columns[1].Width = 225;

            dgvFornecedores.Columns[2].HeaderText = "Nome Fantasia";
            dgvFornecedores.Columns[2].Width = 225;

            dgvFornecedores.Columns[3].HeaderText = "CNPJ";
            dgvFornecedores.Columns[3].Width = 213;

        }

        private void FornecedoresListForm_FormClosing(object sender, FormClosingEventArgs e)
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

        public void FornecedoresListForm_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            string query = "SELECT FornecedorId, RazaoSocial, NomeFantasia, Cnpj FROM Fornecedores";
            SqlCommand cmd = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable fornecedores = new DataTable();

                da.Fill(fornecedores);
                dgvFornecedores.DataSource = fornecedores;
                ConfigraDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha ao acessar o banco de dados. \n{ex.Message}", "Falha no DataBase");
            }
            finally
            {
                connection.Close();
            }

        }

        private void dgvFornecedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = e.RowIndex;
        }

        private void dgvFornecedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FornecedorForm fornecedorForm = new FornecedorForm(this);
            fornecedorForm.textFornecedorId.Text = this.dgvFornecedores.CurrentRow.Cells[0].Value.ToString();
            fornecedorForm.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FornecedorForm fornecedorForm = new FornecedorForm(this);
            fornecedorForm.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            FornecedorForm fornecedorForm = new FornecedorForm(this);
            fornecedorForm.textFornecedorId.Text = this.dgvFornecedores.CurrentRow.Cells[0].Value.ToString();
            fornecedorForm.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show($"CUIDADO!!\nVocê está prestes a apgar o cadastro do Fornecedor\n{dgvFornecedores.CurrentRow.Cells[1].Value.ToString()}. " +
                $"\nTem certeza disso?", "CUIDADO!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                FornecedorModel model = new FornecedorModel();
                model = _fornecedorServices.GetById(int.Parse(dgvFornecedores.CurrentRow.Cells[0].Value.ToString()));

                List<TelefoneFornecedorModel> telefonesList = (List<TelefoneFornecedorModel>)_telefoneFornecedorServices.GetByFornecedorId(model.FornecedorId);
                try
                {
                    if (telefonesList.Count > 0)
                    {
                        foreach (TelefoneFornecedorModel telModel in telefonesList)
                        {
                            _telefoneFornecedorServices.Delete(telModel);
                        }
                    }
                    _fornecedorServices.Delete(model);
                    MessageBox.Show($"Fornecedor {model.NomeFantasia} excluído com sucesso.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Falha ao tentar apagar o registro do forneceddor.\nErrorMessage: \n{ex.Message}.", "Error");
                }
                this.FornecedoresListForm_Load(sender, e);
            }
        }

        private void dgvFornecedores_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.ColumnIndex == 3) && (e.RowIndex != dgvFornecedores.NewRowIndex))
            {
                e.Value = string.Format(@"{0:##\.###\.###\/####\-##}", Int64.Parse(e.Value.ToString()));
            }
        }
    }
}
