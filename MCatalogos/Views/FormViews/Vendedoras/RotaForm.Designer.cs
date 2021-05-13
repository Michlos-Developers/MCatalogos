
namespace MCatalogos.Views.FormViews.Vendedoras
{
    partial class RotaForm
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
            this.textVendedoraNome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxLetraRota = new System.Windows.Forms.ComboBox();
            this.comboBoxNumeroRota = new System.Windows.Forms.ComboBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddLetra = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textVendedoraNome
            // 
            this.textVendedoraNome.Enabled = false;
            this.textVendedoraNome.Location = new System.Drawing.Point(77, 12);
            this.textVendedoraNome.Name = "textVendedoraNome";
            this.textVendedoraNome.Size = new System.Drawing.Size(266, 20);
            this.textVendedoraNome.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vendedora";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Letra:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(210, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Número:";
            // 
            // comboBoxLetraRota
            // 
            this.comboBoxLetraRota.FormattingEnabled = true;
            this.comboBoxLetraRota.Location = new System.Drawing.Point(76, 58);
            this.comboBoxLetraRota.Name = "comboBoxLetraRota";
            this.comboBoxLetraRota.Size = new System.Drawing.Size(69, 21);
            this.comboBoxLetraRota.TabIndex = 4;
            this.comboBoxLetraRota.SelectedIndexChanged += new System.EventHandler(this.comboBoxLetraRota_SelectedIndexChanged);
            // 
            // comboBoxNumeroRota
            // 
            this.comboBoxNumeroRota.FormattingEnabled = true;
            this.comboBoxNumeroRota.Location = new System.Drawing.Point(263, 58);
            this.comboBoxNumeroRota.Name = "comboBoxNumeroRota";
            this.comboBoxNumeroRota.Size = new System.Drawing.Size(54, 21);
            this.comboBoxNumeroRota.TabIndex = 4;
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
            this.btnSalvar.Location = new System.Drawing.Point(47, 98);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(91, 27);
            this.btnSalvar.TabIndex = 5;
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
            this.btnCancel.Location = new System.Drawing.Point(238, 98);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 27);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.TabStop = false;
            this.btnCancel.Tag = "Pedidos";
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAddLetra
            // 
            this.btnAddLetra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddLetra.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAddLetra.FlatAppearance.BorderSize = 0;
            this.btnAddLetra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddLetra.ForeColor = System.Drawing.Color.White;
            this.btnAddLetra.Image = global::MCatalogos.Properties.Resources.IconAdd10x10;
            this.btnAddLetra.Location = new System.Drawing.Point(146, 58);
            this.btnAddLetra.Name = "btnAddLetra";
            this.btnAddLetra.Size = new System.Drawing.Size(20, 21);
            this.btnAddLetra.TabIndex = 7;
            this.btnAddLetra.TabStop = false;
            this.btnAddLetra.Tag = "";
            this.btnAddLetra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddLetra.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::MCatalogos.Properties.Resources.IconAdd10x10;
            this.button1.Location = new System.Drawing.Point(318, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(20, 21);
            this.button1.TabIndex = 8;
            this.button1.TabStop = false;
            this.button1.Tag = "";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // RotaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 142);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAddLetra);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.comboBoxNumeroRota);
            this.Controls.Add(this.comboBoxLetraRota);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textVendedoraNome);
            this.Name = "RotaForm";
            this.Text = "Rota: Vendedora";
            this.Load += new System.EventHandler(this.RotaForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxLetraRota;
        private System.Windows.Forms.ComboBox comboBoxNumeroRota;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAddLetra;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox textVendedoraNome;
    }
}