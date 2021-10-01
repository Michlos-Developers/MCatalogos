using DomainLayer.Models.TitulosPagar;

using MCatalogos.Views.FormViews.Financeiro.ContasPagar;
using MCatalogos.Views.FormViews.Financeiro.ContasReceber;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.TitulosPagarServices;

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MCatalogos.Views.FormViews.Financeiro
{
    public partial class FinanceiroForm : Form
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

        enum RequestType
        {
        
            Edit
        }

        private MainView MainView;
        private QueryStringServices _queryString;
        private StatusTitulosServices _statusTitulos;
        private TituloPagarServices _tituloPagarServices;


        private TituloPagarModel TituloPagarModel = new TituloPagarModel();
        private List<TituloPagarModel> TitulosList = new List<TituloPagarModel>();

        
        

        private static FinanceiroForm aForm = null;
        internal static FinanceiroForm Instance(MainView mainView)
        {
            if (aForm == null)
            {
                aForm = new FinanceiroForm(mainView);
            }
            else
            {
                aForm.BringToFront();
            }
            return aForm;
        }
        public FinanceiroForm(MainView mainView)
        {
            InitializeComponent();
            this.MainView = mainView;
        }

        private void OpenFormContasPagar()
        {
            ContasPagarForm contasPagarForm = ContasPagarForm.Instance(this);
            contasPagarForm.Show();
            
        }

        private void btnContasPagar_Click(object sender, System.EventArgs e)
        {
            OpenFormContasPagar();
        }

        private void btnContasReceber_Click(object sender, System.EventArgs e)
        {
            OpenFormContasReceber();
        }

        private void OpenFormContasReceber()
        {
            ContasReceberForm contasReceberForm = ContasReceberForm.Instance(this);
            contasReceberForm.Show();
        }

        private void btnCaixa_Click(object sender, System.EventArgs e)
        {
            //TODO: FAZER FORMULÁRIO DE CADASTRO DE BANCO E CONTAS
        }

        private void pictureClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void FinanceiroForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
