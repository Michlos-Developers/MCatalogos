
namespace MCatalogos.Views.FormViews.Rotas
{
    partial class RotasFormView
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
            this.title = new System.Windows.Forms.Label();
            this.panelCommands = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.gboxEditRotas = new System.Windows.Forms.GroupBox();
            this.btnAddLetraRota = new System.Windows.Forms.Button();
            this.btnAddNumRota = new System.Windows.Forms.Button();
            this.cbNumeroRota = new System.Windows.Forms.ComboBox();
            this.cbLetraRota = new System.Windows.Forms.ComboBox();
            this.textNomeVendedora = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelListRotas = new System.Windows.Forms.Panel();
            this.dgvRotas = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.panelListSemRotas = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvVendedoraSemRota = new System.Windows.Forms.DataGridView();
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureClose)).BeginInit();
            this.panelCommands.SuspendLayout();
            this.panelContainer.SuspendLayout();
            this.gboxEditRotas.SuspendLayout();
            this.panelListRotas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRotas)).BeginInit();
            this.panelListSemRotas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendedoraSemRota)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.White;
            this.panelTitle.Controls.Add(this.pictureClose);
            this.panelTitle.Controls.Add(this.title);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(973, 32);
            this.panelTitle.TabIndex = 40;
            this.panelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitle_MouseDown);
            // 
            // pictureClose
            // 
            this.pictureClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureClose.Image = global::MCatalogos.Properties.Resources.IconClose20x20;
            this.pictureClose.Location = new System.Drawing.Point(949, 7);
            this.pictureClose.Name = "pictureClose";
            this.pictureClose.Size = new System.Drawing.Size(15, 16);
            this.pictureClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureClose.TabIndex = 1;
            this.pictureClose.TabStop = false;
            this.pictureClose.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.ForeColor = System.Drawing.SystemColors.ControlText;
            this.title.Location = new System.Drawing.Point(10, 9);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(94, 14);
            this.title.TabIndex = 0;
            this.title.Text = "Edição de Rotas";
            // 
            // panelCommands
            // 
            this.panelCommands.Controls.Add(this.btnCancel);
            this.panelCommands.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCommands.ForeColor = System.Drawing.SystemColors.Control;
            this.panelCommands.Location = new System.Drawing.Point(0, 435);
            this.panelCommands.Name = "panelCommands";
            this.panelCommands.Size = new System.Drawing.Size(973, 45);
            this.panelCommands.TabIndex = 41;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(871, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 27);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Tag = "Pedidos";
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panelContainer
            // 
            this.panelContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(111)))), ((int)(((byte)(156)))));
            this.panelContainer.Controls.Add(this.panelListSemRotas);
            this.panelContainer.Controls.Add(this.gboxEditRotas);
            this.panelContainer.Controls.Add(this.panelListRotas);
            this.panelContainer.Controls.Add(this.label6);
            this.panelContainer.Controls.Add(this.label5);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 32);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(973, 403);
            this.panelContainer.TabIndex = 42;
            // 
            // gboxEditRotas
            // 
            this.gboxEditRotas.Controls.Add(this.btnAddLetraRota);
            this.gboxEditRotas.Controls.Add(this.btnAddNumRota);
            this.gboxEditRotas.Controls.Add(this.cbNumeroRota);
            this.gboxEditRotas.Controls.Add(this.cbLetraRota);
            this.gboxEditRotas.Controls.Add(this.textNomeVendedora);
            this.gboxEditRotas.Controls.Add(this.label3);
            this.gboxEditRotas.Controls.Add(this.label4);
            this.gboxEditRotas.Controls.Add(this.label1);
            this.gboxEditRotas.Controls.Add(this.label2);
            this.gboxEditRotas.Enabled = false;
            this.gboxEditRotas.Location = new System.Drawing.Point(645, 24);
            this.gboxEditRotas.Name = "gboxEditRotas";
            this.gboxEditRotas.Size = new System.Drawing.Size(319, 107);
            this.gboxEditRotas.TabIndex = 1;
            this.gboxEditRotas.TabStop = false;
            // 
            // btnAddLetraRota
            // 
            this.btnAddLetraRota.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAddLetraRota.FlatAppearance.BorderSize = 0;
            this.btnAddLetraRota.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddLetraRota.ForeColor = System.Drawing.Color.White;
            this.btnAddLetraRota.Image = global::MCatalogos.Properties.Resources.IconAdd10x10;
            this.btnAddLetraRota.Location = new System.Drawing.Point(118, 68);
            this.btnAddLetraRota.Name = "btnAddLetraRota";
            this.btnAddLetraRota.Size = new System.Drawing.Size(20, 20);
            this.btnAddLetraRota.TabIndex = 37;
            this.btnAddLetraRota.TabStop = false;
            this.btnAddLetraRota.Tag = "";
            this.btnAddLetraRota.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddLetraRota.UseVisualStyleBackColor = false;
            this.btnAddLetraRota.Click += new System.EventHandler(this.btnAddLetraRota_Click);
            // 
            // btnAddNumRota
            // 
            this.btnAddNumRota.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAddNumRota.FlatAppearance.BorderSize = 0;
            this.btnAddNumRota.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNumRota.ForeColor = System.Drawing.Color.White;
            this.btnAddNumRota.Image = global::MCatalogos.Properties.Resources.IconAdd10x10;
            this.btnAddNumRota.Location = new System.Drawing.Point(288, 69);
            this.btnAddNumRota.Name = "btnAddNumRota";
            this.btnAddNumRota.Size = new System.Drawing.Size(20, 20);
            this.btnAddNumRota.TabIndex = 37;
            this.btnAddNumRota.TabStop = false;
            this.btnAddNumRota.Tag = "";
            this.btnAddNumRota.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddNumRota.UseVisualStyleBackColor = false;
            this.btnAddNumRota.Click += new System.EventHandler(this.btnAddNumRota_Click);
            // 
            // cbNumeroRota
            // 
            this.cbNumeroRota.FormattingEnabled = true;
            this.cbNumeroRota.Location = new System.Drawing.Point(226, 68);
            this.cbNumeroRota.Name = "cbNumeroRota";
            this.cbNumeroRota.Size = new System.Drawing.Size(61, 22);
            this.cbNumeroRota.TabIndex = 5;
            this.cbNumeroRota.SelectedIndexChanged += new System.EventHandler(this.cbNumeroRota_SelectedIndexChanged);
            // 
            // cbLetraRota
            // 
            this.cbLetraRota.FormattingEnabled = true;
            this.cbLetraRota.Location = new System.Drawing.Point(56, 67);
            this.cbLetraRota.Name = "cbLetraRota";
            this.cbLetraRota.Size = new System.Drawing.Size(61, 22);
            this.cbLetraRota.TabIndex = 5;
            this.cbLetraRota.SelectedIndexChanged += new System.EventHandler(this.cbLetraRota_SelectedIndexChanged);
            // 
            // textNomeVendedora
            // 
            this.textNomeVendedora.Enabled = false;
            this.textNomeVendedora.Location = new System.Drawing.Point(12, 32);
            this.textNomeVendedora.Name = "textNomeVendedora";
            this.textNomeVendedora.Size = new System.Drawing.Size(296, 22);
            this.textNomeVendedora.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Letra:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(167, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "Número:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Edição de Rota";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Vendedora:";
            // 
            // panelListRotas
            // 
            this.panelListRotas.Controls.Add(this.dgvRotas);
            this.panelListRotas.Location = new System.Drawing.Point(24, 32);
            this.panelListRotas.Name = "panelListRotas";
            this.panelListRotas.Size = new System.Drawing.Size(605, 341);
            this.panelListRotas.TabIndex = 0;
            // 
            // dgvRotas
            // 
            this.dgvRotas.AllowUserToAddRows = false;
            this.dgvRotas.AllowUserToDeleteRows = false;
            this.dgvRotas.AllowUserToResizeColumns = false;
            this.dgvRotas.AllowUserToResizeRows = false;
            this.dgvRotas.BackgroundColor = System.Drawing.Color.White;
            this.dgvRotas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRotas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRotas.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvRotas.Location = new System.Drawing.Point(0, 0);
            this.dgvRotas.Name = "dgvRotas";
            this.dgvRotas.ReadOnly = true;
            this.dgvRotas.RowHeadersVisible = false;
            this.dgvRotas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvRotas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRotas.ShowCellErrors = false;
            this.dgvRotas.ShowCellToolTips = false;
            this.dgvRotas.ShowEditingIcon = false;
            this.dgvRotas.ShowRowErrors = false;
            this.dgvRotas.Size = new System.Drawing.Size(605, 341);
            this.dgvRotas.TabIndex = 0;
            this.dgvRotas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRotas_CellClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 14);
            this.label5.TabIndex = 0;
            this.label5.Text = "Vendedoras Com Rota:";
            // 
            // panelListSemRotas
            // 
            this.panelListSemRotas.Controls.Add(this.dgvVendedoraSemRota);
            this.panelListSemRotas.Location = new System.Drawing.Point(645, 164);
            this.panelListSemRotas.Name = "panelListSemRotas";
            this.panelListSemRotas.Size = new System.Drawing.Size(319, 209);
            this.panelListSemRotas.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(642, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 14);
            this.label6.TabIndex = 0;
            this.label6.Text = "Vendedoras Sem Rotas:";
            // 
            // dgvVendedoraSemRota
            // 
            this.dgvVendedoraSemRota.AllowUserToAddRows = false;
            this.dgvVendedoraSemRota.AllowUserToDeleteRows = false;
            this.dgvVendedoraSemRota.AllowUserToOrderColumns = true;
            this.dgvVendedoraSemRota.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendedoraSemRota.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVendedoraSemRota.Location = new System.Drawing.Point(0, 0);
            this.dgvVendedoraSemRota.Name = "dgvVendedoraSemRota";
            this.dgvVendedoraSemRota.ReadOnly = true;
            this.dgvVendedoraSemRota.RowHeadersVisible = false;
            this.dgvVendedoraSemRota.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvVendedoraSemRota.Size = new System.Drawing.Size(319, 209);
            this.dgvVendedoraSemRota.TabIndex = 0;
            this.dgvVendedoraSemRota.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVendedoraSemRota_CellClick);
            // 
            // RotasFormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 480);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelCommands);
            this.Controls.Add(this.panelTitle);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RotasFormView";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RotasFormView";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RotasFormView_FormClosing);
            this.Load += new System.EventHandler(this.RotasFormView_Load);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureClose)).EndInit();
            this.panelCommands.ResumeLayout(false);
            this.panelContainer.ResumeLayout(false);
            this.panelContainer.PerformLayout();
            this.gboxEditRotas.ResumeLayout(false);
            this.gboxEditRotas.PerformLayout();
            this.panelListRotas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRotas)).EndInit();
            this.panelListSemRotas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendedoraSemRota)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.PictureBox pictureClose;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Panel panelCommands;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.GroupBox gboxEditRotas;
        private System.Windows.Forms.ComboBox cbNumeroRota;
        private System.Windows.Forms.ComboBox cbLetraRota;
        public System.Windows.Forms.TextBox textNomeVendedora;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelListRotas;
        public System.Windows.Forms.DataGridView dgvRotas;
        private System.Windows.Forms.Button btnAddLetraRota;
        private System.Windows.Forms.Button btnAddNumRota;
        private System.Windows.Forms.Panel panelListSemRotas;
        public System.Windows.Forms.DataGridView dgvVendedoraSemRota;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}