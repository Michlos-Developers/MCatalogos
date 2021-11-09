using Microsoft.Reporting.WinForms;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCatalogos.Views.FormViews.Reports.Pedidos
{
    public partial class ReportPedidosForm : Form
    {
        public ReportPedidosForm()
        {
            InitializeComponent();
        }

        private void ReportPedidosForm_Load(object sender, EventArgs e)
        {
            reportViewerPedidos.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewerPedidos.ZoomMode = ZoomMode.Percent;
            reportViewerPedidos.ZoomPercent = 75;
            this.reportViewerPedidos.RefreshReport();
        }
    }
}
