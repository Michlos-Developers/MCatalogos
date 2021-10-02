using DomainLayer.Models.CommonModels.Enums;

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

namespace MCatalogos.Views.FormViews.Financeiro.Bancos
{
    public partial class BancoAddForm : Form
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

        private RequestType RequestType;
        
        public BancoAddForm(RequestType requestType)
        {
            InitializeComponent();

            RequestType = requestType;
            
        }

        private void BancoAddForm_Load(object sender, EventArgs e)
        {
            if (RequestType == RequestType.Add)
            {
                //new bank
            }
            else if (RequestType == RequestType.Edit)
            {
                //load bank and acoutns
            }
        }
    }
}
