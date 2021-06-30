
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.groupVariacaoValor = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.chkVariacaoValor = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textNumeracaoVariacao = new System.Windows.Forms.TextBox();
            this.textTamanhoVariacao = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textValorTaxaPedido = new System.Windows.Forms.TextBox();
            this.checkBoxTaxaPedido = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textValorTaxaProduto = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBoxTaxaProduto = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBoxCampanhas = new System.Windows.Forms.GroupBox();
            this.panelCampanhas = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panelCommands = new System.Windows.Forms.Panel();
            this.panelContent.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupVariacaoValor.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxCampanhas.SuspendLayout();
            this.panelCommands.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbFornecedor
            // 
            this.cbFornecedor.Enabled = false;
            this.cbFornecedor.FormattingEnabled = true;
            this.cbFornecedor.Location = new System.Drawing.Point(271, 18);
            this.cbFornecedor.Name = "cbFornecedor";
            this.cbFornecedor.Size = new System.Drawing.Size(282, 22);
            this.cbFornecedor.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(194, 22);
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
            this.cbStatus.Location = new System.Drawing.Point(63, 46);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(62, 22);
            this.cbStatus.TabIndex = 1;
            this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.cbStatus_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 14);
            this.label4.TabIndex = 24;
            this.label4.Text = "Status:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 14);
            this.label3.TabIndex = 23;
            this.label3.Text = "% Distribuidor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 14);
            this.label2.TabIndex = 23;
            this.label2.Text = "% Vendedora:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 23;
            this.label1.Text = "Nome:";
            // 
            // textMargemDistribuidor
            // 
            this.textMargemDistribuidor.Location = new System.Drawing.Point(174, 41);
            this.textMargemDistribuidor.Name = "textMargemDistribuidor";
            this.textMargemDistribuidor.Size = new System.Drawing.Size(46, 22);
            this.textMargemDistribuidor.TabIndex = 1;
            // 
            // textMargemVendedora
            // 
            this.textMargemVendedora.Location = new System.Drawing.Point(174, 13);
            this.textMargemVendedora.Name = "textMargemVendedora";
            this.textMargemVendedora.Size = new System.Drawing.Size(46, 22);
            this.textMargemVendedora.TabIndex = 0;
            // 
            // textNome
            // 
            this.textNome.Location = new System.Drawing.Point(63, 74);
            this.textNome.Name = "textNome";
            this.textNome.Size = new System.Drawing.Size(487, 22);
            this.textNome.TabIndex = 2;
            // 
            // textCatalogoId
            // 
            this.textCatalogoId.Enabled = false;
            this.textCatalogoId.Location = new System.Drawing.Point(63, 18);
            this.textCatalogoId.Name = "textCatalogoId";
            this.textCatalogoId.Size = new System.Drawing.Size(100, 22);
            this.textCatalogoId.TabIndex = 0;
            this.textCatalogoId.TabStop = false;
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
            this.btnSalvar.Location = new System.Drawing.Point(638, 10);
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
            this.btnCancel.Location = new System.Drawing.Point(756, 10);
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
            this.panelContent.Controls.Add(this.groupBox3);
            this.panelContent.Controls.Add(this.groupVariacaoValor);
            this.panelContent.Controls.Add(this.groupBox2);
            this.panelContent.Controls.Add(this.groupBox1);
            this.panelContent.Controls.Add(this.groupBoxCampanhas);
            this.panelContent.Controls.Add(this.cbFornecedor);
            this.panelContent.Controls.Add(this.label5);
            this.panelContent.Controls.Add(this.cbStatus);
            this.panelContent.Controls.Add(this.label4);
            this.panelContent.Controls.Add(this.label1);
            this.panelContent.Controls.Add(this.textNome);
            this.panelContent.Controls.Add(this.textCatalogoId);
            this.panelContent.Controls.Add(this.LblCodigo);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(854, 409);
            this.panelContent.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textMargemDistribuidor);
            this.groupBox3.Controls.Add(this.textMargemVendedora);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(591, 222);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(236, 69);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(104, 14);
            this.label20.TabIndex = 23;
            this.label20.Text = "Margens Padrões:";
            // 
            // groupVariacaoValor
            // 
            this.groupVariacaoValor.Controls.Add(this.label15);
            this.groupVariacaoValor.Controls.Add(this.chkVariacaoValor);
            this.groupVariacaoValor.Controls.Add(this.label17);
            this.groupVariacaoValor.Controls.Add(this.textNumeracaoVariacao);
            this.groupVariacaoValor.Controls.Add(this.textTamanhoVariacao);
            this.groupVariacaoValor.Controls.Add(this.label18);
            this.groupVariacaoValor.Controls.Add(this.label19);
            this.groupVariacaoValor.Location = new System.Drawing.Point(591, 294);
            this.groupVariacaoValor.Name = "groupVariacaoValor";
            this.groupVariacaoValor.Size = new System.Drawing.Size(236, 110);
            this.groupVariacaoValor.TabIndex = 6;
            this.groupVariacaoValor.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(102, 14);
            this.label15.TabIndex = 23;
            this.label15.Text = "Valores Variados:";
            // 
            // chkVariacaoValor
            // 
            this.chkVariacaoValor.AutoSize = true;
            this.chkVariacaoValor.Location = new System.Drawing.Point(174, 27);
            this.chkVariacaoValor.Name = "chkVariacaoValor";
            this.chkVariacaoValor.Size = new System.Drawing.Size(15, 14);
            this.chkVariacaoValor.TabIndex = 0;
            this.chkVariacaoValor.UseVisualStyleBackColor = true;
            this.chkVariacaoValor.CheckStateChanged += new System.EventHandler(this.chkVariacaoValor_CheckStateChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(80, 26);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(96, 14);
            this.label17.TabIndex = 23;
            this.label17.Text = "Possui Variação:";
            // 
            // textNumeracaoVariacao
            // 
            this.textNumeracaoVariacao.Enabled = false;
            this.textNumeracaoVariacao.Location = new System.Drawing.Point(174, 75);
            this.textNumeracaoVariacao.Name = "textNumeracaoVariacao";
            this.textNumeracaoVariacao.Size = new System.Drawing.Size(29, 22);
            this.textNumeracaoVariacao.TabIndex = 2;
            // 
            // textTamanhoVariacao
            // 
            this.textTamanhoVariacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textTamanhoVariacao.Enabled = false;
            this.textTamanhoVariacao.Location = new System.Drawing.Point(174, 47);
            this.textTamanhoVariacao.Name = "textTamanhoVariacao";
            this.textTamanhoVariacao.Size = new System.Drawing.Size(29, 22);
            this.textTamanhoVariacao.TabIndex = 1;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(26, 78);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(150, 14);
            this.label18.TabIndex = 23;
            this.label18.Text = "Numeração para Variação:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(38, 51);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(138, 14);
            this.label19.TabIndex = 23;
            this.label19.Text = "Tamanho para Variação:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.textValorTaxaPedido);
            this.groupBox2.Controls.Add(this.checkBoxTaxaPedido);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(591, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(236, 94);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(97, 14);
            this.label14.TabIndex = 23;
            this.label14.Text = "Taxa Por PEDIDO:";
            // 
            // textValorTaxaPedido
            // 
            this.textValorTaxaPedido.Enabled = false;
            this.textValorTaxaPedido.Location = new System.Drawing.Point(174, 50);
            this.textValorTaxaPedido.Name = "textValorTaxaPedido";
            this.textValorTaxaPedido.Size = new System.Drawing.Size(46, 22);
            this.textValorTaxaPedido.TabIndex = 1;
            // 
            // checkBoxTaxaPedido
            // 
            this.checkBoxTaxaPedido.AutoSize = true;
            this.checkBoxTaxaPedido.Location = new System.Drawing.Point(174, 28);
            this.checkBoxTaxaPedido.Name = "checkBoxTaxaPedido";
            this.checkBoxTaxaPedido.Size = new System.Drawing.Size(15, 14);
            this.checkBoxTaxaPedido.TabIndex = 0;
            this.checkBoxTaxaPedido.UseVisualStyleBackColor = true;
            this.checkBoxTaxaPedido.CheckStateChanged += new System.EventHandler(this.checkBoxTaxaPedido_CheckStateChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(156, 14);
            this.label10.TabIndex = 23;
            this.label10.Text = "Valor da Taxa por Pedido: %";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(31, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(138, 14);
            this.label11.TabIndex = 23;
            this.label11.Text = "Possui Taxa por Pedido?";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textValorTaxaProduto);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.checkBoxTaxaProduto);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Location = new System.Drawing.Point(591, 116);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 99);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // textValorTaxaProduto
            // 
            this.textValorTaxaProduto.Enabled = false;
            this.textValorTaxaProduto.Location = new System.Drawing.Point(174, 50);
            this.textValorTaxaProduto.Name = "textValorTaxaProduto";
            this.textValorTaxaProduto.Size = new System.Drawing.Size(46, 22);
            this.textValorTaxaProduto.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(164, 14);
            this.label9.TabIndex = 23;
            this.label9.Text = "Valor da Taxa por Produto: R$";
            // 
            // checkBoxTaxaProduto
            // 
            this.checkBoxTaxaProduto.AutoSize = true;
            this.checkBoxTaxaProduto.Location = new System.Drawing.Point(174, 28);
            this.checkBoxTaxaProduto.Name = "checkBoxTaxaProduto";
            this.checkBoxTaxaProduto.Size = new System.Drawing.Size(15, 14);
            this.checkBoxTaxaProduto.TabIndex = 0;
            this.checkBoxTaxaProduto.UseVisualStyleBackColor = true;
            this.checkBoxTaxaProduto.CheckStateChanged += new System.EventHandler(this.checkBoxTaxaProduto_CheckStateChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(108, 14);
            this.label12.TabIndex = 23;
            this.label12.Text = "Taxa Por PRODUTO:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(31, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(142, 14);
            this.label13.TabIndex = 23;
            this.label13.Text = "Possui Taxa por Produto?";
            // 
            // groupBoxCampanhas
            // 
            this.groupBoxCampanhas.Controls.Add(this.panelCampanhas);
            this.groupBoxCampanhas.Controls.Add(this.label6);
            this.groupBoxCampanhas.Location = new System.Drawing.Point(13, 116);
            this.groupBoxCampanhas.Name = "groupBoxCampanhas";
            this.groupBoxCampanhas.Size = new System.Drawing.Size(540, 272);
            this.groupBoxCampanhas.TabIndex = 27;
            this.groupBoxCampanhas.TabStop = false;
            // 
            // panelCampanhas
            // 
            this.panelCampanhas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCampanhas.Location = new System.Drawing.Point(3, 18);
            this.panelCampanhas.Name = "panelCampanhas";
            this.panelCampanhas.Size = new System.Drawing.Size(534, 251);
            this.panelCampanhas.TabIndex = 0;
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
            // panelCommands
            // 
            this.panelCommands.Controls.Add(this.btnSalvar);
            this.panelCommands.Controls.Add(this.btnCancel);
            this.panelCommands.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCommands.Location = new System.Drawing.Point(0, 409);
            this.panelCommands.Name = "panelCommands";
            this.panelCommands.Size = new System.Drawing.Size(854, 48);
            this.panelCommands.TabIndex = 5;
            // 
            // CatalogoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 457);
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
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupVariacaoValor.ResumeLayout(false);
            this.groupVariacaoValor.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxCampanhas.ResumeLayout(false);
            this.groupBoxCampanhas.PerformLayout();
            this.panelCommands.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

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
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelCommands;
        private System.Windows.Forms.GroupBox groupBoxCampanhas;
        private System.Windows.Forms.Panel panelCampanhas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textValorTaxaPedido;
        private System.Windows.Forms.CheckBox checkBoxTaxaPedido;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textValorTaxaProduto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBoxTaxaProduto;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox groupVariacaoValor;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox chkVariacaoValor;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textNumeracaoVariacao;
        private System.Windows.Forms.TextBox textTamanhoVariacao;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
    }
}