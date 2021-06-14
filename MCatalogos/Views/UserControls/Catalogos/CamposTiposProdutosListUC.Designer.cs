
namespace MCatalogos.Views.UserControls.Catalogos
{
    partial class CamposTiposProdutosListUC
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
            this.dgvCampos = new System.Windows.Forms.DataGridView();
            this.ColumnCampoTipoId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFormato = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnTipoProdutoId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCampos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCampos
            // 
            this.dgvCampos.BackgroundColor = System.Drawing.Color.White;
            this.dgvCampos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCampos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCampoTipoId,
            this.ColumnNome,
            this.ColumnFormato,
            this.ColumnTipoProdutoId});
            this.dgvCampos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCampos.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvCampos.Location = new System.Drawing.Point(0, 0);
            this.dgvCampos.MultiSelect = false;
            this.dgvCampos.Name = "dgvCampos";
            this.dgvCampos.Size = new System.Drawing.Size(307, 93);
            this.dgvCampos.TabIndex = 1;
            // 
            // ColumnCampoTipoId
            // 
            this.ColumnCampoTipoId.HeaderText = "CampoTipoId";
            this.ColumnCampoTipoId.Name = "ColumnCampoTipoId";
            this.ColumnCampoTipoId.Visible = false;
            // 
            // ColumnNome
            // 
            this.ColumnNome.HeaderText = "Nome";
            this.ColumnNome.Name = "ColumnNome";
            this.ColumnNome.Width = 120;
            // 
            // ColumnFormato
            // 
            this.ColumnFormato.HeaderText = "Formato";
            this.ColumnFormato.Name = "ColumnFormato";
            this.ColumnFormato.Width = 120;
            // 
            // ColumnTipoProdutoId
            // 
            this.ColumnTipoProdutoId.HeaderText = "TipoProdutoId";
            this.ColumnTipoProdutoId.Name = "ColumnTipoProdutoId";
            this.ColumnTipoProdutoId.Visible = false;
            // 
            // CamposTiposProdutosListUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvCampos);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "CamposTiposProdutosListUC";
            this.Size = new System.Drawing.Size(307, 93);
            this.Load += new System.EventHandler(this.CamposTiposProdutosListUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCampos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCampoTipoId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNome;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnFormato;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTipoProdutoId;
        public System.Windows.Forms.DataGridView dgvCampos;
    }
}
