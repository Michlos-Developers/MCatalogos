using DomainLayer.Models.Catalogos;
using DomainLayer.Models.Fornecedores;

using InfrastructureLayer.DataAccess.Repositories.Specific.Catalogo;
using InfrastructureLayer.DataAccess.Repositories.Specific.Fornecedor;

using MCatalogos.Views.FormViews.Catalogos;
using MCatalogos.Views.FormViews.Fornecedores;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.CatalogoServices;
using ServiceLayer.Services.FornecedorServices;

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

namespace MCatalogos.Views.UserControls.Fornecedores
{
    public partial class CatalogosFornecedorListUc : UserControl
    {
        FornecedorForm FornecedorForm;
        private CatalogoServices _catalogoServices;
        private FornecedorServices _fornecedorServices;

        private int? idCatalogo = null;

        private static string _connectionString = @"SERVER=.\SQLEXPRESS;DATABASE=MCatalogoDB;INTEGRATED SECURITY=SSPI";

        public CatalogosFornecedorListUc(FornecedorForm fornecedorForm)
        {
            _fornecedorServices = new FornecedorServices(new FornecedorRepository(_connectionString), new ModelDataAnnotationCheck());
            _catalogoServices = new CatalogoServices(new CatalogoRepository(_connectionString), new ModelDataAnnotationCheck());

            InitializeComponent();
            this.FornecedorForm = fornecedorForm;
        }


        //SETTING AND GETTINGS
        public void LoadCatalogos()
        {
            int fornecedorId = 0;
            if (this.FornecedorForm.textFornecedorId.Text != "")
            {
                fornecedorId = int.Parse(this.FornecedorForm.textFornecedorId.Text);
            }
            string query = "SELECT CatalogoId, Nome, Ativo " +
                           "FROM Catalogos " +
                           "WHERE FornecedorId = @FornecedorId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@FornecedorId", fornecedorId));
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable catalogos = new DataTable();

                        da.Fill(catalogos);
                        dgvCatalogos.DataSource = catalogos;
                        ConfiguraDGV();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Não foi possível trazer a lista de Catálogos do Fornecedor\nMessage: {e.Message}", "Alerta");
                }
                finally
                {
                    connection.Close();
                }
            }

        }
        private bool CheckCatalogosExistInForneceddor(int fornecedorId)
        {
            bool result = false;
            List<CatalogoModel> modelList = null;

            try
            {
                modelList = (List<CatalogoModel>)_catalogoServices.GetByFornecedorId(fornecedorId);
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
        private void ConfiguraDGV()
        {
            dgvCatalogos.ForeColor = Color.Black;

            dgvCatalogos.Columns[0].Visible = false;
            dgvCatalogos.Columns[0].HeaderText = "CatalogoId";

            dgvCatalogos.Columns[1].HeaderText = "Nome";
            dgvCatalogos.Columns[1].Width = 165;
            dgvCatalogos.Columns[2].HeaderText = "Status";
            dgvCatalogos.Columns[2].Width = 50;
        }
        private void SetEnableButtons()
        {
            int fornecedorId = 0;
            if (this.FornecedorForm.textFornecedorId.Text != "")
            {
                fornecedorId = int.Parse(this.FornecedorForm.textFornecedorId.Text);
                btnAdd.Enabled = true;
                if (CheckCatalogosExistInForneceddor(fornecedorId))
                {
                    btnDelete.Enabled = true;
                    btnEdit.Enabled = true;
                }
            }
            else
            {
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
            }

        }


        //EVENTS FORM
        private void CatalogosFornecedorListUc_Load(object sender, EventArgs e)
        {
            LoadCatalogos();
            SetEnableButtons();
        }
        private void dgvCatalogos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idCatalogo = e.RowIndex;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            CatalogoModel model = _catalogoServices.GetById(int.Parse(dgvCatalogos.CurrentRow.Cells[0].Value.ToString()));
            var result = MessageBox.Show("Você está preste a APGAR o Catálogo do Fornecedor. Tem certeza disso?", "Exclusão de Catálogo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _catalogoServices.Delete(model);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Não foi possível apagar o Catálogo do sistema. \nMessage: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    LoadCatalogos();
                }
            }

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            CatalogoAddForm catalogoForm = new CatalogoAddForm(this.FornecedorForm, this);
            catalogoForm.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            CatalogoAddForm catalogoForm = new CatalogoAddForm(this.FornecedorForm, this);
            catalogoForm.textCatalogoId.Text = this.dgvCatalogos.CurrentRow.Cells[0].Value.ToString();
            catalogoForm.Show();
        }
    }
}
