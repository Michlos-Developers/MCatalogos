
using MCatalogos.Views.FormViews.Distribuidor;

using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MCatalogos.Views.FormViews.Configuracoes
{
    public partial class ConfiguracoesForm : Form
    {
        #region PROPRIEDADES PARA MOVER A JANELA

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        #endregion

        MainView MainView;

        DistribuidorForm distribuidorForm = new DistribuidorForm();

        private static ConfiguracoesForm aForm = null;
        public static ConfiguracoesForm Instance(MainView mainView)
        {
            if (aForm == null)
            {
                aForm = new ConfiguracoesForm(mainView);
            }
            else
            {
                aForm.BringToFront();
            }
            return aForm;
        }


        public ConfiguracoesForm(MainView mainView)
        {
            InitializeComponent();
            this.MainView = mainView;
        }

        private void btnRotas_Click(object sender, EventArgs e)
        {
            //RefatoraRotasFormList refatoraRotasFormList = new RefatoraRotasFormList();
            //refatoraRotasFormList.ShowDialog();
        }

        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfiguracoesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            //this.MainView.SetUnselectedButtons();
            base.Dispose(Disposing);
            aForm = null;
        }

        private void btnDadosDistribuidor_Click(object sender, EventArgs e)
        {
            distribuidorForm.ShowDialog();
            distribuidorForm = new DistribuidorForm();

            //ConfiguracoesForm configuracoesForm = ConfiguracoesForm.Instance(this);
            //configuracoesForm.WindowState = FormWindowState.Normal;
            //configuracoesForm.MdiParent = this;
            //configuracoesForm.Show();
        }
    }
}
