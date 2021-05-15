
namespace MCatalogos.Views.FormViews.Vendedoras
{
    partial class VendedorasListForm
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
            this.panelListView = new System.Windows.Forms.Panel();
            this.panelSearchVendedoras = new System.Windows.Forms.Panel();
            this.textSearch = new System.Windows.Forms.MaskedTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureSearch = new System.Windows.Forms.PictureBox();
            this.radioButtonNome = new System.Windows.Forms.RadioButton();
            this.radioButtonCpf = new System.Windows.Forms.RadioButton();
            this.panelContentGridView = new System.Windows.Forms.Panel();
            this.dgvVendedoras = new System.Windows.Forms.DataGridView();
            this.panelCommands = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelListView.SuspendLayout();
            this.panelSearchVendedoras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSearch)).BeginInit();
            this.panelContentGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendedoras)).BeginInit();
            this.panelCommands.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelListView
            // 
            this.panelListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(111)))), ((int)(((byte)(156)))));
            this.panelListView.Controls.Add(this.panelSearchVendedoras);
            this.panelListView.Controls.Add(this.panelContentGridView);
            this.panelListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelListView.Location = new System.Drawing.Point(0, 0);
            this.panelListView.Name = "panelListView";
            this.panelListView.Size = new System.Drawing.Size(800, 440);
            this.panelListView.TabIndex = 4;
            // 
            // panelSearchVendedoras
            // 
            this.panelSearchVendedoras.Controls.Add(this.textSearch);
            this.panelSearchVendedoras.Controls.Add(this.panel2);
            this.panelSearchVendedoras.Controls.Add(this.pictureSearch);
            this.panelSearchVendedoras.Controls.Add(this.radioButtonNome);
            this.panelSearchVendedoras.Controls.Add(this.radioButtonCpf);
            this.panelSearchVendedoras.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearchVendedoras.Location = new System.Drawing.Point(0, 0);
            this.panelSearchVendedoras.Name = "panelSearchVendedoras";
            this.panelSearchVendedoras.Size = new System.Drawing.Size(800, 37);
            this.panelSearchVendedoras.TabIndex = 2;
            // 
            // textSearch
            // 
            this.textSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textSearch.Location = new System.Drawing.Point(41, 9);
            this.textSearch.Name = "textSearch";
            this.textSearch.Size = new System.Drawing.Size(246, 15);
            this.textSearch.TabIndex = 9;
            this.textSearch.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Location = new System.Drawing.Point(41, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(246, 2);
            this.panel2.TabIndex = 8;
            this.panel2.Visible = false;
            // 
            // pictureSearch
            // 
            this.pictureSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureSearch.Image = global::MCatalogos.Properties.Resources.IconPesquisa35x35;
            this.pictureSearch.Location = new System.Drawing.Point(288, 6);
            this.pictureSearch.Name = "pictureSearch";
            this.pictureSearch.Size = new System.Drawing.Size(22, 22);
            this.pictureSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureSearch.TabIndex = 7;
            this.pictureSearch.TabStop = false;
            this.pictureSearch.Visible = false;
            this.pictureSearch.Click += new System.EventHandler(this.pictureSearch_Click_1);
            // 
            // radioButtonNome
            // 
            this.radioButtonNome.AutoSize = true;
            this.radioButtonNome.Checked = true;
            this.radioButtonNome.FlatAppearance.BorderSize = 0;
            this.radioButtonNome.ForeColor = System.Drawing.Color.White;
            this.radioButtonNome.Location = new System.Drawing.Point(330, 8);
            this.radioButtonNome.Name = "radioButtonNome";
            this.radioButtonNome.Size = new System.Drawing.Size(57, 18);
            this.radioButtonNome.TabIndex = 5;
            this.radioButtonNome.TabStop = true;
            this.radioButtonNome.Text = "Nome";
            this.radioButtonNome.UseVisualStyleBackColor = true;
            this.radioButtonNome.Visible = false;
            // 
            // radioButtonCpf
            // 
            this.radioButtonCpf.AutoSize = true;
            this.radioButtonCpf.FlatAppearance.BorderSize = 0;
            this.radioButtonCpf.ForeColor = System.Drawing.Color.White;
            this.radioButtonCpf.Location = new System.Drawing.Point(389, 8);
            this.radioButtonCpf.Name = "radioButtonCpf";
            this.radioButtonCpf.Size = new System.Drawing.Size(43, 18);
            this.radioButtonCpf.TabIndex = 6;
            this.radioButtonCpf.Text = "CPF";
            this.radioButtonCpf.UseVisualStyleBackColor = true;
            this.radioButtonCpf.Visible = false;
            this.radioButtonCpf.CheckedChanged += new System.EventHandler(this.radioButtonCpf_CheckedChanged);
            // 
            // panelContentGridView
            // 
            this.panelContentGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContentGridView.Controls.Add(this.dgvVendedoras);
            this.panelContentGridView.Location = new System.Drawing.Point(40, 43);
            this.panelContentGridView.Name = "panelContentGridView";
            this.panelContentGridView.Size = new System.Drawing.Size(715, 329);
            this.panelContentGridView.TabIndex = 1;
            // 
            // dgvVendedoras
            // 
            this.dgvVendedoras.AllowUserToAddRows = false;
            this.dgvVendedoras.AllowUserToDeleteRows = false;
            this.dgvVendedoras.AllowUserToResizeColumns = false;
            this.dgvVendedoras.AllowUserToResizeRows = false;
            this.dgvVendedoras.BackgroundColor = System.Drawing.Color.White;
            this.dgvVendedoras.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVendedoras.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvVendedoras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendedoras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVendedoras.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvVendedoras.Location = new System.Drawing.Point(0, 0);
            this.dgvVendedoras.Name = "dgvVendedoras";
            this.dgvVendedoras.ReadOnly = true;
            this.dgvVendedoras.RowHeadersVisible = false;
            this.dgvVendedoras.RowTemplate.ReadOnly = true;
            this.dgvVendedoras.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvVendedoras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVendedoras.ShowCellErrors = false;
            this.dgvVendedoras.ShowEditingIcon = false;
            this.dgvVendedoras.ShowRowErrors = false;
            this.dgvVendedoras.Size = new System.Drawing.Size(715, 329);
            this.dgvVendedoras.TabIndex = 0;
            this.dgvVendedoras.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVendedoras_CellDoubleClick);
            // 
            // panelCommands
            // 
            this.panelCommands.Controls.Add(this.btnAdd);
            this.panelCommands.Controls.Add(this.btnEdit);
            this.panelCommands.Controls.Add(this.btnDelete);
            this.panelCommands.Controls.Add(this.btnCancel);
            this.panelCommands.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCommands.Location = new System.Drawing.Point(0, 440);
            this.panelCommands.Name = "panelCommands";
            this.panelCommands.Size = new System.Drawing.Size(800, 45);
            this.panelCommands.TabIndex = 3;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Image = global::MCatalogos.Properties.Resources.IconAddVendedora20x20;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(344, 9);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(91, 27);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Tag = "Pedidos";
            this.btnAdd.Text = "Adicionar";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Image = global::MCatalogos.Properties.Resources.IconEditVendedora20x20;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(462, 9);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(91, 27);
            this.btnEdit.TabIndex = 2;
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
            this.btnDelete.Location = new System.Drawing.Point(580, 9);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(91, 27);
            this.btnDelete.TabIndex = 2;
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
            this.btnCancel.Location = new System.Drawing.Point(698, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 27);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Tag = "Pedidos";
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // VendedorasListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 485);
            this.Controls.Add(this.panelListView);
            this.Controls.Add(this.panelCommands);
            this.Font = new System.Drawing.Font("Calibri", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "VendedorasListForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.VendedorasListForm_Load);
            this.panelListView.ResumeLayout(false);
            this.panelSearchVendedoras.ResumeLayout(false);
            this.panelSearchVendedoras.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSearch)).EndInit();
            this.panelContentGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendedoras)).EndInit();
            this.panelCommands.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelListView;
        private System.Windows.Forms.Panel panelSearchVendedoras;
        private System.Windows.Forms.MaskedTextBox textSearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureSearch;
        private System.Windows.Forms.RadioButton radioButtonNome;
        private System.Windows.Forms.RadioButton radioButtonCpf;
        private System.Windows.Forms.Panel panelContentGridView;
        private System.Windows.Forms.Panel panelCommands;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.DataGridView dgvVendedoras;
    }
}