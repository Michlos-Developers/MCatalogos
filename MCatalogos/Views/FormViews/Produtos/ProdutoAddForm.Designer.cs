
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelCatalogoCampanha = new System.Windows.Forms.GroupBox();
            this.textCatalogo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textCampanha = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textReferencia = new System.Windows.Forms.TextBox();
            this.cbTipoProduto = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textDescricao = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textValor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textMargemVendedora = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textMargemDistribuidor = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCampoAdicional = new System.Windows.Forms.Label();
            this.cbCampoAdicional = new System.Windows.Forms.ComboBox();
            this.textPagina = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panelCommands.SuspendLayout();
            this.panelContainer.SuspendLayout();
            this.panelCatalogoCampanha.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCommands
            // 
            this.panelCommands.Controls.Add(this.btnAdd);
            this.panelCommands.Controls.Add(this.btnCancel);
            this.panelCommands.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCommands.Location = new System.Drawing.Point(0, 282);
            this.panelCommands.Name = "panelCommands";
            this.panelCommands.Size = new System.Drawing.Size(454, 36);
            this.panelCommands.TabIndex = 8;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Image = global::MCatalogos.Properties.Resources.iconSave20x20;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(255, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(91, 29);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Tag = "Pedidos";
            this.btnAdd.Text = "Salvar";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = false;
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
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Tag = "Pedidos";
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // panelContainer
            // 
            this.panelContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(111)))), ((int)(((byte)(156)))));
            this.panelContainer.Controls.Add(this.comboBox1);
            this.panelContainer.Controls.Add(this.label10);
            this.panelContainer.Controls.Add(this.cbCampoAdicional);
            this.panelContainer.Controls.Add(this.lblCampoAdicional);
            this.panelContainer.Controls.Add(this.cbTipoProduto);
            this.panelContainer.Controls.Add(this.label8);
            this.panelContainer.Controls.Add(this.label4);
            this.panelContainer.Controls.Add(this.label7);
            this.panelContainer.Controls.Add(this.label6);
            this.panelContainer.Controls.Add(this.label9);
            this.panelContainer.Controls.Add(this.label5);
            this.panelContainer.Controls.Add(this.label3);
            this.panelContainer.Controls.Add(this.textDescricao);
            this.panelContainer.Controls.Add(this.textMargemDistribuidor);
            this.panelContainer.Controls.Add(this.textMargemVendedora);
            this.panelContainer.Controls.Add(this.textPagina);
            this.panelContainer.Controls.Add(this.textValor);
            this.panelContainer.Controls.Add(this.textReferencia);
            this.panelContainer.Controls.Add(this.panelCatalogoCampanha);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(454, 282);
            this.panelContainer.TabIndex = 9;
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
            // textCatalogo
            // 
            this.textCatalogo.Location = new System.Drawing.Point(64, 15);
            this.textCatalogo.Name = "textCatalogo";
            this.textCatalogo.Size = new System.Drawing.Size(136, 22);
            this.textCatalogo.TabIndex = 0;
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
            this.textCampanha.Size = new System.Drawing.Size(136, 22);
            this.textCampanha.TabIndex = 0;
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
            // textReferencia
            // 
            this.textReferencia.Location = new System.Drawing.Point(7, 73);
            this.textReferencia.Name = "textReferencia";
            this.textReferencia.Size = new System.Drawing.Size(100, 22);
            this.textReferencia.TabIndex = 1;
            this.textReferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbTipoProduto
            // 
            this.cbTipoProduto.FormattingEnabled = true;
            this.cbTipoProduto.Location = new System.Drawing.Point(197, 168);
            this.cbTipoProduto.Name = "cbTipoProduto";
            this.cbTipoProduto.Size = new System.Drawing.Size(121, 22);
            this.cbTipoProduto.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 14);
            this.label3.TabIndex = 1;
            this.label3.Text = "Referência:";
            // 
            // textDescricao
            // 
            this.textDescricao.Location = new System.Drawing.Point(7, 121);
            this.textDescricao.Name = "textDescricao";
            this.textDescricao.Size = new System.Drawing.Size(434, 22);
            this.textDescricao.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 1;
            this.label4.Text = "Descrição:";
            // 
            // textValor
            // 
            this.textValor.Location = new System.Drawing.Point(7, 168);
            this.textValor.Name = "textValor";
            this.textValor.Size = new System.Drawing.Size(100, 22);
            this.textValor.TabIndex = 1;
            this.textValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 14);
            this.label5.TabIndex = 1;
            this.label5.Text = "Preço:";
            // 
            // textMargemVendedora
            // 
            this.textMargemVendedora.Location = new System.Drawing.Point(131, 206);
            this.textMargemVendedora.Name = "textMargemVendedora";
            this.textMargemVendedora.Size = new System.Drawing.Size(33, 22);
            this.textMargemVendedora.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 14);
            this.label6.TabIndex = 1;
            this.label6.Text = "Margem Vendedora:";
            // 
            // textMargemDistribuidor
            // 
            this.textMargemDistribuidor.Location = new System.Drawing.Point(131, 234);
            this.textMargemDistribuidor.Name = "textMargemDistribuidor";
            this.textMargemDistribuidor.Size = new System.Drawing.Size(33, 22);
            this.textMargemDistribuidor.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 238);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 14);
            this.label7.TabIndex = 1;
            this.label7.Text = "Margem Distribuidor:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(197, 151);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 14);
            this.label8.TabIndex = 1;
            this.label8.Text = "Tipo Produto:";
            // 
            // lblCampoAdicional
            // 
            this.lblCampoAdicional.AutoSize = true;
            this.lblCampoAdicional.Location = new System.Drawing.Point(339, 152);
            this.lblCampoAdicional.Name = "lblCampoAdicional";
            this.lblCampoAdicional.Size = new System.Drawing.Size(102, 14);
            this.lblCampoAdicional.TabIndex = 1;
            this.lblCampoAdicional.Text = "Campo Adicional:";
            this.lblCampoAdicional.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCampoAdicional.Visible = false;
            // 
            // cbCampoAdicional
            // 
            this.cbCampoAdicional.FormattingEnabled = true;
            this.cbCampoAdicional.Location = new System.Drawing.Point(341, 169);
            this.cbCampoAdicional.Name = "cbCampoAdicional";
            this.cbCampoAdicional.Size = new System.Drawing.Size(100, 22);
            this.cbCampoAdicional.TabIndex = 2;
            this.cbCampoAdicional.Visible = false;
            // 
            // textPagina
            // 
            this.textPagina.Location = new System.Drawing.Point(128, 168);
            this.textPagina.Name = "textPagina";
            this.textPagina.Size = new System.Drawing.Size(48, 22);
            this.textPagina.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(128, 151);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 14);
            this.label9.TabIndex = 1;
            this.label9.Text = "Página:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(339, 193);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 14);
            this.label10.TabIndex = 1;
            this.label10.Text = "Formato Campo:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label10.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(341, 210);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 22);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.Visible = false;
            // 
            // ProdutoAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 318);
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
            this.panelCatalogoCampanha.ResumeLayout(false);
            this.panelCatalogoCampanha.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCommands;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.ComboBox cbCampoAdicional;
        private System.Windows.Forms.Label lblCampoAdicional;
        private System.Windows.Forms.ComboBox cbTipoProduto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textDescricao;
        private System.Windows.Forms.TextBox textMargemDistribuidor;
        private System.Windows.Forms.TextBox textMargemVendedora;
        private System.Windows.Forms.TextBox textPagina;
        private System.Windows.Forms.TextBox textValor;
        private System.Windows.Forms.TextBox textReferencia;
        private System.Windows.Forms.GroupBox panelCatalogoCampanha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textCampanha;
        private System.Windows.Forms.TextBox textCatalogo;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label10;
    }
}