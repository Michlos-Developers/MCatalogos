using DomainLayer.Models.Catalogos;
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

namespace MCatalogos.Views.FormViews.Reports.Pedidos
{
    public partial class UCConfigReportPedido : UserControl
    {
        ReportControleForm ReportControleForm;

        private IEnumerable<VendedoraModel> ListVendedorasModels = new List<VendedoraModel>();
        private IEnumerable<PedidosVendedorasModel> ListPedidosVendedorasModels = new List<PedidosVendedorasModel>();

        private QueryStringServices _queryString;
        private VendedoraServices _vendedoraServices;
        private PedidosVendedorasServices _pedidosVendedorasServices;
        private static List<string> MonthList = new List<string>();


        public UCConfigReportPedido(ReportControleForm reportControleForm)
        {
            _queryString = new QueryStringServices(new QueryString());
            _vendedoraServices = new VendedoraServices(new VendedoraRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _pedidosVendedorasServices = new PedidosVendedorasServices(new PedidoVendedoraRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());


            InitializeComponent();
            this.ReportControleForm = reportControleForm;
        }

        private void UCConfigReportPedido_Load(object sender, EventArgs e)
        {
            LoadComboBoxMes();
            LoadPedidosModels();
            LoadComboBoxVendedoras();
        }

        /// <summary>
        /// Gera datasource de ComboBoxMes com lista de meses.
        /// </summary>
        private void LoadComboBoxMes()
        {
            for (int i = 1; i <= 13; i++)
            {
                MonthList.Add(DateTimeFormatInfo.CurrentInfo.GetMonthName(i).ToUpper());
            }

            cbMes.DataSource = MonthList;
            cbMes.SelectedItem = DateTimeFormatInfo.CurrentInfo.GetMonthName(DateTime.Now.Month).ToUpper();
        }

        /// <summary>
        /// Busca todos os pedidos existentes no sistema.
        /// CONFORME A DATA SELECIONADA NO COMBOBOX
        /// </summary>
        private void LoadPedidosModels()
        {
            ListPedidosVendedorasModels = (List<PedidosVendedorasModel>)_pedidosVendedorasServices.GetAll();
            ListPedidosVendedorasModels = ListPedidosVendedorasModels.Where(data => data.DataRegistro.Month == cbMes.SelectedIndex + 1);
        }


        /// <summary>
        /// GERA A LISTA DE VENDEDORAS ATIVAS QUE TEM PEDIDOS NO MÊS.
        /// </summary>
        private void LoadComboBoxVendedoras()
        {
            ListVendedorasModels = (List<VendedoraModel>)_vendedoraServices.GetAll();

            cbVendedora.ValueMember = "Nome";
            cbVendedora.DisplayMember = "Nome";
            cbVendedora.Items.Clear();
            cbVendedora.Items.Add("==  TODAS  ==");
            foreach (VendedoraModel vendedora in ListVendedorasModels)
            {
                if (vendedora.Ativa)
                {
                    if (VendedoraTemPedido(vendedora))
                    {
                        cbVendedora.Items.Add(vendedora);
                    }
                }
            }
            cbVendedora.SelectedIndex = 0;
        }


        /// <summary>
        /// VERIFICA SE A VENDEDORA TEM PEDIDO REGISTRADO NA LISTA DE PEDIDOS GERADA DO MES SELECIONADO
        /// </summary>
        /// <param name="vendedora"></param>
        /// <returns></returns>
        private bool VendedoraTemPedido(VendedoraModel vendedora)
        {
            foreach (PedidosVendedorasModel pedido in ListPedidosVendedorasModels)
            {
                if (pedido.VendedoraId == vendedora.VendedoraId)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
