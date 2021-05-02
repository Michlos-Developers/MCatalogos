
namespace PresentationLayer.Views.UserControls
{
    partial class VendedoraListViewUC
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
            this.VendedoraListDataGridView = new System.Windows.Forms.DataGridView();
            this.commandsListVendedoraPanel = new System.Windows.Forms.Panel();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.listVendedorasPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.VendedoraListDataGridView)).BeginInit();
            this.commandsListVendedoraPanel.SuspendLayout();
            this.listVendedorasPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // VendedoraListDataGridView
            // 
            this.VendedoraListDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.VendedoraListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VendedoraListDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VendedoraListDataGridView.Location = new System.Drawing.Point(0, 0);
            this.VendedoraListDataGridView.Name = "VendedoraListDataGridView";
            this.VendedoraListDataGridView.ReadOnly = true;
            this.VendedoraListDataGridView.Size = new System.Drawing.Size(763, 307);
            this.VendedoraListDataGridView.TabIndex = 0;
            this.VendedoraListDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.VendedoraListDataGridView_CellClick);
            this.VendedoraListDataGridView.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.VendedoraListDataGridView_CellMouseLeave);
            this.VendedoraListDataGridView.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.VendedoraListDataGridView_CellMouseMove);
            // 
            // commandsListVendedoraPanel
            // 
            this.commandsListVendedoraPanel.Controls.Add(this.btnEdit);
            this.commandsListVendedoraPanel.Controls.Add(this.btnClose);
            this.commandsListVendedoraPanel.Controls.Add(this.btnDelete);
            this.commandsListVendedoraPanel.Controls.Add(this.btnAdd);
            this.commandsListVendedoraPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.commandsListVendedoraPanel.Location = new System.Drawing.Point(0, 307);
            this.commandsListVendedoraPanel.Name = "commandsListVendedoraPanel";
            this.commandsListVendedoraPanel.Size = new System.Drawing.Size(763, 41);
            this.commandsListVendedoraPanel.TabIndex = 1;
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::PresentationLayer.Properties.Resources.IconEditVendedora20x20;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(508, 6);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(80, 30);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Editar  ";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(674, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 30);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Fechar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::PresentationLayer.Properties.Resources.IconDelete20x20;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(591, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 30);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "Apagar";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::PresentationLayer.Properties.Resources.IconAddVendedora20x20;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(425, 6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 30);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Adicionar";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // listVendedorasPanel
            // 
            this.listVendedorasPanel.Controls.Add(this.VendedoraListDataGridView);
            this.listVendedorasPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listVendedorasPanel.Location = new System.Drawing.Point(0, 0);
            this.listVendedorasPanel.Name = "listVendedorasPanel";
            this.listVendedorasPanel.Size = new System.Drawing.Size(763, 307);
            this.listVendedorasPanel.TabIndex = 2;
            // 
            // VendedoraListViewUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listVendedorasPanel);
            this.Controls.Add(this.commandsListVendedoraPanel);
            this.Name = "VendedoraListViewUC";
            this.Size = new System.Drawing.Size(763, 348);
            this.Load += new System.EventHandler(this.VendedoraListViewUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VendedoraListDataGridView)).EndInit();
            this.commandsListVendedoraPanel.ResumeLayout(false);
            this.listVendedorasPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView VendedoraListDataGridView;
        private System.Windows.Forms.Panel commandsListVendedoraPanel;
        private System.Windows.Forms.Panel listVendedorasPanel;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
    }
}
