using DomainLayer.Models.Catalogos;
using DomainLayer.Models.PedidosVendedoras;
using DomainLayer.Models.Reports.Pedidos;
using DomainLayer.Models.Vendedora;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Specific.Catalogo;
using InfrastructureLayer.DataAccess.Repositories.Specific.PedidoVendedora;
using InfrastructureLayer.DataAccess.Repositories.Specific.Vendedora;

using MCatalogos.Commons;
using MCatalogos.Views.FormViews.Reports.Pedidos;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.CatalogoServices;
using ServiceLayer.Services.DetalhePedidoServices;
using ServiceLayer.Services.PedidosVendedorasServices;
using ServiceLayer.Services.RotaServices;
using ServiceLayer.Services.VendedoraServices;


//using ReportsLayer.Forms.Pedidos;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCatalogos.Views.FormViews.Reports
{
    public partial class ControleRelatoriosForm : Form
    {

        #region PROPRIEDADES PARA MOVER A JANELA

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        #endregion

        /// <summary>
        /// SERVICES
        /// </summary>
        private QueryStringServices _queryString;
        private CatalogoServices _catalogoServices;
        private PedidosVendedorasServices _pedidoServices;
        private DetalhePedidoSerivces _detalheServices;
        private VendedoraServices _vendedoraServices;
        private RotaLetraServices _rotaLetraServices;
        private RotaServices _rotaNumeroServices;


        private MainView MainView;
        private static ControleRelatoriosForm aForm = null;

        private ButtonHelper ButtonHelper = new ButtonHelper();
        List<Button> ButtonsCollection = new List<Button>();

        private ConfigReportPedidosUC UCPedidos = null;

        //private IEnumerable<IVendedoraModel> vendedorasListModel;
        private IEnumerable<ICatalogoModel> catalogosListModel;
        private IEnumerable<IPedidosVendedorasModel> pedidosListModel;
        private IEnumerable<IDetalhePedidoModel> detalheListModel;
        private IEnumerable<IRotaLetraModel> rotaLetraListModel;
        private IEnumerable<IRotaModel> rotaNumeroListModel;
        private List<IDadosRelatoriosPedidosVendedora> dadosRelatorioListModel = new List<IDadosRelatoriosPedidosVendedora>();

        internal static ControleRelatoriosForm Instance(MainView mainView)
        {
            if (aForm == null)
            {
                aForm = new ControleRelatoriosForm(mainView);

            }
            else
            {
                aForm.BringToFront();
            }

            return aForm;
        }

        public ControleRelatoriosForm(MainView mainView)
        {
            _queryString = new QueryStringServices(new QueryString());
            _vendedoraServices = new VendedoraServices(new VendedoraRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _catalogoServices = new CatalogoServices(new CatalogoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _pedidoServices = new PedidosVendedorasServices(new PedidoVendedoraRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _detalheServices = new DetalhePedidoSerivces(new DetalhePedidoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _rotaLetraServices = new RotaLetraServices(new RotaLetraRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _rotaNumeroServices = new RotaServices(new RotaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());

            InitializeComponent();
            this.MainView = mainView;


        }

        private void LoadListModels()
        {
            //vendedorasListModel = _vendedoraServices.GetAll();
            catalogosListModel = _catalogoServices.GetAll();
            pedidosListModel = _pedidoServices.GetAll();
            detalheListModel = _detalheServices.GetAll();
            rotaLetraListModel = _rotaLetraServices.GetAll();
            rotaNumeroListModel = _rotaNumeroServices.GetAll();


        }

        /// <summary>
        /// Add Buttons in ButtonsCollection to use ButtonHelper 
        /// </summary>
        public void SetCollectionButtons()
        {
            ButtonsCollection.Add(btnReportPedidos);
            ButtonsCollection.Add(btnReportPromissorias);
            ButtonsCollection.Add(btnReportContasPagar);
            ButtonsCollection.Add(btnReportContasReceber);

        }


        /// <summary>
        /// MÉTODO DE EVENTO QUE CHAMA A TELA DE CONFIGURAÇÃO DE RELATÓRIO DE PEDIDOS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReportPedidos_Click(object sender, EventArgs e)
        {
            ButtonHelper.SetDesabledButtons(ButtonsCollection, btnReportPedidos);
            panelConfigReport.Visible = true;
            LoadUserControlReporPedidos();
        }

        /// <summary>
        /// INSTANCIA O USERCONTROL "ConfigReporPedidosUS" NOMEADO DE "UCPedidos"
        /// INCLUI O UCPedidos NO PANEL "panelCallConfigRepor" QUE ESTÁ DENTRO DO OUTRO PAINEL DE COMANDOS 
        /// CHAMADO DE "panelConfigReport"
        /// </summary>
        private void LoadUserControlReporPedidos()
        {

            UCPedidos = new ConfigReportPedidosUC(this);
            panelCallConfigReport.Controls.Clear();
            panelCallConfigReport.Controls.Add(UCPedidos);
            UCPedidos.Dock = DockStyle.Fill;
        }


        /// <summary>
        /// MÉTODO DE EVENTO QUE CHAMA A TELA DE CONFIGURAÇÕES DE RELATÓRIO DE PROMISSÓRIAS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReportPromissorias_Click(object sender, EventArgs e)
        {
            ButtonHelper.SetDesabledButtons(ButtonsCollection, btnReportPromissorias);
            panelConfigReport.Visible = true;
        }

        /// <summary>
        /// MÉTODO DE EVENTO QUE FECHA A TELA DE CONFIGURAÇÃO DE RELATÓRIO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelReport_Click(object sender, EventArgs e)
        {
            panelConfigReport.Visible = false;
            ButtonHelper.SetEnabledButtons(ButtonsCollection);
        }

        /// <summary>
        /// Close Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// Disposing Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReportControleForm_FormClosing(object sender, FormClosingEventArgs e)
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


        /// <summary>
        /// MÉTODO DE EVENTO QUE CHAMAO O RELATÓRIO CONFORME 
        /// O USER CONTROL QUE ESTIVER NA TELA.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            //dadosRelatorioListModel.Clear();

            IEnumerable<VendedoraModel> vendedorasList = UCPedidos.vendedorasModelsList;
            int selectedMonth = UCPedidos.cbMes.SelectedIndex + 1;
            bool printPromissorias = UCPedidos.chkPrintPromissorias.Checked;
            if (UCPedidos != null)
            {


                ///VERIFICA SE A SELEÇÃO É PARA APENAS UMA VENDEDORA
                if (UCPedidos.cbVendedoras.SelectedIndex != 0)
                {
                    VendedoraModel selectedVendedora = (VendedoraModel)UCPedidos.cbVendedoras.SelectedItem;
                    vendedorasList = vendedorasList.Where(vend => vend.VendedoraId == selectedVendedora.VendedoraId);

                }


                foreach (var vendedora in vendedorasList)
                {

                    pedidosListModel = pedidosListModel.Where(pedVend => pedVend.VendedoraId == vendedora.VendedoraId);
                }

                foreach (var pedido in pedidosListModel)
                {
                    detalheListModel = detalheListModel.Where(pedId => pedId.PedidoId == pedido.PedidoId);
                }

                foreach (var detalhe in detalheListModel)
                {
                    int pedVendedoraId = vendedorasList.Where(vendId => vendId.VendedoraId ==
                        (
                            pedidosListModel.Where(pedIdVend => pedIdVend.PedidoId == detalhe.PedidoId).Select(idVend => idVend.VendedoraId).First())
                        ).Select(idvend => idvend.VendedoraId).FirstOrDefault();

                    int pedRotaLetraId = Convert.ToInt32(vendedorasList.Where(vendRotLetId => vendRotLetId.VendedoraId == pedVendedoraId).Select(rotaLtId => rotaLtId.RotaLetraId).First());
                    int pedRotaNumeroId = Convert.ToInt32(rotaNumeroListModel.Where(vendRotNumId => vendRotNumId.VendedoraId == pedVendedoraId).Select(rotNumId => rotNumId.RotaId).First());


                    IDadosRelatoriosPedidosVendedora dadosRelatorio = new DadosRelatoriosPedidosVendedora();

                    dadosRelatorio.PedidoId = detalhe.PedidoId;
                    //UNSOLVED: NÃO ESTÁ TRAZENDO O NOME DA VENDEDORA QUANDO É PRA VIR TODAS AS VENDEDORAS
                    dadosRelatorio.VendedoraNome = vendedorasList
                            .Where(vend => vend.VendedoraId == pedidosListModel
                                .Where(pedId => pedId.PedidoId == detalhe.PedidoId)
                                .Select(vnedId => vnedId.VendedoraId).FirstOrDefault())
                            .Select(vendNom => vendNom.Nome).FirstOrDefault();
                    dadosRelatorio.CatalogoNome = catalogosListModel.Where(catId => catId.CatalogoId == detalhe.CatalogoId).Select(catNom => catNom.Nome).FirstOrDefault();
                    dadosRelatorio.DataVencimento = pedidosListModel.Where(pedVenc => pedVenc.PedidoId == detalhe.PedidoId).Select(venc => venc.DataVencimento).FirstOrDefault();
                    dadosRelatorio.ItemReferencia = detalhe.Referencia;
                    dadosRelatorio.ItemDescricao = detalhe.Descricao;
                    dadosRelatorio.ItemQuantidade = detalhe.Quantidade;
                    dadosRelatorio.ItemValorUnitario = detalhe.ValorProduto;
                    dadosRelatorio.ItemValorTotal = detalhe.ValorTotalItem;
                    dadosRelatorio.ItemMargemVendedora = detalhe.MargemVendedora;
                    dadosRelatorio.ItemLucroVendedora = detalhe.ValorLucroVendedoraItem;
                    dadosRelatorio.VendedoraRotaLetra = _rotaLetraServices.GetById(_vendedoraServices.GetById(pedVendedoraId).RotaLetraId).RotaLetra;
                    dadosRelatorio.VendedoraRotaNumero = _rotaNumeroServices.GetByVendedoraId(pedVendedoraId).Numero;



                    dadosRelatorioListModel.Add(dadosRelatorio);
                }

                RelatorioPedidosVendedorasForm relatorioPedidos = new RelatorioPedidosVendedorasForm(dadosRelatorioListModel);
                relatorioPedidos.Show();


                //ReportPedidosVendedoras reportPedidosVendedoras = new ReportPedidosVendedoras(vendedorasList, selectedMonth, printPromissorias);
                //reportPedidosVendedoras.Show();
            }
        }



        private void ControleRelatoriosForm_Load(object sender, EventArgs e)
        {
            SetCollectionButtons();
            LoadListModels();
        }
    }
}
