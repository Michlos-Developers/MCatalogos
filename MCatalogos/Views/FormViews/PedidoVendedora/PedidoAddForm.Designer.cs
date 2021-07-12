
namespace MCatalogos.Views.FormViews.PedidoVendedora
{
    partial class PedidoAddForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PedidoAddForm));
            this.panelCommands = new System.Windows.Forms.Panel();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelDetalhePedido = new System.Windows.Forms.Panel();
            this.dgvDetalhePedido = new System.Windows.Forms.DataGridView();
            this.mTextCpfVendedora = new System.Windows.Forms.MaskedTextBox();
            this.textNomeVendedora = new System.Windows.Forms.TextBox();
            this.textRotaVendedora = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbVendedora = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gbCatalogo = new System.Windows.Forms.GroupBox();
            this.cbCampanha = new System.Windows.Forms.ComboBox();
            this.cbCatalogo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gbAddItem = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbTamanho = new System.Windows.Forms.ComboBox();
            this.textQtd = new System.Windows.Forms.TextBox();
            this.textReferencia = new System.Windows.Forms.TextBox();
            this.panelCommands.SuspendLayout();
            this.panelDetalhePedido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalhePedido)).BeginInit();
            this.gbVendedora.SuspendLayout();
            this.gbCatalogo.SuspendLayout();
            this.gbAddItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCommands
            // 
            this.panelCommands.BackColor = System.Drawing.SystemColors.Control;
            this.panelCommands.Controls.Add(this.btnEdit);
            this.panelCommands.Controls.Add(this.btnDelete);
            this.panelCommands.Controls.Add(this.btnCancel);
            this.panelCommands.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCommands.Location = new System.Drawing.Point(0, 431);
            this.panelCommands.Name = "panelCommands";
            this.panelCommands.Size = new System.Drawing.Size(896, 34);
            this.panelCommands.TabIndex = 9;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Image = global::MCatalogos.Properties.Resources.IconEditProduto1;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(650, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(74, 27);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.TabStop = false;
            this.btnEdit.Tag = "Pedidos";
            this.btnEdit.Text = "Editar";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Image = global::MCatalogos.Properties.Resources.IconDelete20x20;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(730, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(74, 27);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.TabStop = false;
            this.btnDelete.Tag = "";
            this.btnDelete.Text = "Deletar";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(810, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(74, 27);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.TabStop = false;
            this.btnCancel.Tag = "Pedidos";
            this.btnCancel.Text = "Fechar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panelDetalhePedido
            // 
            this.panelDetalhePedido.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDetalhePedido.Controls.Add(this.dgvDetalhePedido);
            this.panelDetalhePedido.Location = new System.Drawing.Point(12, 158);
            this.panelDetalhePedido.Name = "panelDetalhePedido";
            this.panelDetalhePedido.Size = new System.Drawing.Size(872, 261);
            this.panelDetalhePedido.TabIndex = 10;
            // 
            // dgvDetalhePedido
            // 
            this.dgvDetalhePedido.AllowUserToAddRows = false;
            this.dgvDetalhePedido.AllowUserToDeleteRows = false;
            this.dgvDetalhePedido.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalhePedido.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgvDetalhePedido.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalhePedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalhePedido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalhePedido.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvDetalhePedido.GridColor = System.Drawing.Color.DeepSkyBlue;
            this.dgvDetalhePedido.Location = new System.Drawing.Point(0, 0);
            this.dgvDetalhePedido.Name = "dgvDetalhePedido";
            this.dgvDetalhePedido.ReadOnly = true;
            this.dgvDetalhePedido.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetalhePedido.ShowEditingIcon = false;
            this.dgvDetalhePedido.Size = new System.Drawing.Size(872, 261);
            this.dgvDetalhePedido.TabIndex = 0;
            this.dgvDetalhePedido.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalhePedido_CellDoubleClick);
            // 
            // mTextCpfVendedora
            // 
            this.mTextCpfVendedora.Location = new System.Drawing.Point(56, 23);
            this.mTextCpfVendedora.Name = "mTextCpfVendedora";
            this.mTextCpfVendedora.ReadOnly = true;
            this.mTextCpfVendedora.Size = new System.Drawing.Size(100, 23);
            this.mTextCpfVendedora.TabIndex = 0;
            this.mTextCpfVendedora.TabStop = false;
            // 
            // textNomeVendedora
            // 
            this.textNomeVendedora.Location = new System.Drawing.Point(56, 53);
            this.textNomeVendedora.Name = "textNomeVendedora";
            this.textNomeVendedora.ReadOnly = true;
            this.textNomeVendedora.Size = new System.Drawing.Size(329, 23);
            this.textNomeVendedora.TabIndex = 1;
            this.textNomeVendedora.TabStop = false;
            // 
            // textRotaVendedora
            // 
            this.textRotaVendedora.Location = new System.Drawing.Point(348, 24);
            this.textRotaVendedora.Name = "textRotaVendedora";
            this.textRotaVendedora.ReadOnly = true;
            this.textRotaVendedora.Size = new System.Drawing.Size(37, 23);
            this.textRotaVendedora.TabIndex = 1;
            this.textRotaVendedora.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "CPF:";
            // 
            // gbVendedora
            // 
            this.gbVendedora.Controls.Add(this.label2);
            this.gbVendedora.Controls.Add(this.label4);
            this.gbVendedora.Controls.Add(this.label3);
            this.gbVendedora.Controls.Add(this.label1);
            this.gbVendedora.Controls.Add(this.textNomeVendedora);
            this.gbVendedora.Controls.Add(this.textRotaVendedora);
            this.gbVendedora.Controls.Add(this.mTextCpfVendedora);
            this.gbVendedora.Location = new System.Drawing.Point(12, 12);
            this.gbVendedora.Name = "gbVendedora";
            this.gbVendedora.Size = new System.Drawing.Size(404, 90);
            this.gbVendedora.TabIndex = 0;
            this.gbVendedora.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Dados da Vendedora";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(312, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Rota:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nome:";
            // 
            // gbCatalogo
            // 
            this.gbCatalogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCatalogo.Controls.Add(this.cbCampanha);
            this.gbCatalogo.Controls.Add(this.cbCatalogo);
            this.gbCatalogo.Controls.Add(this.label7);
            this.gbCatalogo.Controls.Add(this.label6);
            this.gbCatalogo.Controls.Add(this.label5);
            this.gbCatalogo.Location = new System.Drawing.Point(459, 12);
            this.gbCatalogo.Name = "gbCatalogo";
            this.gbCatalogo.Size = new System.Drawing.Size(404, 90);
            this.gbCatalogo.TabIndex = 1;
            this.gbCatalogo.TabStop = false;
            // 
            // cbCampanha
            // 
            this.cbCampanha.FormattingEnabled = true;
            this.cbCampanha.Location = new System.Drawing.Point(87, 54);
            this.cbCampanha.Name = "cbCampanha";
            this.cbCampanha.Size = new System.Drawing.Size(298, 23);
            this.cbCampanha.TabIndex = 3;
            this.cbCampanha.TabStop = false;
            this.cbCampanha.SelectedIndexChanged += new System.EventHandler(this.cbCampanha_SelectedIndexChanged);
            // 
            // cbCatalogo
            // 
            this.cbCatalogo.FormattingEnabled = true;
            this.cbCatalogo.Location = new System.Drawing.Point(87, 23);
            this.cbCatalogo.Name = "cbCatalogo";
            this.cbCatalogo.Size = new System.Drawing.Size(298, 23);
            this.cbCatalogo.TabIndex = 3;
            this.cbCatalogo.TabStop = false;
            this.cbCatalogo.SelectedIndexChanged += new System.EventHandler(this.cbCatalogo_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "Campanha:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Nome:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Catálogo";
            // 
            // gbAddItem
            // 
            this.gbAddItem.Controls.Add(this.label11);
            this.gbAddItem.Controls.Add(this.label10);
            this.gbAddItem.Controls.Add(this.label9);
            this.gbAddItem.Controls.Add(this.label8);
            this.gbAddItem.Controls.Add(this.cbTamanho);
            this.gbAddItem.Controls.Add(this.textQtd);
            this.gbAddItem.Controls.Add(this.textReferencia);
            this.gbAddItem.Location = new System.Drawing.Point(12, 109);
            this.gbAddItem.Name = "gbAddItem";
            this.gbAddItem.Size = new System.Drawing.Size(404, 43);
            this.gbAddItem.TabIndex = 2;
            this.gbAddItem.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(249, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 15);
            this.label11.TabIndex = 2;
            this.label11.Text = "Tam.:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(156, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 15);
            this.label10.TabIndex = 2;
            this.label10.Text = "Qtd.:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 15);
            this.label9.TabIndex = 2;
            this.label9.Text = "Ref.:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 15);
            this.label8.TabIndex = 2;
            this.label8.Text = "Item";
            // 
            // cbTamanho
            // 
            this.cbTamanho.FormattingEnabled = true;
            this.cbTamanho.Location = new System.Drawing.Point(286, 15);
            this.cbTamanho.Name = "cbTamanho";
            this.cbTamanho.Size = new System.Drawing.Size(70, 23);
            this.cbTamanho.TabIndex = 2;
            this.cbTamanho.SelectedIndexChanged += new System.EventHandler(this.cbTamanho_SelectedIndexChanged);
            // 
            // textQtd
            // 
            this.textQtd.Location = new System.Drawing.Point(191, 15);
            this.textQtd.Name = "textQtd";
            this.textQtd.Size = new System.Drawing.Size(40, 23);
            this.textQtd.TabIndex = 1;
            this.textQtd.Leave += new System.EventHandler(this.textQtd_Leave);
            // 
            // textReferencia
            // 
            this.textReferencia.Location = new System.Drawing.Point(35, 15);
            this.textReferencia.Name = "textReferencia";
            this.textReferencia.Size = new System.Drawing.Size(109, 23);
            this.textReferencia.TabIndex = 0;
            this.textReferencia.Leave += new System.EventHandler(this.textReferencia_Leave);
            // 
            // PedidoAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(111)))), ((int)(((byte)(156)))));
            this.ClientSize = new System.Drawing.Size(896, 465);
            this.Controls.Add(this.gbAddItem);
            this.Controls.Add(this.gbCatalogo);
            this.Controls.Add(this.gbVendedora);
            this.Controls.Add(this.panelDetalhePedido);
            this.Controls.Add(this.panelCommands);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PedidoAddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PedidoAddForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PedidoAddForm_FormClosing);
            this.Load += new System.EventHandler(this.PedidoAddForm_Load);
            this.panelCommands.ResumeLayout(false);
            this.panelDetalhePedido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalhePedido)).EndInit();
            this.gbVendedora.ResumeLayout(false);
            this.gbVendedora.PerformLayout();
            this.gbCatalogo.ResumeLayout(false);
            this.gbCatalogo.PerformLayout();
            this.gbAddItem.ResumeLayout(false);
            this.gbAddItem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelCommands;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelDetalhePedido;
        private System.Windows.Forms.MaskedTextBox mTextCpfVendedora;
        private System.Windows.Forms.TextBox textRotaVendedora;
        private System.Windows.Forms.TextBox textNomeVendedora;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbVendedora;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbCatalogo;
        private System.Windows.Forms.ComboBox cbCampanha;
        private System.Windows.Forms.ComboBox cbCatalogo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvDetalhePedido;
        private System.Windows.Forms.GroupBox gbAddItem;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbTamanho;
        private System.Windows.Forms.TextBox textQtd;
        private System.Windows.Forms.TextBox textReferencia;
    }
}