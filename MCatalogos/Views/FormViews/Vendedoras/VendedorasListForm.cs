using CommonComponents;

using DomainLayer.Models.TitulosReceber;
using DomainLayer.Models.Vendedora;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Specific.TituloReceber;
using InfrastructureLayer.DataAccess.Repositories.Specific.Vendedora;

using MCatalogos.Commons;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.TelefoneVendedoraServices;
using ServiceLayer.Services.TitulosReceberServices;
using ServiceLayer.Services.VendedoraServices;

using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCatalogos.Views.FormViews.Vendedoras
{
    public partial class VendedorasListForm : Form
    {
        #region PROPRIEDADES PARA MOVER A JANELA

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        #endregion


        QueryStringServices _queryString;
        MainView MainView;
        //Control Control;

        private VendedoraServices _vendedoraServices;
        private TelefoneVendedoraServices _telefoneVendedoraServices;
        private TituloReceberServices _tituloReceberServices;

        private int indexDGV = 0;
        private static VendedorasListForm aForm = null;
        public static VendedorasListForm Instance(MainView mainView)
        {
            if (aForm == null)
            {
                aForm = new VendedorasListForm(mainView);
            }
            else
            {
                aForm.BringToFront();
            }
            return aForm;
        }
        public VendedorasListForm(MainView mainView)
        {
            _queryString = new QueryStringServices(new QueryString());
            _vendedoraServices = new VendedoraServices(new VendedoraRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _telefoneVendedoraServices = new TelefoneVendedoraServices(new TelefoneVendedoraRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _tituloReceberServices = new TituloReceberServices(new TituloReceberRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());


            InitializeComponent();
            this.MainView = mainView;
        }


        //OWN METHODS
        public void LoadVendedorasToDataGridView()
        {
            List<VendedoraModel> modelList = null;
            try
            {
                modelList = (List<VendedoraModel>)_vendedoraServices.GetAll();
            }
            catch (Exception e)
            {
                MessageBox.Show($"Não foi possível recuperar a lista de Vendedoras.\nMessage: {e.Message}", "Error Access List");
            }

            DataTable tableVendedoras = ModelaDataTable();
            ModelaRowTable(tableVendedoras, modelList);

            dgvVendedoras.DataSource = tableVendedoras;
            ConfiguraDataGridView();
        }

        private void ModelaRowTable(DataTable tableVendedoras, List<VendedoraModel> modelList)
        {
            DataRow row;
           
            if (modelList.Count != 0)
            {
                foreach (VendedoraModel model in modelList)
                {
                    row = tableVendedoras.NewRow();
                    row["VendedoraId"] = int.Parse(model.VendedoraId.ToString());
                    row["Nome"] = model.Nome.ToString();
                    row["Cpf"] = model.Cpf;

                    tableVendedoras.Rows.Add(row);
                }
            }

            
        }

        private DataTable ModelaDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("VendedoraId", typeof(int));
            table.Columns.Add("Nome", typeof(string));
            table.Columns.Add("Cpf", typeof(string));

            return table;
            
        }

        public void ConfiguraDataGridView()
        {
            dgvVendedoras.Columns[0].HeaderText = "Código";
            dgvVendedoras.Columns[0].Width = 50;

            dgvVendedoras.Columns[1].HeaderText = "Nome";
            dgvVendedoras.Columns[1].Width = 555;

            dgvVendedoras.Columns[2].HeaderText = "CPF";
            dgvVendedoras.Columns[2].Width = 108;

            if (indexDGV != 0)
            {
                dgvVendedoras.Rows[0].Selected = false;
                dgvVendedoras.Rows[indexDGV].Selected = true;
            }

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

        //EVENTS FORM
        public void VendedorasListForm_Load(object sender, EventArgs e)
        {
            LoadVendedorasToDataGridView();


        }
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
            if (dgvVendedoras.CurrentRow != null)
            {
                indexDGV = dgvVendedoras.CurrentRow.Index;
            }
        }
        private void dgvVendedoras_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            VendedoraForm vf = new VendedoraForm(this);
            vf.textVendedoraId.Text = this.dgvVendedoras.CurrentRow.Cells[0].Value.ToString();
            vf.WindowState = FormWindowState.Normal;
            vf.Show();

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show($"CUIDADO!!\nVocê está prestes a apagar a vendedora " +
                $"\n{dgvVendedoras.CurrentRow.Cells[1].Value.ToString()}.\nTem certeza disso?",
                "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                VendedoraModel model = new VendedoraModel();
                IEnumerable<TituloReceberModel> titulosReceber;

                model = _vendedoraServices.GetById(int.Parse(dgvVendedoras.CurrentRow.Cells[0].Value.ToString()));
                titulosReceber = (List<TituloReceberModel>)_tituloReceberServices.GetAllByVendedora(model);

                List<TelefoneVendedoraModel> telefonesList = (List<TelefoneVendedoraModel>)_telefoneVendedoraServices.GetByVendedoraId(model.VendedoraId);
                try
                {

                    if (titulosReceber.Any())
                    {
                        throw new DataAccessException();
                    }
                    if (telefonesList.Count > 0)
                    {
                        foreach (TelefoneVendedoraModel telModel in telefonesList)
                        {
                            _telefoneVendedoraServices.Delete(telModel);
                        }
                    }
                    _vendedoraServices.Delete(model);
                    MessageBox.Show($"Vendedora {model.Nome} apagada com sucesso.");

                }
                catch (DataAccessException)
                {
                    MessageBox.Show("Não foi possível apagar o registro da vendedora.\nEla possui um registro em Contas a Receber\nAo invés de excluir altere o STATUS da Vendedora.");
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
            //this.MainView.SetUnselectedButtons();
            base.Dispose(Disposing);
            aForm = null;
        }
        private void dgvVendedoras_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.ColumnIndex == 2) && (e.RowIndex != dgvVendedoras.NewRowIndex))
            {
                e.Value = string.Format(@"{0:000\.000\.000\-00}", long.Parse(e.Value.ToString()));
            }
        }
        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


    }

}
