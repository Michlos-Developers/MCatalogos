
namespace MCatalogos.Views.FormViews.Configuracoes
{
    partial class ConfiguracoesForm
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
            this.panelTitle = new System.Windows.Forms.Panel();
            this.pictureClose = new System.Windows.Forms.PictureBox();
            this.title = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelContentCadastros = new System.Windows.Forms.Panel();
            this.btnDadosDistribuidor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupTarefas = new System.Windows.Forms.GroupBox();
            this.panelContentTarefas = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelCommands = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureClose)).BeginInit();
            this.panelContent.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelContentCadastros.SuspendLayout();
            this.groupTarefas.SuspendLayout();
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
            this.panelTitle.Size = new System.Drawing.Size(221, 32);
            this.panelTitle.TabIndex = 39;
            this.panelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitle_MouseDown);
            // 
            // pictureClose
            // 
            this.pictureClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureClose.Image = global::MCatalogos.Properties.Resources.IconClose20x20;
            this.pictureClose.Location = new System.Drawing.Point(198, 8);
            this.pictureClose.Name = "pictureClose";
            this.pictureClose.Size = new System.Drawing.Size(15, 16);
            this.pictureClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureClose.TabIndex = 1;
            this.pictureClose.TabStop = false;
            this.pictureClose.Click += new System.EventHandler(this.pictureClose_Click);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.ForeColor = System.Drawing.SystemColors.ControlText;
            this.title.Location = new System.Drawing.Point(10, 9);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(146, 14);
            this.title.TabIndex = 0;
            this.title.Text = "Configurações do Sistema";
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(111)))), ((int)(((byte)(156)))));
            this.panelContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelContent.Controls.Add(this.groupBox1);
            this.panelContent.Controls.Add(this.groupTarefas);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 32);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(221, 453);
            this.panelContent.TabIndex = 40;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panelContentCadastros);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(13, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(182, 396);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // panelContentCadastros
            // 
            this.panelContentCadastros.BackColor = System.Drawing.SystemColors.Control;
            this.panelContentCadastros.Controls.Add(this.btnDadosDistribuidor);
            this.panelContentCadastros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContentCadastros.Location = new System.Drawing.Point(3, 18);
            this.panelContentCadastros.Name = "panelContentCadastros";
            this.panelContentCadastros.Size = new System.Drawing.Size(176, 375);
            this.panelContentCadastros.TabIndex = 5;
            // 
            // btnDadosDistribuidor
            // 
            this.btnDadosDistribuidor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnDadosDistribuidor.FlatAppearance.BorderSize = 0;
            this.btnDadosDistribuidor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDadosDistribuidor.ForeColor = System.Drawing.Color.White;
            this.btnDadosDistribuidor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDadosDistribuidor.Location = new System.Drawing.Point(6, 6);
            this.btnDadosDistribuidor.Name = "btnDadosDistribuidor";
            this.btnDadosDistribuidor.Size = new System.Drawing.Size(164, 47);
            this.btnDadosDistribuidor.TabIndex = 2;
            this.btnDadosDistribuidor.Tag = "Pedidos";
            this.btnDadosDistribuidor.Text = "Dados do Distribuidor";
            this.btnDadosDistribuidor.UseVisualStyleBackColor = false;
            this.btnDadosDistribuidor.Click += new System.EventHandler(this.btnDadosDistribuidor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "Cadastros:";
            // 
            // groupTarefas
            // 
            this.groupTarefas.Controls.Add(this.panelContentTarefas);
            this.groupTarefas.Controls.Add(this.label1);
            this.groupTarefas.Location = new System.Drawing.Point(581, 6);
            this.groupTarefas.Name = "groupTarefas";
            this.groupTarefas.Size = new System.Drawing.Size(182, 393);
            this.groupTarefas.TabIndex = 3;
            this.groupTarefas.TabStop = false;
            // 
            // panelContentTarefas
            // 
            this.panelContentTarefas.BackColor = System.Drawing.SystemColors.Control;
            this.panelContentTarefas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContentTarefas.Location = new System.Drawing.Point(3, 18);
            this.panelContentTarefas.Name = "panelContentTarefas";
            this.panelContentTarefas.Size = new System.Drawing.Size(176, 372);
            this.panelContentTarefas.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tarefas:";
            // 
            // panelCommands
            // 
            this.panelCommands.Controls.Add(this.btnCancel);
            this.panelCommands.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCommands.ForeColor = System.Drawing.SystemColors.Control;
            this.panelCommands.Location = new System.Drawing.Point(0, 440);
            this.panelCommands.Name = "panelCommands";
            this.panelCommands.Size = new System.Drawing.Size(221, 45);
            this.panelCommands.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(119, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 27);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Tag = "Pedidos";
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.pictureClose_Click);
            // 
            // ConfiguracoesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 485);
            this.Controls.Add(this.panelCommands);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelTitle);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConfiguracoesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfiguracoesForm_FormClosing);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureClose)).EndInit();
            this.panelContent.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelContentCadastros.ResumeLayout(false);
            this.groupTarefas.ResumeLayout(false);
            this.groupTarefas.PerformLayout();
            this.panelCommands.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.PictureBox pictureClose;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.GroupBox groupTarefas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDadosDistribuidor;
        private System.Windows.Forms.Panel panelContentCadastros;
        private System.Windows.Forms.Panel panelContentTarefas;
        private System.Windows.Forms.Panel panelCommands;
        private System.Windows.Forms.Button btnCancel;
    }
}