
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
            this.groupVariacaoValor = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.chkVariacaoValor = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textNumeracaoVariacao = new System.Windows.Forms.TextBox();
            this.textTamanhoVariacao = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
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
            this.label6 = new System.Windows.Forms.Label();
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
            this.groupVariacaoValor.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCommands
            // 
            this.panelCommands.Controls.Add(this.btnSalvar);
            this.panelCommands.Controls.Add(this.btnCancel);
            this.panelCommands.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCommands.Location = new System.Drawing.Point(0, 320);
            this.panelCommands.Name = "panelCommands";
            this.panelCommands.Size = new System.Drawing.Size(554, 45);
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
            this.btnSalvar.Location = new System.Drawing.Point(338, 9);
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
            this.btnCancel.Location = new System.Drawing.Point(456, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 27);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.TabStop = false;
            this.btnCancel.Tag = "Pedidos";
            this.btnCancel.Text = "Fechar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(111)))), ((int)(((byte)(156)))));
            this.panelContent.Controls.Add(this.groupVariacaoValor);
            this.panelContent.Controls.Add(this.groupBox2);
            this.panelContent.Controls.Add(this.groupBox1);
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
            this.panelContent.Size = new System.Drawing.Size(554, 320);
            this.panelContent.TabIndex = 0;
            // 
            // groupVariacaoValor
            // 
            this.groupVariacaoValor.Controls.Add(this.label13);
            this.groupVariacaoValor.Controls.Add(this.chkVariacaoValor);
            this.groupVariacaoValor.Controls.Add(this.label16);
            this.groupVariacaoValor.Controls.Add(this.label15);
            this.groupVariacaoValor.Controls.Add(this.textNumeracaoVariacao);
            this.groupVariacaoValor.Controls.Add(this.textTamanhoVariacao);
            this.groupVariacaoValor.Controls.Add(this.label18);
            this.groupVariacaoValor.Controls.Add(this.label17);
            this.groupVariacaoValor.Location = new System.Drawing.Point(109, 235);
            this.groupVariacaoValor.Name = "groupVariacaoValor";
            this.groupVariacaoValor.Size = new System.Drawing.Size(354, 82);
            this.groupVariacaoValor.TabIndex = 7;
            this.groupVariacaoValor.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(102, 14);
            this.label13.TabIndex = 23;
            this.label13.Text = "Valores Variados:";
            // 
            // chkVariacaoValor
            // 
            this.chkVariacaoValor.AutoSize = true;
            this.chkVariacaoValor.Location = new System.Drawing.Point(55, 52);
            this.chkVariacaoValor.Name = "chkVariacaoValor";
            this.chkVariacaoValor.Size = new System.Drawing.Size(15, 14);
            this.chkVariacaoValor.TabIndex = 0;
            this.chkVariacaoValor.UseVisualStyleBackColor = true;
            this.chkVariacaoValor.CheckStateChanged += new System.EventHandler(this.chkVariacaoValor_CheckStateChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(5, 35);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(115, 14);
            this.label16.TabIndex = 23;
            this.label16.Text = "Valor por Tamanho?";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 21);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(110, 14);
            this.label15.TabIndex = 23;
            this.label15.Text = "Possui Variação de";
            // 
            // textNumeracaoVariacao
            // 
            this.textNumeracaoVariacao.Enabled = false;
            this.textNumeracaoVariacao.Location = new System.Drawing.Point(306, 48);
            this.textNumeracaoVariacao.Name = "textNumeracaoVariacao";
            this.textNumeracaoVariacao.Size = new System.Drawing.Size(29, 22);
            this.textNumeracaoVariacao.TabIndex = 2;
            // 
            // textTamanhoVariacao
            // 
            this.textTamanhoVariacao.Enabled = false;
            this.textTamanhoVariacao.Location = new System.Drawing.Point(306, 20);
            this.textTamanhoVariacao.Name = "textTamanhoVariacao";
            this.textTamanhoVariacao.Size = new System.Drawing.Size(29, 22);
            this.textTamanhoVariacao.TabIndex = 1;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(158, 51);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(150, 14);
            this.label18.TabIndex = 23;
            this.label18.Text = "Numeração para Variação:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(170, 24);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(138, 14);
            this.label17.TabIndex = 23;
            this.label17.Text = "Tamanho para Variação:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.textValorTaxaPedido);
            this.groupBox2.Controls.Add(this.checkBoxTaxaPedido);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(23, 135);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(236, 94);
            this.groupBox2.TabIndex = 5;
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
            this.textValorTaxaPedido.Location = new System.Drawing.Point(165, 50);
            this.textValorTaxaPedido.Name = "textValorTaxaPedido";
            this.textValorTaxaPedido.Size = new System.Drawing.Size(46, 22);
            this.textValorTaxaPedido.TabIndex = 1;
            // 
            // checkBoxTaxaPedido
            // 
            this.checkBoxTaxaPedido.AutoSize = true;
            this.checkBoxTaxaPedido.Location = new System.Drawing.Point(165, 28);
            this.checkBoxTaxaPedido.Name = "checkBoxTaxaPedido";
            this.checkBoxTaxaPedido.Size = new System.Drawing.Size(15, 14);
            this.checkBoxTaxaPedido.TabIndex = 0;
            this.checkBoxTaxaPedido.UseVisualStyleBackColor = true;
            this.checkBoxTaxaPedido.CheckStateChanged += new System.EventHandler(this.checkBoxTaxaPedido_CheckStateChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(160, 14);
            this.label10.TabIndex = 23;
            this.label10.Text = "Valor da Taxa por Pedido: R$";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 28);
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
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(290, 135);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 94);
            this.groupBox1.TabIndex = 6;
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 14);
            this.label6.TabIndex = 23;
            this.label6.Text = "Possui Taxa por Produto?";
            // 
            // cbFornecedor
            // 
            this.cbFornecedor.Enabled = false;
            this.cbFornecedor.FormattingEnabled = true;
            this.cbFornecedor.Location = new System.Drawing.Point(306, 12);
            this.cbFornecedor.Name = "cbFornecedor";
            this.cbFornecedor.Size = new System.Drawing.Size(220, 22);
            this.cbFornecedor.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(229, 15);
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
            this.cbStatus.Location = new System.Drawing.Point(63, 53);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(62, 22);
            this.cbStatus.TabIndex = 1;
            this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.cbStatus_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(528, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 14);
            this.label8.TabIndex = 24;
            this.label8.Text = "%";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(528, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 14);
            this.label7.TabIndex = 24;
            this.label7.Text = "%";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 14);
            this.label4.TabIndex = 24;
            this.label4.Text = "Status:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(326, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 14);
            this.label3.TabIndex = 23;
            this.label3.Text = "Margem Padrão Distribuidor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(334, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 14);
            this.label2.TabIndex = 23;
            this.label2.Text = "Margem Padrão Vendedora:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 23;
            this.label1.Text = "Nome:";
            // 
            // textMargemDistribuidor
            // 
            this.textMargemDistribuidor.Location = new System.Drawing.Point(497, 73);
            this.textMargemDistribuidor.Name = "textMargemDistribuidor";
            this.textMargemDistribuidor.Size = new System.Drawing.Size(29, 22);
            this.textMargemDistribuidor.TabIndex = 4;
            // 
            // textMargemVendedora
            // 
            this.textMargemVendedora.Location = new System.Drawing.Point(497, 45);
            this.textMargemVendedora.Name = "textMargemVendedora";
            this.textMargemVendedora.Size = new System.Drawing.Size(29, 22);
            this.textMargemVendedora.TabIndex = 3;
            // 
            // textNome
            // 
            this.textNome.Location = new System.Drawing.Point(63, 88);
            this.textNome.Name = "textNome";
            this.textNome.Size = new System.Drawing.Size(242, 22);
            this.textNome.TabIndex = 2;
            // 
            // textCatalogoId
            // 
            this.textCatalogoId.Enabled = false;
            this.textCatalogoId.Location = new System.Drawing.Point(63, 17);
            this.textCatalogoId.Name = "textCatalogoId";
            this.textCatalogoId.Size = new System.Drawing.Size(100, 22);
            this.textCatalogoId.TabIndex = 0;
            this.textCatalogoId.TabStop = false;
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
            this.ClientSize = new System.Drawing.Size(554, 365);
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
            this.groupVariacaoValor.ResumeLayout(false);
            this.groupVariacaoValor.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.CheckBox checkBoxTaxaProduto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textValorTaxaProduto;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textValorTaxaPedido;
        private System.Windows.Forms.CheckBox checkBoxTaxaPedido;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupVariacaoValor;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox chkVariacaoValor;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textNumeracaoVariacao;
        private System.Windows.Forms.TextBox textTamanhoVariacao;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
    }
}