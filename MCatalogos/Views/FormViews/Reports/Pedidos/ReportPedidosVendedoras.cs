using DomainLayer.Models.PedidosVendedoras;
using DomainLayer.Models.Reports.Pedidos;
using DomainLayer.Models.Vendedora;

using ServiceLayer.Services;
using ServiceLayer.CommonServices;
using ServiceLayer.Services.DetalhePedidoServices;
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
using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Specific.PedidoVendedora;
using DomainLayer.Models.Distribuidor;
using ServiceLayer.Services.DistribuidorServices;
using InfrastructureLayer.DataAccess.Repositories.Specific.Distribuidor;
using ServiceLayer.Services.RotaServices;
using InfrastructureLayer.DataAccess.Repositories.Specific.Vendedora;
using Microsoft.Reporting.WinForms;
using DomainLayer.Models.Catalogos;
using ServiceLayer.Services.CatalogoServices;
using InfrastructureLayer.DataAccess.Repositories.Specific.Catalogo;

namespace MCatalogos.Views.FormViews.Reports.Pedidos
{
    public partial class ReportPedidosVendedoras : Form
    {
        /// <summary>
        /// SERVICES
        /// </summary>
        QueryStringServices _querystring;
        DetalhePedidoSerivces _detalhePedidoServices;
        PedidosVendedorasServices _pedidosVendedorasServices;
        DistribuidorServices _distribuidorServices;
        RotaLetraServices _rotaLetraServices;
        RotaServices _rotaServices;
        CatalogoServices _catalogoServices;

        /// <summary>
        /// MODELS LIST
        /// </summary>
        IEnumerable<PedidosVendedorasModel> pedidosHeader;
        IEnumerable<RotaModel> rotasModelList;
        IEnumerable<RotaLetraModel> rotasLetrasModelList;
        IEnumerable<DetalhePedidoModel> detalhesPedido;
        IEnumerable<CatalogoModel> catalogosModelList;
        IEnumerable<VendedoraModel> vendedorasList;
        List<ReportPedidosVendedorasModel> pedidosReportModelList = new List<ReportPedidosVendedorasModel>();


        /// <summary>
        /// MODELS SINGLE
        /// </summary>
        DistribuidorModel distribuidor = new DistribuidorModel();



        /// <summary>
        /// GLOBAL VARIABLES
        /// </summary>
        int monthSelectedReport = 0;
        bool printPromissoriasReport = false;


        /// <summary>
        /// REPORT DATA SOURCE 
        /// </summary>
        private ReportDataSource RDSReportPedidosModel = new ReportDataSource();



        public ReportPedidosVendedoras(IEnumerable<VendedoraModel> vendedoras, int monthReport, bool printPromissorias)
        {

            ///INCIALIZING SERVICES
            _querystring = new QueryStringServices(new QueryString());
            _pedidosVendedorasServices = new PedidosVendedorasServices(new PedidoVendedoraRepository(_querystring.GetQueryApp()), new ModelDataAnnotationCheck());
            _distribuidorServices = new DistribuidorServices(new DistribuidorRepository(_querystring.GetQueryApp()), new ModelDataAnnotationCheck());
            _rotaLetraServices = new RotaLetraServices(new RotaLetraRepository(_querystring.GetQueryApp()), new ModelDataAnnotationCheck());
            _rotaServices = new RotaServices(new RotaRepository(_querystring.GetQueryApp()), new ModelDataAnnotationCheck());
            _detalhePedidoServices = new DetalhePedidoSerivces(new DetalhePedidoRepository(_querystring.GetQueryApp()), new ModelDataAnnotationCheck());
            _catalogoServices = new CatalogoServices(new CatalogoRepository(_querystring.GetQueryApp()), new ModelDataAnnotationCheck());


            InitializeComponent();

            ///EXTERNAL PROPERTIES RECEIVED
            vendedorasList = vendedoras;
            monthSelectedReport = monthReport;
            printPromissoriasReport = printPromissorias;
        }

        private void ReportPedidosVendedoras_Load(object sender, EventArgs e)
        {
            LoadModels();
            LoadPedidosModelReport();

            RDSReportPedidosModel.Name = "DSReportPedidosVendedoras";
            RDSReportPedidosModel.Value = LoadDataTableReportPedidosVendedora(pedidosReportModelList);


            reportView.LocalReport.DataSources.Add(RDSReportPedidosModel);
            reportView.LocalReport.ReportEmbeddedResource = "MCatalogos.Reports.Pedidos.ReportPedidosVendedoras.rdlc";



            reportView.SetDisplayMode(DisplayMode.PrintLayout);
            reportView.ZoomMode = ZoomMode.Percent;
            reportView.ZoomPercent = 75;
            this.reportView.RefreshReport();
        }

