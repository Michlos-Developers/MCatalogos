
namespace MCatalogos.Views.FormViews.Financeiro
{
    partial class FinanceiroForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FinanceiroForm));
            this.panelTitle = new System.Windows.Forms.Panel();
            this.pictureClose = new System.Windows.Forms.PictureBox();
            this.title = new System.Windows.Forms.Label();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelContasReceber = new System.Windows.Forms.Panel();
            this.panelContasPagar = new System.Windows.Forms.Panel();
            this.btnContasPagar = new System.Windows.Forms.Button();
            this.btnCaixa = new System.Windows.Forms.Button();
            this.btnContasReceber = new System.Windows.Forms.Button();
            this.panelCommands = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureClose)).BeginInit();
            this.panelContainer.SuspendLayout();
            this.panelCommands.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.White;
            this.panelTitle.Controls.Add(this.pictureClose);
            this.panelTitle.Controls.Add(this.title);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(800, 30);
            this.panelTitle.TabIndex = 7;
            this.panelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitle_MouseDown);
            // 
            // pictureClose
            // 
            this.pictureClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureClose.Image = global::MCatalogos.Properties.Resources.IconClose20x20;
            this.pictureClose.Location = new System.Drawing.Point(777, 6);
            this.pictureClose.Name = "pictureClose";
            this.pictureClose.Size = new System.Drawing.Size(15, 15);
            this.pictureClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureClose.TabIndex = 1;
            this.pictureClose.TabStop = false;
            this.pictureClose.Click += new System.EventHandler(this.pictureClose_Click);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.ForeColor = System.Drawing.SystemColors.ControlText;
            this.title.Location = new System.Drawing.Point(10, 8);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(114, 14);
            this.title.TabIndex = 0;
            this.title.Text = "Controle Financeiro";
            // 
            // panelContainer
            // 
            this.panelContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(111)))), ((int)(((byte)(156)))));
            this.panelContainer.Controls.Add(this.panelCommands);
            this.panelContainer.Controls.Add(this.panelContasReceber);
            this.panelContainer.Controls.Add(this.panelContasPagar);
            this.panelContainer.Controls.Add(this.btnContasPagar);
            this.panelContainer.Controls.Add(this.btnCaixa);
            this.panelContainer.Controls.Add(this.btnContasReceber);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 30);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(800, 500);
            this.panelContainer.TabIndex = 8;
            // 
            // panelContasReceber
            // 
            this.panelContasReceber.Location = new System.Drawing.Point(410, 141);
            this.panelContasReceber.Name = "panelContasReceber";
            this.panelContasReceber.Size = new System.Drawing.Size(378, 302);
            this.panelContasReceber.TabIndex = 10;
            // 
            // panelContasPagar
            // 
            this.panelContasPagar.Location = new System.Drawing.Point(13, 141);
            this.panelContasPagar.Name = "panelContasPagar";
            this.panelContasPagar.Size = new System.Drawing.Size(378, 302);
            this.panelContasPagar.TabIndex = 10;
            // 
            // btnContasPagar
            // 
            this.btnContasPagar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContasPagar.FlatAppearance.BorderSize = 0;
            this.btnContasPagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContasPagar.Image = global::MCatalogos.Properties.Resources.IconContasPagar35x35;
            this.btnContasPagar.Location = new System.Drawing.Point(142, 60);
            this.btnContasPagar.Name = "btnContasPagar";
            this.btnContasPagar.Size = new System.Drawing.Size(120, 75);
            this.btnContasPagar.TabIndex = 9;
            this.btnContasPagar.Text = "Contas a Pagar";
            this.btnContasPagar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnContasPagar.UseVisualStyleBackColor = true;
            this.btnContasPagar.Click += new System.EventHandler(this.btnContasPagar_Click);
            // 
            // btnCaixa
            // 
            this.btnCaixa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCaixa.FlatAppearance.BorderSize = 0;
            this.btnCaixa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCaixa.Image = global::MCatalogos.Properties.Resources.IconFluxoCaixa35x35;
            this.btnCaixa.Location = new System.Drawing.Point(341, 6);
            this.btnCaixa.Name = "btnCaixa";
            this.btnCaixa.Size = new System.Drawing.Size(120, 75);
            this.btnCaixa.TabIndex = 9;
            this.btnCaixa.Text = "Fluxo de Caixa";
            this.btnCaixa.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCaixa.UseVisualStyleBackColor = true;
            this.btnCaixa.Click += new System.EventHandler(this.btnCaixa_Click);
            // 
            // btnContasReceber
            // 
            this.btnContasReceber.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContasReceber.FlatAppearance.BorderSize = 0;
            this.btnContasReceber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContasReceber.Image = ((System.Drawing.Image)(resources.GetObject("btnContasReceber.Image")));
            this.btnContasReceber.Location = new System.Drawing.Point(539, 60);
            this.btnContasReceber.Name = "btnContasReceber";
            this.btnContasReceber.Size = new System.Drawing.Size(120, 75);
            this.btnContasReceber.TabIndex = 9;
            this.btnContasReceber.Text = "Contas a Receber";
            this.btnContasReceber.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnContasReceber.UseVisualStyleBackColor = true;
            this.btnContasReceber.Click += new System.EventHandler(this.btnContasReceber_Click);
            // 
            // panelCommands
            // 
            this.panelCommands.BackColor = System.Drawing.SystemColors.Control;
            this.panelCommands.Controls.Add(this.btnCancel);
            this.panelCommands.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCommands.Location = new System.Drawing.Point(0, 455);
            this.panelCommands.Name = "panelCommands";
            this.panelCommands.Size = new System.Drawing.Size(800, 45);
            this.panelCommands.TabIndex = 11;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(704, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 27);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Tag = "Pedidos";
            this.btnCancel.Text = "Fechar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FinanceiroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 530);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelTitle);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FinanceiroForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FinaceiroForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FinanceiroForm_FormClosing);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureClose)).EndInit();
            this.panelContainer.ResumeLayout(false);
            this.panelCommands.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.PictureBox pictureClose;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Panel panelContasReceber;
        private System.Windows.Forms.Panel panelContasPagar;
        private System.Windows.Forms.Button btnContasPagar;
        private System.Windows.Forms.Button btnContasReceber;
        private System.Windows.Forms.Button btnCaixa;
        private System.Windows.Forms.Panel panelCommands;
        private System.Windows.Forms.Button btnCancel;
    }
}