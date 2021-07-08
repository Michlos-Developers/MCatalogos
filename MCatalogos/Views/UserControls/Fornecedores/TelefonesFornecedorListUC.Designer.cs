
namespace MCatalogos.Views.UserControls.Fornecedores
{
    partial class TelefonesFornecedorListUC
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
            this.components = new System.ComponentModel.Container();
            this.panelCommands = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panelContentListTelefones = new System.Windows.Forms.Panel();
            this.dgvTeleForn = new System.Windows.Forms.DataGridView();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelCommands.SuspendLayout();
            this.panelContentListTelefones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeleForn)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCommands
            // 
            this.panelCommands.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.panelCommands.Controls.Add(this.btnDelete);
            this.panelCommands.Controls.Add(this.btnEdit);
            this.panelCommands.Controls.Add(this.btnAdd);
            this.panelCommands.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelCommands.Location = new System.Drawing.Point(727, 0);
            this.panelCommands.Name = "panelCommands";
            this.panelCommands.Size = new System.Drawing.Size(30, 119);
            this.panelCommands.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Image = global::MCatalogos.Properties.Resources.IconDelete20x20;
            this.btnDelete.Location = new System.Drawing.Point(2, 91);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(25, 25);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.TabStop = false;
            this.btnDelete.Tag = "";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip.SetToolTip(this.btnDelete, "Excluir Contato");
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Image = global::MCatalogos.Properties.Resources.iconEdit20x20;
            this.btnEdit.Location = new System.Drawing.Point(2, 62);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(25, 25);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.TabStop = false;
            this.btnEdit.Tag = "";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip.SetToolTip(this.btnEdit, "Editar Contato");
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Image = global::MCatalogos.Properties.Resources.IconAdd20x20;
            this.btnAdd.Location = new System.Drawing.Point(2, 33);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(25, 25);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.TabStop = false;
            this.btnAdd.Tag = "";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip.SetToolTip(this.btnAdd, "Adicionar Contato");
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panelContentListTelefones
            // 
            this.panelContentListTelefones.Controls.Add(this.dgvTeleForn);
            this.panelContentListTelefones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContentListTelefones.Location = new System.Drawing.Point(0, 0);
            this.panelContentListTelefones.Name = "panelContentListTelefones";
            this.panelContentListTelefones.Size = new System.Drawing.Size(727, 119);
            this.panelContentListTelefones.TabIndex = 1;
            // 
            // dgvTeleForn
            // 
            this.dgvTeleForn.AllowUserToAddRows = false;
            this.dgvTeleForn.AllowUserToDeleteRows = false;
            this.dgvTeleForn.AllowUserToResizeColumns = false;
            this.dgvTeleForn.AllowUserToResizeRows = false;
            this.dgvTeleForn.BackgroundColor = System.Drawing.Color.White;
            this.dgvTeleForn.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTeleForn.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvTeleForn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeleForn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTeleForn.GridColor = System.Drawing.Color.DeepSkyBlue;
            this.dgvTeleForn.Location = new System.Drawing.Point(0, 0);
            this.dgvTeleForn.Name = "dgvTeleForn";
            this.dgvTeleForn.ReadOnly = true;
            this.dgvTeleForn.RowHeadersVisible = false;
            this.dgvTeleForn.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvTeleForn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTeleForn.ShowCellErrors = false;
            this.dgvTeleForn.ShowEditingIcon = false;
            this.dgvTeleForn.ShowRowErrors = false;
            this.dgvTeleForn.Size = new System.Drawing.Size(727, 119);
            this.dgvTeleForn.TabIndex = 0;
            this.dgvTeleForn.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTeleForn_CellClick);
            this.dgvTeleForn.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTeleForn_CellDoubleClick);
            this.dgvTeleForn.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTeleForn_CellFormatting);
            // 
            // TelefonesFornecedorListUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelContentListTelefones);
            this.Controls.Add(this.panelCommands);
            this.Font = new System.Drawing.Font("Calibri", 9F);
            this.Name = "TelefonesFornecedorListUC";
            this.Size = new System.Drawing.Size(757, 119);
            this.Load += new System.EventHandler(this.TelefonesFornecedorListUC_Load);
            this.panelCommands.ResumeLayout(false);
            this.panelContentListTelefones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeleForn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCommands;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panelContentListTelefones;
        public System.Windows.Forms.DataGridView dgvTeleForn;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
