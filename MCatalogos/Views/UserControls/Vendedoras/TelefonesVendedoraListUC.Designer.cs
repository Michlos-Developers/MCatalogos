
namespace MCatalogos.Views.UserControls
{
    partial class TelefonesVendedoraListUC
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
            this.panelCmdTelefones = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panelDgvTelefones = new System.Windows.Forms.Panel();
            this.dgvTelefonesVendedora = new System.Windows.Forms.DataGridView();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelCmdTelefones.SuspendLayout();
            this.panelDgvTelefones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTelefonesVendedora)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCmdTelefones
            // 
            this.panelCmdTelefones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.panelCmdTelefones.Controls.Add(this.btnDelete);
            this.panelCmdTelefones.Controls.Add(this.btnAdd);
            this.panelCmdTelefones.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelCmdTelefones.Location = new System.Drawing.Point(269, 0);
            this.panelCmdTelefones.Name = "panelCmdTelefones";
            this.panelCmdTelefones.Size = new System.Drawing.Size(30, 186);
            this.panelCmdTelefones.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Image = global::MCatalogos.Properties.Resources.IconDelete20x20;
            this.btnDelete.Location = new System.Drawing.Point(2, 157);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(25, 25);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.TabStop = false;
            this.btnDelete.Tag = "";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip.SetToolTip(this.btnDelete, "Excluir Telefone");
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Image = global::MCatalogos.Properties.Resources.IconAdd20x20;
            this.btnAdd.Location = new System.Drawing.Point(2, 128);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(25, 25);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.TabStop = false;
            this.btnAdd.Tag = "";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip.SetToolTip(this.btnAdd, "Adicionar Telefone");
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panelDgvTelefones
            // 
            this.panelDgvTelefones.Controls.Add(this.dgvTelefonesVendedora);
            this.panelDgvTelefones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDgvTelefones.Location = new System.Drawing.Point(0, 0);
            this.panelDgvTelefones.Name = "panelDgvTelefones";
            this.panelDgvTelefones.Size = new System.Drawing.Size(269, 186);
            this.panelDgvTelefones.TabIndex = 1;
            // 
            // dgvTelefonesVendedora
            // 
            this.dgvTelefonesVendedora.AllowUserToAddRows = false;
            this.dgvTelefonesVendedora.AllowUserToDeleteRows = false;
            this.dgvTelefonesVendedora.AllowUserToResizeColumns = false;
            this.dgvTelefonesVendedora.AllowUserToResizeRows = false;
            this.dgvTelefonesVendedora.BackgroundColor = System.Drawing.Color.White;
            this.dgvTelefonesVendedora.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTelefonesVendedora.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvTelefonesVendedora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTelefonesVendedora.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTelefonesVendedora.GridColor = System.Drawing.Color.DeepSkyBlue;
            this.dgvTelefonesVendedora.Location = new System.Drawing.Point(0, 0);
            this.dgvTelefonesVendedora.Name = "dgvTelefonesVendedora";
            this.dgvTelefonesVendedora.ReadOnly = true;
            this.dgvTelefonesVendedora.RowHeadersVisible = false;
            this.dgvTelefonesVendedora.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvTelefonesVendedora.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTelefonesVendedora.ShowCellErrors = false;
            this.dgvTelefonesVendedora.ShowEditingIcon = false;
            this.dgvTelefonesVendedora.ShowRowErrors = false;
            this.dgvTelefonesVendedora.Size = new System.Drawing.Size(269, 186);
            this.dgvTelefonesVendedora.TabIndex = 0;
            this.dgvTelefonesVendedora.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTelefonesVendedora_CellClick);
            this.dgvTelefonesVendedora.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTelefonesVendedora_CellFormatting);
            // 
            // TelefonesVendedoraListUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelDgvTelefones);
            this.Controls.Add(this.panelCmdTelefones);
            this.Font = new System.Drawing.Font("Calibri", 9F);
            this.Name = "TelefonesVendedoraListUC";
            this.Size = new System.Drawing.Size(299, 186);
            this.Load += new System.EventHandler(this.TelefonesVendedoraListUC_Load);
            this.panelCmdTelefones.ResumeLayout(false);
            this.panelDgvTelefones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTelefonesVendedora)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCmdTelefones;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panelDgvTelefones;
        public System.Windows.Forms.DataGridView dgvTelefonesVendedora;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
