
namespace MCatalogos.Views.FormViews.Fornecedores
{
    partial class FornecedorForm
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
            this.toolTipFornecedorForm = new System.Windows.Forms.ToolTip(this.components);
            this.panelCommands = new System.Windows.Forms.Panel();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.pictureClose = new System.Windows.Forms.PictureBox();
            this.title = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.groupBoxContatos = new System.Windows.Forms.GroupBox();
            this.panelContatosList = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBoxEndereco = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textNumero = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textComplemento = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbBairro = new System.Windows.Forms.ComboBox();
            this.textLogradouro = new System.Windows.Forms.TextBox();
            this.cbCidade = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.mTextCep = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbUf = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBoxCatalogos = new System.Windows.Forms.GroupBox();
            this.panelCatalogosList = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.textSite = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textEmail = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textNomeFantasia = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textRazaoSocial = new System.Windows.Forms.TextBox();
            this.LblRazaoSocial = new System.Windows.Forms.Label();
            this.mTextInscricaoEstadual = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.mTextCnpj = new System.Windows.Forms.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.LblCnpj = new System.Windows.Forms.Label();
            this.textFornecedorId = new System.Windows.Forms.TextBox();
            this.LblCodigo = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelCommands.SuspendLayout();
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureClose)).BeginInit();
            this.panelContent.SuspendLayout();
            this.groupBoxContatos.SuspendLayout();
            this.groupBoxEndereco.SuspendLayout();
            this.groupBoxCatalogos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCommands
            // 
            this.panelCommands.Controls.Add(this.btnSalvar);
            this.panelCommands.Controls.Add(this.btnCancel);
            this.panelCommands.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCommands.Location = new System.Drawing.Point(0, 470);
            this.panelCommands.Name = "panelCommands";
            this.panelCommands.Size = new System.Drawing.Size(800, 45);
            this.panelCommands.TabIndex = 2;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnSalvar.FlatAppearance.BorderSize = 0;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.Image = global::MCatalogos.Properties.Resources.iconSave20x20;
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar.Location = new System.Drawing.Point(580, 9);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(91, 27);
            this.btnSalvar.TabIndex = 0;
            this.btnSalvar.TabStop = false;
            this.btnSalvar.Tag = "";
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(698, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 27);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.TabStop = false;
            this.btnCancel.Tag = "Pedidos";
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            this.panelTitle.TabIndex = 39;
            this.panelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitle_MouseDown);
            // 
            // pictureClose
            // 
            this.pictureClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureClose.Image = global::MCatalogos.Properties.Resources.IconClose20x20;
            this.pictureClose.Location = new System.Drawing.Point(777, 6);
            this.pictureClose.Name = "pictureClose";
            this.pictureClose.Size = new System.Drawing.Size(15, 15);
            this.pictureClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureClose.TabIndex = 1;
            this.pictureClose.TabStop = false;
            this.pictureClose.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.ForeColor = System.Drawing.SystemColors.ControlText;
            this.title.Location = new System.Drawing.Point(10, 8);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(136, 14);
            this.title.TabIndex = 0;
            this.title.Text = "Cadastro do Fornecedor";
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(111)))), ((int)(((byte)(156)))));
            this.panelContent.Controls.Add(this.groupBoxContatos);
            this.panelContent.Controls.Add(this.groupBoxEndereco);
            this.panelContent.Controls.Add(this.groupBoxCatalogos);
            this.panelContent.Controls.Add(this.textSite);
            this.panelContent.Controls.Add(this.label14);
            this.panelContent.Controls.Add(this.textEmail);
            this.panelContent.Controls.Add(this.label13);
            this.panelContent.Controls.Add(this.textNomeFantasia);
            this.panelContent.Controls.Add(this.label1);
            this.panelContent.Controls.Add(this.textRazaoSocial);
            this.panelContent.Controls.Add(this.LblRazaoSocial);
            this.panelContent.Controls.Add(this.mTextInscricaoEstadual);
            this.panelContent.Controls.Add(this.label9);
            this.panelContent.Controls.Add(this.mTextCnpj);
            this.panelContent.Controls.Add(this.label12);
            this.panelContent.Controls.Add(this.LblCnpj);
            this.panelContent.Controls.Add(this.textFornecedorId);
            this.panelContent.Controls.Add(this.LblCodigo);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.ForeColor = System.Drawing.Color.White;
            this.panelContent.Location = new System.Drawing.Point(0, 30);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(800, 440);
            this.panelContent.TabIndex = 0;
            // 
            // groupBoxContatos
            // 
            this.groupBoxContatos.Controls.Add(this.panelContatosList);
            this.groupBoxContatos.Controls.Add(this.label15);
            this.groupBoxContatos.Location = new System.Drawing.Point(18, 285);
            this.groupBoxContatos.Name = "groupBoxContatos";
            this.groupBoxContatos.Size = new System.Drawing.Size(763, 140);
            this.groupBoxContatos.TabIndex = 26;
            this.groupBoxContatos.TabStop = false;
            // 
            // panelContatosList
            // 
            this.panelContatosList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContatosList.Location = new System.Drawing.Point(3, 18);
            this.panelContatosList.Name = "panelContatosList";
            this.panelContatosList.Size = new System.Drawing.Size(757, 119);
            this.panelContatosList.TabIndex = 24;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(58, 14);
            this.label15.TabIndex = 23;
            this.label15.Text = "Contatos:";
            // 
            // groupBoxEndereco
            // 
            this.groupBoxEndereco.Controls.Add(this.label3);
            this.groupBoxEndereco.Controls.Add(this.textNumero);
            this.groupBoxEndereco.Controls.Add(this.label5);
            this.groupBoxEndereco.Controls.Add(this.textComplemento);
            this.groupBoxEndereco.Controls.Add(this.label8);
            this.groupBoxEndereco.Controls.Add(this.cbBairro);
            this.groupBoxEndereco.Controls.Add(this.textLogradouro);
            this.groupBoxEndereco.Controls.Add(this.cbCidade);
            this.groupBoxEndereco.Controls.Add(this.label4);
            this.groupBoxEndereco.Controls.Add(this.mTextCep);
            this.groupBoxEndereco.Controls.Add(this.label6);
            this.groupBoxEndereco.Controls.Add(this.cbUf);
            this.groupBoxEndereco.Controls.Add(this.label11);
            this.groupBoxEndereco.Controls.Add(this.label7);
            this.groupBoxEndereco.Controls.Add(this.label10);
            this.groupBoxEndereco.Location = new System.Drawing.Point(18, 99);
            this.groupBoxEndereco.Name = "groupBoxEndereco";
            this.groupBoxEndereco.Size = new System.Drawing.Size(486, 142);
            this.groupBoxEndereco.TabIndex = 4;
            this.groupBoxEndereco.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, -1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 14);
            this.label3.TabIndex = 23;
            this.label3.Text = "Endereço:";
            // 
            // textNumero
            // 
            this.textNumero.Location = new System.Drawing.Point(82, 49);
            this.textNumero.Name = "textNumero";
            this.textNumero.Size = new System.Drawing.Size(62, 22);
            this.textNumero.TabIndex = 1;
            this.textNumero.Validating += new System.ComponentModel.CancelEventHandler(this.textNumero_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 14);
            this.label5.TabIndex = 23;
            this.label5.Text = "Número:";
            // 
            // textComplemento
            // 
            this.textComplemento.Location = new System.Drawing.Point(96, 77);
            this.textComplemento.Name = "textComplemento";
            this.textComplemento.Size = new System.Drawing.Size(369, 22);
            this.textComplemento.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 14);
            this.label8.TabIndex = 23;
            this.label8.Text = "Complemento:";
            // 
            // cbBairro
            // 
            this.cbBairro.FormattingEnabled = true;
            this.cbBairro.Location = new System.Drawing.Point(309, 105);
            this.cbBairro.Name = "cbBairro";
            this.cbBairro.Size = new System.Drawing.Size(156, 22);
            this.cbBairro.TabIndex = 6;
            this.cbBairro.Validating += new System.ComponentModel.CancelEventHandler(this.cbBairro_Validating);
            // 
            // textLogradouro
            // 
            this.textLogradouro.Location = new System.Drawing.Point(82, 21);
            this.textLogradouro.MaxLength = 300;
            this.textLogradouro.Name = "textLogradouro";
            this.textLogradouro.Size = new System.Drawing.Size(383, 22);
            this.textLogradouro.TabIndex = 0;
            this.textLogradouro.Validating += new System.ComponentModel.CancelEventHandler(this.textLogradouro_Validating);
            // 
            // cbCidade
            // 
            this.cbCidade.FormattingEnabled = true;
            this.cbCidade.Location = new System.Drawing.Point(82, 105);
            this.cbCidade.Name = "cbCidade";
            this.cbCidade.Size = new System.Drawing.Size(172, 22);
            this.cbCidade.TabIndex = 5;
            this.cbCidade.SelectedIndexChanged += new System.EventHandler(this.cbCidade_SelectedIndexChanged);
            this.cbCidade.Validating += new System.ComponentModel.CancelEventHandler(this.cbCidade_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 14);
            this.label4.TabIndex = 23;
            this.label4.Text = "Logradouro:";
            // 
            // mTextCep
            // 
            this.mTextCep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mTextCep.Location = new System.Drawing.Point(247, 49);
            this.mTextCep.Mask = "00000-000";
            this.mTextCep.Name = "mTextCep";
            this.mTextCep.Size = new System.Drawing.Size(80, 22);
            this.mTextCep.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(213, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 14);
            this.label6.TabIndex = 20;
            this.label6.Text = "CEP:";
            // 
            // cbUf
            // 
            this.cbUf.FormattingEnabled = true;
            this.cbUf.Items.AddRange(new object[] {
            "-"});
            this.cbUf.Location = new System.Drawing.Point(418, 49);
            this.cbUf.Name = "cbUf";
            this.cbUf.Size = new System.Drawing.Size(47, 22);
            this.cbUf.TabIndex = 3;
            this.cbUf.SelectedIndexChanged += new System.EventHandler(this.cbUf_SelectedIndexChanged);
            this.cbUf.Validating += new System.ComponentModel.CancelEventHandler(this.cbUf_Validating);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(260, 108);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 14);
            this.label11.TabIndex = 13;
            this.label11.Text = "Bairro:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(388, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 14);
            this.label7.TabIndex = 13;
            this.label7.Text = "UF:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(26, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 14);
            this.label10.TabIndex = 13;
            this.label10.Text = "Cidade:";
            // 
            // groupBoxCatalogos
            // 
            this.groupBoxCatalogos.Controls.Add(this.panelCatalogosList);
            this.groupBoxCatalogos.Controls.Add(this.label2);
            this.groupBoxCatalogos.Location = new System.Drawing.Point(525, 64);
            this.groupBoxCatalogos.Name = "groupBoxCatalogos";
            this.groupBoxCatalogos.Size = new System.Drawing.Size(256, 211);
            this.groupBoxCatalogos.TabIndex = 24;
            this.groupBoxCatalogos.TabStop = false;
            // 
            // panelCatalogosList
            // 
            this.panelCatalogosList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCatalogosList.Location = new System.Drawing.Point(3, 18);
            this.panelCatalogosList.Name = "panelCatalogosList";
            this.panelCatalogosList.Size = new System.Drawing.Size(250, 190);
            this.panelCatalogosList.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, -2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 14);
            this.label2.TabIndex = 23;
            this.label2.Text = "Catálogos:";
            // 
            // textSite
            // 
            this.textSite.Location = new System.Drawing.Point(304, 253);
            this.textSite.Name = "textSite";
            this.textSite.Size = new System.Drawing.Size(200, 22);
            this.textSite.TabIndex = 6;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(272, 257);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 14);
            this.label14.TabIndex = 23;
            this.label14.Text = "Site:";
            // 
            // textEmail
            // 
            this.textEmail.Location = new System.Drawing.Point(62, 253);
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(200, 22);
            this.textEmail.TabIndex = 5;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 257);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 14);
            this.label13.TabIndex = 23;
            this.label13.Text = "E-mail:";
            // 
            // textNomeFantasia
            // 
            this.textNomeFantasia.Location = new System.Drawing.Point(108, 68);
            this.textNomeFantasia.MaxLength = 300;
            this.textNomeFantasia.Name = "textNomeFantasia";
            this.textNomeFantasia.Size = new System.Drawing.Size(396, 22);
            this.textNomeFantasia.TabIndex = 3;
            this.textNomeFantasia.Validating += new System.ComponentModel.CancelEventHandler(this.textNomeFantasia_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 14);
            this.label1.TabIndex = 23;
            this.label1.Text = "Nome Fantasia:";
            // 
            // textRazaoSocial
            // 
            this.textRazaoSocial.Location = new System.Drawing.Point(108, 37);
            this.textRazaoSocial.MaxLength = 300;
            this.textRazaoSocial.Name = "textRazaoSocial";
            this.textRazaoSocial.Size = new System.Drawing.Size(396, 22);
            this.textRazaoSocial.TabIndex = 2;
            this.textRazaoSocial.Validating += new System.ComponentModel.CancelEventHandler(this.textRazaoSocial_Validating);
            // 
            // LblRazaoSocial
            // 
            this.LblRazaoSocial.AutoSize = true;
            this.LblRazaoSocial.Location = new System.Drawing.Point(29, 41);
            this.LblRazaoSocial.Name = "LblRazaoSocial";
            this.LblRazaoSocial.Size = new System.Drawing.Size(79, 14);
            this.LblRazaoSocial.TabIndex = 23;
            this.LblRazaoSocial.Text = "Razão Social:";
            // 
            // mTextInscricaoEstadual
            // 
            this.mTextInscricaoEstadual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mTextInscricaoEstadual.Location = new System.Drawing.Point(662, 37);
            this.mTextInscricaoEstadual.Name = "mTextInscricaoEstadual";
            this.mTextInscricaoEstadual.Size = new System.Drawing.Size(118, 22);
            this.mTextInscricaoEstadual.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(546, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 14);
            this.label9.TabIndex = 20;
            this.label9.Text = "Inscrição Estadual:";
            // 
            // mTextCnpj
            // 
            this.mTextCnpj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mTextCnpj.Location = new System.Drawing.Point(662, 8);
            this.mTextCnpj.Mask = "00,000,000/0000-99";
            this.mTextCnpj.Name = "mTextCnpj";
            this.mTextCnpj.Size = new System.Drawing.Size(118, 22);
            this.mTextCnpj.TabIndex = 0;
            this.mTextCnpj.Validating += new System.ComponentModel.CancelEventHandler(this.mTextCnpj_Validating);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(628, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 14);
            this.label12.TabIndex = 20;
            this.label12.Text = "CNPJ:";
            // 
            // LblCnpj
            // 
            this.LblCnpj.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblCnpj.AutoSize = true;
            this.LblCnpj.Location = new System.Drawing.Point(636, 12);
            this.LblCnpj.Name = "LblCnpj";
            this.LblCnpj.Size = new System.Drawing.Size(28, 14);
            this.LblCnpj.TabIndex = 21;
            this.LblCnpj.Text = "CPF:";
            // 
            // textFornecedorId
            // 
            this.textFornecedorId.Enabled = false;
            this.textFornecedorId.Location = new System.Drawing.Point(62, 8);
            this.textFornecedorId.Name = "textFornecedorId";
            this.textFornecedorId.Size = new System.Drawing.Size(100, 22);
            this.textFornecedorId.TabIndex = 17;
            // 
            // LblCodigo
            // 
            this.LblCodigo.AutoSize = true;
            this.LblCodigo.Location = new System.Drawing.Point(15, 11);
            this.LblCodigo.Name = "LblCodigo";
            this.LblCodigo.Size = new System.Drawing.Size(47, 14);
            this.LblCodigo.TabIndex = 19;
            this.LblCodigo.Text = "Codigo:";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // FornecedorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 515);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelTitle);
            this.Controls.Add(this.panelCommands);
            this.Font = new System.Drawing.Font("Calibri", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FornecedorForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FornecedorForm";
            this.Load += new System.EventHandler(this.FornecedorForm_Load);
            this.panelCommands.ResumeLayout(false);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureClose)).EndInit();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.groupBoxContatos.ResumeLayout(false);
            this.groupBoxContatos.PerformLayout();
            this.groupBoxEndereco.ResumeLayout(false);
            this.groupBoxEndereco.PerformLayout();
            this.groupBoxCatalogos.ResumeLayout(false);
            this.groupBoxCatalogos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTipFornecedorForm;
        private System.Windows.Forms.Panel panelCommands;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.PictureBox pictureClose;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Panel panelContent;
        public System.Windows.Forms.MaskedTextBox mTextCnpj;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label LblCnpj;
        public System.Windows.Forms.TextBox textFornecedorId;
        private System.Windows.Forms.Label LblCodigo;
        private System.Windows.Forms.GroupBox groupBoxEndereco;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox textNumero;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox textLogradouro;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.MaskedTextBox mTextCep;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBoxCatalogos;
        private System.Windows.Forms.Panel panelCatalogosList;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox textNomeFantasia;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textRazaoSocial;
        private System.Windows.Forms.Label LblRazaoSocial;
        public System.Windows.Forms.ComboBox cbUf;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox textComplemento;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.MaskedTextBox mTextInscricaoEstadual;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbCidade;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.ComboBox cbBairro;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox textSite;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.TextBox textEmail;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBoxContatos;
        private System.Windows.Forms.Panel panelContatosList;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}