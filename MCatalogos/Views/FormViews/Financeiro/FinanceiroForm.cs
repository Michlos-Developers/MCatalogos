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

        #endregion

        private static FinanceiroForm aForm = null;

        private MainView MainView;
        
        
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


        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnContasPagar_Click(object sender, System.EventArgs e)
        {

        }

        private void btnContasReceber_Click(object sender, System.EventArgs e)
        {

        }

        private void btnCaixa_Click(object sender, System.EventArgs e)
        {

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
