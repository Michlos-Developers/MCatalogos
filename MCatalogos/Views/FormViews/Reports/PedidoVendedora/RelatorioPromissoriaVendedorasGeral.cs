using CommonComponents;

using DomainLayer.Models.Distribuidor;
using DomainLayer.Models.PedidosVendedoras;
using DomainLayer.Models.Reports.PedidosVendedoras;
using DomainLayer.Models.Vendedora;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Commons;
using InfrastructureLayer.DataAccess.Repositories.Specific.Distribuidor;
using InfrastructureLayer.DataAccess.Repositories.Specific.PedidoVendedora;

using Microsoft.Reporting.WinForms;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.CidadeServices;
using ServiceLayer.Services.DistribuidorServices;
using ServiceLayer.Services.PedidosVendedorasServices;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCatalogos.Views.FormViews.Reports.PedidoVendedora
{
    public partial class RelatorioPromissoriaVendedorasGeral : Form
    {
        //SERVICES
        private QueryStringServices _queryString;
        private PedidosVendedorasServices _pedidosServices;
        private DistribuidorServices _distribuidorServices;
        private CidadeServices _cidadesServices;

        //LIST MODELS
        private IEnumerable<VendedoraModel> VendedoraListModel = new List<VendedoraModel>();
        private IEnumerable<IPedidosVendedorasModel> pedidosListModel;
        private List<IRelatorioPromissoriasModel> relatorioPromissoriasModels = new List<IRelatorioPromissoriasModel>();

        //LOCAL PROPERTIES
        private int SelectedMonth;
        private DistribuidorModel distribuidorModel = new DistribuidorModel();
        
        public RelatorioPromissoriaVendedorasGeral(IEnumerable<VendedoraModel> vendedorasList, int selectedMonth)
        {
            LoadListModelServices();

            InitializeComponent();
            SelectedMonth = selectedMonth;
            VendedoraListModel = vendedorasList;
        }

        private void LoadListModelServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _pedidosServices = new PedidosVendedorasServices(new PedidoVendedoraRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _distribuidorServices = new DistribuidorServices(new DistribuidorRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _cidadesServices = new CidadeServices(new CidadeRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());

        }

        private void RelatorioPromissoriaVendedorasGeral_Load(object sender, EventArgs e)
        {
            LoadModelsEnum();
            LoadModelReport();

            var dataSource = new ReportDataSource("DSRelatorioPromissoriasGeral", relatorioPromissoriasModels);
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(dataSource);
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            reportViewer.RefreshReport();
        }

        private void LoadModelReport()
        {
            foreach (var vendedora in VendedoraListModel)
            {
                IEnumerable<IPedidosVendedorasModel> pedidoHeader = pedidosListModel.Where(vend => vend.VendedoraId == vendedora.VendedoraId).Where(dtPed => dtPed.DataRegistro.Month == SelectedMonth);
                foreach (var pedido in pedidoHeader)
                {
                    RelatorioPromissoriasModel relProm = new RelatorioPromissoriasModel();
                    relProm.PedidoId = pedido.PedidoId;
                    relProm.DataEmissao = DateTime.Parse($"{pedido.DataRegistro.Year}/{pedido.DataRegistro.Month}/28");
                    relProm.ValorPagar = (double)pedido.ValorTotalPagar;
                    relProm.DataVencimento = pedido.DataVencimento;
                    relProm.VendedoraId = pedido.VendedoraId;
                    relProm.VendedoraCpf = string.Format(@"{0:000\.000\.000\-00}", long.Parse(vendedora.Cpf));
                    relProm.VendedoraNome = vendedora.Nome;
                    relProm.VendedoraEndereco = $"{vendedora.Logradouro}, {vendedora.Numero}, {vendedora.Complemento}";
                    relProm.DistribuidorCidade = _cidadesServices.GetById(distribuidorModel.CidadeId).Nome;
                    relProm.DistribuidorRazao = distribuidorModel.RazaoSocial;
                    relProm.DistribuidorCnpj = string.Format(@"{0:00\.000\.000\/0000\-00}", long.Parse(distribuidorModel.Cnpj));
                    relProm.ExtensoValor = WriteCurrencyValue.GetExtesionValue((double)pedido.ValorTotalPagar).ToUpper();
                    relProm.ExtensoDataVencimento = WriteDateTime.GetCompleteDate(pedido.DataVencimento).ToUpper();

                    relatorioPromissoriasModels.Add(relProm);
                }
            }
        }

        private void LoadModelsEnum()
        {

            pedidosListModel = _pedidosServices.GetAll();
            distribuidorModel = _distribuidorServices.GetModel();
        }
    }
}
