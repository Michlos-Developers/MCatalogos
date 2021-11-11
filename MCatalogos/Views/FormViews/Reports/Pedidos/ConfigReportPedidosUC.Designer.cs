
namespace MCatalogos.Views.FormViews.Reports.Pedidos
{
    partial class ConfigReportPedidosUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbVendedoras = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbMes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkPrintPromissorias = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cbVendedoras
            // 
            this.cbVendedoras.FormattingEnabled = true;
            this.cbVendedoras.Location = new System.Drawing.Point(155, 28);
            this.cbVendedoras.Name = "cbVendedoras";
            this.cbVendedoras.Size = new System.Drawing.Size(267, 21);
            this.cbVendedoras.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vendedora:";
            // 
            // cbMes
            // 
            this.cbMes.FormattingEnabled = true;
            this.cbMes.Location = new System.Drawing.Point(155, 55);
            this.cbMes.Name = "cbMes";
            this.cbMes.Size = new System.Drawing.Size(267, 21);
            this.cbMes.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mês";
            // 
            // chkPrintPromissorias
            // 
            this.chkPrintPromissorias.AutoSize = true;
            this.chkPrintPromissorias.Location = new System.Drawing.Point(155, 82);
            this.chkPrintPromissorias.Name = "chkPrintPromissorias";
            this.chkPrintPromissorias.Size = new System.Drawing.Size(118, 17);
            this.chkPrintPromissorias.TabIndex = 2;
            this.chkPrintPromissorias.Text = "Imprime Promissória";
            this.chkPrintPromissorias.UseVisualStyleBackColor = true;
            // 
            // ConfigReportPedidosUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkPrintPromissorias);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbMes);
            this.Controls.Add(this.cbVendedoras);
            this.Name = "ConfigReportPedidosUC";
            this.Size = new System.Drawing.Size(548, 311);
            this.Load += new System.EventHandler(this.ConfigReportPedidosUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cbVendedoras;
        public System.Windows.Forms.ComboBox cbMes;
        public System.Windows.Forms.CheckBox chkPrintPromissorias;
    }
}
