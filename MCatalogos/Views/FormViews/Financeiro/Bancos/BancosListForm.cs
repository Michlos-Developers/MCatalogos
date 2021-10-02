using DomainLayer.Models.CommonModels.Enums;
using DomainLayer.Models.Financeiro.Banco;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Specific.Financeiro.Banco;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.FinanceiroServices.BancoServices;
using ServiceLayer.Services.FinanceiroServices.BancoServices.ContaServices;

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MCatalogos.Views.FormViews.Financeiro.Bancos
{
    public partial class BancosListForm : Form
    {

        #region PROPRIEDADES PARA MOVER A JANELA

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        #endregion


        private RequestType RequestType;

        private List<BancoModel> BancosList = new List<BancoModel>();
        private List<ContaModel> ContasList = new List<ContaModel>();

        private QueryStringServices _queryString;
        private BancoServices _bancoServices;
        private ContaServices _contaServices;

        private IEnumerable<BancoModel> listaBancosDGV;

        private int indexDGV = 0;
        
        public BancosListForm()
        {
            _queryString = new QueryStringServices(new QueryString());
            _bancoServices = new BancoServices(new BancoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _contaServices = new ContaServices(new ContaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());

            InitializeComponent();
        }

        private void BancosListForm_Load(object sender, EventArgs e)
        {
            LoadModels();
            LoadDataGridView();
        }


        private void LoadModels()
        {
            BancosList = (List<BancoModel>)_bancoServices.GetAll();
            ContasList = (List<ContaModel>)_contaServices.GetAll();
        }
        private void LoadDataGridView()
        {
            listaBancosDGV = BancosList;
            listaBancosDGV = listaBancosDGV.Where(b => b.BancoId != 0);

            DataTable tableBancos = ModelaDataTableBancos();
            DataRow row = ModelaDataRowTableBanco(tableBancos, listaBancosDGV);
            ConfigureDataGridBancos(tableBancos);
        }


        private DataTable ModelaDataTableBancos()
        {
            DataTable table = new DataTable();

            table.Columns.Add("IdColumn", typeof(int));
            table.Columns.Add("NomeBancoColumn", typeof(string));
            table.Columns.Add("CodigoBancoColumn", typeof(int));
            table.Columns.Add("QtdContasColumn", typeof(int));

            return table;
        }
        private DataRow ModelaDataRowTableBanco(DataTable tableBancos, IEnumerable<BancoModel> listaBancosDGV)
        {
            DataRow row = null;
            if (listaBancosDGV.Any())
            {
                foreach (BancoModel model in listaBancosDGV)
                {

                    row = tableBancos.NewRow();
                    row["IdColumn"] = int.Parse(model.BancoId.ToString());
                    row["NomeBancoColumn"] = model.NomeBanco == null ? "" : model.NomeBanco.ToString();
                    row["CodigoBancoColumn"] = int.Parse(model.NumeroBanco.ToString());
                    row["QtdContasColumn"] = ContasList.Where(c => c.BancoId == model.BancoId).Where(c => c.ContaId != 0).Count();

                    tableBancos.Rows.Add(row);
                }
            }

            return row;
        }
        private void ConfigureDataGridBancos(DataTable tableBancos)
        {
            dgvBancos.DataSource = tableBancos;

            dgvBancos.Columns[0].HeaderText = "Id";
            dgvBancos.Columns[0].Width = 60;

            dgvBancos.Columns[1].HeaderText = "Banco";
            dgvBancos.Columns[1].Width = 300;

            dgvBancos.Columns[2].HeaderText = "Nº Banco";
            dgvBancos.Columns[2].Width = 100;

            dgvBancos.Columns[3].HeaderText = "Qtd.Contas";
            dgvBancos.Columns[3].Width = 100;


            dgvBancos.ForeColor = Color.Black;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BancoAddForm bancoAddForm = new BancoAddForm(RequestType.Add);
            bancoAddForm.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //TODO: ADICIONAR O CÓDIGO DO BANCO SELECIONADO NA DATAGRID
            BancoAddForm bancoAddForm = new BancoAddForm(RequestType.Edit);
            bancoAddForm.Show();
        }
    }
}
