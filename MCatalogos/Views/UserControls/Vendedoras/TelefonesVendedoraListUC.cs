using DomainLayer.Models.Vendedora;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Commons;
using InfrastructureLayer.DataAccess.Repositories.Specific.Vendedora;

using MCatalogos.Views.FormViews.Telefones;
using MCatalogos.Views.FormViews.Vendedoras;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.TelefoneVendedoraServices;
using ServiceLayer.Services.TipoTelefoneServices;
using ServiceLayer.Services.VendedoraServices;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace MCatalogos.Views.UserControls
{
    public partial class TelefonesVendedoraListUC : UserControl
    {
        QueryStringServices _queryString;
        VendedoraForm VendedoraForm;


        private TelefoneVendedoraServices _telefoneServices;
        private TipoTelefoneServices _tipoTelefoneServices;
        private VendedoraServices _vendedoraServices;

        private int? idTelefone = null;
        public int vendedoraId = 0;


        public TelefonesVendedoraListUC(VendedoraForm vendedoraForm)
        {
            _queryString = new QueryStringServices(new QueryString());
            _tipoTelefoneServices = new TipoTelefoneServices(new TipoTelefoneRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _telefoneServices = new TelefoneVendedoraServices(new TelefoneVendedoraRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _vendedoraServices = new VendedoraServices(new VendedoraRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());

            InitializeComponent();
            this.VendedoraForm = vendedoraForm;
        }

        public void TelefonesVendedoraListUC_Load(object sender, EventArgs e)
        {
            LoadTelefonresToDataGridView();
            ConfiguraDGV();

        }

        private void LoadTelefonresToDataGridView()
        {
            List<TelefoneVendedoraModel> modelList = null;

            DataTable tableTelefones = new DataTable();
            DataColumn column;
            DataRow row;

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "TelefoneId";
            tableTelefones.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "TiposTelefones";
            tableTelefones.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Numero";
            tableTelefones.Columns.Add(column);

            if (vendedoraId != 0)
            {
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                try
                {
                    modelList = (List<TelefoneVendedoraModel>)_telefoneServices.GetByVendedoraId(vendedoraId);
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Não foi possível trazer a lista de Telefones da Vendedora.\nMessage: {e.Message}", "Data Access Error");
                }
                
                if (modelList.Count != 0)
                {
                    foreach (TelefoneVendedoraModel model in modelList)
                    {
                        row = tableTelefones.NewRow();
                        row["TelefoneId"] = int.Parse(model.TelefoneId.ToString());
                        row["TiposTelefones"] = _tipoTelefoneServices.GetById(model.TipoTelefoneId).TipoTelefone.ToString();
                        row["Numero"] = model.Numero.ToString();

                        tableTelefones.Rows.Add(row);
                    }
                }
            }
            else
            {
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
            }
            dgvTelefonesVendedora.DataSource = tableTelefones;

        }

        private void ConfiguraDGV()
        {
            dgvTelefonesVendedora.ForeColor = Color.Black;

            dgvTelefonesVendedora.Columns[0].Visible = false;
            dgvTelefonesVendedora.Columns[1].HeaderText = "Operadora";
            dgvTelefonesVendedora.Columns[1].Width = 100;
            dgvTelefonesVendedora.Columns[2].HeaderText = "Número";
            dgvTelefonesVendedora.Columns[2].Width = 195;

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

        private void dgvTelefonesVendedora_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex != dgvTelefonesVendedora.NewRowIndex)
            {
                if (dgvTelefonesVendedora.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString() == "Fixo")
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
            TelefoneVendedoraModel model = _telefoneServices.GetById(
                int.Parse(
                    dgvTelefonesVendedora.CurrentRow.Cells[0].Value.ToString()
                    )
                );
            var result = MessageBox.Show("Vocês está prestes a apagar o número de telefone selecionado. Tem certeza disso?",
                "Exclusão de Telefone", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    _telefoneServices.Delete(model);
                    MessageBox.Show("Telefone excluído com sucesso");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Falha ao tentar apagar o número de telefone {model.Numero}\nMessage: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {

                    TelefonesVendedoraListUC_Load(sender, e);
                }

            }



        }

        private void dgvTelefonesVendedora_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idTelefone = e.RowIndex;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TelefoneVendedoraAddForm telefoneVendedoraAddForm = new TelefoneVendedoraAddForm(this.VendedoraForm, this);
            telefoneVendedoraAddForm.ShowDialog();
        }
    }
}
