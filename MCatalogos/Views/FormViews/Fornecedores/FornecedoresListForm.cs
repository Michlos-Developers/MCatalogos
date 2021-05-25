using DomainLayer.Models.Fornecedores;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Specific.Fornecedor;

using Microsoft.Win32;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.FornecedorServices;
using ServiceLayer.Services.TelefoneFornecedorServices;

using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MCatalogos.Views.FormViews.Fornecedores
{
    public partial class FornecedoresListForm : Form
    {
        #region PROPRIEDADES PARA MOVER A JANELA

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        
        #endregion


        QueryStringServices _queryString;
        MainView MainView;
        
        //Instância de MainView. Evita que mais de uma janela seja aberta.
        private static FornecedoresListForm aForm = null;
        public static FornecedoresListForm Instance(MainView mainView)
        {
            if (aForm == null)
            {
                aForm = new FornecedoresListForm(mainView);
            }
            else
            {
                aForm.BringToFront();
            }
            return aForm;
        }

        private FornecedorServices _fornecedorServices;
        private TelefoneFornecedorServices _telefoneFornecedorServices;
        private int? id = null;

        public FornecedoresListForm(MainView mainView)
        {
            _queryString = new QueryStringServices(new QueryString());
            _fornecedorServices = new FornecedorServices(new FornecedorRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _telefoneFornecedorServices = new TelefoneFornecedorServices(new TelefoneFornecedorRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());

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
            LoadFornecedoresToDataGrid();

        }

        private void LoadFornecedoresToDataGrid()
        {
            List<FornecedorModel> modelList = null;
            try
            {
                modelList = (List<FornecedorModel>)_fornecedorServices.GetAll();

            }
            catch (Exception ex)
            {

                MessageBox.Show($"Não foi possível trazer a lista de fornecedores.\nMessage: {ex.Message}", "Error Acess List");
            }

            DataTable tableFornecedores = new DataTable();
            DataColumn column;
            DataRow row;

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "FornecedorId";
            tableFornecedores.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "RazaoSocial";
            column.Caption = "Razão Social";
            tableFornecedores.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "NomeFantasia";
            column.Caption = "Nome Fantasia";
            tableFornecedores.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Cnpj";
            column.Caption = "CNPJ";
            tableFornecedores.Columns.Add(column);

            if (modelList.Count != 0)
            {
                foreach (FornecedorModel model in modelList)
                {
                    row = tableFornecedores.NewRow();
                    row["FornecedorId"] = int.Parse(model.FornecedorId.ToString());
                    row["RazaoSocial"] = model.RazaoSocial.ToString();
                    row["NomeFantasia"] = model.NomeFantasia.ToString();
                    row["Cnpj"] = model.Cnpj.ToString();

                    tableFornecedores.Rows.Add(row);
                }
            }

            dgvFornecedores.DataSource = tableFornecedores;
            ConfigraDataGridView();
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
                    MessageBox.Show($"Não foi possível apagar o registro do forneceddor.\nErrorMessage: \n{ex.Message}.", "Error");
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

        private void titlePanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
