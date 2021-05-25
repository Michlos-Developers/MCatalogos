
namespace MCatalogos.Views.FormViews.Configuracoes.Rotas
{
    partial class RefatoraRotasFormList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RefatoraRotasFormList));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.progressBarr = new System.Windows.Forms.ToolStripProgressBar();
            this.panelContent = new System.Windows.Forms.Panel();
            this.dgvRotasAntuais = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvRotasRefatoradas = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnRefact = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelCommands = new System.Windows.Forms.Panel();
            this.statusStrip.SuspendLayout();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRotasAntuais)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRotasRefatoradas)).BeginInit();
            this.panelCommands.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBarr});
            this.statusStrip.Location = new System.Drawing.Point(0, 539);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(598, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // progressBarr
            // 
            this.progressBarr.Name = "progressBarr";
            this.progressBarr.Size = new System.Drawing.Size(300, 17);
            this.progressBarr.Visible = false;
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(111)))), ((int)(((byte)(156)))));
            this.panelContent.Controls.Add(this.panelCommands);
            this.panelContent.Controls.Add(this.label2);
            this.panelContent.Controls.Add(this.label1);
            this.panelContent.Controls.Add(this.dgvRotasRefatoradas);
            this.panelContent.Controls.Add(this.dgvRotasAntuais);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(598, 539);
            this.panelContent.TabIndex = 1;
            // 
            // dgvRotasAntuais
            // 
            this.dgvRotasAntuais.AllowUserToAddRows = false;
            this.dgvRotasAntuais.AllowUserToDeleteRows = false;
            this.dgvRotasAntuais.AllowUserToResizeRows = false;
            this.dgvRotasAntuais.BackgroundColor = System.Drawing.Color.White;
            this.dgvRotasAntuais.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRotasAntuais.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRotasAntuais.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvRotasAntuais.Location = new System.Drawing.Point(9, 28);
            this.dgvRotasAntuais.Name = "dgvRotasAntuais";
            this.dgvRotasAntuais.ReadOnly = true;
            this.dgvRotasAntuais.RowHeadersVisible = false;
            this.dgvRotasAntuais.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvRotasAntuais.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRotasAntuais.ShowEditingIcon = false;
            this.dgvRotasAntuais.Size = new System.Drawing.Size(580, 199);
            this.dgvRotasAntuais.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Rotas Atuais:";
            // 
            // dgvRotasRefatoradas
            // 
            this.dgvRotasRefatoradas.BackgroundColor = System.Drawing.Color.White;
            this.dgvRotasRefatoradas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRotasRefatoradas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRotasRefatoradas.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvRotasRefatoradas.Location = new System.Drawing.Point(9, 277);
            this.dgvRotasRefatoradas.Name = "dgvRotasRefatoradas";
            this.dgvRotasRefatoradas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvRotasRefatoradas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRotasRefatoradas.ShowEditingIcon = false;
            this.dgvRotasRefatoradas.Size = new System.Drawing.Size(580, 197);
            this.dgvRotasRefatoradas.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Rotas Refatoradas:";
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirm.Location = new System.Drawing.Point(388, 3);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(83, 29);
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.Tag = "Pedidos";
            this.btnConfirm.Text = "Confirmar";
            this.btnConfirm.UseVisualStyleBackColor = false;
            // 
            // btnRefact
            // 
            this.btnRefact.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnRefact.FlatAppearance.BorderSize = 0;
            this.btnRefact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefact.ForeColor = System.Drawing.Color.White;
            this.btnRefact.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefact.Location = new System.Drawing.Point(299, 3);
            this.btnRefact.Name = "btnRefact";
            this.btnRefact.Size = new System.Drawing.Size(83, 29);
            this.btnRefact.TabIndex = 3;
            this.btnRefact.Tag = "Pedidos";
            this.btnRefact.Text = "Refatorar";
            this.btnRefact.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(506, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 29);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Tag = "Pedidos";
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panelCommands
            // 
            this.panelCommands.BackColor = System.Drawing.SystemColors.Control;
            this.panelCommands.Controls.Add(this.btnCancel);
            this.panelCommands.Controls.Add(this.btnRefact);
            this.panelCommands.Controls.Add(this.btnConfirm);
            this.panelCommands.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCommands.Location = new System.Drawing.Point(0, 504);
            this.panelCommands.Name = "panelCommands";
            this.panelCommands.Size = new System.Drawing.Size(598, 35);
            this.panelCommands.TabIndex = 4;
            // 
            // RefatoraRotasFormList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 561);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.statusStrip);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RefatoraRotasFormList";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Refatorando Rotas";
            this.Load += new System.EventHandler(this.RefatoraRotasFormList_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRotasAntuais)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRotasRefatoradas)).EndInit();
            this.panelCommands.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar progressBarr;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvRotasRefatoradas;
        private System.Windows.Forms.DataGridView dgvRotasAntuais;
        private System.Windows.Forms.Button btnRefact;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelCommands;
    }
}