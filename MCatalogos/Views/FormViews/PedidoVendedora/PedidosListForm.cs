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
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCatalogos.Views.FormViews.PedidoVendedora
{
    public partial class PedidosListForm : Form
    {
        #region PROPRIEDADES PARA MOVER A JANELA

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        #endregion

        MainView MainView;
        private List<PedidosVendedorasModel> PedidosList = new List<PedidosVendedorasModel>();
        private List<VendedoraModel> VendedorasList = new List<VendedoraModel>();
        private VendedoraModel VendedoraFilter = new VendedoraModel();
        private PedidosVendedorasModel Pedido = new PedidosVendedorasModel();

        private QueryStringServices _queryString;
        private PedidosVendedorasServices _pedidosServices;
        private VendedoraServices _vendedoraServices;

        public PedidosListForm(MainView mainView)
        {
            _queryString = new QueryStringServices(new QueryString());
            _pedidosServices = new PedidosVendedorasServices(new PedidoVendedoraRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _vendedoraServices = new VendedoraServices(new VendedoraRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());

            InitializeComponent();
            MainView = mainView;
        }

        private void pictureClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private static PedidosListForm aForm = null;

        internal static PedidosListForm Instance(MainView mainView)
        {
            if (aForm == null)
            {
                aForm = new PedidosListForm(mainView);
            }
            else
            {
                aForm.BringToFront();
            }
            return aForm;
        }

        private void PedidosListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }

            MainView.SetUnselectedButtons();
            base.Dispose(Disposing);
            aForm = null;

            
        }

        private void PedidosListForm_Load(object sender, EventArgs e)
        {
            DefineDataInicial();
            DefineDataFinal();
            ReadModels();

        }

        private void ReadModels()
        {
            List<VendedoraModel> model = new List<VendedoraModel>();
            model = (List<VendedoraModel>)_vendedoraServices.GetAll();
            this.VendedorasList = 
        }

        private void LetTodosOsPedidos()
        {
            
        }

        private void DefineDataFinal()
        {
            DateTime dataFim = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            dateDataFim.Value = dataFim;
        }

        private void DefineDataInicial()
        {
            DateTime dataIni = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            
            dateDataInicio.Value = dataIni;
        }
    }
}
