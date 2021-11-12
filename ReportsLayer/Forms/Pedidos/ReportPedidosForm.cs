using DomainLayer.Models.Catalogos;
using DomainLayer.Models.Distribuidor;
using DomainLayer.Models.PedidosVendedoras;
using DomainLayer.Models.Produtos;
using DomainLayer.Models.Reports.Pedidos;
using DomainLayer.Models.Vendedora;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Specific.Catalogo;
using InfrastructureLayer.DataAccess.Repositories.Specific.Distribuidor;
using InfrastructureLayer.DataAccess.Repositories.Specific.PedidoVendedora;
using InfrastructureLayer.DataAccess.Repositories.Specific.Produto;

using Microsoft.Reporting.WinForms;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.CatalogoServices;
using ServiceLayer.Services.DetalhePedidoServices;
using ServiceLayer.Services.DistribuidorServices;
using ServiceLayer.Services.PedidosVendedorasServices;
using ServiceLayer.Services.ProdutoServices;

using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportsLayer.Forms.Pedidos
{
    public partial class ReportPedidosForm : Form
    {
        /// <summary>
        /// SERVICES
        /// </summary>
        private QueryStringServices _queryString;
        private DistribuidorServices _distribuidorServices;
        private CatalogoServices _catalogoSercices;
        private CampanhaServices _campanhaServices;
        private PedidosVendedorasServices _pedidosVendedorasServices;
        private DetalhePedidoSerivces _detalhesPedidoServices;
        private ProdutoServices _produtoServices;


        /// <summary>
        /// MODELS LISTS
        /// </summary>
        private IEnumerable<VendedoraModel> VendedorasModelsList = new List<VendedoraModel>();
        private IEnumerable<CatalogoModel> CatalogosModelsList = new List<CatalogoModel>();
        private IEnumerable<CampanhaModel> CampanhasModelsList = new List<CampanhaModel>();
        private IEnumerable<PedidosVendedorasModel> PedidosModelsList = new List<PedidosVendedorasModel>();
        private IEnumerable<DetalhePedidoModel> DetalhesModelsList = new List<DetalhePedidoModel>();
        private IEnumerable<ProdutoModel> ProdutosModelsList = new List<ProdutoModel>();

        /// <summary>
        /// MODELS SINGLES
        /// </summary>
        private DistribuidorModel distribuidorModel = new DistribuidorModel();


        private int monthPedido = 0;
        private bool printPromissorias = false;
        private ReportDataSource RDSPedidos = new ReportDataSource();
        private ReportDataSource RDSDistribuidor = new ReportDataSource();
        private ReportDataSource RDSCatalogos = new ReportDataSource();
        private ReportDataSource RDSCampanhas = new ReportDataSource();
        private ReportDataSource RDSVendedoras = new ReportDataSource();
        private ReportDataSource RDSDetatlhesPedidos = new ReportDataSource();
        private ReportDataSource RDSProdutos = new ReportDataSource();







        public ReportPedidosForm(IEnumerable<VendedoraModel> vendedorasModelsList, int monthPedido, bool printPromissorias)
        {
            ///INICIALIZANDO OS SERVIÇOS
            _queryString = new QueryStringServices(new QueryString());
            _distribuidorServices = new DistribuidorServices(new DistribuidorRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _catalogoSercices = new CatalogoServices(new CatalogoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _campanhaServices = new CampanhaServices(new CampanhaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _pedidosVendedorasServices = new PedidosVendedorasServices(new PedidoVendedoraRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _detalhesPedidoServices = new DetalhePedidoSerivces(new DetalhePedidoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _produtoServices = new ProdutoServices(new ProdutoRepository(_queryString.GetQuery()), new ModelDataAnnotationCheck());


            InitializeComponent();
            VendedorasModelsList = vendedorasModelsList;
            this.monthPedido = monthPedido;
            this.printPromissorias = printPromissorias;
            LoadListModels();
            LoadModels();
        }

        private void LoadModels()
        {
            distribuidorModel = _distribuidorServices.GetModel();
        }

        private void LoadListModels()
        {
            CatalogosModelsList = (IEnumerable<CatalogoModel>)_catalogoSercices.GetAll();
            CampanhasModelsList = (IEnumerable<CampanhaModel>)_campanhaServices.GetAll();
            PedidosModelsList = (IEnumerable<PedidosVendedorasModel>)_pedidosVendedorasServices.GetAll();
            DetalhesModelsList = (IEnumerable<DetalhePedidoModel>)_detalhesPedidoServices.GetAll();
            //ProdutosModelsList = (IEnumerable<ProdutoModel>)_produtoServices.GetAll();

        }


        private void ReportPedidosForm_Load(object sender, EventArgs e)
        {


            RDSDistribuidor.Name = "DSDistribuidor";
            RDSDistribuidor.Value = LoadDataTableDistribuidor(distribuidorModel);



            RDSPedidos.Name = "DSPedidoHeader";
            RDSPedidos.Value = LoadDataTablePedido(PedidosModelsList);

            RDSVendedoras.Name = "DSVendedora";
            RDSVendedoras.Value = LoadDataTableVendedora(VendedorasModelsList);




            RDSDetatlhesPedidos.Name = "DSPedidoDetalhes";
            RDSDetatlhesPedidos.Value = LoadDataTableDetalhesPedidos(DetalhesModelsList);

            RDSCatalogos.Name = "DSCatalogo";
            RDSCatalogos.Value = LoadDataTableCatalogo(CatalogosModelsList);

            //RDSProdutos.Name = "DSProduto";
            //RDSProdutos.Value = LoadDataTableProduto(ProdutosModelsList);

            //RDSPedidos.Name = "DSReportPedidos";
            //RDSPedidos.Value = reportPedidosList;

            //RDSCampanhas.Name = "DSReportPedidosCampanhas";
            //RDSCampanhas.Value = reportPedidosList;


            reportViewer.LocalReport.DataSources.Add(RDSDistribuidor);
            reportViewer.LocalReport.DataSources.Add(RDSPedidos);
            reportViewer.LocalReport.DataSources.Add(RDSVendedoras);
            reportViewer.LocalReport.DataSources.Add(RDSDetatlhesPedidos);
            reportViewer.LocalReport.DataSources.Add(RDSCatalogos);
            //reportViewer.LocalReport.DataSources.Add(RDSProdutos);
            //reportViewer.LocalReport.DataSources.Add(RDSCampanhas);


            reportViewer.LocalReport.ReportEmbeddedResource = "ReportsLayer.Reports.Pedidos.ReportPedidos.rdlc";
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 75;
            this.reportViewer.RefreshReport();

        }

        //private object LoadDataTableProduto(IEnumerable<ProdutoModel> produtosModelsList)
        //{
        //    DataTable table = new DataTable();
        //    DataRow row = null;
        //    List<ProdutoModel> listProdutos = new List<ProdutoModel>();
        //    List<DetalhePedidoModel> listDetalhes = new List<DetalhePedidoModel>();

        //    //table.Columns.Add("ProdutoId", typeof(int));
        //    table.Columns.Add("Descricao", typeof(string));
        //    //produtosModelsList = null;

        //    foreach (var detalhePedido in DetalhesModelsList)
        //    {
        //        foreach (var produto in ProdutosModelsList)
        //        {
        //            if (produto.ProdutoId == detalhePedido.ProdutoId)
        //            {
        //                DetalhePedidoModel detalhe = new DetalhePedidoModel();
        //                detalhe.PedidoId = detalhePedido.PedidoId;
        //                detalhe.CampanhaId = detalhePedido.CampanhaId;
        //                detalhe.Descricao = produto.Descricao.ToString();
        //                detalhe.DetalheId = detalhePedido.DetalheId;
        //                detalhe.CatalogoId = detalhePedido.CatalogoId;
        //                detalhe.Faltou = detalhePedido.Faltou;
        //                detalhe.MargemDistribuidor = detalhePedido.MargemDistribuidor;
        //                detalhe.MargemVendedora = detalhePedido.MargemVendedora;
        //                detalhe.PedidoId = detalhePedido.PedidoId;
        //                detalhe.ProdutoId = detalhePedido.ProdutoId;
        //                detalhe.Quantidade = detalhePedido.Quantidade;
        //                detalhe.Referencia = detalhePedido.Referencia;
        //                detalhe.TamanhoId = detalhePedido.TamanhoId;
        //                detalhe.ValorProduto = detalhePedido.ValorProduto;
        //                detalhe.ValorTaxaItem = detalhePedido.ValorTaxaItem;

        //                listDetalhes.Add(detalhe);

        //            }
        //        }

        //    }

        //    foreach (var item in listDetalhes)
        //    {

        //        row = table.NewRow();
        //        //row["ProdutoId"] = int.Parse(item.ProdutoId.ToString());
        //        row["Descricao"] = item.Descricao.ToString();

        //        table.Rows.Add(row);
        //    }


        //    return table;
        //}

        private object LoadDataTableCatalogo(IEnumerable<CatalogoModel> catalogosModelsList)
        {
            DataTable table = new DataTable();
            DataRow row = null;

            table.Columns.Add("CatalogoId", typeof(int));
            table.Columns.Add("Nome", typeof(string));

            foreach (var item in catalogosModelsList)
            {
                row = table.NewRow();
                row["CatalogoId"] = int.Parse(item.CatalogoId.ToString());
                row["Nome"] = item.Nome.ToString();

                table.Rows.Add(row);
            }

            return table;
        }

        private object LoadDataTableDetalhesPedidos(IEnumerable<DetalhePedidoModel> detalhesModelsList)
        {
            DataTable table = new DataTable();
            DataRow row = null;

            table.Columns.Add("PedidoId", typeof(int));
            table.Columns.Add("DetalheId", typeof(int));
            table.Columns.Add("ProdutoId", typeof(int));
            table.Columns.Add("Referencia", typeof(string));
            table.Columns.Add("Descricao", typeof(string));
            table.Columns.Add("MargemVendedora", typeof(string));
            table.Columns.Add("ValorProduto", typeof(string));
            table.Columns.Add("Quantidade", typeof(int));
            table.Columns.Add("ValorTotalItem", typeof(string));
            table.Columns.Add("ValorTotalBruto", typeof(string));//FAZER ESSE CAMPO SEPARADO EM SOMA
            table.Columns.Add("Faltou", typeof(string));
            table.Clear();

            foreach (var item in detalhesModelsList)
            {

                row = table.NewRow();
                row["PedidoId"] = int.Parse(item.ProdutoId.ToString());
                row["DetalheId"] = int.Parse(item.DetalheId.ToString());
                row["ProdutoId"] = int.Parse(item.ProdutoId.ToString());
                row["Referencia"] = item.Referencia.ToString();
                row["Descricao"] = item.Descricao.ToString();
                row["MargemVendedora"] =  String.Format("{0:00%}", item.MargemVendedora /100);
                row["ValorProduto"] = item.Faltou ? "-" :  String.Format("{0:n2}", item.ValorProduto);
                row["Quantidade"] = int.Parse(item.Quantidade.ToString());
                row["ValorTotalItem"] = item.Faltou ? "-" : String.Format("{0:n2}", item.ValorTotalItem);
                row["ValorTotalBruto"] = item.Faltou ? "-" : String.Format("{0:n2}", item.ValorTotalBruto);
                row["Faltou"] = item.Faltou ? "F" : "";


                table.Rows.Add(row);
            }
            return table;
        }

        private object LoadDataTableVendedora(IEnumerable<VendedoraModel> vendedorasModelsList)
        {

            DataTable table = new DataTable();
            DataRow row = null;

            foreach (var item in vendedorasModelsList)
            {
                table.Columns.Add("VendedoraId", typeof(int));
                table.Columns.Add("Nome", typeof(string));

                row = table.NewRow();
                row["VendedoraId"] = int.Parse(item.VendedoraId.ToString());
                row["Nome"] = item.Nome.ToString();

                table.Rows.Add(row);
            }

            return table;
        }

        private object LoadDataTablePedido(IEnumerable<PedidosVendedorasModel> pedidosModelsList)
        {
            DataTable table = new DataTable();
            DataRow row = null;

            foreach (var item in pedidosModelsList)
            {
                table.Columns.Add("PedidoId", typeof(int));
                table.Columns.Add("VendedoraId", typeof(int));

                row = table.NewRow();
                row["PedidoId"] = int.Parse(item.PedidoId.ToString());
                row["VendedoraId"] = int.Parse(item.VendedoraId.ToString());

                table.Rows.Add(row);


            }
            return table;
        }

        private DataTable LoadDataTableDistribuidor(DistribuidorModel distribuidorModel)
        {
            DataTable table = new DataTable();
            DataRow row = null;

            table.Columns.Add("DistribuidorId", typeof(int));
            table.Columns.Add("NomeFantasia", typeof(string));
            //table.Clear();

            row = table.NewRow();
            row["DistribuidorId"] = int.Parse(distribuidorModel.DistribuidorId.ToString());
            row["NomeFantasia"] = distribuidorModel.NomeFantasia.ToString();

            table.Rows.Add(row);

            return table;




        }
    }
}
