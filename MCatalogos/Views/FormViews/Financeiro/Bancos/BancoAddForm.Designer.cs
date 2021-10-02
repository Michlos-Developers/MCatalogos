
namespace MCatalogos.Views.FormViews.Financeiro.Bancos
{
    partial class BancoAddForm
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
            this.panelTitle = new System.Windows.Forms.Panel();
            this.pictureClose = new System.Windows.Forms.PictureBox();
            this.titleFicha = new System.Windows.Forms.Label();
            this.panelCommands = new System.Windows.Forms.Panel();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.gbContas = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvContasBancarias = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.gbBanco = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textNomeBanco = new System.Windows.Forms.TextBox();
            this.textNumeroBanco = new System.Windows.Forms.TextBox();
            this.textBancoId = new System.Windows.Forms.TextBox();
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureClose)).BeginInit();
            this.panelCommands.SuspendLayout();
            this.panelContainer.SuspendLayout();
            this.gbContas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContasBancarias)).BeginInit();
            this.gbBanco.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.White;
            this.panelTitle.Controls.Add(this.pictureClose);
            this.panelTitle.Controls.Add(this.titleFicha);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(505, 30);
            this.panelTitle.TabIndex = 39;
            this.panelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitle_MouseDown);
            // 
            // pictureClose
            // 
            this.pictureClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureClose.Image = global::MCatalogos.Properties.Resources.IconClose20x20;
            this.pictureClose.Location = new System.Drawing.Point(480, 7);
            this.pictureClose.Name = "pictureClose";
            this.pictureClose.Size = new System.Drawing.Size(15, 15);
            this.pictureClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureClose.TabIndex = 1;
            this.pictureClose.TabStop = false;
            // 
            // titleFicha
            // 
            this.titleFicha.AutoSize = true;
            this.titleFicha.ForeColor = System.Drawing.SystemColors.ControlText;
            this.titleFicha.Location = new System.Drawing.Point(10, 8);
            this.titleFicha.Name = "titleFicha";
            this.titleFicha.Size = new System.Drawing.Size(164, 14);
            this.titleFicha.TabIndex = 0;
            this.titleFicha.Text = "Cadastro de Bancos e Contas";
            // 
            // panelCommands
            // 
            this.panelCommands.Controls.Add(this.btnSalvar);
            this.panelCommands.Controls.Add(this.btnClose);
            this.panelCommands.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCommands.Location = new System.Drawing.Point(0, 447);
            this.panelCommands.Name = "panelCommands";
            this.panelCommands.Size = new System.Drawing.Size(505, 45);
            this.panelCommands.TabIndex = 40;
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
            this.btnSalvar.Location = new System.Drawing.Point(285, 9);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(91, 27);
            this.btnSalvar.TabIndex = 0;
            this.btnSalvar.TabStop = false;
            this.btnSalvar.Tag = "";
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvar.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(403, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(91, 27);
            this.btnClose.TabIndex = 1;
            this.btnClose.TabStop = false;
            this.btnClose.Tag = "";
            this.btnClose.Text = "Fechar";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // panelContainer
            // 
            this.panelContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(111)))), ((int)(((byte)(156)))));
            this.panelContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelContainer.Controls.Add(this.gbContas);
            this.panelContainer.Controls.Add(this.gbBanco);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 30);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(505, 417);
            this.panelContainer.TabIndex = 41;
            // 
            // gbContas
            // 
            this.gbContas.Controls.Add(this.btnAdd);
            this.gbContas.Controls.Add(this.btnEdit);
            this.gbContas.Controls.Add(this.btnDelete);
            this.gbContas.Controls.Add(this.dgvContasBancarias);
            this.gbContas.Controls.Add(this.label5);
            this.gbContas.Enabled = false;
            this.gbContas.Location = new System.Drawing.Point(12, 131);
            this.gbContas.Name = "gbContas";
            this.gbContas.Size = new System.Drawing.Size(480, 267);
            this.gbContas.TabIndex = 1;
            this.gbContas.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Image = global::MCatalogos.Properties.Resources.IconAddPedido;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(181, 226);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(91, 27);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Tag = "";
            this.btnAdd.Text = "Adicionar";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Image = global::MCatalogos.Properties.Resources.IconEditPedido;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(280, 226);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(91, 27);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Tag = "";
            this.btnEdit.Text = "Editar";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Image = global::MCatalogos.Properties.Resources.IconDelete20x20;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(379, 226);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(91, 27);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Tag = "";
            this.btnDelete.Text = "Deletar";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // dgvContasBancarias
            // 
            this.dgvContasBancarias.AllowUserToAddRows = false;
            this.dgvContasBancarias.AllowUserToDeleteRows = false;
            this.dgvContasBancarias.BackgroundColor = System.Drawing.Color.White;
            this.dgvContasBancarias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContasBancarias.Location = new System.Drawing.Point(7, 18);
            this.dgvContasBancarias.Name = "dgvContasBancarias";
            this.dgvContasBancarias.ReadOnly = true;
            this.dgvContasBancarias.Size = new System.Drawing.Size(465, 196);
            this.dgvContasBancarias.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 14);
            this.label5.TabIndex = 1;
            this.label5.Text = "Cadastro de Contas";
            // 
            // gbBanco
            // 
            this.gbBanco.Controls.Add(this.label3);
            this.gbBanco.Controls.Add(this.label4);
            this.gbBanco.Controls.Add(this.label2);
            this.gbBanco.Controls.Add(this.label1);
            this.gbBanco.Controls.Add(this.textNomeBanco);
            this.gbBanco.Controls.Add(this.textNumeroBanco);
            this.gbBanco.Controls.Add(this.textBancoId);
            this.gbBanco.Location = new System.Drawing.Point(12, 5);
            this.gbBanco.Name = "gbBanco";
            this.gbBanco.Size = new System.Drawing.Size(480, 120);
            this.gbBanco.TabIndex = 0;
            this.gbBanco.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(143, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 14);
            this.label3.TabIndex = 1;
            this.label3.Text = "Nome do Banco:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 14);
            this.label4.TabIndex = 1;
            this.label4.Text = "Dados do Banco:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Código Banco:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Id:";
            // 
            // textNomeBanco
            // 
            this.textNomeBanco.Location = new System.Drawing.Point(143, 84);
            this.textNomeBanco.Name = "textNomeBanco";
            this.textNomeBanco.Size = new System.Drawing.Size(306, 22);
            this.textNomeBanco.TabIndex = 0;
            // 
            // textNumeroBanco
            // 
            this.textNumeroBanco.Location = new System.Drawing.Point(28, 84);
            this.textNumeroBanco.Name = "textNumeroBanco";
            this.textNumeroBanco.Size = new System.Drawing.Size(80, 22);
            this.textNumeroBanco.TabIndex = 0;
            // 
            // textBancoId
            // 
            this.textBancoId.Location = new System.Drawing.Point(28, 34);
            this.textBancoId.Name = "textBancoId";
            this.textBancoId.Size = new System.Drawing.Size(65, 22);
            this.textBancoId.TabIndex = 0;
            // 
            // BancoAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 492);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelCommands);
            this.Controls.Add(this.panelTitle);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BancoAddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Bancos e Contas";
            this.Load += new System.EventHandler(this.BancoAddForm_Load);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureClose)).EndInit();
            this.panelCommands.ResumeLayout(false);
            this.panelContainer.ResumeLayout(false);
            this.gbContas.ResumeLayout(false);
            this.gbContas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContasBancarias)).EndInit();
            this.gbBanco.ResumeLayout(false);
            this.gbBanco.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.PictureBox pictureClose;
        public System.Windows.Forms.Label titleFicha;
        private System.Windows.Forms.Panel panelCommands;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.GroupBox gbContas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gbBanco;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textNomeBanco;
        private System.Windows.Forms.TextBox textNumeroBanco;
        private System.Windows.Forms.TextBox textBancoId;
        private System.Windows.Forms.DataGridView dgvContasBancarias;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
    }
}