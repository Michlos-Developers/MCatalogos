
namespace PresentationLayer
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
            this.PanelMenu = new System.Windows.Forms.Panel();
            this.PanelUserProperties = new System.Windows.Forms.Panel();
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.UserBtn = new System.Windows.Forms.Button();
            this.pictureLogo = new System.Windows.Forms.PictureBox();
            this.VendedorasBtn = new System.Windows.Forms.Button();
            this.UserControlPanel = new System.Windows.Forms.Panel();
            this.optionsPanel = new System.Windows.Forms.Panel();
            this.pictureMenu = new System.Windows.Forms.PictureBox();
            this.moreOptionContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.helpAboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VendedoraDetailTimer = new System.Windows.Forms.Timer(this.components);
            this.PanelMenu.SuspendLayout();
            this.PanelUserProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).BeginInit();
            this.UserControlPanel.SuspendLayout();
            this.optionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureMenu)).BeginInit();
            this.moreOptionContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelMenu
            // 
            this.PanelMenu.Controls.Add(this.PanelUserProperties);
            this.PanelMenu.Controls.Add(this.pictureLogo);
            this.PanelMenu.Controls.Add(this.VendedorasBtn);
            this.PanelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelMenu.Location = new System.Drawing.Point(0, 0);
            this.PanelMenu.Name = "PanelMenu";
            this.PanelMenu.Size = new System.Drawing.Size(200, 520);
            this.PanelMenu.TabIndex = 0;
            // 
            // PanelUserProperties
            // 
            this.PanelUserProperties.Controls.Add(this.UserNameLabel);
            this.PanelUserProperties.Controls.Add(this.UserBtn);
            this.PanelUserProperties.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelUserProperties.Location = new System.Drawing.Point(0, 480);
            this.PanelUserProperties.Name = "PanelUserProperties";
            this.PanelUserProperties.Size = new System.Drawing.Size(200, 40);
            this.PanelUserProperties.TabIndex = 2;
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNameLabel.Location = new System.Drawing.Point(46, 11);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(85, 20);
            this.UserNameLabel.TabIndex = 1;
            this.UserNameLabel.Text = "UserName";
            // 
            // UserBtn
            // 
            this.UserBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.UserBtn.FlatAppearance.BorderSize = 0;
            this.UserBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UserBtn.Font = new System.Drawing.Font("Segoe UI Symbol", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserBtn.Location = new System.Drawing.Point(0, 0);
            this.UserBtn.Name = "UserBtn";
            this.UserBtn.Size = new System.Drawing.Size(40, 40);
            this.UserBtn.TabIndex = 0;
            this.UserBtn.Text = "";
            this.UserBtn.UseVisualStyleBackColor = true;
            // 
            // pictureLogo
            // 
            this.pictureLogo.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureLogo.Image = global::PresentationLayer.Properties.Resources.CatLogoLogo;
            this.pictureLogo.Location = new System.Drawing.Point(0, 0);
            this.pictureLogo.Name = "pictureLogo";
            this.pictureLogo.Size = new System.Drawing.Size(200, 60);
            this.pictureLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureLogo.TabIndex = 1;
            this.pictureLogo.TabStop = false;
            // 
            // VendedorasBtn
            // 
            this.VendedorasBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.VendedorasBtn.FlatAppearance.BorderSize = 0;
            this.VendedorasBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VendedorasBtn.ForeColor = System.Drawing.Color.White;
            this.VendedorasBtn.Image = global::PresentationLayer.Properties.Resources.IconVendedora35x35;
            this.VendedorasBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.VendedorasBtn.Location = new System.Drawing.Point(0, 61);
            this.VendedorasBtn.Name = "VendedorasBtn";
            this.VendedorasBtn.Size = new System.Drawing.Size(200, 50);
            this.VendedorasBtn.TabIndex = 0;
            this.VendedorasBtn.Text = "Vendedoras";
            this.VendedorasBtn.UseVisualStyleBackColor = false;
            this.VendedorasBtn.Click += new System.EventHandler(this.VendedorasBtn_Click);
            // 
            // UserControlPanel
            // 
            this.UserControlPanel.Controls.Add(this.optionsPanel);
            this.UserControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserControlPanel.Location = new System.Drawing.Point(200, 0);
            this.UserControlPanel.Name = "UserControlPanel";
            this.UserControlPanel.Size = new System.Drawing.Size(758, 520);
            this.UserControlPanel.TabIndex = 0;
            // 
            // optionsPanel
            // 
            this.optionsPanel.Controls.Add(this.pictureMenu);
            this.optionsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.optionsPanel.Location = new System.Drawing.Point(0, 0);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.Size = new System.Drawing.Size(758, 23);
            this.optionsPanel.TabIndex = 0;
            // 
            // pictureMenu
            // 
            this.pictureMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureMenu.Image = global::PresentationLayer.Properties.Resources.IconConfig35x35;
            this.pictureMenu.Location = new System.Drawing.Point(729, 0);
            this.pictureMenu.Name = "pictureMenu";
            this.pictureMenu.Size = new System.Drawing.Size(29, 23);
            this.pictureMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureMenu.TabIndex = 0;
            this.pictureMenu.TabStop = false;
            this.pictureMenu.Click += new System.EventHandler(this.pictureMenu_Click);
            // 
            // moreOptionContextMenuStrip
            // 
            this.moreOptionContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpAboutToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.moreOptionContextMenuStrip.Name = "moreOptionContextMenuStrip";
            this.moreOptionContextMenuStrip.Size = new System.Drawing.Size(136, 70);
            // 
            // helpAboutToolStripMenuItem
            // 
            this.helpAboutToolStripMenuItem.Name = "helpAboutToolStripMenuItem";
            this.helpAboutToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.helpAboutToolStripMenuItem.Text = "Help About";
            this.helpAboutToolStripMenuItem.Click += new System.EventHandler(this.helpAboutToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // VendedoraDetailTimer
            // 
            this.VendedoraDetailTimer.Tick += new System.EventHandler(this.vendedoraDetailTimer_Tick);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 520);
            this.Controls.Add(this.UserControlPanel);
            this.Controls.Add(this.PanelMenu);
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Model View Presenter Demo";
            this.Load += new System.EventHandler(this.MainView_Load);
            this.PanelMenu.ResumeLayout(false);
            this.PanelUserProperties.ResumeLayout(false);
            this.PanelUserProperties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).EndInit();
            this.UserControlPanel.ResumeLayout(false);
            this.optionsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureMenu)).EndInit();
            this.moreOptionContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelMenu;
        private System.Windows.Forms.Panel PanelUserProperties;
        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.Button UserBtn;
        private System.Windows.Forms.PictureBox pictureLogo;
        private System.Windows.Forms.Button VendedorasBtn;
        private System.Windows.Forms.Panel UserControlPanel;
        private System.Windows.Forms.ContextMenuStrip moreOptionContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem helpAboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Timer VendedoraDetailTimer;
        private System.Windows.Forms.Panel optionsPanel;
        private System.Windows.Forms.PictureBox pictureMenu;
    }
}

