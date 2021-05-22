using DomainLayer.Models.Fornecedores;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Commons;
using InfrastructureLayer.DataAccess.Repositories.Specific.Fornecedor;

using MCatalogos.Views.FormViews.Fornecedores;
using MCatalogos.Views.FormViews.Telefones;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.FornecedorServices;
using ServiceLayer.Services.TelefoneFornecedorServices;
using ServiceLayer.Services.TipoTelefoneServices;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCatalogos.Views.UserControls.Fornecedores
{
    public partial class TelefonesFornecedorListUC : UserControl
    {
        QueryStringServices _queryString;
        FornecedorForm FornecedorForm;

        private TelefoneFornecedorServices _telefoneServices;
        private TipoTelefoneServices _tipoServices;
        private FornecedorServices _fornecedorServices;

        private int? idTelefone = null;


        public TelefonesFornecedorListUC(FornecedorForm fornecedorForm)
        {
            _queryString = new QueryStringServices(new QueryString());
            _tipoServices = new TipoTelefoneServices(new TipoTelefoneRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _fornecedorServices = new FornecedorServices(new FornecedorRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _telefoneServices = new TelefoneFornecedorServices(new TelefoneFornecedorRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());

            InitializeComponent();
            this.FornecedorForm = fornecedorForm;
        }

        public void LoadTelefones()
        {
            int fornecedorId = 0;
            if (this.FornecedorForm.textFornecedorId.Text != "")
            {
                fornecedorId = int.Parse(this.FornecedorForm.textFornecedorId.Text);
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
            }

            string query = "SELECT Tel.TelefoneId, Tel.Departamento, Tel.Contato, Tipo.TipoTelefone, Tel.Numero, Tel.Ramal " +
                               "FROM (TelefonesFornecedores AS Tel INNER JOIN TiposTelefones AS Tipo ON Tipo.TipoId = Tel.TipoTelefoneId) " +
                               "WHERE Tel.FornecedorId = @FornecedorId " +
                               "ORDER BY Tipo.TipoTelefone";

            using (SqlConnection connection = new SqlConnection(_queryString.GetQuery()))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@FornecedorId", fornecedorId));
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable telefones = new DataTable();

                        da.Fill(telefones);
                        dgvTeleForn.DataSource = telefones;
                        ConfiguraDGV();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Não foi possível trazser a lista de Telefones do Fornecedor.\nMessage: {e.Message}", "Alerta");
                }
                finally
                {
                    connection.Close();
                }
            }

        }

        private void ConfiguraDGV()
        {
            dgvTeleForn.ForeColor = Color.Black;

            dgvTeleForn.Columns[0].Visible = false;
            dgvTeleForn.Columns[0].HeaderText = "TelefoneId";
            dgvTeleForn.Columns[1].HeaderText = "Departamento";
            dgvTeleForn.Columns[1].Width = 200;
            dgvTeleForn.Columns[2].HeaderText = "Contato";
            dgvTeleForn.Columns[2].Width = 300;
            dgvTeleForn.Columns[3].HeaderText = "Tipo";
            dgvTeleForn.Columns[3].Width = 50;
            dgvTeleForn.Columns[4].HeaderText = "Número";
            dgvTeleForn.Columns[5].HeaderText = "Ramal";
            dgvTeleForn.Columns[5].Width = 73;

        }

        private bool CheckTelfefonesExistInFornecedor(int fornecedorId)
        {
            bool result = false;
            List<TelefoneFornecedorModel> modelList = null;

            try
            {
                modelList = (List<TelefoneFornecedorModel>)_telefoneServices.GetByFornecedorId(fornecedorId);
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

        private void TelefonesFornecedorListUC_Load(object sender, EventArgs e)
        {
            LoadTelefones();
        }

        private void dgvTeleForn_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex != dgvTeleForn.NewRowIndex)
            {
                if (dgvTeleForn.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString() == "Fixo")
                {
                    e.Value = string.Format("{0:(##) ####-####}", long.Parse(e.Value.ToString()));
                }
                else
                {
                    e.Value = string.Format("{0:(##) # ####-####}", long.Parse(e.Value.ToString()));
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            TelefoneFornecedorModel model = _telefoneServices.GetById(int.Parse(dgvTeleForn.CurrentRow.Cells[0].Value.ToString()));
            var result = MessageBox.Show("Você está prestes a APGAR o número de telefone selecionado. Tem certeza disso?", "Exclusão de Telefone",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _telefoneServices.Delete(model);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Falha ao tentar apagar o número de telefone {model.Numero}\nMessage: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    LoadTelefones();
                }
            }
        }

        private void dgvTeleForn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idTelefone = e.RowIndex;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TelefoneFornecedorAddForm telefoneFornecedorAddForm = new TelefoneFornecedorAddForm(this.FornecedorForm, this);
            telefoneFornecedorAddForm.Text = "Adicionar Contato";
            telefoneFornecedorAddForm.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            TelefoneFornecedorAddForm telefoneFornecedorAddForm = new TelefoneFornecedorAddForm(this.FornecedorForm, this);
            telefoneFornecedorAddForm.telefoneId = int.Parse(dgvTeleForn.CurrentRow.Cells[0].Value.ToString());
            telefoneFornecedorAddForm.Text = "Editar Contato";
            telefoneFornecedorAddForm.ShowDialog();
        }

        private void dgvTeleForn_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit_Click(sender, e);
        }
    }
}