        private object LoadDataTableReportPedidosVendedora(List<ReportPedidosVendedorasModel> pedidosReportModelList)
        {
            DataTable table = new DataTable();
            DataRow row = null;

            table.Columns.Add("DistribuidorId", typeof(int));
            table.Columns.Add("DistribuidorNome", typeof(string));
            table.Columns.Add("VendedoraId", typeof(int));
            table.Columns.Add("VendedoraNome", typeof(string));
            table.Columns.Add("RotaLetraIdVendedora", typeof(int));
            table.Columns.Add("RotaLetraVendedora", typeof(string));
            table.Columns.Add("RotaNumeroIdVendedora", typeof(int));
            table.Columns.Add("RotaNumeroVendedora", typeof(string));
            table.Columns.Add("CatalogoId", typeof(int));
            table.Columns.Add("CatalogoNome", typeof(string));
            table.Columns.Add("PedidoId", typeof(int));
            table.Columns.Add("PedidoValorTotal", typeof(double));
            table.Columns.Add("PedidoValorLucroVendedora", typeof(double));
            table.Columns.Add("PedidoValorTotalPagar", typeof(double));
            table.Columns.Add("DataRegistroPedido", typeof(DateTime));
            table.Columns.Add("DataVencimento", typeof(DateTime));
            table.Columns.Add("DetalhePedidoId", typeof(int));
            table.Columns.Add("DetalheProdutoId", typeof(int));
            table.Columns.Add("DetalheProdutoReferencia", typeof(string));
            table.Columns.Add("DetalheProdutoDescricao", typeof(string));
            table.Columns.Add("DetalheProdutoValor", typeof(double));
            table.Columns.Add("DetalheMargemVendedora", typeof(double));
            table.Columns.Add("DetalheQuantidade", typeof(int));
            table.Columns.Add("DetalheValorTotalItem", typeof(double));
            table.Columns.Add("DetalheValorTotalBruto", typeof(double));
            table.Columns.Add("DetalheValorTotalLiquido", typeof(double));
            table.Columns.Add("DetalheFalta", typeof(bool));




            table.Clear();
            foreach (var item in pedidosReportModelList)
            {
                row = table.NewRow();

                row["DistribuidorId"] = item.DistribuidorId;
                row["DistribuidorNome"] = item.DistribuidorNome;
                row["VendedoraId"] = item.VendedoraId;
                row["VendedoraNome"] = item.VendedoraNome;
                row["RotaLetraIdVendedora"] = item.RotaLetraIdVendedora;
                row["RotaLetraVendedora"] = item.RotaLetraVendedora;
                row["RotaNumeroIdVendedora"] = item.RotaNumeroIdVendedora;
                row["RotaNumeroVendedora"] = item.RotaNumeroVendedora;
                row["CatalogoId"] = item.CatalogoId;
                row["CatalogoNome"] = item.CatalogoNome;
                row["PedidoId"] = item.PedidoId;
                row["PedidoValorTotal"] = item.PedidoValorTotal;
                row["PedidoValorLucroVendedora"] = item.PedidoValorLucroVendedora;
                row["PedidoValorTotalPagar"] = item.PedidoValorTotalPagar;
                row["DataRegistroPedido"] = item.DataRegistroPedido;
                row["DataVencimento"] = item.DataVencimento;
                row["DetalhePedidoId"] = item.DetlhePedidoId;
                row["DetalheProdutoId"] = item.DetalheProdutoId;
                row["DetalheProdutoReferencia"] = item.DetalheProdutoReferencia;
                row["DetalheProdutoDescricao"] = item.DetalheProdutoDescricao;
                row["DetalheProdutoValor"] = item.DetalheProdutoValor;
                row["DetalheMargemVendedora"] = item.DetalheMargemVendedora;
                row["DetalheQuantidade"] = item.DetalheQuantidade;
                row["DetalheValorTotalItem"] = item.DetalheValorTotalItem;
                row["DetalheValorTotalBruto"] = item.DetalheValorTotalBruto;
                row["DetalheValorTotalLiquido"] = item.DetalheValorTotalLiquido;
                row["DetalheFalta"] = item.DetalheFalta;


                //row["DistribuidorId"] = int.Parse(distribuidorModel.DistribuidorId.ToString());
                //row["NomeFantasia"] = distribuidorModel.NomeFantasia.ToString();

                table.Rows.Add(row);

            }


            return table;
        }

        private void LoadModels()
        {
            pedidosHeader = (List<PedidosVendedorasModel>)_pedidosVendedorasServices.GetAll();
            detalhesPedido = (IEnumerable<DetalhePedidoModel>)_detalhePedidoServices.GetAll();
            distribuidor = _distribuidorServices.GetModel();
            rotasLetrasModelList = (IEnumerable<RotaLetraModel>)_rotaLetraServices.GetAll();
            rotasModelList = (IEnumerable<RotaModel>)_rotaServices.GetAll();
            catalogosModelList = (IEnumerable<CatalogoModel>)_catalogoServices.GetAll();
        }

