using DomainLayer.Models.Vendedora;

using InfrastructureLayer.DataAccess.Repositories.Specific.Vendedora;

using MCatalogos.Commons;
using MCatalogos.Views.FormViews.Reports.Pedidos;


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

        private MainView MainView;
        private static ControleRelatoriosForm aForm = null;

        private ButtonHelper ButtonHelper = new ButtonHelper();
        List<Button> ButtonsCollection = new List<Button>();

        private ConfigReportPedidosUC UCPedidos = null;

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
                ReportPedidosVendedoras reportPedidosVendedoras = new ReportPedidosVendedoras(vendedorasList, selectedMonth, printPromissorias);
                reportPedidosVendedoras.Show();
            }
        }
    }
}
