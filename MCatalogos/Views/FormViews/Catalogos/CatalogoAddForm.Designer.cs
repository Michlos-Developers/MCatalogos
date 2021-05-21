
namespace MCatalogos.Views.FormViews.Catalogos
{
    partial class CatalogoAddForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CatalogoAddForm));
            this.panelCommands = new System.Windows.Forms.Panel();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelContent = new System.Windows.Forms.Panel();
            this.cbFornecedor = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textMargemDistribuidor = new System.Windows.Forms.TextBox();
            this.textMargemVendedora = new System.Windows.Forms.TextBox();
            this.textNome = new System.Windows.Forms.TextBox();
            this.textCatalogoId = new System.Windows.Forms.TextBox();
            this.LblCodigo = new System.Windows.Forms.Label();
            this.panelCommands.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCommands
            // 
            this.panelCommands.Controls.Add(this.btnSalvar);
            this.panelCommands.Controls.Add(this.btnCancel);
            this.panelCommands.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCommands.Location = new System.Drawing.Point(0, 216);
            this.panelCommands.Name = "panelCommands";
            this.panelCommands.Size = new System.Drawing.Size(310, 45);
            this.panelCommands.TabIndex = 3;
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
            this.btnSalvar.Location = new System.Drawing.Point(94, 9);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(91, 27);
            this.btnSalvar.TabIndex = 0;
            this.btnSalvar.TabStop = false;
            this.btnSalvar.Tag = "";
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(212, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 27);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.TabStop = false;
            this.btnCancel.Tag = "Pedidos";
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(111)))), ((int)(((byte)(156)))));
            this.panelContent.Controls.Add(this.cbFornecedor);
            this.panelContent.Controls.Add(this.label5);
            this.panelContent.Controls.Add(this.cbStatus);
            this.panelContent.Controls.Add(this.label8);
            this.panelContent.Controls.Add(this.label7);
            this.panelContent.Controls.Add(this.label4);
            this.panelContent.Controls.Add(this.label3);
            this.panelContent.Controls.Add(this.label2);
            this.panelContent.Controls.Add(this.label1);
            this.panelContent.Controls.Add(this.textMargemDistribuidor);
            this.panelContent.Controls.Add(this.textMargemVendedora);
            this.panelContent.Controls.Add(this.textNome);
            this.panelContent.Controls.Add(this.textCatalogoId);
            this.panelContent.Controls.Add(this.LblCodigo);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(310, 216);
            this.panelContent.TabIndex = 0;
            // 
            // cbFornecedor
            // 
            this.cbFornecedor.Enabled = false;
            this.cbFornecedor.FormattingEnabled = true;
            this.cbFornecedor.Location = new System.Drawing.Point(12, 160);
            this.cbFornecedor.Name = "cbFornecedor";
            this.cbFornecedor.Size = new System.Drawing.Size(282, 22);
            this.cbFornecedor.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 14);
            this.label5.TabIndex = 26;
            this.label5.Text = "Fornecedor:";
            // 
            // cbStatus
            // 
            this.cbStatus.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "-",
            "Ativo",
            "Inativo"});
            this.cbStatus.Location = new System.Drawing.Point(232, 17);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(62, 22);
            this.cbStatus.TabIndex = 0;
            this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.cbStatus_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(286, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 14);
            this.label8.TabIndex = 24;
            this.label8.Text = "%";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(286, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 14);
            this.label7.TabIndex = 24;
            this.label7.Text = "%";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(187, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 14);
            this.label4.TabIndex = 24;
            this.label4.Text = "Status:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 14);
            this.label3.TabIndex = 23;
            this.label3.Text = "Margem Padrão Distribuidor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 14);
            this.label2.TabIndex = 23;
            this.label2.Text = "Margem Padrão Vendedora:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 23;
            this.label1.Text = "Nome:";
            // 
            // textMargemDistribuidor
            // 
            this.textMargemDistribuidor.Location = new System.Drawing.Point(238, 112);
            this.textMargemDistribuidor.Name = "textMargemDistribuidor";
            this.textMargemDistribuidor.Size = new System.Drawing.Size(46, 22);
            this.textMargemDistribuidor.TabIndex = 3;
            // 
            // textMargemVendedora
            // 
            this.textMargemVendedora.Location = new System.Drawing.Point(238, 84);
            this.textMargemVendedora.Name = "textMargemVendedora";
            this.textMargemVendedora.Size = new System.Drawing.Size(46, 22);
            this.textMargemVendedora.TabIndex = 2;
            // 
            // textNome
            // 
            this.textNome.Location = new System.Drawing.Point(63, 56);
            this.textNome.Name = "textNome";
            this.textNome.Size = new System.Drawing.Size(231, 22);
            this.textNome.TabIndex = 1;
            // 
            // textCatalogoId
            // 
            this.textCatalogoId.Enabled = false;
            this.textCatalogoId.Location = new System.Drawing.Point(63, 17);
            this.textCatalogoId.Name = "textCatalogoId";
            this.textCatalogoId.Size = new System.Drawing.Size(100, 22);
            this.textCatalogoId.TabIndex = 0;
            // 
            // LblCodigo
            // 
            this.LblCodigo.AutoSize = true;
            this.LblCodigo.Location = new System.Drawing.Point(16, 20);
            this.LblCodigo.Name = "LblCodigo";
            this.LblCodigo.Size = new System.Drawing.Size(47, 14);
            this.LblCodigo.TabIndex = 21;
            this.LblCodigo.Text = "Codigo:";
            // 
            // CatalogoAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 261);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelCommands);
            this.Font = new System.Drawing.Font("Calibri", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CatalogoAddForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Adicionar Catálogo";
            this.Load += new System.EventHandler(this.CatalogoAddForm_Load);
            this.panelCommands.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCommands;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.ComboBox cbFornecedor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textMargemDistribuidor;
        private System.Windows.Forms.TextBox textMargemVendedora;
        private System.Windows.Forms.TextBox textNome;
        public System.Windows.Forms.TextBox textCatalogoId;
        private System.Windows.Forms.Label LblCodigo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}