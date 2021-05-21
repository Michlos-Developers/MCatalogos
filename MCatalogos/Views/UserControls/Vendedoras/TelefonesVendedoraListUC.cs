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
        QueryString _queryString;
        VendedoraForm VendedoraForm;


        private TelefoneVendedoraServices _telefoneServices;
        private TipoTelefoneServices _tipoServices;
        private VendedoraServices _vendedoraServices;

        private int? idTelefone = null;


        public TelefonesVendedoraListUC(VendedoraForm vendedoraForm)
        {
            _tipoServices = new TipoTelefoneServices(new TipoTelefoneRepository(_queryString.GetQuery()), new ModelDataAnnotationCheck());
            _telefoneServices = new TelefoneVendedoraServices(new TelefoneVendedoraRepository(_queryString.GetQuery()), new ModelDataAnnotationCheck());
            _vendedoraServices = new VendedoraServices(new VendedoraRepository(_queryString.GetQuery()), new ModelDataAnnotationCheck());

            InitializeComponent();
            this.VendedoraForm = vendedoraForm;
        }

        public void TelefonesVendedoraListUC_Load(object sender, EventArgs e)
        {
            //ConfiguraDGV();
            VendedoraModel vm = new VendedoraModel();
            int vendedoraId = 0;
            //var vendModel;
            if (this.VendedoraForm.textVendedoraId.Text != "")
            {
                vendedoraId = int.Parse(this.VendedoraForm.textVendedoraId.Text);
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;



                string query = "SELECT TelefonesVendedoras.TelefoneId, TiposTelefones.TipoTelefone, TelefonesVendedoras.Numero  " +
                    " FROM(TelefonesVendedoras INNER JOIN TiposTelefones ON TiposTelefones.TipoId = TelefonesVendedoras.TipoTelefoneId) " +
                    " WHERE TelefonesVendedoras.VendedoraId = @VendedoraId " +
                    " ORDER BY TipoTelefoneId";

                vm = _vendedoraServices.GetById(vendedoraId);
                if (CheckTelefonesExistVendedora(vm.VendedoraId))
                {

                    using (SqlConnection connection = new SqlConnection(_queryString.GetQuery()))
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

            }
            else
            {
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
            }


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
