
namespace MCatalogos.Views.FormViews.PedidoVendedora
{
    partial class ItemPedidoEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemPedidoEditForm));
            this.panelCommands = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.gbAddItem = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textDescricao = new System.Windows.Forms.TextBox();
            this.textReferencia = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textQtd = new System.Windows.Forms.TextBox();
            this.cbTamanho = new System.Windows.Forms.ComboBox();
            this.panelCommands.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbAddItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCommands
            // 
            this.panelCommands.BackColor = System.Drawing.SystemColors.Control;
            this.panelCommands.Controls.Add(this.btnSave);
            this.panelCommands.Controls.Add(this.btnCancel);
            this.panelCommands.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCommands.Location = new System.Drawing.Point(0, 159);
            this.panelCommands.Name = "panelCommands";
            this.panelCommands.Size = new System.Drawing.Size(316, 37);
            this.panelCommands.TabIndex = 10;
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
            this.btnSave.Location = new System.Drawing.Point(150, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(74, 29);
            this.btnSave.TabIndex = 2;
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
            this.btnCancel.Location = new System.Drawing.Point(230, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(74, 29);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.TabStop = false;
            this.btnCancel.Tag = "Pedidos";
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(111)))), ((int)(((byte)(156)))));
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.gbAddItem);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.textQtd);
            this.panel1.Controls.Add(this.cbTamanho);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(316, 159);
            this.panel1.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 124);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 14);
            this.label11.TabIndex = 2;
            this.label11.Text = "Tam.:";
            // 
            // gbAddItem
            // 
            this.gbAddItem.Controls.Add(this.label1);
            this.gbAddItem.Controls.Add(this.label9);
            this.gbAddItem.Controls.Add(this.label8);
            this.gbAddItem.Controls.Add(this.textDescricao);
            this.gbAddItem.Controls.Add(this.textReferencia);
            this.gbAddItem.Location = new System.Drawing.Point(12, 3);
            this.gbAddItem.Name = "gbAddItem";
            this.gbAddItem.Size = new System.Drawing.Size(292, 83);
            this.gbAddItem.TabIndex = 3;
            this.gbAddItem.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Descrição:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(39, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 14);
            this.label9.TabIndex = 2;
            this.label9.Text = "Ref.:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 14);
            this.label8.TabIndex = 2;
            this.label8.Text = "Item";
            // 
            // textDescricao
            // 
            this.textDescricao.Location = new System.Drawing.Point(75, 43);
            this.textDescricao.Name = "textDescricao";
            this.textDescricao.Size = new System.Drawing.Size(211, 22);
            this.textDescricao.TabIndex = 0;
            // 
            // textReferencia
            // 
            this.textReferencia.Location = new System.Drawing.Point(75, 16);
            this.textReferencia.Name = "textReferencia";
            this.textReferencia.Size = new System.Drawing.Size(211, 22);
            this.textReferencia.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 14);
            this.label10.TabIndex = 2;
            this.label10.Text = "Qtd.:";
            // 
            // textQtd
            // 
            this.textQtd.Location = new System.Drawing.Point(47, 92);
            this.textQtd.Name = "textQtd";
            this.textQtd.Size = new System.Drawing.Size(40, 22);
            this.textQtd.TabIndex = 1;
            // 
            // cbTamanho
            // 
            this.cbTamanho.FormattingEnabled = true;
            this.cbTamanho.Location = new System.Drawing.Point(47, 120);
            this.cbTamanho.Name = "cbTamanho";
            this.cbTamanho.Size = new System.Drawing.Size(70, 22);
            this.cbTamanho.TabIndex = 2;
            // 
            // ItemPedidoEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 196);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelCommands);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemPedidoEditForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ItemPedidoEditForm_Load);
            this.panelCommands.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbAddItem.ResumeLayout(false);
            this.gbAddItem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCommands;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox gbAddItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textDescricao;
        private System.Windows.Forms.TextBox textReferencia;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textQtd;
        private System.Windows.Forms.ComboBox cbTamanho;
    }
}