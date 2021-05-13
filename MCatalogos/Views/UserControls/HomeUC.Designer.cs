
namespace MCatalogos.UserControls
{
    partial class HomeUC
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
            this.pictureLogoMichlos = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogoMichlos)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureLogoMichlos
            // 
            this.pictureLogoMichlos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureLogoMichlos.Image = global::MCatalogos.Properties.Resources.LOGOPNG;
            this.pictureLogoMichlos.Location = new System.Drawing.Point(419, 382);
            this.pictureLogoMichlos.Name = "pictureLogoMichlos";
            this.pictureLogoMichlos.Size = new System.Drawing.Size(391, 128);
            this.pictureLogoMichlos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureLogoMichlos.TabIndex = 0;
            this.pictureLogoMichlos.TabStop = false;
            // 
            // HomeUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureLogoMichlos);
            this.Name = "HomeUC";
            this.Size = new System.Drawing.Size(810, 510);
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogoMichlos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureLogoMichlos;
    }
}
