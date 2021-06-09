
namespace MCatalogos.Views.FormViews.Produtos
{
    partial class TipoProdutoAddForm
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
            this.panelCommands = new System.Windows.Forms.Panel();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelContent = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textCatalogo = new System.Windows.Forms.TextBox();
            this.textTipoProdutoId = new System.Windows.Forms.TextBox();
            this.textTipoProduto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gBoxCampos = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panelCampos = new System.Windows.Forms.Panel();
            this.dgvCampos = new System.Windows.Forms.DataGridView();
            this.CampoTipoId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Formato = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.panelCommands.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.gBoxCampos.SuspendLayout();
            this.panelCampos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCampos)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCommands
            // 
            this.panelCommands.Controls.Add(this.btnSalvar);
            this.panelCommands.Controls.Add(this.btnCancel);
            this.panelCommands.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCommands.Location = new System.Drawing.Point(0, 136);
            this.panelCommands.Name = "panelCommands";
            this.panelCommands.Size = new System.Drawing.Size(593, 45);
            this.panelCommands.TabIndex = 5;
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
            this.btnSalvar.Location = new System.Drawing.Point(377, 9);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(91, 27);
            this.btnSalvar.TabIndex = 0;
            this.btnSalvar.TabStop = false;
            this.btnSalvar.Tag = "";
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvar.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(495, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 27);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.TabStop = false;
            this.btnCancel.Tag = "Pedidos";
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(111)))), ((int)(((byte)(156)))));
            this.panelContent.Controls.Add(this.gBoxCampos);
            this.panelContent.Controls.Add(this.label3);
            this.panelContent.Controls.Add(this.label2);
            this.panelContent.Controls.Add(this.label1);
            this.panelContent.Controls.Add(this.textTipoProduto);
            this.panelContent.Controls.Add(this.textCatalogo);
            this.panelContent.Controls.Add(this.textTipoProdutoId);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelContent.ForeColor = System.Drawing.Color.White;
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(593, 136);
            this.panelContent.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "Catálogo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "Código:";
            // 
            // textCatalogo
            // 
            this.textCatalogo.Enabled = false;
            this.textCatalogo.Location = new System.Drawing.Point(79, 41);
            this.textCatalogo.Name = "textCatalogo";
            this.textCatalogo.Size = new System.Drawing.Size(158, 22);
            this.textCatalogo.TabIndex = 1;
            // 
            // textTipoProdutoId
            // 
            this.textTipoProdutoId.Enabled = false;
            this.textTipoProdutoId.Location = new System.Drawing.Point(79, 14);
            this.textTipoProdutoId.Name = "textTipoProdutoId";
            this.textTipoProdutoId.Size = new System.Drawing.Size(59, 22);
            this.textTipoProdutoId.TabIndex = 0;
            // 
            // textTipoProduto
            // 
            this.textTipoProduto.Location = new System.Drawing.Point(22, 94);
            this.textTipoProduto.Name = "textTipoProduto";
            this.textTipoProduto.Size = new System.Drawing.Size(215, 22);
            this.textTipoProduto.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tipo de Produto:";
            // 
            // gBoxCampos
            // 
            this.gBoxCampos.Controls.Add(this.panelCampos);
            this.gBoxCampos.Controls.Add(this.label4);
            this.gBoxCampos.Location = new System.Drawing.Point(268, 12);
            this.gBoxCampos.Name = "gBoxCampos";
            this.gBoxCampos.Size = new System.Drawing.Size(313, 107);
            this.gBoxCampos.TabIndex = 9;
            this.gBoxCampos.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, -3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "Campos Adicionais:";
            // 
            // panelCampos
            // 
            this.panelCampos.Controls.Add(this.dgvCampos);
            this.panelCampos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCampos.Location = new System.Drawing.Point(3, 18);
            this.panelCampos.Name = "panelCampos";
            this.panelCampos.Size = new System.Drawing.Size(307, 86);
            this.panelCampos.TabIndex = 9;
            // 
            // dgvCampos
            // 
            this.dgvCampos.BackgroundColor = System.Drawing.Color.White;
            this.dgvCampos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCampos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CampoTipoId,
            this.Nome,
            this.Formato});
            this.dgvCampos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCampos.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvCampos.Location = new System.Drawing.Point(0, 0);
            this.dgvCampos.Name = "dgvCampos";
            this.dgvCampos.RowHeadersVisible = false;
            this.dgvCampos.Size = new System.Drawing.Size(307, 86);
            this.dgvCampos.TabIndex = 0;
            // 
            // CampoTipoId
            // 
            this.CampoTipoId.HeaderText = "CampoTipoId";
            this.CampoTipoId.Name = "CampoTipoId";
            this.CampoTipoId.Visible = false;
            // 
            // Nome
            // 
            this.Nome.HeaderText = "Campo";
            this.Nome.Name = "Nome";
            this.Nome.Width = 140;
            // 
            // Formato
            // 
            this.Formato.HeaderText = "Formato";
            this.Formato.Name = "Formato";
            this.Formato.Width = 140;
            // 
            // TipoProdutoAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 181);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelCommands);
            this.Name = "TipoProdutoAddForm";
            this.Text = "Cadastro de Tipo de Produto";
            this.panelCommands.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.gBoxCampos.ResumeLayout(false);
            this.gBoxCampos.PerformLayout();
            this.panelCampos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCampos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCommands;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textTipoProduto;
        private System.Windows.Forms.TextBox textCatalogo;
        private System.Windows.Forms.TextBox textTipoProdutoId;
        private System.Windows.Forms.GroupBox gBoxCampos;
        private System.Windows.Forms.Panel panelCampos;
        private System.Windows.Forms.DataGridView dgvCampos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn CampoTipoId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewComboBoxColumn Formato;
    }
}