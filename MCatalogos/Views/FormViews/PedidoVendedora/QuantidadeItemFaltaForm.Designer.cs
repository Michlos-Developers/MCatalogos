
namespace MCatalogos.Views.FormViews.PedidoVendedora
{
    partial class QuantidadeItemFaltaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuantidadeItemFaltaForm));
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textQtd = new System.Windows.Forms.TextBox();
            this.panelContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContainer
            // 
            this.panelContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(111)))), ((int)(((byte)(156)))));
            this.panelContainer.Controls.Add(this.panel1);
            this.panelContainer.Controls.Add(this.label1);
            this.panelContainer.Controls.Add(this.textQtd);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelContainer.ForeColor = System.Drawing.Color.White;
            this.panelContainer.Location = new System.Drawing.Point(0, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(194, 103);
            this.panelContainer.TabIndex = 1;
            this.panelContainer.TabStop = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(194, 41);
            this.panel1.TabIndex = 2;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(123, 8);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(61, 26);
            this.btnOk.TabIndex = 3;
            this.btnOk.TabStop = false;
            this.btnOk.Tag = "Pedidos";
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Quantidade:";
            // 
            // textQtd
            // 
            this.textQtd.Location = new System.Drawing.Point(102, 29);
            this.textQtd.Name = "textQtd";
            this.textQtd.Size = new System.Drawing.Size(41, 22);
            this.textQtd.TabIndex = 0;
            this.textQtd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textQtd_KeyDown);
            this.textQtd.Leave += new System.EventHandler(this.textQuantidade_Leave);
            // 
            // QuantidadeItemFaltaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(194, 103);
            this.Controls.Add(this.panelContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuantidadeItemFaltaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Falta";
            this.panelContainer.ResumeLayout(false);
            this.panelContainer.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textQtd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOk;
    }
}