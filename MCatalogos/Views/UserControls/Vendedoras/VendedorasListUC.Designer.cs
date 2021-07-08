
namespace MCatalogos.UserControls
{
    partial class VendedorasListUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelCommands = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelListView = new System.Windows.Forms.Panel();
            this.panelSearchVendedoras = new System.Windows.Forms.Panel();
            this.textSearch = new System.Windows.Forms.MaskedTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureSearch = new System.Windows.Forms.PictureBox();
            this.radioButtonNome = new System.Windows.Forms.RadioButton();
            this.radioButtonCpf = new System.Windows.Forms.RadioButton();
            this.panelContentGridView = new System.Windows.Forms.Panel();
            this.dataGridViewVendedoras = new System.Windows.Forms.DataGridView();
            this.panelCommands.SuspendLayout();
            this.panelListView.SuspendLayout();
            this.panelSearchVendedoras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSearch)).BeginInit();
            this.panelContentGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVendedoras)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCommands
            // 
            this.panelCommands.Controls.Add(this.btnAdd);
            this.panelCommands.Controls.Add(this.btnEdit);
            this.panelCommands.Controls.Add(this.btnDelete);
            this.panelCommands.Controls.Add(this.btnCancel);
            this.panelCommands.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCommands.Location = new System.Drawing.Point(0, 465);
            this.panelCommands.Name = "panelCommands";
            this.panelCommands.Size = new System.Drawing.Size(810, 45);
            this.panelCommands.TabIndex = 1;
            // 
            // btnAdd
            // 
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
            // 
            // btnEdit
            // 
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
            // 
            // btnDelete
            // 
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
            // 
            // btnCancel
            // 
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
            // panelListView
            // 
            this.panelListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(111)))), ((int)(((byte)(156)))));
            this.panelListView.Controls.Add(this.panelSearchVendedoras);
            this.panelListView.Controls.Add(this.panelContentGridView);
            this.panelListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelListView.Location = new System.Drawing.Point(0, 0);
            this.panelListView.Name = "panelListView";
            this.panelListView.Size = new System.Drawing.Size(810, 465);
            this.panelListView.TabIndex = 2;
            // 
            // panelSearchVendedoras
            // 
            this.panelSearchVendedoras.Controls.Add(this.textSearch);
            this.panelSearchVendedoras.Controls.Add(this.panel2);
            this.panelSearchVendedoras.Controls.Add(this.pictureSearch);
            this.panelSearchVendedoras.Controls.Add(this.radioButtonNome);
            this.panelSearchVendedoras.Controls.Add(this.radioButtonCpf);
            this.panelSearchVendedoras.Location = new System.Drawing.Point(195, 3);
            this.panelSearchVendedoras.Name = "panelSearchVendedoras";
            this.panelSearchVendedoras.Size = new System.Drawing.Size(416, 27);
            this.panelSearchVendedoras.TabIndex = 2;
            // 
            // textSearch
            // 
            this.textSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textSearch.Location = new System.Drawing.Point(17, 6);
            this.textSearch.Name = "textSearch";
            this.textSearch.Size = new System.Drawing.Size(246, 15);
            this.textSearch.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Location = new System.Drawing.Point(17, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(246, 2);
            this.panel2.TabIndex = 8;
            // 
            // pictureSearch
            // 
            this.pictureSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureSearch.Location = new System.Drawing.Point(264, 3);
            this.pictureSearch.Name = "pictureSearch";
            this.pictureSearch.Size = new System.Drawing.Size(22, 22);
            this.pictureSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureSearch.TabIndex = 7;
            this.pictureSearch.TabStop = false;
            // 
            // radioButtonNome
            // 
            this.radioButtonNome.AutoSize = true;
            this.radioButtonNome.Checked = true;
            this.radioButtonNome.FlatAppearance.BorderSize = 0;
            this.radioButtonNome.ForeColor = System.Drawing.Color.White;
            this.radioButtonNome.Location = new System.Drawing.Point(306, 5);
            this.radioButtonNome.Name = "radioButtonNome";
            this.radioButtonNome.Size = new System.Drawing.Size(57, 18);
            this.radioButtonNome.TabIndex = 5;
            this.radioButtonNome.TabStop = true;
            this.radioButtonNome.Text = "Nome";
            this.radioButtonNome.UseVisualStyleBackColor = true;
            // 
            // radioButtonCpf
            // 
            this.radioButtonCpf.AutoSize = true;
            this.radioButtonCpf.FlatAppearance.BorderSize = 0;
            this.radioButtonCpf.ForeColor = System.Drawing.Color.White;
            this.radioButtonCpf.Location = new System.Drawing.Point(365, 5);
            this.radioButtonCpf.Name = "radioButtonCpf";
            this.radioButtonCpf.Size = new System.Drawing.Size(43, 18);
            this.radioButtonCpf.TabIndex = 6;
            this.radioButtonCpf.Text = "CPF";
            this.radioButtonCpf.UseVisualStyleBackColor = true;
            this.radioButtonCpf.CheckedChanged += new System.EventHandler(this.radioButtonCpf_CheckedChanged);
            // 
            // panelContentGridView
            // 
            this.panelContentGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContentGridView.Controls.Add(this.dataGridViewVendedoras);
            this.panelContentGridView.Location = new System.Drawing.Point(8, 36);
            this.panelContentGridView.Name = "panelContentGridView";
            this.panelContentGridView.Size = new System.Drawing.Size(793, 420);
            this.panelContentGridView.TabIndex = 1;
            // 
            // dataGridViewVendedoras
            // 
            this.dataGridViewVendedoras.AllowUserToAddRows = false;
            this.dataGridViewVendedoras.AllowUserToDeleteRows = false;
            this.dataGridViewVendedoras.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dataGridViewVendedoras.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewVendedoras.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewVendedoras.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridViewVendedoras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVendedoras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewVendedoras.GridColor = System.Drawing.Color.DeepSkyBlue;
            this.dataGridViewVendedoras.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewVendedoras.Name = "dataGridViewVendedoras";
            this.dataGridViewVendedoras.ReadOnly = true;
            this.dataGridViewVendedoras.RowTemplate.ReadOnly = true;
            this.dataGridViewVendedoras.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewVendedoras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewVendedoras.ShowCellErrors = false;
            this.dataGridViewVendedoras.ShowEditingIcon = false;
            this.dataGridViewVendedoras.ShowRowErrors = false;
            this.dataGridViewVendedoras.Size = new System.Drawing.Size(793, 420);
            this.dataGridViewVendedoras.TabIndex = 0;
            // 
            // VendedorasListUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelListView);
            this.Controls.Add(this.panelCommands);
            this.Font = new System.Drawing.Font("Calibri", 9F);
            this.Name = "VendedorasListUC";
            this.Size = new System.Drawing.Size(810, 510);
            this.Load += new System.EventHandler(this.VendedorasListUC_Load);
            this.panelCommands.ResumeLayout(false);
            this.panelListView.ResumeLayout(false);
            this.panelSearchVendedoras.ResumeLayout(false);
            this.panelSearchVendedoras.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSearch)).EndInit();
            this.panelContentGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVendedoras)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelCommands;
        private System.Windows.Forms.Panel panelListView;
        private System.Windows.Forms.DataGridView dataGridViewVendedoras;
        private System.Windows.Forms.Panel panelContentGridView;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelSearchVendedoras;
        private System.Windows.Forms.MaskedTextBox textSearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureSearch;
        private System.Windows.Forms.RadioButton radioButtonNome;
        private System.Windows.Forms.RadioButton radioButtonCpf;
    }
}
