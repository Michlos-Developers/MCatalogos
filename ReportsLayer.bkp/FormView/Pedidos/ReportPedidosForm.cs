using DomainLayer.Models.Catalogos;
using DomainLayer.Models.Distribuidor;
using DomainLayer.Models.PedidosVendedoras;
using DomainLayer.Models.Reports.Pedidos;
using DomainLayer.Models.Vendedora;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Specific.Catalogo;
using InfrastructureLayer.DataAccess.Repositories.Specific.Distribuidor;
using InfrastructureLayer.DataAccess.Repositories.Specific.PedidoVendedora;
using InfrastructureLayer.DataAccess.Repositories.Specific.Vendedora;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.CatalogoServices;
using ServiceLayer.Services.DetalhePedidoServices;
using ServiceLayer.Services.DistribuidorServices;
using ServiceLayer.Services.PedidosVendedorasServices;
using ServiceLayer.Services.VendedoraServices;





using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace ReportsLayer.FormView.Pedidos
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
        //private VendedoraServices _vendedoraServices;
        private PedidosVendedorasServices _pedidosVendedorasServices;
        private DetalhePedidoSerivces _detalhesPedidoServices;


        /// <summary>
        /// MODELS LISTS
        /// </summary>
        private IEnumerable<VendedoraModel> VendedorasModelsList = new List<VendedoraModel>();
        private IEnumerable<CatalogoModel> CatalogosModelsList = new List<CatalogoModel>();
        private IEnumerable<CampanhaModel> CampanhasModelsList = new List<CampanhaModel>();
        private IEnumerable<PedidosVendedorasModel> PedidosModelsList = new List<PedidosVendedorasModel>();
        private IEnumerable<DetalhePedidoModel> DetalhesModelsList = new List<DetalhePedidoModel>();

        /// <summary>
        /// MODELS SINGLES
        /// </summary>
        private DistribuidorModel distribuidorModel = new DistribuidorModel();


        private int monthPedido = 0;
        private bool printPromissorias = false;







        public ReportPedidosForm(IEnumerable<VendedoraModel> vendedorasModelsList, int monthPedido, bool printPromissorias)
        {
            ///INICIALIZANDO OS SERVIÇOS
            _queryString = new QueryStringServices(new QueryString());
            _distribuidorServices = new DistribuidorServices(new DistribuidorRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _catalogoSercices = new CatalogoServices(new CatalogoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _campanhaServices = new CampanhaServices(new CampanhaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            //_vendedoraServices = new VendedoraServices(new VendedoraRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _pedidosVendedorasServices = new PedidosVendedorasServices(new PedidoVendedoraRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _detalhesPedidoServices = new DetalhePedidoSerivces(new DetalhePedidoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());


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
            //vendedorasModelsList = (IEnumerable<VendedoraModel>)_vendedoraServices.GetAll();
            PedidosModelsList = (IEnumerable<PedidosVendedorasModel>)_pedidosVendedorasServices.GetAll();
            DetalhesModelsList = (IEnumerable<DetalhePedidoModel>)_detalhesPedidoServices.GetAll();

        }

        private void ReportPedidosVendedorasForm_Load(object sender, EventArgs e)
        {


            List<ReportPedidosVendedorasModel> reportPedidosList = new List<ReportPedidosVendedorasModel>();
            reportPedidosList.Clear();

            reportPedidosList.ForEach(dist =>
            {
                reportPedidosList.Add(new ReportPedidosVendedorasModel
                {
                    NomeFantasiaDistribuidor = distribuidorModel.NomeFantasia,
                    Vendedoras = (List<VendedoraModel>)VendedorasModelsList,
                    Catalogos = (List<CatalogoModel>)CatalogosModelsList,
                    Campanhas = (List<CampanhaModel>)CampanhasModelsList,
                    Pedidos = (List<PedidosVendedorasModel>)PedidosModelsList,
                    DetalhePedidos = (List<DetalhePedidoModel>)DetalhesModelsList
                });
            });

            
            //reportViewer.LocalReport.ReportEmbeddedResource = "MCatalogos.Reports.Pedidos.ReportPedidosVendedoras.rdlc";
            reportViewer.LocalReport.ReportEmbeddedResource = "ReportLayer.Report1.rdlc";
            this.reportViewer.RefreshReport();
        }
    }
}
