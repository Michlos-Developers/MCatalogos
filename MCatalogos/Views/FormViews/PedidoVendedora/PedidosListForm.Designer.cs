
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
            this.components = new System.ComponentModel.Container();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.pictureClose = new System.Windows.Forms.PictureBox();
            this.title = new System.Windows.Forms.Label();
            this.panelCommands = new System.Windows.Forms.Panel();
            this.btnConferir = new System.Windows.Forms.Button();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.dgvPedidos = new System.Windows.Forms.DataGridView();
            this.panelCatalogo = new System.Windows.Forms.GroupBox();
            this.gbStatus = new System.Windows.Forms.GroupBox();
            this.rbCancelado = new System.Windows.Forms.RadioButton();
            this.rbEntregue = new System.Windows.Forms.RadioButton();
            this.rbDespachado = new System.Windows.Forms.RadioButton();
            this.rbFinalizado = new System.Windows.Forms.RadioButton();
            this.rbConferido = new System.Windows.Forms.RadioButton();
            this.rbSeparado = new System.Windows.Forms.RadioButton();
            this.rbEnviado = new System.Windows.Forms.RadioButton();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.rbAberto = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.dateDataFim = new System.Windows.Forms.MaskedTextBox();
            this.dateDataInicio = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnClearDate = new System.Windows.Forms.Button();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.mTextCpf = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbNomeVendedora = new System.Windows.Forms.ComboBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureClose)).BeginInit();
            this.panelCommands.SuspendLayout();
            this.panelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
            this.panelCatalogo.SuspendLayout();
            this.gbStatus.SuspendLayout();
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
            this.panelCommands.Controls.Add(this.btnConferir);
            this.panelCommands.Controls.Add(this.btnFinalizar);
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
            // btnConferir
            // 
            this.btnConferir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConferir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnConferir.FlatAppearance.BorderSize = 0;
            this.btnConferir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConferir.ForeColor = System.Drawing.Color.White;
            this.btnConferir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConferir.Location = new System.Drawing.Point(11, 9);
            this.btnConferir.Name = "btnConferir";
            this.btnConferir.Size = new System.Drawing.Size(64, 27);
            this.btnConferir.TabIndex = 2;
            this.btnConferir.Tag = "";
            this.btnConferir.Text = "Conferir";
            this.btnConferir.UseVisualStyleBackColor = false;
            this.btnConferir.Click += new System.EventHandler(this.btnConferir_Click);
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnFinalizar.FlatAppearance.BorderSize = 0;
            this.btnFinalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizar.ForeColor = System.Drawing.Color.White;
            this.btnFinalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFinalizar.Location = new System.Drawing.Point(90, 9);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(64, 27);
            this.btnFinalizar.TabIndex = 2;
            this.btnFinalizar.Tag = "";
            this.btnFinalizar.Text = "Finalizar";
            this.btnFinalizar.UseVisualStyleBackColor = false;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
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
            this.btnAdd.Tag = "";
            this.btnAdd.Text = "Adicionar";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            this.btnEdit.Tag = "";
            this.btnEdit.Text = "Editar";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
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
            this.btnCancel.Tag = "";
            this.btnCancel.Text = "Fechar";
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
            this.dgvPedidos.Location = new System.Drawing.Point(5, 125);
            this.dgvPedidos.Name = "dgvPedidos";
            this.dgvPedidos.ReadOnly = true;
            this.dgvPedidos.RowHeadersVisible = false;
            this.dgvPedidos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedidos.Size = new System.Drawing.Size(790, 279);
            this.dgvPedidos.TabIndex = 4;
            this.dgvPedidos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPedidos_CellDoubleClick);
            this.dgvPedidos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPedidos_CellFormatting);
            this.dgvPedidos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvPedidos_KeyDown);
            // 
            // panelCatalogo
            // 
            this.panelCatalogo.Controls.Add(this.gbStatus);
            this.panelCatalogo.Controls.Add(this.dateDataFim);
            this.panelCatalogo.Controls.Add(this.dateDataInicio);
            this.panelCatalogo.Controls.Add(this.label1);
            this.panelCatalogo.Controls.Add(this.label5);
            this.panelCatalogo.Controls.Add(this.btnFiltrar);
            this.panelCatalogo.Controls.Add(this.btnClearDate);
            this.panelCatalogo.Controls.Add(this.btnClearFilter);
            this.panelCatalogo.Controls.Add(this.label4);
            this.panelCatalogo.Controls.Add(this.mTextCpf);
            this.panelCatalogo.Controls.Add(this.label3);
            this.panelCatalogo.Controls.Add(this.cbNomeVendedora);
            this.panelCatalogo.Location = new System.Drawing.Point(5, 1);
            this.panelCatalogo.Name = "panelCatalogo";
            this.panelCatalogo.Size = new System.Drawing.Size(790, 118);
            this.panelCatalogo.TabIndex = 3;
            this.panelCatalogo.TabStop = false;
            // 
            // gbStatus
            // 
            this.gbStatus.Controls.Add(this.rbCancelado);
            this.gbStatus.Controls.Add(this.rbEntregue);
            this.gbStatus.Controls.Add(this.rbDespachado);
            this.gbStatus.Controls.Add(this.rbFinalizado);
            this.gbStatus.Controls.Add(this.rbConferido);
            this.gbStatus.Controls.Add(this.rbSeparado);
            this.gbStatus.Controls.Add(this.rbEnviado);
            this.gbStatus.Controls.Add(this.rbTodos);
            this.gbStatus.Controls.Add(this.rbAberto);
            this.gbStatus.Controls.Add(this.label2);
            this.gbStatus.Location = new System.Drawing.Point(10, 64);
            this.gbStatus.Name = "gbStatus";
            this.gbStatus.Size = new System.Drawing.Size(501, 50);
            this.gbStatus.TabIndex = 10;
            this.gbStatus.TabStop = false;
            // 
            // rbCancelado
            // 
            this.rbCancelado.AutoSize = true;
            this.rbCancelado.Location = new System.Drawing.Point(394, 21);
            this.rbCancelado.Name = "rbCancelado";
            this.rbCancelado.Size = new System.Drawing.Size(82, 18);
            this.rbCancelado.TabIndex = 0;
            this.rbCancelado.Text = "Cancelado";
            this.rbCancelado.UseVisualStyleBackColor = true;
            this.rbCancelado.CheckedChanged += new System.EventHandler(this.rbCancelado_CheckedChanged);
            // 
            // rbEntregue
            // 
            this.rbEntregue.AutoSize = true;
            this.rbEntregue.Location = new System.Drawing.Point(309, 51);
            this.rbEntregue.Name = "rbEntregue";
            this.rbEntregue.Size = new System.Drawing.Size(73, 18);
            this.rbEntregue.TabIndex = 0;
            this.rbEntregue.Text = "Entregue";
            this.rbEntregue.UseVisualStyleBackColor = true;
            this.rbEntregue.CheckedChanged += new System.EventHandler(this.rbEntregue_CheckedChanged);
            // 
            // rbDespachado
            // 
            this.rbDespachado.AutoSize = true;
            this.rbDespachado.Location = new System.Drawing.Point(195, 49);
            this.rbDespachado.Name = "rbDespachado";
            this.rbDespachado.Size = new System.Drawing.Size(93, 18);
            this.rbDespachado.TabIndex = 0;
            this.rbDespachado.Text = "Despachado";
            this.rbDespachado.UseVisualStyleBackColor = true;
            this.rbDespachado.CheckedChanged += new System.EventHandler(this.rbDespachado_CheckedChanged);
            // 
            // rbFinalizado
            // 
            this.rbFinalizado.AutoSize = true;
            this.rbFinalizado.Location = new System.Drawing.Point(291, 21);
            this.rbFinalizado.Name = "rbFinalizado";
            this.rbFinalizado.Size = new System.Drawing.Size(83, 18);
            this.rbFinalizado.TabIndex = 0;
            this.rbFinalizado.Text = "Finalizado";
            this.rbFinalizado.UseVisualStyleBackColor = true;
            this.rbFinalizado.CheckedChanged += new System.EventHandler(this.rbFinalizado_CheckedChanged);
            // 
            // rbConferido
            // 
            this.rbConferido.AutoSize = true;
            this.rbConferido.Location = new System.Drawing.Point(193, 21);
            this.rbConferido.Name = "rbConferido";
            this.rbConferido.Size = new System.Drawing.Size(78, 18);
            this.rbConferido.TabIndex = 0;
            this.rbConferido.Text = "Conferido";
            this.rbConferido.UseVisualStyleBackColor = true;
            this.rbConferido.CheckedChanged += new System.EventHandler(this.rbConferido_CheckedChanged);
            // 
            // rbSeparado
            // 
            this.rbSeparado.AutoSize = true;
            this.rbSeparado.Location = new System.Drawing.Point(93, 49);
            this.rbSeparado.Name = "rbSeparado";
            this.rbSeparado.Size = new System.Drawing.Size(77, 18);
            this.rbSeparado.TabIndex = 0;
            this.rbSeparado.Text = "Separado";
            this.rbSeparado.UseVisualStyleBackColor = true;
            this.rbSeparado.CheckedChanged += new System.EventHandler(this.rbSeparado_CheckedChanged);
            // 
            // rbEnviado
            // 
            this.rbEnviado.AutoSize = true;
            this.rbEnviado.Location = new System.Drawing.Point(7, 49);
            this.rbEnviado.Name = "rbEnviado";
            this.rbEnviado.Size = new System.Drawing.Size(68, 18);
            this.rbEnviado.TabIndex = 0;
            this.rbEnviado.Text = "Enviado";
            this.rbEnviado.UseVisualStyleBackColor = true;
            this.rbEnviado.CheckedChanged += new System.EventHandler(this.rbEnviado_CheckedChanged);
            // 
            // rbTodos
            // 
            this.rbTodos.AutoSize = true;
            this.rbTodos.Checked = true;
            this.rbTodos.Location = new System.Drawing.Point(6, 21);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(57, 18);
            this.rbTodos.TabIndex = 0;
            this.rbTodos.TabStop = true;
            this.rbTodos.Text = "Todos";
            this.rbTodos.UseVisualStyleBackColor = true;
            this.rbTodos.CheckedChanged += new System.EventHandler(this.rbTodos_CheckedChanged);
            // 
            // rbAberto
            // 
            this.rbAberto.AutoSize = true;
            this.rbAberto.Location = new System.Drawing.Point(93, 21);
            this.rbAberto.Name = "rbAberto";
            this.rbAberto.Size = new System.Drawing.Size(80, 18);
            this.rbAberto.TabIndex = 0;
            this.rbAberto.Text = "Em Aberto";
            this.rbAberto.UseVisualStyleBackColor = true;
            this.rbAberto.CheckedChanged += new System.EventHandler(this.rbAberto_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Status:";
            // 
            // dateDataFim
            // 
            this.dateDataFim.Location = new System.Drawing.Point(241, 14);
            this.dateDataFim.Mask = "00/00/0000";
            this.dateDataFim.Name = "dateDataFim";
            this.dateDataFim.Size = new System.Drawing.Size(75, 22);
            this.dateDataFim.TabIndex = 9;
            this.dateDataFim.ValidatingType = typeof(System.DateTime);
            // 
            // dateDataInicio
            // 
            this.dateDataInicio.Location = new System.Drawing.Point(131, 14);
            this.dateDataInicio.Mask = "00/00/0000";
            this.dateDataInicio.Name = "dateDataInicio";
            this.dateDataInicio.Size = new System.Drawing.Size(76, 22);
            this.dateDataInicio.TabIndex = 8;
            this.dateDataInicio.ValidatingType = typeof(System.DateTime);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(210, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "até";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 14);
            this.label5.TabIndex = 5;
            this.label5.Text = "Data de Registro:  de";
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
            this.btnFiltrar.Location = new System.Drawing.Point(634, 82);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(71, 27);
            this.btnFiltrar.TabIndex = 2;
            this.btnFiltrar.Tag = "Pedidos";
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnClearDate
            // 
            this.btnClearDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearDate.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnClearDate.FlatAppearance.BorderSize = 0;
            this.btnClearDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearDate.ForeColor = System.Drawing.Color.White;
            this.btnClearDate.Image = global::MCatalogos.Properties.Resources.IconClear15x15;
            this.btnClearDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearDate.Location = new System.Drawing.Point(321, 15);
            this.btnClearDate.Name = "btnClearDate";
            this.btnClearDate.Size = new System.Drawing.Size(20, 20);
            this.btnClearDate.TabIndex = 2;
            this.btnClearDate.Tag = "Pedidos";
            this.btnClearDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip.SetToolTip(this.btnClearDate, "Limpar Datas");
            this.btnClearDate.UseVisualStyleBackColor = false;
            this.btnClearDate.Click += new System.EventHandler(this.btnClearDate_Click);
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearFilter.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnClearFilter.FlatAppearance.BorderSize = 0;
            this.btnClearFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearFilter.ForeColor = System.Drawing.Color.White;
            this.btnClearFilter.Image = global::MCatalogos.Properties.Resources.IconClear;
            this.btnClearFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearFilter.Location = new System.Drawing.Point(711, 82);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(71, 27);
            this.btnClearFilter.TabIndex = 2;
            this.btnClearFilter.Tag = "Pedidos";
            this.btnClearFilter.Text = "Limpar";
            this.btnClearFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClearFilter.UseVisualStyleBackColor = false;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(422, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 14);
            this.label4.TabIndex = 4;
            this.label4.Text = "Nome Vendedora:";
            // 
            // mTextCpf
            // 
            this.mTextCpf.Location = new System.Drawing.Point(532, 14);
            this.mTextCpf.Mask = "000,000,000-99";
            this.mTextCpf.Name = "mTextCpf";
            this.mTextCpf.Size = new System.Drawing.Size(92, 22);
            this.mTextCpf.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(443, 18);
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
            this.cbNomeVendedora.Location = new System.Drawing.Point(532, 44);
            this.cbNomeVendedora.Name = "cbNomeVendedora";
            this.cbNomeVendedora.Size = new System.Drawing.Size(250, 22);
            this.cbNomeVendedora.TabIndex = 0;
            this.cbNomeVendedora.SelectedIndexChanged += new System.EventHandler(this.cbNomeVendedora_SelectedIndexChanged);
            this.cbNomeVendedora.Leave += new System.EventHandler(this.cbNomeVendedora_Leave);
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
            this.gbStatus.ResumeLayout(false);
            this.gbStatus.PerformLayout();
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
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox mTextCpf;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbNomeVendedora;
        private System.Windows.Forms.DataGridView dgvPedidos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.MaskedTextBox dateDataFim;
        private System.Windows.Forms.MaskedTextBox dateDataInicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClearDate;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.GroupBox gbStatus;
        private System.Windows.Forms.RadioButton rbCancelado;
        private System.Windows.Forms.RadioButton rbEntregue;
        private System.Windows.Forms.RadioButton rbDespachado;
        private System.Windows.Forms.RadioButton rbFinalizado;
        private System.Windows.Forms.RadioButton rbConferido;
        private System.Windows.Forms.RadioButton rbSeparado;
        private System.Windows.Forms.RadioButton rbEnviado;
        private System.Windows.Forms.RadioButton rbAberto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConferir;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.RadioButton rbTodos;
    }
}