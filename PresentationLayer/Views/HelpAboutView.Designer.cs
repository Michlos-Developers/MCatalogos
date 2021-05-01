
namespace PresentationLayer.Views
{
    partial class HelpAboutView
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.productLabel = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.copyRightLabel = new System.Windows.Forms.Label();
            this.companyLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PresentationLayer.Properties.Resources.CatLogoLogo;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(265, 66);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // productLabel
            // 
            this.productLabel.Location = new System.Drawing.Point(29, 81);
            this.productLabel.Name = "productLabel";
            this.productLabel.Size = new System.Drawing.Size(225, 23);
            this.productLabel.TabIndex = 1;
            this.productLabel.Text = "Produto";
            this.productLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // versionLabel
            // 
            this.versionLabel.Location = new System.Drawing.Point(29, 104);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(225, 23);
            this.versionLabel.TabIndex = 2;
            this.versionLabel.Text = "Versão";
            this.versionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // copyRightLabel
            // 
            this.copyRightLabel.Location = new System.Drawing.Point(29, 127);
            this.copyRightLabel.Name = "copyRightLabel";
            this.copyRightLabel.Size = new System.Drawing.Size(225, 23);
            this.copyRightLabel.TabIndex = 3;
            this.copyRightLabel.Text = "Copyright";
            this.copyRightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // companyLabel
            // 
            this.companyLabel.Location = new System.Drawing.Point(29, 150);
            this.companyLabel.Name = "companyLabel";
            this.companyLabel.Size = new System.Drawing.Size(225, 23);
            this.companyLabel.TabIndex = 4;
            this.companyLabel.Text = "Empresa";
            this.companyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.Location = new System.Drawing.Point(29, 173);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(225, 44);
            this.descriptionLabel.TabIndex = 5;
            this.descriptionLabel.Text = "Descrição";
            this.descriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(106, 237);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 6;
            this.closeButton.Text = "Fechar";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // HelpAboutView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 338);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.companyLabel);
            this.Controls.Add(this.copyRightLabel);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.productLabel);
            this.Controls.Add(this.pictureBox1);
            this.Name = "HelpAboutView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "HelpAboutView";
            this.Load += new System.EventHandler(this.HelpAboutView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label productLabel;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label copyRightLabel;
        private System.Windows.Forms.Label companyLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Button closeButton;
    }
}