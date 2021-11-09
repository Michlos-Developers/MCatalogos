using MCatalogos.Commons;
using MCatalogos.Views.FormViews.Reports.Pedidos;

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
    public partial class ReportControleForm : Form
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

        private MainView MainView;
        private static ReportControleForm aForm = null;

        private ButtonHelper ButtonHelper = new ButtonHelper();
        List<Button> ButtonsCollection = new List<Button>();

        internal static ReportControleForm Instance(MainView mainView)
        {
            if (aForm == null)
            {
                aForm = new ReportControleForm(mainView);

            }
            else
            {
                aForm.BringToFront();
            }

            return aForm;
        }

        public ReportControleForm(MainView mainView)
        {
            InitializeComponent();
            this.MainView = mainView;

            SetCollectionButtons();
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

        private void btnReportPedidos_Click(object sender, EventArgs e)
        {
            ButtonHelper.SetDesabledButtons(ButtonsCollection, btnReportPedidos);
            LoadUserControlReporPedidos();
            panelConfigReport.Visible = true;
        }

        private void LoadUserControlReporPedidos()
        {
            UCConfigReportPedido configReportPedido = new UCConfigReportPedido(this);
            panelConfigReport.Controls.Clear();
            panelConfigReport.Controls.Add(configReportPedido);
            configReportPedido.Dock = DockStyle.Fill;
        }

        private void btnReportPromissorias_Click(object sender, EventArgs e)
        {
            ButtonHelper.SetDesabledButtons(ButtonsCollection, btnReportPromissorias);
            panelConfigReport.Visible = true;
        }


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

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            //ReportPedidoForm reportPedido = new ReportPedidoForm();
            //reportPedido.Show();
        }
    }
}
