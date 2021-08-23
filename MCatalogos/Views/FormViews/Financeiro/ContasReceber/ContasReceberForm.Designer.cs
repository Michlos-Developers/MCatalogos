
namespace MCatalogos.Views.FormViews.Financeiro.ContasReceber
{
    partial class ContasReceberForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContasReceberForm));
            this.panelCommands = new System.Windows.Forms.Panel();
            this.btnProtestar = new System.Windows.Forms.Button();
            this.btnReceber = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbMes = new System.Windows.Forms.ComboBox();
            this.textTotalAberto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textTotalVencido = new System.Windows.Forms.TextBox();
            this.gbFiltros = new System.Windows.Forms.GroupBox();
            this.mTextCpf = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.pnlDGV = new System.Windows.Forms.Panel();
            this.dgvTitulosReceber = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbLiquidado = new System.Windows.Forms.RadioButton();
            this.rbVencido = new System.Windows.Forms.RadioButton();
            this.rbAberto = new System.Windows.Forms.RadioButton();
            this.rbProtestado = new System.Windows.Forms.RadioButton();
            this.panelCommands.SuspendLayout();
            this.panelContainer.SuspendLayout();
            this.gbFiltros.SuspendLayout();
            this.pnlDGV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTitulosReceber)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCommands
            // 
            this.panelCommands.BackColor = System.Drawing.SystemColors.Control;
            this.panelCommands.Controls.Add(this.btnProtestar);
            this.panelCommands.Controls.Add(this.btnReceber);
            this.panelCommands.Controls.Add(this.btnCancelar);
            this.panelCommands.Controls.Add(this.btnFechar);
            this.panelCommands.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCommands.Location = new System.Drawing.Point(0, 474);
            this.panelCommands.Name = "panelCommands";
            this.panelCommands.Size = new System.Drawing.Size(933, 45);
            this.panelCommands.TabIndex = 13;
            // 
            // btnProtestar
            // 
            this.btnProtestar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnProtestar.FlatAppearance.BorderSize = 0;
            this.btnProtestar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProtestar.ForeColor = System.Drawing.Color.White;
            this.btnProtestar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProtestar.Location = new System.Drawing.Point(106, 9);
            this.btnProtestar.Name = "btnProtestar";
            this.btnProtestar.Size = new System.Drawing.Size(91, 27);
            this.btnProtestar.TabIndex = 2;
            this.btnProtestar.Tag = "";
            this.btnProtestar.Text = "Protestar";
            this.btnProtestar.UseVisualStyleBackColor = false;
            // 
            // btnReceber
            // 
            this.btnReceber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnReceber.FlatAppearance.BorderSize = 0;
            this.btnReceber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceber.ForeColor = System.Drawing.Color.White;
            this.btnReceber.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReceber.Location = new System.Drawing.Point(9, 9);
            this.btnReceber.Name = "btnReceber";
            this.btnReceber.Size = new System.Drawing.Size(91, 27);
            this.btnReceber.TabIndex = 2;
            this.btnReceber.Tag = "";
            this.btnReceber.Text = "Receber";
            this.btnReceber.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(203, 9);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(91, 27);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Tag = "";
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnFechar.FlatAppearance.BorderSize = 0;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFechar.Location = new System.Drawing.Point(830, 9);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(91, 27);
            this.btnFechar.TabIndex = 2;
            this.btnFechar.Tag = "";
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = false;
            // 
            // panelContainer
            // 
            this.panelContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(111)))), ((int)(((byte)(156)))));
            this.panelContainer.Controls.Add(this.groupBox1);
            this.panelContainer.Controls.Add(this.pnlDGV);
            this.panelContainer.Controls.Add(this.gbFiltros);
            this.panelContainer.Controls.Add(this.textTotalVencido);
            this.panelContainer.Controls.Add(this.label3);
            this.panelContainer.Controls.Add(this.textTotalAberto);
            this.panelContainer.Controls.Add(this.label4);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(933, 474);
            this.panelContainer.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mês:";
            // 
            // cbMes
            // 
            this.cbMes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbMes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbMes.FormattingEnabled = true;
            this.cbMes.Location = new System.Drawing.Point(11, 33);
            this.cbMes.Name = "cbMes";
            this.cbMes.Size = new System.Drawing.Size(121, 23);
            this.cbMes.TabIndex = 2;
            // 
            // textTotalAberto
            // 
            this.textTotalAberto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textTotalAberto.BackColor = System.Drawing.Color.Gold;
            this.textTotalAberto.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTotalAberto.ForeColor = System.Drawing.Color.Black;
            this.textTotalAberto.Location = new System.Drawing.Point(738, 28);
            this.textTotalAberto.Name = "textTotalAberto";
            this.textTotalAberto.ReadOnly = true;
            this.textTotalAberto.Size = new System.Drawing.Size(183, 31);
            this.textTotalAberto.TabIndex = 5;
            this.textTotalAberto.TabStop = false;
            this.textTotalAberto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(738, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Total em Aberto:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(738, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Total Vencido:";
            // 
            // textTotalVencido
            // 
            this.textTotalVencido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textTotalVencido.BackColor = System.Drawing.Color.Tomato;
            this.textTotalVencido.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTotalVencido.ForeColor = System.Drawing.Color.Black;
            this.textTotalVencido.Location = new System.Drawing.Point(738, 87);
            this.textTotalVencido.Name = "textTotalVencido";
            this.textTotalVencido.ReadOnly = true;
            this.textTotalVencido.Size = new System.Drawing.Size(183, 31);
            this.textTotalVencido.TabIndex = 5;
            this.textTotalVencido.TabStop = false;
            this.textTotalVencido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.btnFiltrar);
            this.gbFiltros.Controls.Add(this.btnClearFilter);
            this.gbFiltros.Controls.Add(this.mTextCpf);
            this.gbFiltros.Controls.Add(this.cbMes);
            this.gbFiltros.Controls.Add(this.label5);
            this.gbFiltros.Controls.Add(this.label1);
            this.gbFiltros.Location = new System.Drawing.Point(9, 11);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(342, 107);
            this.gbFiltros.TabIndex = 6;
            this.gbFiltros.TabStop = false;
            // 
            // mTextCpf
            // 
            this.mTextCpf.Location = new System.Drawing.Point(225, 33);
            this.mTextCpf.Mask = "000,000,000-99";
            this.mTextCpf.Name = "mTextCpf";
            this.mTextCpf.Size = new System.Drawing.Size(106, 23);
            this.mTextCpf.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(225, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "CPF:";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnFiltrar.FlatAppearance.BorderSize = 0;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.Image = global::MCatalogos.Properties.Resources.IconFilter20x20;
            this.btnFiltrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFiltrar.Location = new System.Drawing.Point(183, 70);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(71, 27);
            this.btnFiltrar.TabIndex = 5;
            this.btnFiltrar.Tag = "Pedidos";
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFiltrar.UseVisualStyleBackColor = false;
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnClearFilter.FlatAppearance.BorderSize = 0;
            this.btnClearFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearFilter.ForeColor = System.Drawing.Color.White;
            this.btnClearFilter.Image = global::MCatalogos.Properties.Resources.IconClear;
            this.btnClearFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearFilter.Location = new System.Drawing.Point(260, 70);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(71, 27);
            this.btnClearFilter.TabIndex = 6;
            this.btnClearFilter.Tag = "Pedidos";
            this.btnClearFilter.Text = "Limpar";
            this.btnClearFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClearFilter.UseVisualStyleBackColor = false;
            // 
            // pnlDGV
            // 
            this.pnlDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDGV.Controls.Add(this.dgvTitulosReceber);
            this.pnlDGV.Location = new System.Drawing.Point(9, 129);
            this.pnlDGV.Name = "pnlDGV";
            this.pnlDGV.Size = new System.Drawing.Size(916, 334);
            this.pnlDGV.TabIndex = 7;
            // 
            // dgvTitulosReceber
            // 
            this.dgvTitulosReceber.AllowUserToAddRows = false;
            this.dgvTitulosReceber.AllowUserToDeleteRows = false;
            this.dgvTitulosReceber.BackgroundColor = System.Drawing.Color.White;
            this.dgvTitulosReceber.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTitulosReceber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTitulosReceber.Location = new System.Drawing.Point(0, 0);
            this.dgvTitulosReceber.Name = "dgvTitulosReceber";
            this.dgvTitulosReceber.ReadOnly = true;
            this.dgvTitulosReceber.Size = new System.Drawing.Size(916, 334);
            this.dgvTitulosReceber.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbProtestado);
            this.groupBox1.Controls.Add(this.rbLiquidado);
            this.groupBox1.Controls.Add(this.rbVencido);
            this.groupBox1.Controls.Add(this.rbAberto);
            this.groupBox1.Location = new System.Drawing.Point(357, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(114, 106);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // rbLiquidado
            // 
            this.rbLiquidado.AutoSize = true;
            this.rbLiquidado.Location = new System.Drawing.Point(11, 56);
            this.rbLiquidado.Name = "rbLiquidado";
            this.rbLiquidado.Size = new System.Drawing.Size(86, 19);
            this.rbLiquidado.TabIndex = 0;
            this.rbLiquidado.TabStop = true;
            this.rbLiquidado.Text = "Liquidados";
            this.rbLiquidado.UseVisualStyleBackColor = true;
            // 
            // rbVencido
            // 
            this.rbVencido.AutoSize = true;
            this.rbVencido.Location = new System.Drawing.Point(11, 34);
            this.rbVencido.Name = "rbVencido";
            this.rbVencido.Size = new System.Drawing.Size(74, 19);
            this.rbVencido.TabIndex = 0;
            this.rbVencido.TabStop = true;
            this.rbVencido.Text = "Vencidos";
            this.rbVencido.UseVisualStyleBackColor = true;
            // 
            // rbAberto
            // 
            this.rbAberto.AutoSize = true;
            this.rbAberto.Location = new System.Drawing.Point(11, 12);
            this.rbAberto.Name = "rbAberto";
            this.rbAberto.Size = new System.Drawing.Size(80, 19);
            this.rbAberto.TabIndex = 0;
            this.rbAberto.TabStop = true;
            this.rbAberto.Text = "Em Aberto";
            this.rbAberto.UseVisualStyleBackColor = true;
            // 
            // rbProtestado
            // 
            this.rbProtestado.AutoSize = true;
            this.rbProtestado.Location = new System.Drawing.Point(11, 78);
            this.rbProtestado.Name = "rbProtestado";
            this.rbProtestado.Size = new System.Drawing.Size(91, 19);
            this.rbProtestado.TabIndex = 0;
            this.rbProtestado.TabStop = true;
            this.rbProtestado.Text = "Protestados";
            this.rbProtestado.UseVisualStyleBackColor = true;
            // 
            // ContasReceberForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelCommands);
            this.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ContasReceberForm";
            this.Text = "Controle de Títulos a Receber";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ContasReceberForm_FormClosing);
            this.Load += new System.EventHandler(this.ContasReceberForm_Load);
            this.panelCommands.ResumeLayout(false);
            this.panelContainer.ResumeLayout(false);
            this.panelContainer.PerformLayout();
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.pnlDGV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTitulosReceber)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCommands;
        private System.Windows.Forms.Button btnProtestar;
        private System.Windows.Forms.Button btnReceber;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbMes;
        private System.Windows.Forms.GroupBox gbFiltros;
        private System.Windows.Forms.TextBox textTotalVencido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textTotalAberto;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.MaskedTextBox mTextCpf;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.Panel pnlDGV;
        private System.Windows.Forms.DataGridView dgvTitulosReceber;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbLiquidado;
        private System.Windows.Forms.RadioButton rbVencido;
        private System.Windows.Forms.RadioButton rbAberto;
        private System.Windows.Forms.RadioButton rbProtestado;
    }
}