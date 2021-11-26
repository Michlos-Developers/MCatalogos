using DomainLayer.Models.PedidosVendedoras;
using DomainLayer.Models.Vendedora;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Specific.PedidoVendedora;
using InfrastructureLayer.DataAccess.Repositories.Specific.Vendedora;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.PedidosVendedorasServices;
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

namespace MCatalogos.Views.FormViews.Reports.UserControls
{
    public partial class ConfigReportPromissoriasUC : UserControl
    {
        /// <summary>
        /// PARENT CONTROL
        /// </summary>
        private ControleRelatoriosForm ControleReport;

        // <summary>
        /// MODELS LISTS
        /// SÃO PÚBLICAS PARA SEREM ENVIADAS PARA O FORMULÁRIO DE RELAÓTIO PELO BOTÃO "btnGenerateReport"
        /// </summary>
        public IEnumerable<VendedoraModel> vendedorasModelsList = new List<VendedoraModel>();
        public IEnumerable<PedidosVendedorasModel> pedidosModelsList = new List<PedidosVendedorasModel>();

        /// <summary>
        /// SERVICES
        /// </summary>
        private QueryStringServices _queryString;
        private VendedoraServices _vendedoraServices;
        private PedidosVendedorasServices _pedidosVendedorasServices;

        /// <summary>
        /// PROPRIEDADES PRÓPRIAS DA CLASSE
        /// </summary>
        private static List<string> MonthList = new List<string>();

        public ConfigReportPromissoriasUC(ControleRelatoriosForm controleRelatoriosForm)
        {
            //INITIALIZING SERVICES
            _queryString = new QueryStringServices(new QueryString());
            _vendedoraServices = new VendedoraServices(new VendedoraRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _pedidosVendedorasServices = new PedidosVendedorasServices(new PedidoVendedoraRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());

            InitializeComponent();
            ControleReport = controleRelatoriosForm;
        }

        private void ConfigReportPromissoriasUC_Load(object sender, EventArgs e)
        {
            LoadComboBoxMes();
            LoadPedidosMoedels(); 
            LoadComboBoxVendedoras();
        }

        private void LoadPedidosMoedels()
        {
            pedidosModelsList = (IEnumerable<PedidosVendedorasModel>)_pedidosVendedorasServices.GetAll();
        }

        private void LoadComboBoxVendedoras()
        {
            vendedorasModelsList = (IEnumerable<VendedoraModel>)_vendedoraServices.GetAll();
            cbVendedoras.ValueMember = "Nome";
            cbVendedoras.DisplayMember = "Nome";
            cbVendedoras.Items.Clear();
            cbVendedoras.Items.Add("== TODAS AS VENDEDORAS ==");
            foreach (VendedoraModel vendedora in vendedorasModelsList)
            {
                if (vendedora.Ativa)
                {
                    if (VendedoraTemPedido(vendedora))
                    {
                        cbVendedoras.Items.Add(vendedora);
                    }
                }
            }

            cbVendedoras.SelectedIndex = 0;
        }

        private bool VendedoraTemPedido(VendedoraModel vendedora)
        {
            foreach (PedidosVendedorasModel pedido in pedidosModelsList)
            {
                
                if (pedido.VendedoraId == vendedora.VendedoraId)
                {
                    return true;
                }
            }

            return false;
        }

 

        private void LoadComboBoxMes()
        {
            MonthList.Clear();
            for (int i = 1; i <= 13; i++)
            {
                MonthList.Add(DateTimeFormatInfo.CurrentInfo.GetMonthName(i).ToUpper());
            }

            cbMes.DataSource = MonthList;
            cbMes.SelectedItem = DateTimeFormatInfo.CurrentInfo.GetMonthName(DateTime.Now.Month).ToUpper();
        }

        private void cbVendedoras_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbVendedoras.SelectedIndex != 0)
            {
                int idVendedora = (cbVendedoras.SelectedItem as VendedoraModel).VendedoraId;
                vendedorasModelsList.Where(vendId => vendId.VendedoraId == idVendedora);
            }
        }
    }
}