        private bool VendedoraTemPedido(VendedoraModel vendedora)
        {
            foreach (PedidosVendedorasModel pedido in pedidosHeader)
            {
                if (pedido.VendedoraId == vendedora.VendedoraId)
                {
                    return true;
                }
            }

            return false;
        }
        private void LoadPedidosModelReport()
        {
            try
            {
                foreach (var vendedora in vendedorasList)
                {
                    if (vendedora.Ativa)
                    {
                        if (VendedoraTemPedido(vendedora))
                        {
                            foreach (var catalogo in catalogosModelList)
                            {
                                foreach (var item in detalhesPedido)
                                {




                                    pedidosHeader = pedidosHeader.Where(dtPedido => dtPedido.DataRegistro.Month == monthSelectedReport);
                                    pedidosHeader = pedidosHeader.Where(vend => vend.VendedoraId == vendedora.VendedoraId);
                                    if (pedidosHeader.Select(pedid => pedid.PedidoId).FirstOrDefault() == 0)
                                    {
                                        throw new Exception("Nenhum Pedido Encontrado");
                                    }
                                    rotasModelList = rotasModelList.Where(vend => vend.VendedoraId == vendedora.VendedoraId);


                                    ReportPedidosVendedorasModel pedido = new ReportPedidosVendedorasModel();

                                    ///DADS DO DISTRIBUIDOR
                                    pedido.DistribuidorId = distribuidor.DistribuidorId;
                                    pedido.DistribuidorNome = distribuidor.NomeFantasia;

                                    ///DADOS DA VENDEDORA
                                    pedido.VendedoraId = vendedora.VendedoraId;
                                    pedido.VendedoraNome = vendedora.Nome;

                                    ///DADOS DE ROTA DA VENDEDORA
                                    pedido.RotaLetraIdVendedora = vendedora.RotaLetraId;
                                    pedido.RotaLetraVendedora = rotasLetrasModelList.Where(rotaid => rotaid.RotaLetraId == pedido.RotaLetraIdVendedora).Select(letra => letra.RotaLetra).FirstOrDefault().ToString();
                                    pedido.RotaNumeroIdVendedora = rotasModelList.Select(rotaNumId => rotaNumId.RotaId).FirstOrDefault();
                                    pedido.RotaNumeroVendedora = rotasModelList.Select(rota => rota.Numero).FirstOrDefault().ToString();

                                    ///DADOS DO CATÁLOGO
                                    pedido.CatalogoId = catalogo.CatalogoId;
                                    pedido.CatalogoNome = catalogo.Nome;


                                    ///DADOS DO PEDIDO HEADER
                                    pedido.PedidoId = pedidosHeader.Select(pedid => pedid.PedidoId).FirstOrDefault();
                                    pedido.PedidoValorLucroVendedora = double.Parse(pedidosHeader.Select(valLuc => valLuc.ValorLucroVendedora).FirstOrDefault().ToString());
                                    pedido.PedidoValorTotal = double.Parse(pedidosHeader.Select(valTot => valTot.ValorTotalPedido).FirstOrDefault().ToString());
                                    pedido.PedidoValorTotalPagar = double.Parse(pedidosHeader.Select(valTotPag => valTotPag.ValorTotalPagar).FirstOrDefault().ToString());
                                    pedido.DataRegistroPedido = DateTime.Parse(pedidosHeader.Select(dataPed => dataPed.DataRegistro).FirstOrDefault().ToString());

                                    ///DADOS DOS DETALHES DO PEDIDO (ITENS)
                                    pedido.DetlhePedidoId = item.DetalheId;
                                    pedido.DetalheProdutoId = item.ProdutoId;
                                    pedido.DetalheProdutoReferencia = item.Referencia;
                                    pedido.DetalheProdutoDescricao = item.Descricao;
                                    pedido.DetalheProdutoValor = item.ValorProduto;
                                    pedido.DetalheMargemVendedora = item.MargemVendedora;
                                    pedido.DetalheQuantidade = item.Quantidade;
                                    pedido.DetalheValorTotalItem = item.ValorTotalItem;
                                    pedido.DetalheValorTotalBruto = item.ValorTotalBruto;
                                    pedido.DetalheValorTotalLiquido = item.ValorLucroVendedoraItem;
                                    pedido.DetalheFalta = item.Faltou;

                                    pedidosReportModelList.Add(pedido);

                                }

                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Não foi possível gerar o relatório.\n{e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //this.Close(); 
                //this.Dispose();
            }
        }
    }
}
