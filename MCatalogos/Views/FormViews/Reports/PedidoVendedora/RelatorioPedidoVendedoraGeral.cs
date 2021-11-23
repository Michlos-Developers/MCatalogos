using DomainLayer.Models.Catalogos;
using DomainLayer.Models.PedidosVendedoras;
using DomainLayer.Models.Reports.PedidosVendedoras;
using DomainLayer.Models.Vendedora;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Specific.Catalogo;
using InfrastructureLayer.DataAccess.Repositories.Specific.PedidoVendedora;
using InfrastructureLayer.DataAccess.Repositories.Specific.Vendedora;

using Microsoft.Reporting.WinForms;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.CatalogoServices;
using ServiceLayer.Services.DetalhePedidoServices;
using ServiceLayer.Services.PedidosVendedorasServices;
using ServiceLayer.Services.RotaServices;

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
    public partial class RelatorioPedidoVendedoraGeral : Form
    {
        //SERVICES
        private QueryStringServices _queryStringServices;
        private CatalogoServices _catalogoServices;
        private PedidosVendedorasServices _pedidosServices;
        private DetalhePedidoSerivces _detalhesServices;
        private RotaLetraServices _rotaLetraServices;
        private RotaServices _rotaNumeroServices;

        //LIST MODELS
        private IEnumerable<ICatalogoModel> catalogosListModel;
        private IEnumerable<IPedidosVendedorasModel> pedidosListModel;
        private IEnumerable<IDetalhePedidoModel> detalheListModel;
        private IEnumerable<IRotaLetraModel> rotaLetraListModel;
        private IEnumerable<IRotaModel> rotaNumeroListModel;

        private List<IRelatorioPedidosVendedorasMasterModel> relatorioMaster = new List<IRelatorioPedidosVendedorasMasterModel>();
        private List<IRelatorioPedidosVendedorasDetalhesModel> relatorioDetalhe = new List<IRelatorioPedidosVendedorasDetalhesModel>();



        private IEnumerable<VendedoraModel> vendedorasList;
        private int selectedMonth;
        private bool printPromissorias;

        public RelatorioPedidoVendedoraGeral(IEnumerable<VendedoraModel> vendedorasList, int selectedMonth, bool printPromissorias)
        {
            _queryStringServices = new QueryStringServices(new QueryString());
            _catalogoServices = new CatalogoServices(new CatalogoRepository(_queryStringServices.GetQueryApp()), new ModelDataAnnotationCheck());
            _pedidosServices = new PedidosVendedorasServices(new PedidoVendedoraRepository(_queryStringServices.GetQueryApp()), new ModelDataAnnotationCheck());
            _detalhesServices = new DetalhePedidoSerivces(new DetalhePedidoRepository(_queryStringServices.GetQueryApp()), new ModelDataAnnotationCheck());
            _rotaLetraServices = new RotaLetraServices(new RotaLetraRepository(_queryStringServices.GetQueryApp()), new ModelDataAnnotationCheck());
            _rotaNumeroServices = new RotaServices(new RotaRepository(_queryStringServices.GetQueryApp()), new ModelDataAnnotationCheck());


            InitializeComponent();
            this.vendedorasList = vendedorasList;
            this.selectedMonth = selectedMonth;
            this.printPromissorias = printPromissorias;

            reportViewer.LocalReport.SubreportProcessing += LocalReport_SubreportProcessing;
        }

        private void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            var dataSource = new ReportDataSource("DSPedidoVendedoraDetalhe", relatorioDetalhe);
            //e.DataSources.Clear();
            e.DataSources.Add(dataSource);
        }

        private void RelatorioPedidoVendedoraGeral_Load(object sender, EventArgs e)
        {
            LoadListModelsEnums();
            LoadModelsReport();

            var dataSource = new ReportDataSource("DSPedidoVendedoraHeader", relatorioMaster);
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(dataSource);
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;

            reportViewer.RefreshReport();
        }

        private void LoadModelsReport()
        {
            foreach (var vendedora in this.vendedorasList)
            {
                string rotaLetra = _rotaLetraServices.GetById(vendedora.RotaLetraId).RotaLetra;
                string rotaNumero = _rotaNumeroServices.GetByVendedoraId(vendedora.VendedoraId).Numero.ToString();
                IEnumerable<IPedidosVendedorasModel> pedidoHeader = pedidosListModel.Where(vend => vend.VendedoraId == vendedora.VendedoraId).Where(dtPed => dtPed.DataRegistro.Month == selectedMonth);
                foreach (var pedido in pedidoHeader)
                {
                    //ATRIBUINDO MODEL HEADER DO RELATÓRIO
                    RelatorioPedidosVendedorasMasterModel relMaster = new RelatorioPedidosVendedorasMasterModel();
                    relMaster.PedidoId = pedido.PedidoId;
                    relMaster.PedidoValorTotal = (double)pedido.ValorTotalPedido;
                    relMaster.PedidoValorTotalPagar = (double)pedido.ValorTotalPagar;
                    relMaster.PedidoValorLucroVendedora = (double)pedido.ValorLucroVendedora;
                    relMaster.PedidoDataVencimento = pedido.DataVencimento;
                    relMaster.VendedoraNome = vendedora.Nome;
                    relMaster.VendedoraRota = $"{rotaLetra}-{rotaNumero}";
                    relatorioMaster.Add(relMaster);

                    IEnumerable<IDetalhePedidoModel> pedidoDetalhe = detalheListModel.Where(ped => ped.PedidoId == pedido.PedidoId);
                    foreach (var detalhe in pedidoDetalhe)
                    {
                        RelatorioPedidosVendedorasDetalhesModel relDetalhe = new RelatorioPedidosVendedorasDetalhesModel();
                        relDetalhe.PedidoId = detalhe.PedidoId;
                        relDetalhe.CatalogoNome = catalogosListModel.Where(catId => catId.CatalogoId == detalhe.CatalogoId).Select(catNom => catNom.Nome).FirstOrDefault();
                        relDetalhe.ItemReferencia = detalhe.Referencia;
                        relDetalhe.ItemDescricao = detalhe.Descricao;
                        relDetalhe.ItemQuantidade = detalhe.Quantidade;
                        relDetalhe.ItemValorUnitario = detalhe.Faltou ? 0 : detalhe.ValorProduto;
                        relDetalhe.ItemValorTotal = detalhe.Faltou ? 0 : detalhe.ValorTotalItem;
                        relDetalhe.ItemMargemVendedora = detalhe.MargemVendedora;
                        relDetalhe.ItemLucroVendedora = detalhe.Faltou ? 0 : detalhe.ValorLucroVendedoraItem;
                        relDetalhe.ItemFalta = detalhe.Faltou ? "F" : string.Empty;
                        relatorioDetalhe.Add(relDetalhe);

                    }
                }
            }
        }

        private void LoadListModelsEnums()
        {
            catalogosListModel = _catalogoServices.GetAll();
            pedidosListModel = _pedidosServices.GetAll();
            detalheListModel = _detalhesServices.GetAll();
            rotaLetraListModel = _rotaLetraServices.GetAll();
            rotaNumeroListModel = _rotaNumeroServices.GetAll();
        }
    }
}
