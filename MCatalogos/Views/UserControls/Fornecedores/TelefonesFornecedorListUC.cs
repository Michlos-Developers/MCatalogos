using DomainLayer.Models.Fornecedores;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Commons;
using InfrastructureLayer.DataAccess.Repositories.Specific.Fornecedor;

using MCatalogos.Views.FormViews.Fornecedores;
using MCatalogos.Views.FormViews.Telefones;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.TelefoneFornecedorServices;
using ServiceLayer.Services.TipoTelefoneServices;

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MCatalogos.Views.UserControls.Fornecedores
{
    public partial class TelefonesFornecedorListUC : UserControl
    {
        QueryStringServices _queryString;
        FornecedorForm FornecedorForm;

        private TelefoneFornecedorServices _telefoneServices;
        private TipoTelefoneServices _tipoTelefoneServices;

        private int? idTelefone = null;
        public int fornecedorId = 0;


        public TelefonesFornecedorListUC(FornecedorForm fornecedorForm)
        {
            _queryString = new QueryStringServices(new QueryString());
            _tipoTelefoneServices = new TipoTelefoneServices(new TipoTelefoneRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _telefoneServices = new TelefoneFornecedorServices(new TelefoneFornecedorRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());

            InitializeComponent();
            this.FornecedorForm = fornecedorForm;
        }

        //SETTINGS AND GETTINGS
        public void LoadTelefonesToDataGridView()
        {
            List<TelefoneFornecedorModel> modelList = null;

            DataTable tableTelefones = new DataTable();
            DataColumn column;
            DataRow row;

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "TelefoneId";
            tableTelefones.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Departamento";
            tableTelefones.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Contato";
            tableTelefones.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "TipoTelefone";
            tableTelefones.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Numero";
            tableTelefones.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Ramal";
            tableTelefones.Columns.Add(column);



            if (fornecedorId != 0)
            {
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                btnEdit.Enabled = true;

                try
                {
                    modelList = (List<TelefoneFornecedorModel>)_telefoneServices.GetByFornecedorId(fornecedorId);
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Não foi possível trazer a lista de telefones do Fornecedor.\nMessage: {e.Message}", "Error Access Data");
                }

                if (modelList.Count != 0)
                {
                    foreach (TelefoneFornecedorModel model in modelList)
                    {
                        row = tableTelefones.NewRow();
                        row["TelefoneId"] = int.Parse(model.TelefoneId.ToString());
                        row["Departamento"] = model.Departamento.ToString();
                        row["Contato"] = model.Contato.ToString();
                        row["TipoTelefone"] = _tipoTelefoneServices.GetById(model.TipoTelefoneId).TipoTelefone;
                        row["Numero"] = model.Numero.ToString();
                        row["Ramal"] = model.Ramal.ToString();

                        tableTelefones.Rows.Add(row);
                    }
                }

            }
            else
            {
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
            }
            dgvTeleForn.DataSource = tableTelefones;
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


        //EVENTS FORM
        private void TelefonesFornecedorListUC_Load(object sender, EventArgs e)
        {
            LoadTelefonesToDataGridView();
            SetEnableButtons();
            ConfiguraDGV();
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
        private void dgvTeleForn_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit_Click(sender, e);
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
            //LoadTelefonesToDataGridView();
            SetEnableButtons();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            TelefoneFornecedorAddForm telefoneFornecedorAddForm = new TelefoneFornecedorAddForm(this.FornecedorForm, this);
            telefoneFornecedorAddForm.telefoneId = int.Parse(dgvTeleForn.CurrentRow.Cells[0].Value.ToString());
            telefoneFornecedorAddForm.Text = "Editar Contato";
            telefoneFornecedorAddForm.ShowDialog();
            SetEnableButtons();
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
                    LoadTelefonesToDataGridView();
                }
            }

            SetEnableButtons();
        }

        private void SetEnableButtons()
        {
            int fornecedorId = 0;
            if (this.FornecedorForm.textFornecedorId.Text != "")
            {
                fornecedorId = int.Parse(this.FornecedorForm.textFornecedorId.Text);
                btnAdd.Enabled = true;
                if (CkeckTelefoneExistFornecedor(fornecedorId))
                {
                    btnDelete.Enabled = true;
                    btnEdit.Enabled = true;
                }
                else
                {
                    btnDelete.Enabled = false;
                    btnEdit.Enabled = false;
                }
            }



        }

        private bool CkeckTelefoneExistFornecedor(int fornecedorId)
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
    }
}
