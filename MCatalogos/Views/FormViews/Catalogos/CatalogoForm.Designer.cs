
namespace MCatalogos.Views.FormViews.Catalogos
{
    partial class CatalogoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CatalogoForm));
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
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelCommands = new System.Windows.Forms.Panel();
            this.groupBoxCampanhas = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panelCampanhas = new System.Windows.Forms.Panel();
            this.panelContent.SuspendLayout();
            this.panelCommands.SuspendLayout();
            this.groupBoxCampanhas.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbFornecedor
            // 
            this.cbFornecedor.Enabled = false;
            this.cbFornecedor.FormattingEnabled = true;
            this.cbFornecedor.Location = new System.Drawing.Point(12, 172);
            this.cbFornecedor.Name = "cbFornecedor";
            this.cbFornecedor.Size = new System.Drawing.Size(282, 22);
            this.cbFornecedor.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 154);
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
            this.cbStatus.Location = new System.Drawing.Point(232, 18);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(62, 22);
            this.cbStatus.TabIndex = 0;
            this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.cbStatus_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(286, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 14);
            this.label8.TabIndex = 24;
            this.label8.Text = "%";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(286, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 14);
            this.label7.TabIndex = 24;
            this.label7.Text = "%";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(187, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 14);
            this.label4.TabIndex = 24;
            this.label4.Text = "Status:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 14);
            this.label3.TabIndex = 23;
            this.label3.Text = "Margem Padrão Distribuidor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 14);
            this.label2.TabIndex = 23;
            this.label2.Text = "Margem Padrão Vendedora:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 23;
            this.label1.Text = "Nome:";
            // 
            // textMargemDistribuidor
            // 
            this.textMargemDistribuidor.Location = new System.Drawing.Point(238, 121);
            this.textMargemDistribuidor.Name = "textMargemDistribuidor";
            this.textMargemDistribuidor.Size = new System.Drawing.Size(46, 22);
            this.textMargemDistribuidor.TabIndex = 3;
            // 
            // textMargemVendedora
            // 
            this.textMargemVendedora.Location = new System.Drawing.Point(238, 90);
            this.textMargemVendedora.Name = "textMargemVendedora";
            this.textMargemVendedora.Size = new System.Drawing.Size(46, 22);
            this.textMargemVendedora.TabIndex = 2;
            // 
            // textNome
            // 
            this.textNome.Location = new System.Drawing.Point(63, 60);
            this.textNome.Name = "textNome";
            this.textNome.Size = new System.Drawing.Size(231, 22);
            this.textNome.TabIndex = 1;
            // 
            // textCatalogoId
            // 
            this.textCatalogoId.Enabled = false;
            this.textCatalogoId.Location = new System.Drawing.Point(63, 18);
            this.textCatalogoId.Name = "textCatalogoId";
            this.textCatalogoId.Size = new System.Drawing.Size(100, 22);
            this.textCatalogoId.TabIndex = 0;
            // 
            // LblCodigo
            // 
            this.LblCodigo.AutoSize = true;
            this.LblCodigo.Location = new System.Drawing.Point(16, 22);
            this.LblCodigo.Name = "LblCodigo";
            this.LblCodigo.Size = new System.Drawing.Size(47, 14);
            this.LblCodigo.TabIndex = 21;
            this.LblCodigo.Text = "Codigo:";
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
            this.btnSalvar.Location = new System.Drawing.Point(509, 10);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(91, 29);
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
            this.btnCancel.Location = new System.Drawing.Point(627, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 29);
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
            this.panelContent.Controls.Add(this.groupBoxCampanhas);
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
            this.panelContent.Size = new System.Drawing.Size(725, 207);
            this.panelContent.TabIndex = 4;
            // 
            // panelCommands
            // 
            this.panelCommands.Controls.Add(this.btnSalvar);
            this.panelCommands.Controls.Add(this.btnCancel);
            this.panelCommands.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCommands.Location = new System.Drawing.Point(0, 207);
            this.panelCommands.Name = "panelCommands";
            this.panelCommands.Size = new System.Drawing.Size(725, 48);
            this.panelCommands.TabIndex = 5;
            // 
            // groupBoxCampanhas
            // 
            this.groupBoxCampanhas.Controls.Add(this.panelCampanhas);
            this.groupBoxCampanhas.Controls.Add(this.label6);
            this.groupBoxCampanhas.Location = new System.Drawing.Point(334, 12);
            this.groupBoxCampanhas.Name = "groupBoxCampanhas";
            this.groupBoxCampanhas.Size = new System.Drawing.Size(379, 182);
            this.groupBoxCampanhas.TabIndex = 27;
            this.groupBoxCampanhas.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 14);
            this.label6.TabIndex = 21;
            this.label6.Text = "Campanhas:";
            // 
            // panelCampanhas
            // 
            this.panelCampanhas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCampanhas.Location = new System.Drawing.Point(3, 18);
            this.panelCampanhas.Name = "panelCampanhas";
            this.panelCampanhas.Size = new System.Drawing.Size(373, 161);
            this.panelCampanhas.TabIndex = 22;
            // 
            // CatalogoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 255);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelCommands);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CatalogoForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Catálogo";
            this.Load += new System.EventHandler(this.CatalogoForm_Load);
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.panelCommands.ResumeLayout(false);
            this.groupBoxCampanhas.ResumeLayout(false);
            this.groupBoxCampanhas.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbFornecedor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textMargemDistribuidor;
        private System.Windows.Forms.TextBox textMargemVendedora;
        private System.Windows.Forms.TextBox textNome;
        public System.Windows.Forms.TextBox textCatalogoId;
        private System.Windows.Forms.Label LblCodigo;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelCommands;
        private System.Windows.Forms.GroupBox groupBoxCampanhas;
        private System.Windows.Forms.Panel panelCampanhas;
        private System.Windows.Forms.Label label6;
    }
}