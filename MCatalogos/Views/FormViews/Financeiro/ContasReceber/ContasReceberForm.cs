using DomainLayer.Models.CommonModels.Enums;
using DomainLayer.Models.TitulosReceber;
using DomainLayer.Models.Vendedora;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Specific.TituloReceber;
using InfrastructureLayer.DataAccess.Repositories.Specific.Vendedora;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.TitulosReceberServices;
using ServiceLayer.Services.VendedoraServices;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCatalogos.Views.FormViews.Financeiro.ContasReceber
{

    public partial class ContasReceberForm : Form
    {
        #region INSTANCE TREATMENT
        private static ContasReceberForm aForm = null;
        internal static ContasReceberForm Instance(FinanceiroForm financeiroForm)
        {
            if (aForm == null)
            {
                aForm = new ContasReceberForm(financeiroForm);
            }
            else
            {
                aForm.BringToFront();
            }
            return aForm;
        }

        private FinanceiroForm FinanceiroForm;
        private void ContasReceberForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }

            base.Dispose(Disposing);
            aForm = null;
        }
        #endregion


        #region LOAD MODELS
        private List<TituloReceberModel> ListTitulos = new List<TituloReceberModel>();
        private TituloReceberModel SelectedTitulo = new TituloReceberModel();

        //SERVICES
        private QueryStringServices _queryStringService;
        private TituloReceberServices _tituloReceberServices;
        private VendedoraServices _vendedoraServices;

        #endregion

        private List<string> MonthList = new List<string>();
        private IEnumerable<TituloReceberModel> titulosReceberDGV;
        private StatusTitulo status = StatusTitulo.Aberto;
        private int indexDGV = 0;


        public ContasReceberForm(FinanceiroForm financeiroForm)
        {
            _queryStringService = new QueryStringServices(new QueryString());
            _tituloReceberServices = new TituloReceberServices(new TituloReceberRepository(_queryStringService.GetQueryApp()), new ModelDataAnnotationCheck());
            _vendedoraServices = new VendedoraServices(new VendedoraRepository(_queryStringService.GetQueryApp()), new ModelDataAnnotationCheck());

            InitializeComponent();
            FinanceiroForm = financeiroForm;

        }
        private void ContasReceberForm_Load(object sender, EventArgs e)
        {
            ReadModelsList();
            LoadComboBoxMonths();
            LoadContasReceberDGV(StatusTitulo.Aberto, null, null); //lê todos os títulos abertos de todo o sistema ignorando o mês
        }


        private void LoadComboBoxMonths()
        {
            for (int i = 1; i <= 13; i++)
            {
                MonthList.Add(DateTimeFormatInfo.CurrentInfo.GetMonthName(i).ToUpper());
            }

            cbMes.DataSource = MonthList;
            cbMes.SelectedItem = DateTimeFormatInfo.CurrentInfo.GetMonthName(DateTime.Now.Month).ToUpper();
        }

        private void LoadContasReceberDGV(StatusTitulo status, int? currentMonth, string cpf)
        {
            titulosReceberDGV = ListTitulos;
            VendedoraModel vendedora = null;

            //E-- TENHO OS DOIS
            if (currentMonth != null & !string.IsNullOrEmpty(cpf))
            {
                titulosReceberDGV = titulosReceberDGV.Where(mes => mes.DataVencimento.Month == currentMonth + 1);
                vendedora = _vendedoraServices.GetByCpf(cpf);
                titulosReceberDGV = titulosReceberDGV.Where(vendedoraid => vendedoraid.VendedoraId == vendedora.VendedoraId);
            }
            else if (currentMonth != null)
            {
                titulosReceberDGV = titulosReceberDGV.Where(mes => mes.DataVencimento.Month == currentMonth + 1);

            }
            else if (!string.IsNullOrEmpty(cpf))
            {
                vendedora = _vendedoraServices.GetByCpf(cpf);
                titulosReceberDGV = titulosReceberDGV.Where(vendedoraid => vendedoraid.VendedoraId == vendedora.VendedoraId);
            }

            titulosReceberDGV = ConfiguraDGVByStatus(status, titulosReceberDGV);
            LoadTableTitulos(vendedora);


        }

        private void LoadTableTitulos(VendedoraModel vendedora)
        {

            DataTable tableTitulos = ModelaDataTableTitulos();
            ModelaDataRowTableTitulos(tableTitulos, titulosReceberDGV, vendedora);
            ConfiguraDataGridTitulos(tableTitulos);
        }

        private DataTable ModelaDataTableTitulos()
        {
            DataTable table = new DataTable();

            table.Columns.Add("CodigoTituloColumn", typeof(int));
            table.Columns.Add("NomeVendedoraTituloColumn", typeof(string));
            table.Columns.Add("CpfVendedoraTituloColumn", typeof(string));
            table.Columns.Add("DataVencimentoTituloColumn", typeof(DateTime));
            table.Columns.Add("ValorTituloColumn", typeof(string));
            table.Columns.Add("StatusTituloColumn", typeof(string));

            return table;
        }
        private void ModelaDataRowTableTitulos(DataTable tableTitulos, IEnumerable<TituloReceberModel> titulosReceberDGV, VendedoraModel vendedora)
        {
            DataRow row = null;
            if (titulosReceberDGV.Any())
            {
                foreach (TituloReceberModel model in titulosReceberDGV)
                {
                    if (vendedora == null)
                    {
                        vendedora = _vendedoraServices.GetById(model.VendedoraId);
                    }
                    row = tableTitulos.NewRow();
                    row["CodigoTituloColumn"] = int.Parse(model.TituloId.ToString());
                    row["NomeVendedoraTituloColumn"] = vendedora.Nome;
                    row["CpfVendedoraTituloColumn"] = vendedora.Cpf;
                    row["DataVencimentoTituloColumn"] = model.DataVencimento;
                    row["ValorTituloColumn"] = model.ValorTitulo;
                    row["StatusTituloColumn"] = model.StatusTitulo;

                    tableTitulos.Rows.Add(row);
                }
            }
        }
        private void ConfiguraDataGridTitulos(DataTable tableTitulos)
        {
            dgvTitulosReceber.DataSource = tableTitulos;

            dgvTitulosReceber.Columns["CodigoTituloColumn"].HeaderText = "Código";
            dgvTitulosReceber.Columns["NomeVendedoraTituloColumn"].HeaderText = "Vendedora";
            dgvTitulosReceber.Columns["CpfVendedoraTituloColumn"].HeaderText = "CPF";
            dgvTitulosReceber.Columns["DataVencimentoTituloColumn"].HeaderText = "Vencimento";
            dgvTitulosReceber.Columns["ValorTituloColumn"].HeaderText = "Valor";
            dgvTitulosReceber.Columns["StatusTituloColumn"].HeaderText = "Status";

            dgvTitulosReceber.ForeColor = Color.Black;
        }

        private void ReadModelsList()
        {
            ListTitulos = (List<TituloReceberModel>)_tituloReceberServices.GetAll();
        }
        private IEnumerable<TituloReceberModel> ConfiguraDGVByStatus(StatusTitulo status, IEnumerable<TituloReceberModel> titulosReceberDGV)
        {
            switch (status)
            {
                case StatusTitulo.Aberto:
                    titulosReceberDGV = titulosReceberDGV.Where(statusTit => statusTit.StatusTitulo == StatusTitulo.Aberto);
                    break;
                case StatusTitulo.Liquidado:
                    titulosReceberDGV = titulosReceberDGV.Where(statusTit => statusTit.StatusTitulo == StatusTitulo.Liquidado);
                    break;
                case StatusTitulo.Vencido:
                    titulosReceberDGV = titulosReceberDGV.Where(statusTit => statusTit.StatusTitulo == StatusTitulo.Vencido);
                    break;
                case StatusTitulo.Cancelado:
                    titulosReceberDGV = titulosReceberDGV.Where(statusTit => statusTit.StatusTitulo == StatusTitulo.Cancelado);
                    break;
                case StatusTitulo.Protestado:
                    titulosReceberDGV = titulosReceberDGV.Where(statusTit => statusTit.StatusTitulo == StatusTitulo.Protestado);
                    break;
                default:
                    break;
            }

            return titulosReceberDGV;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string cpf = mTextCpf.Text.Replace(".", "");
            cpf = cpf.Replace("-", "");
            cpf = cpf.Replace(" ", "");
            LoadContasReceberDGV(StatusTitulo.Aberto, cbMes.SelectedIndex, cpf);
            //if (cbMes.SelectedIndex > 0)
            //{
            //    //TODO: Fazer um loadTitulos com os parametros de mes e do radiobutton selecionado.
            //    //titulosReceberDGV = ListTitulos;
            //    //titulosReceberDGV = titulosReceberDGV.Where(mes => mes.DataRegistro.Month == cbMes.SelectedIndex + 1);
            //    //titulosReceberDGV = ConfiguraDGVByStatus(status, titulosReceberDGV);
            //    LoadContasReceberDGV(StatusTitulo.Aberto, cbMes.SelectedIndex + 1, null);
            //}

            //if (!string.IsNullOrEmpty(cpf))
            //{
            //    //titulosReceberDGV = titulosReceberDGV.Where(vendTit => vendTit.VendedoraId == _vendedoraServices.GetByCpf(cpf).VendedoraId);
            //    LoadContasReceberDGV(StatusTitulo.Aberto, null, cpf);
            //}

            //LoadTableTitulos();

        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {

            ContasReceberForm_Load(sender, e);
            UncheckRadioButtons();
            cbMes.SelectedIndex = -1;
            LoadContasReceberDGV(StatusTitulo.Aberto, null, null);
        }

        private void UncheckRadioButtons()
        {
            rbAberto.Checked = true;
            rbVencido.Checked = false;
            rbLiquidado.Checked = false;
            rbProtestado.Checked = false;

        }
        private void rbAberto_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAberto.Checked)
            {
                LoadContasReceberDGV(StatusTitulo.Aberto, cbMes.SelectedIndex, null);
                //titulosReceberDGV = titulosReceberDGV.Where(mes => mes.DataVencimento.Month == cbMes.SelectedIndex + 1);
                //titulosReceberDGV = titulosReceberDGV.Where(status => status.StatusTitulo == StatusTitulo.Aberto);
                LoadTableTitulos(null);
            }
        }

        private void rbVencido_CheckedChanged(object sender, EventArgs e)
        {
            if (rbVencido.Checked)
            {
                LoadContasReceberDGV(StatusTitulo.Vencido, cbMes.SelectedIndex, null);
                //titulosReceberDGV = titulosReceberDGV.Where(mes => mes.DataVencimento.Month == cbMes.SelectedIndex + 1);
                //titulosReceberDGV = titulosReceberDGV.Where(status => status.StatusTitulo == StatusTitulo.Vencido);
                LoadTableTitulos(null);
            }
        }

        private void rbLiquidado_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLiquidado.Checked)
            {
                LoadContasReceberDGV(StatusTitulo.Liquidado, cbMes.SelectedIndex, null);
                //titulosReceberDGV = titulosReceberDGV.Where(mes => mes.DataVencimento.Month == cbMes.SelectedIndex + 1);
                //titulosReceberDGV = titulosReceberDGV.Where(status => status.StatusTitulo == StatusTitulo.Liquidado);
                LoadTableTitulos(null);
            }
        }

        private void rbProtestado_CheckedChanged(object sender, EventArgs e)
        {
            if (rbProtestado.Checked)
            {
                LoadContasReceberDGV(StatusTitulo.Protestado, cbMes.SelectedIndex, null);
                //titulosReceberDGV = titulosReceberDGV.Where(mes => mes.DataVencimento.Month == cbMes.SelectedIndex + 1);
                //titulosReceberDGV = titulosReceberDGV.Where(status => status.StatusTitulo == StatusTitulo.Protestado);
                LoadTableTitulos(null);
            }
        }
    }
}
