using ServiceLayer.CommonServices;

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

namespace MCatalogos.Views.FormViews.Estoque
{
    public partial class EstoqueListForm : Form
    {
        #region PROPRIEDADES PARA MOVER A JANELA

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        #endregion

        MainView MainView;
        QueryStringServices _queryString;

        private int? rowIndex = null;

        public EstoqueListForm(MainView mainView)
        {
            InitializeComponent();
            this.MainView = mainView;
        }

        private static EstoqueListForm aForm = null;
        internal static EstoqueListForm Instance(MainView mainView)
        {
            if (aForm == null)
            {
                aForm = new EstoqueListForm(mainView);
            }
            else
            {
                aForm.BringToFront();
            }

            return aForm;
        }

        private void EstoqueListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }

            this.MainView.SetUnselectedButtons();
            base.Dispose(Disposing);
            aForm = null;
            
        }

        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void dgvEstoque_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
        }

        private void formClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
