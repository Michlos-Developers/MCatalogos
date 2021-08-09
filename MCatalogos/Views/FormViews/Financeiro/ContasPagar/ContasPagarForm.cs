using DomainLayer.Models.CommonModels.Enums;
using DomainLayer.Models.Fornecedores;
using DomainLayer.Models.TitulosPagar;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Specific.Fornecedor;
using InfrastructureLayer.DataAccess.Repositories.Specific.TituloPagar;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.FornecedorServices;
using ServiceLayer.Services.TitulosPagarServices;

using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace MCatalogos.Views.FormViews.Financeiro.ContasPagar
{
    public partial class ContasPagarForm : Form
    {
        #region INSTANCE TREATMENT
        private static ContasPagarForm aForm = null;
        internal static ContasPagarForm Instance(FinanceiroForm financeiroForm)
        {
            if (aForm == null)
            {
                aForm = new ContasPagarForm(financeiroForm);
            }
            else
            {
                aForm.BringToFront();
            }
            return aForm;
        }
        private void ContasPagarForm_FormClosing(object sender, FormClosingEventArgs e)
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

        /// <summary>
        /// List de Contas a Pagar
        /// </summary>
        private List<TituloPagarModel> ListTitulos = new List<TituloPagarModel>();

        private TituloPagarModel SelectedTitulo = new TituloPagarModel();

        //SERVICES
        private QueryStringServices _queryStringServices;
        private TituloPagarServices _tituloPagarServices;
        private FornecedorServices _fornecedorServices;

        #endregion

        private IEnumerable<TituloPagarModel> titulosPagarDGV;
        private StatusTitulo status = StatusTitulo.Aberto;
        private int indexDGV = 0;

        private FinanceiroForm FinanceiroForm;
        private List<string> MonthsList = new List<string>();
        
        public ContasPagarForm(FinanceiroForm financeiroForm)
        {
            _queryStringServices = new QueryStringServices(new QueryString());
            _tituloPagarServices = new TituloPagarServices(new TituloPagarRepository(_queryStringServices.GetQueryApp()), new ModelDataAnnotationCheck());
            _fornecedorServices = new FornecedorServices(new FornecedorRepository(_queryStringServices.GetQueryApp()), new ModelDataAnnotationCheck());

            InitializeComponent();
            FinanceiroForm = financeiroForm;
        }
        private void ContasPagarForm_Load(object sender, EventArgs e)
        {
            LoadComboBoxMonths();
            LoadContasPagarDGV();
            ReadModelsList();
        }

        private void ReadModelsList()
        {
            ListTitulos = (List<TituloPagarModel>)_tituloPagarServices.GetAll();

        }

        private void LoadContasPagarDGV()
        {
            int currentMonth = DateTime.ParseExact(cbMesComercial.SelectedValue.ToString(), "MMMM", CultureInfo.CurrentCulture).Month;
            
            titulosPagarDGV = ListTitulos;

            titulosPagarDGV = titulosPagarDGV.Where(mes => mes.DataRegistro.Month == currentMonth);

            titulosPagarDGV = ConfiguraDGVByStatus(status, titulosPagarDGV);

            DataTable tableTitulos = ModelaDataTableTitulos();
            ModelaDataRowTableTitulos(tableTitulos, titulosPagarDGV);
            ConfiguraDataGridTitulos(tableTitulos);

        }

        private void ConfiguraDataGridTitulos(DataTable tableTitulos)
        {
            dgvContasPagar.DataSource = tableTitulos;

            dgvContasPagar.Columns["CodigoTituloColumn"].HeaderText = "Código";
            dgvContasPagar.Columns["CodigoTituloColumn"].Width = 80;
            dgvContasPagar.Columns["FornecedorNomeColumn"].HeaderText = "Fornecedor";
            dgvContasPagar.Columns["FornecedorNomeColumn"].Width = 325
                ;
            dgvContasPagar.Columns["DataVencColumn"].HeaderText = "Vencimento";
            dgvContasPagar.Columns["ValorTituloColumn"].HeaderText = "Valor";
            dgvContasPagar.Columns["ParceladoBoolColumn"].HeaderText = "Parcelado";
            dgvContasPagar.Columns["QtdParcelas"].HeaderText = "QTD. Parc.";
            dgvContasPagar.Columns["StatusColumn"].HeaderText = "Status";

            dgvContasPagar.ForeColor = Color.Black;

            
        }

        private void ModelaDataRowTableTitulos(DataTable tableTitulos, IEnumerable<TituloPagarModel> titulosPagarDGV)
        {
            DataRow row = null;
            if (titulosPagarDGV.Any())
            {
                foreach (TituloPagarModel model in titulosPagarDGV)
                {
                    row = tableTitulos.NewRow();
                    row["CodigoTituloColumn"] = int.Parse(model.TituloId.ToString());
                    row["FornecedorNomeColumn"] = _fornecedorServices.GetById(model.FornecedorId).NomeFantasia;
                    row["DataVencColumn"] = model.DataVencimento;
                    row["ValorTituloColumn"] = model.ValorTitulo;
                    row["ParceladoBoolColumn"] = model.Parcelado ? "SIM" : "NÃO";
                    row["QtdParcelas"] = int.Parse(model.QtdParcelas.ToString());
                    row["StatusColumn"] = model.StatusTitulo; //TODO: ver se tem que fazer como pedido.

                    tableTitulos.Rows.Add(row);
                }
            }

            //return row;
        }


        private DataTable ModelaDataTableTitulos()
        {
            DataTable table = new DataTable();

            table.Columns.Add("CodigoTituloColumn", typeof(int));
            table.Columns.Add("FornecedorNomeColumn", typeof(string));
            table.Columns.Add("DataVencColumn", typeof(DateTime));
            table.Columns.Add("ValorTituloColumn", typeof(string));
            table.Columns.Add("ParceladoBoolColumn", typeof(string));
            table.Columns.Add("QtdParcelas", typeof(int));
            table.Columns.Add("StatusColumn", typeof(string));

            return table;


        }

        private IEnumerable<TituloPagarModel> ConfiguraDGVByStatus(StatusTitulo status, IEnumerable<TituloPagarModel> titulosPagarDGV)
        {
            switch (status)
            {
                case StatusTitulo.Aberto:
                    titulosPagarDGV = titulosPagarDGV.Where(statusPed => statusPed.StatusTitulo == StatusTitulo.Aberto);
                    break;
                case StatusTitulo.Liquidado:
                    titulosPagarDGV = titulosPagarDGV.Where(statusPed => statusPed.StatusTitulo == StatusTitulo.Liquidado);
                    break;
                case StatusTitulo.Vencido:
                    titulosPagarDGV = titulosPagarDGV.Where(statusPed => statusPed.StatusTitulo == StatusTitulo.Vencido);
                    break;
                case StatusTitulo.Cancelado:
                    titulosPagarDGV = titulosPagarDGV.Where(statusPed => statusPed.StatusTitulo == StatusTitulo.Cancelado);
                    break;
                case StatusTitulo.Protestado:
                    titulosPagarDGV = titulosPagarDGV.Where(statusPed => statusPed.StatusTitulo == StatusTitulo.Protestado);
                    break;
                default:
                    break;
            }

            return titulosPagarDGV;
        }

        private void LoadComboBoxMonths()
        {

            for (int i = 1; i <= 13; i++)
            {
                MonthsList.Add(DateTimeFormatInfo.CurrentInfo.GetMonthName(i).ToUpper());
            }

            cbMesComercial.DataSource = MonthsList;
            cbMesComercial.SelectedItem = DateTimeFormatInfo.CurrentInfo.GetMonthName(DateTime.Now.Month).ToUpper();
        }
        private void cbMesComercial_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #region EVENT BUTTONS
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnGerar_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnPagar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region RADION BUTTONS EVENTS
        private void rbAberto_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbVencido_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbLiquidado_CheckedChanged(object sender, EventArgs e)
        {

        }

        #endregion

    }

}
