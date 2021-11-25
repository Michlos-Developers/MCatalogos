
namespace MCatalogos.Views.FormViews.Reports
{
    partial class ControleRelatoriosForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControleRelatoriosForm));
            this.panelCommands = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.pictureClose = new System.Windows.Forms.PictureBox();
            this.title = new System.Windows.Forms.Label();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelConfigReport = new System.Windows.Forms.Panel();
            this.panelCallConfigReport = new System.Windows.Forms.Panel();
            this.panelCommandsReport = new System.Windows.Forms.Panel();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.btnCancelReport = new System.Windows.Forms.Button();
            this.btnReportContasPagar = new System.Windows.Forms.Button();
            this.btnReportPedidos = new System.Windows.Forms.Button();
            this.btnReportPromissorias = new System.Windows.Forms.Button();
            this.btnReportContasReceber = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panelCommands.SuspendLayout();
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureClose)).BeginInit();
            this.panelContainer.SuspendLayout();
            this.panelConfigReport.SuspendLayout();
            this.panelCommandsReport.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCommands
            // 
            this.panelCommands.BackColor = System.Drawing.SystemColors.Control;
            this.panelCommands.Controls.Add(this.btnCancel);
            this.panelCommands.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCommands.Location = new System.Drawing.Point(0, 483);
            this.panelCommands.Name = "panelCommands";
            this.panelCommands.Size = new System.Drawing.Size(798, 45);
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
            this.btnCancel.Location = new System.Drawing.Point(701, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 27);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Tag = "Pedidos";
            this.btnCancel.Text = "Fechar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.pictureClose_Click);
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
            this.panelTitle.TabIndex = 9;
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
            this.title.Size = new System.Drawing.Size(138, 18);
            this.title.TabIndex = 0;
            this.title.Text = "Central de Relatórios";
            // 
            // panelContainer
            // 
            this.panelContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(111)))), ((int)(((byte)(156)))));
            this.panelContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelContainer.Controls.Add(this.panelCommands);
            this.panelContainer.Controls.Add(this.panelConfigReport);
            this.panelContainer.Controls.Add(this.btnReportContasPagar);
            this.panelContainer.Controls.Add(this.btnReportPedidos);
            this.panelContainer.Controls.Add(this.btnReportPromissorias);
            this.panelContainer.Controls.Add(this.btnReportContasReceber);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(800, 530);
            this.panelContainer.TabIndex = 10;
            // 
            // panelConfigReport
            // 
            this.panelConfigReport.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panelConfigReport.Controls.Add(this.panelCallConfigReport);
            this.panelConfigReport.Controls.Add(this.panelCommandsReport);
            this.panelConfigReport.ForeColor = System.Drawing.Color.Black;
            this.panelConfigReport.Location = new System.Drawing.Point(134, 31);
            this.panelConfigReport.Name = "panelConfigReport";
            this.panelConfigReport.Size = new System.Drawing.Size(661, 449);
            this.panelConfigReport.TabIndex = 10;
            this.panelConfigReport.Visible = false;
            // 
            // panelCallConfigReport
            // 
            this.panelCallConfigReport.BackColor = System.Drawing.Color.Silver;
            this.panelCallConfigReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCallConfigReport.Location = new System.Drawing.Point(0, 0);
            this.panelCallConfigReport.Name = "panelCallConfigReport";
            this.panelCallConfigReport.Size = new System.Drawing.Size(661, 419);
            this.panelCallConfigReport.TabIndex = 13;
            // 
            // panelCommandsReport
            // 
            this.panelCommandsReport.BackColor = System.Drawing.SystemColors.Control;
            this.panelCommandsReport.Controls.Add(this.button1);
            this.panelCommandsReport.Controls.Add(this.btnGenerateReport);
            this.panelCommandsReport.Controls.Add(this.btnCancelReport);
            this.panelCommandsReport.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCommandsReport.Location = new System.Drawing.Point(0, 419);
            this.panelCommandsReport.Name = "panelCommandsReport";
            this.panelCommandsReport.Size = new System.Drawing.Size(661, 30);
            this.panelCommandsReport.TabIndex = 12;
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnGenerateReport.FlatAppearance.BorderSize = 0;
            this.btnGenerateReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateReport.ForeColor = System.Drawing.Color.White;
            this.btnGenerateReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerateReport.Location = new System.Drawing.Point(256, 4);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(66, 23);
            this.btnGenerateReport.TabIndex = 2;
            this.btnGenerateReport.Tag = "";
            this.btnGenerateReport.Text = "Gerar";
            this.btnGenerateReport.UseVisualStyleBackColor = false;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // btnCancelReport
            // 
            this.btnCancelReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnCancelReport.FlatAppearance.BorderSize = 0;
            this.btnCancelReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelReport.ForeColor = System.Drawing.Color.White;
            this.btnCancelReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelReport.Location = new System.Drawing.Point(342, 4);
            this.btnCancelReport.Name = "btnCancelReport";
            this.btnCancelReport.Size = new System.Drawing.Size(66, 23);
            this.btnCancelReport.TabIndex = 2;
            this.btnCancelReport.Tag = "";
            this.btnCancelReport.Text = "Cancelar";
            this.btnCancelReport.UseVisualStyleBackColor = false;
            this.btnCancelReport.Click += new System.EventHandler(this.btnCancelReport_Click);
            // 
            // btnReportContasPagar
            // 
            this.btnReportContasPagar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReportContasPagar.FlatAppearance.BorderSize = 0;
            this.btnReportContasPagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportContasPagar.Image = global::MCatalogos.Properties.Resources.IconContasPagar35x35;
            this.btnReportContasPagar.Location = new System.Drawing.Point(9, 271);
            this.btnReportContasPagar.Name = "btnReportContasPagar";
            this.btnReportContasPagar.Size = new System.Drawing.Size(120, 75);
            this.btnReportContasPagar.TabIndex = 9;
            this.btnReportContasPagar.Text = "Contas a Pagar";
            this.btnReportContasPagar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReportContasPagar.UseVisualStyleBackColor = true;
            this.btnReportContasPagar.Visible = false;
            // 
            // btnReportPedidos
            // 
            this.btnReportPedidos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReportPedidos.FlatAppearance.BorderSize = 0;
            this.btnReportPedidos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportPedidos.Image = global::MCatalogos.Properties.Resources.IconReportPedidos35x35;
            this.btnReportPedidos.Location = new System.Drawing.Point(9, 47);
            this.btnReportPedidos.Name = "btnReportPedidos";
            this.btnReportPedidos.Size = new System.Drawing.Size(120, 75);
            this.btnReportPedidos.TabIndex = 9;
            this.btnReportPedidos.Text = "Pedidos";
            this.btnReportPedidos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReportPedidos.UseVisualStyleBackColor = true;
            this.btnReportPedidos.Click += new System.EventHandler(this.btnReportPedidos_Click);
            // 
            // btnReportPromissorias
            // 
            this.btnReportPromissorias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReportPromissorias.FlatAppearance.BorderSize = 0;
            this.btnReportPromissorias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportPromissorias.Image = global::MCatalogos.Properties.Resources.IconReportPromissorias35x35;
            this.btnReportPromissorias.Location = new System.Drawing.Point(9, 159);
            this.btnReportPromissorias.Name = "btnReportPromissorias";
            this.btnReportPromissorias.Size = new System.Drawing.Size(120, 75);
            this.btnReportPromissorias.TabIndex = 9;
            this.btnReportPromissorias.Text = "Promissórias";
            this.btnReportPromissorias.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReportPromissorias.UseVisualStyleBackColor = true;
            this.btnReportPromissorias.Click += new System.EventHandler(this.btnReportPromissorias_Click);
            // 
            // btnReportContasReceber
            // 
            this.btnReportContasReceber.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReportContasReceber.FlatAppearance.BorderSize = 0;
            this.btnReportContasReceber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportContasReceber.Image = ((System.Drawing.Image)(resources.GetObject("btnReportContasReceber.Image")));
            this.btnReportContasReceber.Location = new System.Drawing.Point(9, 383);
            this.btnReportContasReceber.Name = "btnReportContasReceber";
            this.btnReportContasReceber.Size = new System.Drawing.Size(120, 75);
            this.btnReportContasReceber.TabIndex = 9;
            this.btnReportContasReceber.Text = "Contas a Receber";
            this.btnReportContasReceber.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReportContasReceber.UseVisualStyleBackColor = true;
            this.btnReportContasReceber.Visible = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(175, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 23);
            this.button1.TabIndex = 2;
            this.button1.Tag = "";
            this.button1.Text = "Promissoria";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ControleRelatoriosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 530);
            this.Controls.Add(this.panelTitle);
            this.Controls.Add(this.panelContainer);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ControleRelatoriosForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportControleForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReportControleForm_FormClosing);
            this.Load += new System.EventHandler(this.ControleRelatoriosForm_Load);
            this.panelCommands.ResumeLayout(false);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureClose)).EndInit();
            this.panelContainer.ResumeLayout(false);
            this.panelConfigReport.ResumeLayout(false);
            this.panelCommandsReport.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCommands;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.PictureBox pictureClose;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Panel panelConfigReport;
        private System.Windows.Forms.Button btnReportContasPagar;
        private System.Windows.Forms.Button btnReportPedidos;
        private System.Windows.Forms.Button btnReportPromissorias;
        private System.Windows.Forms.Button btnReportContasReceber;
        private System.Windows.Forms.Panel panelCommandsReport;
        private System.Windows.Forms.Button btnCancelReport;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.Panel panelCallConfigReport;
        private System.Windows.Forms.Button button1;
    }
}