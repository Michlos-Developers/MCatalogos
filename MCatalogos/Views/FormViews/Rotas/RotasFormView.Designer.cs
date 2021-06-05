
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
            this.panelListSemRotas = new System.Windows.Forms.Panel();
            this.dgvVendedoraSemRota = new System.Windows.Forms.DataGridView();
            this.gboxEditRotas = new System.Windows.Forms.GroupBox();
            this.panelRotasEdit = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelListRotas = new System.Windows.Forms.Panel();
            this.dgvRotas = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureArrowUp = new System.Windows.Forms.PictureBox();
            this.pictureArrowRight = new System.Windows.Forms.PictureBox();
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureClose)).BeginInit();
            this.panelCommands.SuspendLayout();
            this.panelContainer.SuspendLayout();
            this.panelListSemRotas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendedoraSemRota)).BeginInit();
            this.gboxEditRotas.SuspendLayout();
            this.panelListRotas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRotas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureArrowUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureArrowRight)).BeginInit();
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
            this.btnCancel.Text = "Fechar";
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
            this.panelContainer.Controls.Add(this.pictureArrowUp);
            this.panelContainer.Controls.Add(this.pictureArrowRight);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 32);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(973, 403);
            this.panelContainer.TabIndex = 42;
            // 
            // panelListSemRotas
            // 
            this.panelListSemRotas.Controls.Add(this.dgvVendedoraSemRota);
            this.panelListSemRotas.Location = new System.Drawing.Point(643, 196);
            this.panelListSemRotas.Name = "panelListSemRotas";
            this.panelListSemRotas.Size = new System.Drawing.Size(319, 177);
            this.panelListSemRotas.TabIndex = 2;
            // 
            // dgvVendedoraSemRota
            // 
            this.dgvVendedoraSemRota.AllowUserToAddRows = false;
            this.dgvVendedoraSemRota.AllowUserToDeleteRows = false;
            this.dgvVendedoraSemRota.AllowUserToOrderColumns = true;
            this.dgvVendedoraSemRota.AllowUserToResizeColumns = false;
            this.dgvVendedoraSemRota.AllowUserToResizeRows = false;
            this.dgvVendedoraSemRota.BackgroundColor = System.Drawing.Color.White;
            this.dgvVendedoraSemRota.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVendedoraSemRota.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendedoraSemRota.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVendedoraSemRota.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvVendedoraSemRota.Location = new System.Drawing.Point(0, 0);
            this.dgvVendedoraSemRota.Name = "dgvVendedoraSemRota";
            this.dgvVendedoraSemRota.ReadOnly = true;
            this.dgvVendedoraSemRota.RowHeadersVisible = false;
            this.dgvVendedoraSemRota.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvVendedoraSemRota.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVendedoraSemRota.Size = new System.Drawing.Size(319, 177);
            this.dgvVendedoraSemRota.TabIndex = 0;
            this.dgvVendedoraSemRota.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVendedoraSemRota_CellClick);
            // 
            // gboxEditRotas
            // 
            this.gboxEditRotas.Controls.Add(this.panelRotasEdit);
            this.gboxEditRotas.Controls.Add(this.label1);
            this.gboxEditRotas.Enabled = false;
            this.gboxEditRotas.Location = new System.Drawing.Point(643, 24);
            this.gboxEditRotas.Name = "gboxEditRotas";
            this.gboxEditRotas.Size = new System.Drawing.Size(319, 143);
            this.gboxEditRotas.TabIndex = 1;
            this.gboxEditRotas.TabStop = false;
            // 
            // panelRotasEdit
            // 
            this.panelRotasEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRotasEdit.Location = new System.Drawing.Point(3, 18);
            this.panelRotasEdit.Name = "panelRotasEdit";
            this.panelRotasEdit.Size = new System.Drawing.Size(313, 122);
            this.panelRotasEdit.TabIndex = 1;
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
            // panelListRotas
            // 
            this.panelListRotas.Controls.Add(this.dgvRotas);
            this.panelListRotas.Location = new System.Drawing.Point(24, 32);
            this.panelListRotas.Name = "panelListRotas";
            this.panelListRotas.Size = new System.Drawing.Size(595, 341);
            this.panelListRotas.TabIndex = 0;
            // 
            // dgvRotas
            // 
            this.dgvRotas.AllowUserToAddRows = false;
            this.dgvRotas.AllowUserToDeleteRows = false;
            this.dgvRotas.AllowUserToOrderColumns = true;
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
            this.dgvRotas.Size = new System.Drawing.Size(595, 341);
            this.dgvRotas.TabIndex = 0;
            this.dgvRotas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRotas_CellClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(640, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 14);
            this.label6.TabIndex = 0;
            this.label6.Text = "Vendedoras Sem Rotas:";
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
            // pictureArrowUp
            // 
            this.pictureArrowUp.Image = global::MCatalogos.Properties.Resources.UpArrow;
            this.pictureArrowUp.Location = new System.Drawing.Point(937, 179);
            this.pictureArrowUp.Name = "pictureArrowUp";
            this.pictureArrowUp.Size = new System.Drawing.Size(29, 37);
            this.pictureArrowUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureArrowUp.TabIndex = 3;
            this.pictureArrowUp.TabStop = false;
            this.pictureArrowUp.Visible = false;
            // 
            // pictureArrowRight
            // 
            this.pictureArrowRight.Image = global::MCatalogos.Properties.Resources.RightArrow;
            this.pictureArrowRight.Location = new System.Drawing.Point(600, 29);
            this.pictureArrowRight.Name = "pictureArrowRight";
            this.pictureArrowRight.Size = new System.Drawing.Size(37, 29);
            this.pictureArrowRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureArrowRight.TabIndex = 3;
            this.pictureArrowRight.TabStop = false;
            this.pictureArrowRight.Visible = false;
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
            this.panelListSemRotas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendedoraSemRota)).EndInit();
            this.gboxEditRotas.ResumeLayout(false);
            this.gboxEditRotas.PerformLayout();
            this.panelListRotas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRotas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureArrowUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureArrowRight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.PictureBox pictureClose;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Panel panelCommands;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelListRotas;
        public System.Windows.Forms.DataGridView dgvRotas;
        private System.Windows.Forms.Panel panelListSemRotas;
        public System.Windows.Forms.DataGridView dgvVendedoraSemRota;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelRotasEdit;
        public System.Windows.Forms.PictureBox pictureArrowRight;
        public System.Windows.Forms.PictureBox pictureArrowUp;
        public System.Windows.Forms.GroupBox gboxEditRotas;
    }
}