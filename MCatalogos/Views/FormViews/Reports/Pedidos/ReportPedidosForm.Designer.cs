
namespace MCatalogos.Views.FormViews.Reports.Pedidos
{
    partial class ReportPedidosForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewerPedidos = new Microsoft.Reporting.WinForms.ReportViewer();
            this.IProdutoModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.IVendedoraModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ICatalogoModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.IDistribuidorModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.IDetalhePedidoModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.IPedidosVendedorasModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.IProdutoModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IVendedoraModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ICatalogoModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDistribuidorModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDetalhePedidoModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPedidosVendedorasModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewerPedidos
            // 
            this.reportViewerPedidos.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSProduto";
            reportDataSource1.Value = this.IProdutoModelBindingSource;
            reportDataSource2.Name = "DSVendedora";
            reportDataSource2.Value = this.IVendedoraModelBindingSource;
            reportDataSource3.Name = "DSCatalogo";
            reportDataSource3.Value = this.ICatalogoModelBindingSource;
            reportDataSource4.Name = "DSDistribuidor";
            reportDataSource4.Value = this.IDistribuidorModelBindingSource;
            reportDataSource5.Name = "DSPedidoDetalhes";
            reportDataSource5.Value = this.IDetalhePedidoModelBindingSource;
            reportDataSource6.Name = "DSPedidoHeader";
            reportDataSource6.Value = this.IPedidosVendedorasModelBindingSource;
            this.reportViewerPedidos.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewerPedidos.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewerPedidos.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewerPedidos.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewerPedidos.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewerPedidos.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewerPedidos.LocalReport.ReportEmbeddedResource = "MCatalogos.Reports.Pedidos.PedidosVendedorasReport.rdlc";
            this.reportViewerPedidos.Location = new System.Drawing.Point(0, 0);
            this.reportViewerPedidos.Name = "reportViewerPedidos";
            this.reportViewerPedidos.ServerReport.BearerToken = null;
            this.reportViewerPedidos.Size = new System.Drawing.Size(800, 450);
            this.reportViewerPedidos.TabIndex = 0;
            // 
            // IProdutoModelBindingSource
            // 
            this.IProdutoModelBindingSource.DataSource = typeof(DomainLayer.Models.Produtos.IProdutoModel);
            // 
            // IVendedoraModelBindingSource
            // 
            this.IVendedoraModelBindingSource.DataSource = typeof(DomainLayer.Models.Vendedora.IVendedoraModel);
            // 
            // ICatalogoModelBindingSource
            // 
            this.ICatalogoModelBindingSource.DataSource = typeof(DomainLayer.Models.Catalogos.ICatalogoModel);
            // 
            // IDistribuidorModelBindingSource
            // 
            this.IDistribuidorModelBindingSource.DataSource = typeof(DomainLayer.Models.Distribuidor.IDistribuidorModel);
            // 
            // IDetalhePedidoModelBindingSource
            // 
            this.IDetalhePedidoModelBindingSource.DataSource = typeof(DomainLayer.Models.PedidosVendedoras.IDetalhePedidoModel);
            // 
            // IPedidosVendedorasModelBindingSource
            // 
            this.IPedidosVendedorasModelBindingSource.DataSource = typeof(DomainLayer.Models.PedidosVendedoras.IPedidosVendedorasModel);
            // 
            // ReportPedidosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewerPedidos);
            this.Name = "ReportPedidosForm";
            this.Text = "ReportPedidosForm";
            this.Load += new System.EventHandler(this.ReportPedidosForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.IProdutoModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IVendedoraModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ICatalogoModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDistribuidorModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDetalhePedidoModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPedidosVendedorasModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerPedidos;
        private System.Windows.Forms.BindingSource IProdutoModelBindingSource;
        private System.Windows.Forms.BindingSource IVendedoraModelBindingSource;
        private System.Windows.Forms.BindingSource ICatalogoModelBindingSource;
        private System.Windows.Forms.BindingSource IDistribuidorModelBindingSource;
        private System.Windows.Forms.BindingSource IDetalhePedidoModelBindingSource;
        private System.Windows.Forms.BindingSource IPedidosVendedorasModelBindingSource;
    }
}