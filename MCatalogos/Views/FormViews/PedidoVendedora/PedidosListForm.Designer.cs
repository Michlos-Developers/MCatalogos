
namespace MCatalogos.Views.FormViews.PedidoVendedora
{
    partial class PedidosListForm
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
            this.panelCommands = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.dgvPedidos = new System.Windows.Forms.DataGridView();
            this.panelCatalogo = new System.Windows.Forms.GroupBox();
            this.chkEnviados = new System.Windows.Forms.CheckBox();
            this.chkSeparados = new System.Windows.Forms.CheckBox();
            this.dateDataFim = new System.Windows.Forms.DateTimePicker();
            this.dateDataInicio = new System.Windows.Forms.DateTimePicker();
            this.chkConferidos = new System.Windows.Forms.CheckBox();
            this.chkCancelados = new System.Windows.Forms.CheckBox();
            this.chkEntregues = new System.Windows.Forms.CheckBox();
            this.chkDespachados = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btlClearFilter = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.mTextCpf = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbNomeVendedora = new System.Windows.Forms.ComboBox();
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureClose)).BeginInit();
            this.panelCommands.SuspendLayout();
            this.panelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
            this.panelCatalogo.SuspendLayout();
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
            this.title.ForeColor = System.Drawing.Color.Black;
            this.title.Location = new System.Drawing.Point(10, 8);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(97, 14);
            this.title.TabIndex = 0;
            this.title.Text = "Lista de Pedidos";
            // 
            // panelCommands
            // 
            this.panelCommands.Controls.Add(this.btnAdd);
            this.panelCommands.Controls.Add(this.btnEdit);
            this.panelCommands.Controls.Add(this.btnDelete);
            this.panelCommands.Controls.Add(this.btnCancel);
            this.panelCommands.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCommands.Location = new System.Drawing.Point(0, 440);
            this.panelCommands.Name = "panelCommands";
            this.panelCommands.Size = new System.Drawing.Size(800, 45);
            this.panelCommands.TabIndex = 8;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Image = global::MCatalogos.Properties.Resources.IconAddPedido;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(385, 9);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(91, 27);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Tag = "Pedidos";
            this.btnAdd.Text = "Adicionar";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Image = global::MCatalogos.Properties.Resources.IconEditPedido;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(482, 9);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(91, 27);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Tag = "Pedidos";
            this.btnEdit.Text = "Editar";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Image = global::MCatalogos.Properties.Resources.IconDelete20x20;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(579, 9);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(91, 27);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Tag = "";
            this.btnDelete.Text = "Deletar";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = false;
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
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.pictureClose_Click);
            // 
            // panelContainer
            // 
            this.panelContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(111)))), ((int)(((byte)(156)))));
            this.panelContainer.Controls.Add(this.dgvPedidos);
            this.panelContainer.Controls.Add(this.panelCatalogo);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 30);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(800, 410);
            this.panelContainer.TabIndex = 9;
            // 
            // dgvPedidos
            // 
            this.dgvPedidos.AllowUserToAddRows = false;
            this.dgvPedidos.AllowUserToDeleteRows = false;
            this.dgvPedidos.AllowUserToOrderColumns = true;
            this.dgvPedidos.BackgroundColor = System.Drawing.Color.White;
            this.dgvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidos.GridColor = System.Drawing.Color.DeepSkyBlue;
            this.dgvPedidos.Location = new System.Drawing.Point(5, 115);
            this.dgvPedidos.Name = "dgvPedidos";
            this.dgvPedidos.ReadOnly = true;
            this.dgvPedidos.Size = new System.Drawing.Size(790, 289);
            this.dgvPedidos.TabIndex = 4;
            // 
            // panelCatalogo
            // 
            this.panelCatalogo.Controls.Add(this.chkEnviados);
            this.panelCatalogo.Controls.Add(this.chkSeparados);
            this.panelCatalogo.Controls.Add(this.dateDataFim);
            this.panelCatalogo.Controls.Add(this.dateDataInicio);
            this.panelCatalogo.Controls.Add(this.chkConferidos);
            this.panelCatalogo.Controls.Add(this.chkCancelados);
            this.panelCatalogo.Controls.Add(this.chkEntregues);
            this.panelCatalogo.Controls.Add(this.chkDespachados);
            this.panelCatalogo.Controls.Add(this.label5);
            this.panelCatalogo.Controls.Add(this.btnFiltrar);
            this.panelCatalogo.Controls.Add(this.btlClearFilter);
            this.panelCatalogo.Controls.Add(this.label4);
            this.panelCatalogo.Controls.Add(this.mTextCpf);
            this.panelCatalogo.Controls.Add(this.label3);
            this.panelCatalogo.Controls.Add(this.cbNomeVendedora);
            this.panelCatalogo.Location = new System.Drawing.Point(5, 1);
            this.panelCatalogo.Name = "panelCatalogo";
            this.panelCatalogo.Size = new System.Drawing.Size(790, 107);
            this.panelCatalogo.TabIndex = 3;
            this.panelCatalogo.TabStop = false;
            // 
            // chkEnviados
            // 
            this.chkEnviados.AutoSize = true;
            this.chkEnviados.Location = new System.Drawing.Point(15, 81);
            this.chkEnviados.Name = "chkEnviados";
            this.chkEnviados.Size = new System.Drawing.Size(75, 18);
            this.chkEnviados.TabIndex = 7;
            this.chkEnviados.Text = "Enviados";
            this.chkEnviados.UseVisualStyleBackColor = true;
            // 
            // chkSeparados
            // 
            this.chkSeparados.AutoSize = true;
            this.chkSeparados.Location = new System.Drawing.Point(97, 81);
            this.chkSeparados.Name = "chkSeparados";
            this.chkSeparados.Size = new System.Drawing.Size(84, 18);
            this.chkSeparados.TabIndex = 7;
            this.chkSeparados.Text = "Separados";
            this.chkSeparados.UseVisualStyleBackColor = true;
            // 
            // dateDataFim
            // 
            this.dateDataFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDataFim.Location = new System.Drawing.Point(684, 16);
            this.dateDataFim.Name = "dateDataFim";
            this.dateDataFim.Size = new System.Drawing.Size(98, 22);
            this.dateDataFim.TabIndex = 6;
            this.dateDataFim.Value = new System.DateTime(2021, 7, 1, 22, 0, 32, 0);
            // 
            // dateDataInicio
            // 
            this.dateDataInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDataInicio.Location = new System.Drawing.Point(567, 16);
            this.dateDataInicio.Name = "dateDataInicio";
            this.dateDataInicio.Size = new System.Drawing.Size(98, 22);
            this.dateDataInicio.TabIndex = 6;
            this.dateDataInicio.Value = new System.DateTime(2021, 7, 1, 22, 0, 27, 0);
            // 
            // chkConferidos
            // 
            this.chkConferidos.AutoSize = true;
            this.chkConferidos.Location = new System.Drawing.Point(188, 81);
            this.chkConferidos.Name = "chkConferidos";
            this.chkConferidos.Size = new System.Drawing.Size(85, 18);
            this.chkConferidos.TabIndex = 7;
            this.chkConferidos.Text = "Conferidos";
            this.chkConferidos.UseVisualStyleBackColor = true;
            // 
            // chkCancelados
            // 
            this.chkCancelados.AutoSize = true;
            this.chkCancelados.Location = new System.Drawing.Point(474, 81);
            this.chkCancelados.Name = "chkCancelados";
            this.chkCancelados.Size = new System.Drawing.Size(122, 18);
            this.chkCancelados.TabIndex = 7;
            this.chkCancelados.Text = "Exibir Cancelados";
            this.chkCancelados.UseVisualStyleBackColor = true;
            // 
            // chkEntregues
            // 
            this.chkEntregues.AutoSize = true;
            this.chkEntregues.Location = new System.Drawing.Point(387, 81);
            this.chkEntregues.Name = "chkEntregues";
            this.chkEntregues.Size = new System.Drawing.Size(80, 18);
            this.chkEntregues.TabIndex = 7;
            this.chkEntregues.Text = "Entregues";
            this.chkEntregues.UseVisualStyleBackColor = true;
            // 
            // chkDespachados
            // 
            this.chkDespachados.AutoSize = true;
            this.chkDespachados.Location = new System.Drawing.Point(280, 81);
            this.chkDespachados.Name = "chkDespachados";
            this.chkDespachados.Size = new System.Drawing.Size(100, 18);
            this.chkDespachados.TabIndex = 7;
            this.chkDespachados.Text = "Despachados";
            this.chkDespachados.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(459, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 14);
            this.label5.TabIndex = 5;
            this.label5.Text = "Data de Registro:";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFiltrar.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnFiltrar.FlatAppearance.BorderSize = 0;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.Image = global::MCatalogos.Properties.Resources.IconFilter20x20;
            this.btnFiltrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFiltrar.Location = new System.Drawing.Point(636, 72);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(71, 27);
            this.btnFiltrar.TabIndex = 2;
            this.btnFiltrar.Tag = "Pedidos";
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFiltrar.UseVisualStyleBackColor = false;
            // 
            // btlClearFilter
            // 
            this.btlClearFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btlClearFilter.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btlClearFilter.FlatAppearance.BorderSize = 0;
            this.btlClearFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btlClearFilter.ForeColor = System.Drawing.Color.White;
            this.btlClearFilter.Image = global::MCatalogos.Properties.Resources.IconClear;
            this.btlClearFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btlClearFilter.Location = new System.Drawing.Point(713, 72);
            this.btlClearFilter.Name = "btlClearFilter";
            this.btlClearFilter.Size = new System.Drawing.Size(71, 27);
            this.btlClearFilter.TabIndex = 2;
            this.btlClearFilter.Tag = "Pedidos";
            this.btlClearFilter.Text = "Limpar";
            this.btlClearFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btlClearFilter.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 14);
            this.label4.TabIndex = 4;
            this.label4.Text = "Nome Vendedora:";
            // 
            // mTextCpf
            // 
            this.mTextCpf.Location = new System.Drawing.Point(117, 16);
            this.mTextCpf.Mask = "000,000,000-99";
            this.mTextCpf.Name = "mTextCpf";
            this.mTextCpf.Size = new System.Drawing.Size(92, 22);
            this.mTextCpf.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "CPF Vendedora:";
            // 
            // cbNomeVendedora
            // 
            this.cbNomeVendedora.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbNomeVendedora.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbNomeVendedora.FormattingEnabled = true;
            this.cbNomeVendedora.Location = new System.Drawing.Point(117, 44);
            this.cbNomeVendedora.Name = "cbNomeVendedora";
            this.cbNomeVendedora.Size = new System.Drawing.Size(219, 22);
            this.cbNomeVendedora.TabIndex = 0;
            // 
            // PedidosListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 485);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelCommands);
            this.Controls.Add(this.panelTitle);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PedidosListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PedidosListForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PedidosListForm_FormClosing);
            this.Load += new System.EventHandler(this.PedidosListForm_Load);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureClose)).EndInit();
            this.panelCommands.ResumeLayout(false);
            this.panelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).EndInit();
            this.panelCatalogo.ResumeLayout(false);
            this.panelCatalogo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.PictureBox pictureClose;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Panel panelCommands;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.GroupBox panelCatalogo;
        private System.Windows.Forms.Button btlClearFilter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox mTextCpf;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbNomeVendedora;
        private System.Windows.Forms.DataGridView dgvPedidos;
        private System.Windows.Forms.CheckBox chkEnviados;
        private System.Windows.Forms.CheckBox chkSeparados;
        private System.Windows.Forms.DateTimePicker dateDataFim;
        private System.Windows.Forms.DateTimePicker dateDataInicio;
        private System.Windows.Forms.CheckBox chkConferidos;
        private System.Windows.Forms.CheckBox chkCancelados;
        private System.Windows.Forms.CheckBox chkEntregues;
        private System.Windows.Forms.CheckBox chkDespachados;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnFiltrar;
    }
}