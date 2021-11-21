
namespace MCatalogos.Views.FormViews.Reports.Pedidos
{
    partial class ReportPedidosVendedoras
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
            this.reportPedidosVendedorasModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportView = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.reportPedidosVendedorasModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportPedidosVendedorasModelBindingSource
            // 
            this.reportPedidosVendedorasModelBindingSource.DataSource = typeof(DomainLayer.Models.Reports.Pedidos.ReportPedidosVendedorasModel);
            // 
            // reportView
            // 
            this.reportView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportView.LocalReport.ReportEmbeddedResource = "MCatalogos.Reports.Pedidos.ReportPedidosVendedoras.rdlc";
            this.reportView.Location = new System.Drawing.Point(0, 0);
            this.reportView.Name = "reportView";
            this.reportView.ServerReport.BearerToken = null;
            this.reportView.Size = new System.Drawing.Size(800, 450);
            this.reportView.TabIndex = 0;
            // 
            // ReportPedidosVendedoras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportView);
            this.Name = "ReportPedidosVendedoras";
            this.Text = "ReportPedidosVendedoras";
            this.Load += new System.EventHandler(this.ReportPedidosVendedoras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reportPedidosVendedorasModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportView;
        private System.Windows.Forms.BindingSource reportPedidosVendedorasModelBindingSource;
    }
}