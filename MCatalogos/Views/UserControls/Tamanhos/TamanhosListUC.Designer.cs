
namespace MCatalogos.Views.UserControls.Tamanhos
{
    partial class TamanhosListUC
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
            this.dgvTamanhos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTamanhos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTamanhos
            // 
            this.dgvTamanhos.BackgroundColor = System.Drawing.Color.White;
            this.dgvTamanhos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTamanhos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTamanhos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvTamanhos.GridColor = System.Drawing.Color.LightBlue;
            this.dgvTamanhos.Location = new System.Drawing.Point(0, 0);
            this.dgvTamanhos.Name = "dgvTamanhos";
            this.dgvTamanhos.Size = new System.Drawing.Size(142, 119);
            this.dgvTamanhos.TabIndex = 0;
            // 
            // TamanhosListUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvTamanhos);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "TamanhosListUC";
            this.Size = new System.Drawing.Size(142, 119);
            this.Load += new System.EventHandler(this.TamanhosListUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTamanhos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvTamanhos;
    }
}
