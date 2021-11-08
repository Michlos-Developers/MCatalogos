using MCatalogos.Commons;

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
        }

        public void SetCollectionButtons()
        {
            ButtonsCollection.Add(btnReportPedidos);
            ButtonsCollection.Add(btnReportPromissorias);
            //ButtonsCollection.Add(btnReportContasPagar);
            //ButtonsCollection.Add(btnReportContasReceber);

        }

        private void btnReportPedidos_Click(object sender, EventArgs e)
        {
            ButtonHelper.SetDesabledButtons(ButtonsCollection, btnReportPedidos);
            panelCommandsReport.Visible = true;
        }

        private void btnReportPromissorias_Click(object sender, EventArgs e)
        {
            ButtonHelper.SetDesabledButtons(ButtonsCollection, btnReportPromissorias);
            panelCommandsReport.Visible = true;
        }
    }
}
