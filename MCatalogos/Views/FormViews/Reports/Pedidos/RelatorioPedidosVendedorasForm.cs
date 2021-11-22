using DomainLayer.Models.Reports.Pedidos;

using Microsoft.Reporting.WinForms;

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MCatalogos.Views.FormViews.Reports.Pedidos
{
    public partial class RelatorioPedidosVendedorasForm : Form
    {


        IEnumerable<IDadosRelatoriosPedidosVendedora> DadosRelatorio;

        public RelatorioPedidosVendedorasForm(IEnumerable<IDadosRelatoriosPedidosVendedora> dadosRelatorio)
        {
            InitializeComponent();
            DadosRelatorio = dadosRelatorio;
        }

        private void RelatorioPedidosVendedorasForm_Load(object sender, EventArgs e)
        {

            var dataSource = new ReportDataSource("DataSetPedidosVendedoras", DadosRelatorio);
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(dataSource);
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            reportViewer.RefreshReport();
        }

    }
}
