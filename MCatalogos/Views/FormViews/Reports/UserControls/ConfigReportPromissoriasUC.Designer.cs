
namespace MCatalogos.Views.FormViews.Reports.UserControls
{
    partial class ConfigReportPromissoriasUC
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbMes = new System.Windows.Forms.ComboBox();
            this.cbVendedoras = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(142, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mês";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(107, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Vendedora:";
            // 
            // cbMes
            // 
            this.cbMes.FormattingEnabled = true;
            this.cbMes.Location = new System.Drawing.Point(175, 147);
            this.cbMes.Name = "cbMes";
            this.cbMes.Size = new System.Drawing.Size(267, 21);
            this.cbMes.TabIndex = 3;
            // 
            // cbVendedoras
            // 
            this.cbVendedoras.FormattingEnabled = true;
            this.cbVendedoras.Location = new System.Drawing.Point(175, 120);
            this.cbVendedoras.Name = "cbVendedoras";
            this.cbVendedoras.Size = new System.Drawing.Size(267, 21);
            this.cbVendedoras.TabIndex = 4;
            this.cbVendedoras.SelectedIndexChanged += new System.EventHandler(this.cbVendedoras_SelectedIndexChanged);
            // 
            // ConfigReportPromissoriasUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbMes);
            this.Controls.Add(this.cbVendedoras);
            this.Name = "ConfigReportPromissoriasUC";
            this.Size = new System.Drawing.Size(548, 311);
            this.Load += new System.EventHandler(this.ConfigReportPromissoriasUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cbMes;
        public System.Windows.Forms.ComboBox cbVendedoras;
    }
}
