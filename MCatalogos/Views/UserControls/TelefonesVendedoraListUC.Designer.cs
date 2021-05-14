
namespace MCatalogos.Views.UserControls
{
    partial class TelefonesVendedoraListUC
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
            this.panelCmdTelefones = new System.Windows.Forms.Panel();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panelDgvTelefones = new System.Windows.Forms.Panel();
            this.dgvTelefonesVendedora = new System.Windows.Forms.DataGridView();
            this.panelCmdTelefones.SuspendLayout();
            this.panelDgvTelefones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTelefonesVendedora)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCmdTelefones
            // 
            this.panelCmdTelefones.Controls.Add(this.button1);
            this.panelCmdTelefones.Controls.Add(this.btnSalvar);
            this.panelCmdTelefones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCmdTelefones.Location = new System.Drawing.Point(0, 152);
            this.panelCmdTelefones.Name = "panelCmdTelefones";
            this.panelCmdTelefones.Size = new System.Drawing.Size(299, 34);
            this.panelCmdTelefones.TabIndex = 0;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnSalvar.FlatAppearance.BorderSize = 0;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.Image = global::MCatalogos.Properties.Resources.iconSave20x20;
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar.Location = new System.Drawing.Point(141, 4);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(70, 27);
            this.btnSalvar.TabIndex = 1;
            this.btnSalvar.TabStop = false;
            this.btnSalvar.Tag = "";
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvar.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::MCatalogos.Properties.Resources.iconSave20x20;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(221, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 27);
            this.button1.TabIndex = 1;
            this.button1.TabStop = false;
            this.button1.Tag = "";
            this.button1.Text = "Apagar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // panelDgvTelefones
            // 
            this.panelDgvTelefones.Controls.Add(this.dgvTelefonesVendedora);
            this.panelDgvTelefones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDgvTelefones.Location = new System.Drawing.Point(0, 0);
            this.panelDgvTelefones.Name = "panelDgvTelefones";
            this.panelDgvTelefones.Size = new System.Drawing.Size(299, 152);
            this.panelDgvTelefones.TabIndex = 1;
            // 
            // dgvTelefonesVendedora
            // 
            this.dgvTelefonesVendedora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTelefonesVendedora.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTelefonesVendedora.Location = new System.Drawing.Point(0, 0);
            this.dgvTelefonesVendedora.Name = "dgvTelefonesVendedora";
            this.dgvTelefonesVendedora.Size = new System.Drawing.Size(299, 152);
            this.dgvTelefonesVendedora.TabIndex = 0;
            // 
            // TelefonesVendedoraListUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelDgvTelefones);
            this.Controls.Add(this.panelCmdTelefones);
            this.Name = "TelefonesVendedoraListUC";
            this.Size = new System.Drawing.Size(299, 186);
            this.Load += new System.EventHandler(this.TelefonesVendedoraListUC_Load);
            this.panelCmdTelefones.ResumeLayout(false);
            this.panelDgvTelefones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTelefonesVendedora)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCmdTelefones;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Panel panelDgvTelefones;
        private System.Windows.Forms.DataGridView dgvTelefonesVendedora;
    }
}
