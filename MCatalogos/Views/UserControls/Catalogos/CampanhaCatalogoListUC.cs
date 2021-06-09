using DomainLayer.Models.Catalogos;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Specific.Catalogo;

using MCatalogos.Views.FormViews.Catalogos;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.CatalogoServices;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCatalogos.Views.UserControls.Catalogos
{
    public partial class CampanhaCatalogoListUC : UserControl
    {
        QueryStringServices _queryString;
        CatalogoForm CatalogoForm;

        private CampanhaServices _campanhaServices;
        private CatalogoServices _catalogoServices;
        public int catalogoId = 0;
        public int? idCampanhaDgv = null;
        public int campanhaId = 0;
        public CampanhaCatalogoListUC(CatalogoForm catalogoForm)
        {
            _queryString = new QueryStringServices(new QueryString());
            _campanhaServices = new CampanhaServices(new CampanhaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _catalogoServices = new CatalogoServices(new CatalogoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());


            InitializeComponent();
            this.CatalogoForm = catalogoForm;
        }

        //OWN METHODS
        private void LoadCampanhasToDataGridView()
        {
            List<CampanhaModel> modelList = new List<CampanhaModel>();
            try
            {
                if (catalogoId != 0)
                {
                    modelList = (List<CampanhaModel>)_campanhaServices.GetByCatalogoId(catalogoId);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Não foi possível trazer a lista de Campanhas desse catálogo.\nErrorMessage: {e.Message}", "Error");
            }

            DataTable tableCampanhas = new DataTable();
            DataColumn column;
            DataRow row;

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "CampanhaId";
            tableCampanhas.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Campanha";
            tableCampanhas.Columns.Add(column);

            
            column = new DataColumn();
            column.DataType = Type.GetType("System.DateTime");
            column.ColumnName = "DataLancamento";
            tableCampanhas.Columns.Add(column); 
            
            column = new DataColumn();
            column.DataType = Type.GetType("System.DateTime");
            column.ColumnName = "DataEncerramento";
            tableCampanhas.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Status";
            tableCampanhas.Columns.Add(column);

            foreach (CampanhaModel model in modelList)
            {
                row = tableCampanhas.NewRow();
                row["CampanhaId"] = int.Parse(model.CampanhaId.ToString());
                row["Campanha"] = model.Nome.ToString();
                row["DataLancamento"] = model.DataLancamento.ToString("d");
                row["DataEncerramento"] = model.DataEncerramento.ToString("d");
                row["Status"] = model.Ativa ? "Ativo" : "Inativo";

                tableCampanhas.Rows.Add(row);
            }

            dgvCampanhas.DataSource = tableCampanhas;
            ConfiguraDGV();

        }

        private void ConfiguraDGV()
        {
            dgvCampanhas.ForeColor = Color.Black;

            dgvCampanhas.Columns[0].Visible = false;

            dgvCampanhas.Columns[1].HeaderText = "Campanha";
            dgvCampanhas.Columns[1].Width = 228;
            
            dgvCampanhas.Columns[2].HeaderText = "Início";
            dgvCampanhas.Columns[2].Width = 100;
            
            dgvCampanhas.Columns[3].HeaderText = "Final";
            dgvCampanhas.Columns[3].Width = 100;
            
            dgvCampanhas.Columns[4].HeaderText = "Status";
            dgvCampanhas.Columns[4].Width = 50;

        }

        private void SetEnableButtons()
        {
            if (catalogoId != 0)
            {
                btnAdd.Enabled = true;
                if (CheckCampanhasExistInCatalogos(catalogoId))
                {
                    btnDelete.Enabled = true;
                    btnEdit.Enabled = true;
                }
            }
            else
            {
                btnEdit.Enabled = false;
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private bool CheckCampanhasExistInCatalogos(int catalogoId)
        {
            bool result = false;
            List<CampanhaModel> modelList = null;

            try
            {
                modelList = (List<CampanhaModel>)_campanhaServices.GetByCatalogoId(catalogoId);
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

        public void CampanhaCatalogoListUC_Load(object sender, EventArgs e)
        {
            LoadCampanhasToDataGridView();
            SetEnableButtons();
        }

        private void dgvCampanhas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idCampanhaDgv = e.RowIndex;
        }

        private void dgvCampanhas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex != dgvCampanhas.NewRowIndex)
            {
                if (dgvCampanhas.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Ativo")
                {
                    dgvCampanhas.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.LimeGreen;
                }
                else
                {
                    dgvCampanhas.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Red;

                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            CampanhaModel model = _campanhaServices.GetById(int.Parse(dgvCampanhas.CurrentRow.Cells[0].Value.ToString()));

            var result = MessageBox.Show($"Você está prestes a APAGAR a Campanha inteira do Catálogo Selecionado. " +
                $"Tem certeza disso?", "Exclusão de Campanha", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                //TODO: Checar se tem pedido na campanha antes de apagar. Se tiver pedido não apaga apenas desativa.
                try
                {
                    _campanhaServices.Delete(model);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Não foi possível apagar a Campanha do sistema. \nMessage: {ex.Message}", "Error");
                }
                finally
                {
                    LoadCampanhasToDataGridView();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CampanhaAddForm campanhaForm = new CampanhaAddForm(this.CatalogoForm, this);
            campanhaForm.Text = "Adicionar Campanha";
            campanhaForm.catalogoId = catalogoId;
            campanhaForm.StartPosition = FormStartPosition.CenterScreen;
            campanhaForm.ShowDialog();
            this.CampanhaCatalogoListUC_Load(sender, e);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            CampanhaAddForm campanhaForm = new CampanhaAddForm(this.CatalogoForm, this);
            campanhaForm.Text = "Editar Campanha";
            campanhaForm.catalogoId = catalogoId;
            campanhaForm.campanhaId = int.Parse(this.dgvCampanhas.CurrentRow.Cells[0].Value.ToString());
            campanhaForm.StartPosition = FormStartPosition.CenterScreen;
            campanhaForm.ShowDialog();
            this.CampanhaCatalogoListUC_Load(sender, e);
        }
    }
}
