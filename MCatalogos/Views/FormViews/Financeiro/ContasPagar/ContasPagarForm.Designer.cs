
namespace MCatalogos.Views.FormViews.Financeiro.ContasPagar
{
    partial class ContasPagarForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContasPagarForm));
            this.panelCommands = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnGerar = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnPagar = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelDGV = new System.Windows.Forms.Panel();
            this.dgvContasPagar = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbLiquidado = new System.Windows.Forms.RadioButton();
            this.rbVencido = new System.Windows.Forms.RadioButton();
            this.rbAberto = new System.Windows.Forms.RadioButton();
            this.textTotalVencidos = new System.Windows.Forms.TextBox();
            this.textTotalPagoMes = new System.Windows.Forms.TextBox();
            this.textTotalAberto = new System.Windows.Forms.TextBox();
            this.textAprovisionado = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textValorCaixa = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbMesComercial = new System.Windows.Forms.ComboBox();
            this.panelCommands.SuspendLayout();
            this.panelContainer.SuspendLayout();
            this.panelDGV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContasPagar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCommands
            // 
            this.panelCommands.BackColor = System.Drawing.SystemColors.Control;
            this.panelCommands.Controls.Add(this.btnAdd);
            this.panelCommands.Controls.Add(this.btnGerar);
            this.panelCommands.Controls.Add(this.btnEdit);
            this.panelCommands.Controls.Add(this.btnDelete);
            this.panelCommands.Controls.Add(this.btnCancelar);
            this.panelCommands.Controls.Add(this.btnPagar);
            this.panelCommands.Controls.Add(this.btnCancel);
            this.panelCommands.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCommands.Location = new System.Drawing.Point(0, 474);
            this.panelCommands.Name = "panelCommands";
            this.panelCommands.Size = new System.Drawing.Size(933, 45);
            this.panelCommands.TabIndex = 12;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(106, 9);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(91, 27);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Tag = "";
            this.btnAdd.Text = "Adicionar";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnGerar
            // 
            this.btnGerar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnGerar.FlatAppearance.BorderSize = 0;
            this.btnGerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGerar.ForeColor = System.Drawing.Color.White;
            this.btnGerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGerar.Location = new System.Drawing.Point(9, 9);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(91, 27);
            this.btnGerar.TabIndex = 2;
            this.btnGerar.Tag = "";
            this.btnGerar.Text = "Gerar";
            this.btnGerar.UseVisualStyleBackColor = false;
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(203, 9);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(91, 27);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Tag = "";
            this.btnEdit.Text = "Editar";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(539, 9);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(91, 27);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Tag = "";
            this.btnDelete.Text = "Apagar";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(442, 9);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(91, 27);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Tag = "";
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnPagar
            // 
            this.btnPagar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPagar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnPagar.FlatAppearance.BorderSize = 0;
            this.btnPagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagar.ForeColor = System.Drawing.Color.White;
            this.btnPagar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPagar.Location = new System.Drawing.Point(345, 9);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(91, 27);
            this.btnPagar.TabIndex = 2;
            this.btnPagar.Tag = "";
            this.btnPagar.Text = "Pagar";
            this.btnPagar.UseVisualStyleBackColor = false;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(830, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 27);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Tag = "";
            this.btnCancel.Text = "Fechar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panelContainer
            // 
            this.panelContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(111)))), ((int)(((byte)(156)))));
            this.panelContainer.Controls.Add(this.panelDGV);
            this.panelContainer.Controls.Add(this.groupBox1);
            this.panelContainer.Controls.Add(this.textTotalVencidos);
            this.panelContainer.Controls.Add(this.textTotalPagoMes);
            this.panelContainer.Controls.Add(this.textTotalAberto);
            this.panelContainer.Controls.Add(this.textAprovisionado);
            this.panelContainer.Controls.Add(this.label3);
            this.panelContainer.Controls.Add(this.label6);
            this.panelContainer.Controls.Add(this.textValorCaixa);
            this.panelContainer.Controls.Add(this.label5);
            this.panelContainer.Controls.Add(this.label2);
            this.panelContainer.Controls.Add(this.label4);
            this.panelContainer.Controls.Add(this.label1);
            this.panelContainer.Controls.Add(this.cbMesComercial);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(933, 474);
            this.panelContainer.TabIndex = 13;
            // 
            // panelDGV
            // 
            this.panelDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDGV.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelDGV.Controls.Add(this.dgvContasPagar);
            this.panelDGV.Location = new System.Drawing.Point(12, 115);
            this.panelDGV.Name = "panelDGV";
            this.panelDGV.Size = new System.Drawing.Size(909, 346);
            this.panelDGV.TabIndex = 5;
            // 
            // dgvContasPagar
            // 
            this.dgvContasPagar.AllowUserToAddRows = false;
            this.dgvContasPagar.AllowUserToDeleteRows = false;
            this.dgvContasPagar.BackgroundColor = System.Drawing.Color.White;
            this.dgvContasPagar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContasPagar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvContasPagar.GridColor = System.Drawing.Color.DeepSkyBlue;
            this.dgvContasPagar.Location = new System.Drawing.Point(0, 0);
            this.dgvContasPagar.Name = "dgvContasPagar";
            this.dgvContasPagar.ReadOnly = true;
            this.dgvContasPagar.RowHeadersVisible = false;
            this.dgvContasPagar.Size = new System.Drawing.Size(909, 346);
            this.dgvContasPagar.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rbLiquidado);
            this.groupBox1.Controls.Add(this.rbVencido);
            this.groupBox1.Controls.Add(this.rbAberto);
            this.groupBox1.Location = new System.Drawing.Point(564, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(357, 37);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // rbLiquidado
            // 
            this.rbLiquidado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbLiquidado.AutoSize = true;
            this.rbLiquidado.Location = new System.Drawing.Point(256, 12);
            this.rbLiquidado.Name = "rbLiquidado";
            this.rbLiquidado.Size = new System.Drawing.Size(86, 19);
            this.rbLiquidado.TabIndex = 0;
            this.rbLiquidado.TabStop = true;
            this.rbLiquidado.Text = "Liquidados";
            this.rbLiquidado.UseVisualStyleBackColor = true;
            this.rbLiquidado.CheckedChanged += new System.EventHandler(this.rbLiquidado_CheckedChanged);
            // 
            // rbVencido
            // 
            this.rbVencido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbVencido.AutoSize = true;
            this.rbVencido.Location = new System.Drawing.Point(136, 12);
            this.rbVencido.Name = "rbVencido";
            this.rbVencido.Size = new System.Drawing.Size(74, 19);
            this.rbVencido.TabIndex = 0;
            this.rbVencido.TabStop = true;
            this.rbVencido.Text = "Vencidos";
            this.rbVencido.UseVisualStyleBackColor = true;
            this.rbVencido.CheckedChanged += new System.EventHandler(this.rbVencido_CheckedChanged);
            // 
            // rbAberto
            // 
            this.rbAberto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbAberto.AutoSize = true;
            this.rbAberto.Location = new System.Drawing.Point(16, 12);
            this.rbAberto.Name = "rbAberto";
            this.rbAberto.Size = new System.Drawing.Size(80, 19);
            this.rbAberto.TabIndex = 0;
            this.rbAberto.TabStop = true;
            this.rbAberto.Text = "Em Aberto";
            this.rbAberto.UseVisualStyleBackColor = true;
            this.rbAberto.CheckedChanged += new System.EventHandler(this.rbAberto_CheckedChanged);
            // 
            // textTotalVencidos
            // 
            this.textTotalVencidos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textTotalVencidos.BackColor = System.Drawing.Color.Red;
            this.textTotalVencidos.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTotalVencidos.ForeColor = System.Drawing.Color.Black;
            this.textTotalVencidos.Location = new System.Drawing.Point(738, 26);
            this.textTotalVencidos.Name = "textTotalVencidos";
            this.textTotalVencidos.Size = new System.Drawing.Size(183, 40);
            this.textTotalVencidos.TabIndex = 3;
            this.textTotalVencidos.TabStop = false;
            this.textTotalVencidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textTotalPagoMes
            // 
            this.textTotalPagoMes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textTotalPagoMes.BackColor = System.Drawing.Color.MediumOrchid;
            this.textTotalPagoMes.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTotalPagoMes.ForeColor = System.Drawing.Color.Black;
            this.textTotalPagoMes.Location = new System.Drawing.Point(549, 26);
            this.textTotalPagoMes.Name = "textTotalPagoMes";
            this.textTotalPagoMes.Size = new System.Drawing.Size(183, 40);
            this.textTotalPagoMes.TabIndex = 3;
            this.textTotalPagoMes.TabStop = false;
            this.textTotalPagoMes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textTotalAberto
            // 
            this.textTotalAberto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textTotalAberto.BackColor = System.Drawing.Color.RoyalBlue;
            this.textTotalAberto.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTotalAberto.ForeColor = System.Drawing.Color.Black;
            this.textTotalAberto.Location = new System.Drawing.Point(360, 26);
            this.textTotalAberto.Name = "textTotalAberto";
            this.textTotalAberto.Size = new System.Drawing.Size(183, 40);
            this.textTotalAberto.TabIndex = 3;
            this.textTotalAberto.TabStop = false;
            this.textTotalAberto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textAprovisionado
            // 
            this.textAprovisionado.BackColor = System.Drawing.Color.LimeGreen;
            this.textAprovisionado.Location = new System.Drawing.Point(127, 74);
            this.textAprovisionado.Name = "textAprovisionado";
            this.textAprovisionado.Size = new System.Drawing.Size(100, 23);
            this.textAprovisionado.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(127, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Aprovisionado:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(738, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "Total Títulos Vencidos:";
            // 
            // textValorCaixa
            // 
            this.textValorCaixa.BackColor = System.Drawing.Color.Gold;
            this.textValorCaixa.Location = new System.Drawing.Point(12, 74);
            this.textValorCaixa.Name = "textValorCaixa";
            this.textValorCaixa.Size = new System.Drawing.Size(100, 23);
            this.textValorCaixa.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(549, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Total Pago no Mês:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Caixa:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(360, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Total em Aberto:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mês Corrente:";
            // 
            // cbMesComercial
            // 
            this.cbMesComercial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbMesComercial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbMesComercial.FormattingEnabled = true;
            this.cbMesComercial.Location = new System.Drawing.Point(12, 26);
            this.cbMesComercial.Name = "cbMesComercial";
            this.cbMesComercial.Size = new System.Drawing.Size(121, 23);
            this.cbMesComercial.TabIndex = 0;
            this.cbMesComercial.SelectedIndexChanged += new System.EventHandler(this.cbMesComercial_SelectedIndexChanged);
            // 
            // ContasPagarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelCommands);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ContasPagarForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controle de Contas a Pagar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ContasPagarForm_FormClosing);
            this.Load += new System.EventHandler(this.ContasPagarForm_Load);
            this.panelCommands.ResumeLayout(false);
            this.panelContainer.ResumeLayout(false);
            this.panelContainer.PerformLayout();
            this.panelDGV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContasPagar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCommands;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnGerar;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.ComboBox cbMesComercial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textValorCaixa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textAprovisionado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textTotalAberto;
        private System.Windows.Forms.Panel panelDGV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbLiquidado;
        private System.Windows.Forms.RadioButton rbVencido;
        private System.Windows.Forms.RadioButton rbAberto;
        private System.Windows.Forms.TextBox textTotalVencidos;
        private System.Windows.Forms.TextBox textTotalPagoMes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvContasPagar;
    }
}