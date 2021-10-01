using DomainLayer.Models.Financeiro.Banco;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.FinanceiroServices.BancoServices;

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
    public partial class BancosListForm : Form
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

        private List<BancoModel> BancosList = new List<BancoModel>();
        private List<ContaModel> ContasList = new List<ContaModel>();

        private QueryStringServices _queryString;
        private BancoServices _bancoServices;
        
        
        public BancosListForm()
        {
            InitializeComponent();
        }

    }
}
