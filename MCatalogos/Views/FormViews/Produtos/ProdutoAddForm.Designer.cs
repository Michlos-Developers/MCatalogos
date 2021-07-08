
namespace MCatalogos.Views.FormViews.Produtos
{
    partial class ProdutoAddForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProdutoAddForm));
            this.panelCommands = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.groupBoxTamanhos = new System.Windows.Forms.GroupBox();
            this.cbFormatoTamanho = new System.Windows.Forms.ComboBox();
            this.panelTamanhosUC = new System.Windows.Forms.Panel();
            this.dgvTamanhos = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textDescricao = new System.Windows.Forms.TextBox();
            this.textMargemDistribuidor = new System.Windows.Forms.TextBox();
            this.textMargemVendedora = new System.Windows.Forms.TextBox();
            this.textPagina = new System.Windows.Forms.TextBox();
            this.textValorGG = new System.Windows.Forms.TextBox();
            this.textValor = new System.Windows.Forms.TextBox();
            this.textReferencia = new System.Windows.Forms.TextBox();
            this.panelCatalogoCampanha = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textCampanha = new System.Windows.Forms.TextBox();
            this.textCatalogo = new System.Windows.Forms.TextBox();
            this.panelCommands.SuspendLayout();
            this.panelContainer.SuspendLayout();
            this.groupBoxTamanhos.SuspendLayout();
            this.panelTamanhosUC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTamanhos)).BeginInit();
            this.panelCatalogoCampanha.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCommands
            // 
            this.panelCommands.Controls.Add(this.btnSave);
            this.panelCommands.Controls.Add(this.btnCancel);
            this.panelCommands.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCommands.Location = new System.Drawing.Point(0, 315);
            this.panelCommands.Name = "panelCommands";
            this.panelCommands.Size = new System.Drawing.Size(454, 36);
            this.panelCommands.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = global::MCatalogos.Properties.Resources.iconSave20x20;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(255, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 29);
            this.btnSave.TabIndex = 0;
            this.btnSave.TabStop = false;
            this.btnSave.Tag = "Pedidos";
            this.btnSave.Text = "Salvar";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(352, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 29);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.TabStop = false;
            this.btnCancel.Tag = "Pedidos";
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panelContainer
            // 
            this.panelContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(111)))), ((int)(((byte)(156)))));
            this.panelContainer.Controls.Add(this.groupBoxTamanhos);
            this.panelContainer.Controls.Add(this.label4);
            this.panelContainer.Controls.Add(this.label7);
            this.panelContainer.Controls.Add(this.label6);
            this.panelContainer.Controls.Add(this.label9);
            this.panelContainer.Controls.Add(this.label8);
            this.panelContainer.Controls.Add(this.label5);
            this.panelContainer.Controls.Add(this.label3);
            this.panelContainer.Controls.Add(this.textDescricao);
            this.panelContainer.Controls.Add(this.textMargemDistribuidor);
            this.panelContainer.Controls.Add(this.textMargemVendedora);
            this.panelContainer.Controls.Add(this.textPagina);
            this.panelContainer.Controls.Add(this.textValorGG);
            this.panelContainer.Controls.Add(this.textValor);
            this.panelContainer.Controls.Add(this.textReferencia);
            this.panelContainer.Controls.Add(this.panelCatalogoCampanha);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(454, 315);
            this.panelContainer.TabIndex = 0;
            // 
            // groupBoxTamanhos
            // 
            this.groupBoxTamanhos.Controls.Add(this.cbFormatoTamanho);
            this.groupBoxTamanhos.Controls.Add(this.panelTamanhosUC);
            this.groupBoxTamanhos.Controls.Add(this.label10);
            this.groupBoxTamanhos.Controls.Add(this.label11);
            this.groupBoxTamanhos.Enabled = false;
            this.groupBoxTamanhos.Location = new System.Drawing.Point(15, 163);
            this.groupBoxTamanhos.Name = "groupBoxTamanhos";
            this.groupBoxTamanhos.Size = new System.Drawing.Size(269, 146);
            this.groupBoxTamanhos.TabIndex = 7;
            this.groupBoxTamanhos.TabStop = false;
            // 
            // cbFormatoTamanho
            // 
            this.cbFormatoTamanho.FormattingEnabled = true;
            this.cbFormatoTamanho.Location = new System.Drawing.Point(9, 33);
            this.cbFormatoTamanho.Name = "cbFormatoTamanho";
            this.cbFormatoTamanho.Size = new System.Drawing.Size(106, 22);
            this.cbFormatoTamanho.TabIndex = 0;
            this.cbFormatoTamanho.SelectedIndexChanged += new System.EventHandler(this.cbFormatoTamanho_SelectedIndexChanged);
            this.cbFormatoTamanho.Enter += new System.EventHandler(this.cbFormatoTamanho_Enter);
            this.cbFormatoTamanho.Leave += new System.EventHandler(this.cbFormatoTamanho_Leave);
            // 
            // panelTamanhosUC
            // 
            this.panelTamanhosUC.Controls.Add(this.dgvTamanhos);
            this.panelTamanhosUC.Enabled = false;
            this.panelTamanhosUC.Location = new System.Drawing.Point(121, 21);
            this.panelTamanhosUC.Name = "panelTamanhosUC";
            this.panelTamanhosUC.Size = new System.Drawing.Size(142, 119);
            this.panelTamanhosUC.TabIndex = 1;
            this.panelTamanhosUC.TabStop = true;
            // 
            // dgvTamanhos
            // 
            this.dgvTamanhos.BackgroundColor = System.Drawing.Color.White;
            this.dgvTamanhos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTamanhos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTamanhos.GridColor = System.Drawing.Color.DeepSkyBlue;
            this.dgvTamanhos.Location = new System.Drawing.Point(0, 0);
            this.dgvTamanhos.Name = "dgvTamanhos";
            this.dgvTamanhos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvTamanhos.Size = new System.Drawing.Size(142, 119);
            this.dgvTamanhos.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 14);
            this.label10.TabIndex = 1;
            this.label10.Text = "Tamanhos:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 14);
            this.label11.TabIndex = 1;
            this.label11.Text = "Formato Tamanho";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 1;
            this.label4.Text = "Descrição:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(321, 230);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 14);
            this.label7.TabIndex = 1;
            this.label7.Text = "% Distribuidor:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(326, 196);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 14);
            this.label6.TabIndex = 1;
            this.label6.Text = "% Vendedora:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(339, 163);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 14);
            this.label9.TabIndex = 1;
            this.label9.Text = "Página:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(255, 131);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 14);
            this.label8.TabIndex = 1;
            this.label8.Text = "Preço (GG/EG):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 14);
            this.label5.TabIndex = 1;
            this.label5.Text = "Preço:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 14);
            this.label3.TabIndex = 1;
            this.label3.Text = "Referência:";
            // 
            // textDescricao
            // 
            this.textDescricao.Location = new System.Drawing.Point(76, 94);
            this.textDescricao.Name = "textDescricao";
            this.textDescricao.Size = new System.Drawing.Size(366, 22);
            this.textDescricao.TabIndex = 1;
            this.textDescricao.Enter += new System.EventHandler(this.textDescricao_Enter);
            this.textDescricao.Leave += new System.EventHandler(this.textDescricao_Leave);
            // 
            // textMargemDistribuidor
            // 
            this.textMargemDistribuidor.Location = new System.Drawing.Point(409, 226);
            this.textMargemDistribuidor.Name = "textMargemDistribuidor";
            this.textMargemDistribuidor.Size = new System.Drawing.Size(33, 22);
            this.textMargemDistribuidor.TabIndex = 6;
            this.textMargemDistribuidor.Enter += new System.EventHandler(this.textMargemDistribuidor_Enter);
            this.textMargemDistribuidor.Leave += new System.EventHandler(this.textMargemDistribuidor_Leave);
            // 
            // textMargemVendedora
            // 
            this.textMargemVendedora.Location = new System.Drawing.Point(409, 192);
            this.textMargemVendedora.Name = "textMargemVendedora";
            this.textMargemVendedora.Size = new System.Drawing.Size(33, 22);
            this.textMargemVendedora.TabIndex = 5;
            this.textMargemVendedora.Enter += new System.EventHandler(this.textMargemVendedora_Enter);
            this.textMargemVendedora.Leave += new System.EventHandler(this.textMargemVendedora_Leave);
            // 
            // textPagina
            // 
            this.textPagina.Location = new System.Drawing.Point(387, 159);
            this.textPagina.Name = "textPagina";
            this.textPagina.Size = new System.Drawing.Size(55, 22);
            this.textPagina.TabIndex = 4;
            this.textPagina.Enter += new System.EventHandler(this.textPagina_Enter);
            this.textPagina.Leave += new System.EventHandler(this.textPagina_Leave);
            // 
            // textValorGG
            // 
            this.textValorGG.Location = new System.Drawing.Point(342, 127);
            this.textValorGG.Name = "textValorGG";
            this.textValorGG.Size = new System.Drawing.Size(100, 22);
            this.textValorGG.TabIndex = 3;
            this.textValorGG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textValorGG.Enter += new System.EventHandler(this.textValorGG_Enter);
            this.textValorGG.Leave += new System.EventHandler(this.textValorGG_Leave);
            // 
            // textValor
            // 
            this.textValor.Location = new System.Drawing.Point(76, 127);
            this.textValor.Name = "textValor";
            this.textValor.Size = new System.Drawing.Size(107, 22);
            this.textValor.TabIndex = 2;
            this.textValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textValor.Enter += new System.EventHandler(this.textValor_Enter);
            this.textValor.Leave += new System.EventHandler(this.textValor_Leave);
            // 
            // textReferencia
            // 
            this.textReferencia.Location = new System.Drawing.Point(76, 61);
            this.textReferencia.Name = "textReferencia";
            this.textReferencia.Size = new System.Drawing.Size(107, 22);
            this.textReferencia.TabIndex = 0;
            this.textReferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textReferencia.Enter += new System.EventHandler(this.textReferencia_Enter);
            this.textReferencia.Leave += new System.EventHandler(this.textReferencia_Leave);
            // 
            // panelCatalogoCampanha
            // 
            this.panelCatalogoCampanha.Controls.Add(this.label2);
            this.panelCatalogoCampanha.Controls.Add(this.label1);
            this.panelCatalogoCampanha.Controls.Add(this.textCampanha);
            this.panelCatalogoCampanha.Controls.Add(this.textCatalogo);
            this.panelCatalogoCampanha.Location = new System.Drawing.Point(7, 3);
            this.panelCatalogoCampanha.Name = "panelCatalogoCampanha";
            this.panelCatalogoCampanha.Size = new System.Drawing.Size(441, 45);
            this.panelCatalogoCampanha.TabIndex = 0;
            this.panelCatalogoCampanha.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Campanha:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Catálogo:";
            // 
            // textCampanha
            // 
            this.textCampanha.Location = new System.Drawing.Point(299, 15);
            this.textCampanha.Name = "textCampanha";
            this.textCampanha.ReadOnly = true;
            this.textCampanha.Size = new System.Drawing.Size(136, 22);
            this.textCampanha.TabIndex = 1;
            this.textCampanha.TabStop = false;
            // 
            // textCatalogo
            // 
            this.textCatalogo.Location = new System.Drawing.Point(64, 15);
            this.textCatalogo.Name = "textCatalogo";
            this.textCatalogo.ReadOnly = true;
            this.textCatalogo.Size = new System.Drawing.Size(136, 22);
            this.textCatalogo.TabIndex = 0;
            this.textCatalogo.TabStop = false;
            // 
            // ProdutoAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 351);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelCommands);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProdutoAddForm";
            this.ShowInTaskbar = false;
            this.Text = "ProdutoAddForm";
            this.Load += new System.EventHandler(this.ProdutoAddForm_Load);
            this.panelCommands.ResumeLayout(false);
            this.panelContainer.ResumeLayout(false);
            this.panelContainer.PerformLayout();
            this.groupBoxTamanhos.ResumeLayout(false);
            this.groupBoxTamanhos.PerformLayout();
            this.panelTamanhosUC.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTamanhos)).EndInit();
            this.panelCatalogoCampanha.ResumeLayout(false);
            this.panelCatalogoCampanha.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCommands;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textDescricao;
        private System.Windows.Forms.TextBox textPagina;
        private System.Windows.Forms.TextBox textReferencia;
        private System.Windows.Forms.GroupBox panelCatalogoCampanha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textCampanha;
        private System.Windows.Forms.TextBox textCatalogo;
        private System.Windows.Forms.GroupBox groupBoxTamanhos;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panelTamanhosUC;
        private System.Windows.Forms.ComboBox cbFormatoTamanho;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textMargemDistribuidor;
        private System.Windows.Forms.TextBox textMargemVendedora;
        private System.Windows.Forms.TextBox textValorGG;
        private System.Windows.Forms.TextBox textValor;
        public System.Windows.Forms.DataGridView dgvTamanhos;
    }
}