
namespace MCatalogos.Views.FormViews.Reports.Pedidos
{
    partial class ReportPedidoForm
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
            this.reportViewerPedidos = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewerPedidos
            // 
            this.reportViewerPedidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerPedidos.LocalReport.ReportEmbeddedResource = "MCatalogos.Reports.Pedidos.PedidosVendedorasReport.rdlc";
            this.reportViewerPedidos.Location = new System.Drawing.Point(0, 0);
            this.reportViewerPedidos.Name = "reportViewerPedidos";
            this.reportViewerPedidos.ServerReport.BearerToken = null;
            this.reportViewerPedidos.Size = new System.Drawing.Size(879, 450);
            this.reportViewerPedidos.TabIndex = 0;
            // 
            // ReportPedidoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 450);
            this.Controls.Add(this.reportViewerPedidos);
            this.Name = "ReportPedidoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório de Pedidos";
            this.Load += new System.EventHandler(this.ReportPedidoForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerPedidos;
    }
}