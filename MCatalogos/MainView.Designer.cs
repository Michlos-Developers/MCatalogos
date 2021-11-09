
namespace MCatalogos
{
    partial class MainView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.pictureLogo = new System.Windows.Forms.PictureBox();
            this.panelSecondaryMenu = new System.Windows.Forms.Panel();
            this.pictureMenuMobile = new System.Windows.Forms.PictureBox();
            this.toolTipMain = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).BeginInit();
            this.panelSecondaryMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureMenuMobile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.panelButtons);
            this.panelMenu.Controls.Add(this.pictureLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(168, 571);
            this.panelMenu.TabIndex = 0;
            // 
            // panelButtons
            // 
            this.panelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelButtons.Location = new System.Drawing.Point(2, 54);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(165, 514);
            this.panelButtons.TabIndex = 3;
            // 
            // pictureLogo
            // 
            this.pictureLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureLogo.Image")));
            this.pictureLogo.Location = new System.Drawing.Point(0, 0);
            this.pictureLogo.Name = "pictureLogo";
            this.pictureLogo.Size = new System.Drawing.Size(162, 61);
            this.pictureLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureLogo.TabIndex = 0;
            this.pictureLogo.TabStop = false;
            // 
            // panelSecondaryMenu
            // 
            this.panelSecondaryMenu.Controls.Add(this.pictureMenuMobile);
            this.panelSecondaryMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSecondaryMenu.Location = new System.Drawing.Point(168, 0);
            this.panelSecondaryMenu.Name = "panelSecondaryMenu";
            this.panelSecondaryMenu.Size = new System.Drawing.Size(840, 54);
            this.panelSecondaryMenu.TabIndex = 1;
            // 
            // pictureMenuMobile
            // 
            this.pictureMenuMobile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureMenuMobile.Image = global::MCatalogos.Properties.Resources.IconMenuMobile35x35;
            this.pictureMenuMobile.Location = new System.Drawing.Point(0, 13);
            this.pictureMenuMobile.Name = "pictureMenuMobile";
            this.pictureMenuMobile.Size = new System.Drawing.Size(23, 22);
            this.pictureMenuMobile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureMenuMobile.TabIndex = 0;
            this.pictureMenuMobile.TabStop = false;
            this.pictureMenuMobile.Tag = "";
            this.pictureMenuMobile.Click += new System.EventHandler(this.pictureMenuMobile_Click);
            this.pictureMenuMobile.MouseHover += new System.EventHandler(this.pictureMenuMobile_MouseHover);
            // 
            // toolTipMain
            // 
            this.toolTipMain.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolTipMain.ForeColor = System.Drawing.SystemColors.Info;
            // 
            // pictureBox1
            // 
            this.pictureBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic;
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::MCatalogos.Properties.Resources.LOGOPNG;
            this.pictureBox1.Location = new System.Drawing.Point(930, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 571);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panelSecondaryMenu);
            this.Controls.Add(this.panelMenu);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MCatálogos - Gestão de Catálogos de Vendedoras";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainView_Load);
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).EndInit();
            this.panelSecondaryMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureMenuMobile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.PictureBox pictureLogo;
        private System.Windows.Forms.Panel panelSecondaryMenu;
        private System.Windows.Forms.PictureBox pictureMenuMobile;
        private System.Windows.Forms.ToolTip toolTipMain;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelButtons;
    }
}

