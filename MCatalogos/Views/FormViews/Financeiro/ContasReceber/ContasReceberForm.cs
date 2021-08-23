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
            LoadComboBoxMonths();
            LoadContasReceberDGV();
            ReadModelsList();
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

        private void LoadContasReceberDGV()
        {
            int currentMonth = DateTime.ParseExact(cbMes.SelectedValue.ToString(), "MMMM", CultureInfo.CurrentCulture).Month;
            titulosReceberDGV = ListTitulos;
            titulosReceberDGV = titulosReceberDGV.Where(mes => mes.DataRegistro.Month == currentMonth);
            titulosReceberDGV = ConfiguraDGVByStatus(status, titulosReceberDGV);
            
            
            DataTable tableTitulos = ModelaDataTableTitulos();
            ModelaDataRowTableTitulos(tableTitulos, titulosReceberDGV);
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
        private void ModelaDataRowTableTitulos(DataTable tableTitulos, IEnumerable<TituloReceberModel> titulosReceberDGV)
        {
            DataRow row = null;
            if (titulosReceberDGV.Any())
            {
                foreach (TituloReceberModel model in titulosReceberDGV)
                {
                    VendedoraModel vendeddora = new VendedoraModel();
                    vendeddora = _vendedoraServices.GetById(model.VendedoraId);
                    row = tableTitulos.NewRow();
                    row["CodigoTituloColumn"] = int.Parse(model.TituloId.ToString());
                    row["NomeVendedoraTituloColumn"] = vendeddora.Nome;
                    row["CpfVendedoraTituloColumn"] = vendeddora.Cpf;
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

    }
}
