
namespace MCatalogos.Views.FormViews.Reports.Pedidos
{
    partial class UCConfigReportPedido
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
            this.cbVendedora = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chk_printPromissoria = new System.Windows.Forms.CheckBox();
            this.cbMes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbVendedora
            // 
            this.cbVendedora.FormattingEnabled = true;
            this.cbVendedora.Location = new System.Drawing.Point(97, 31);
            this.cbVendedora.Name = "cbVendedora";
            this.cbVendedora.Size = new System.Drawing.Size(352, 22);
            this.cbVendedora.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vendedora:";
            // 
            // chk_printPromissoria
            // 
            this.chk_printPromissoria.AutoSize = true;
            this.chk_printPromissoria.Checked = true;
            this.chk_printPromissoria.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_printPromissoria.Location = new System.Drawing.Point(97, 110);
            this.chk_printPromissoria.Name = "chk_printPromissoria";
            this.chk_printPromissoria.Size = new System.Drawing.Size(146, 18);
            this.chk_printPromissoria.TabIndex = 2;
            this.chk_printPromissoria.Text = "Imprime Promissórias";
            this.chk_printPromissoria.UseVisualStyleBackColor = true;
            // 
            // cbMes
            // 
            this.cbMes.FormattingEnabled = true;
            this.cbMes.Location = new System.Drawing.Point(97, 70);
            this.cbMes.Name = "cbMes";
            this.cbMes.Size = new System.Drawing.Size(121, 22);
            this.cbMes.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mês:";
            // 
            // UCConfigReportPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Controls.Add(this.cbMes);
            this.Controls.Add(this.chk_printPromissoria);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbVendedora);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UCConfigReportPedido";
            this.Size = new System.Drawing.Size(507, 335);
            this.Load += new System.EventHandler(this.UCConfigReportPedido_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbVendedora;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chk_printPromissoria;
        private System.Windows.Forms.ComboBox cbMes;
        private System.Windows.Forms.Label label2;
    }
}
