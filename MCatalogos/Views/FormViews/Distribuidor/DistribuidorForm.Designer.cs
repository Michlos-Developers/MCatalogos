
namespace MCatalogos.Views.FormViews.Distribuidor
{
    partial class DistribuidorForm
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
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddBairro = new System.Windows.Forms.Button();
            this.cbBairro = new System.Windows.Forms.ComboBox();
            this.cbCidade = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbUf = new System.Windows.Forms.ComboBox();
            this.textNumero = new System.Windows.Forms.TextBox();
            this.textComplemento = new System.Windows.Forms.TextBox();
            this.mTextCep = new System.Windows.Forms.MaskedTextBox();
            this.textLogradouro = new System.Windows.Forms.TextBox();
            this.mTextTelefone = new System.Windows.Forms.MaskedTextBox();
            this.mTextInscricaoEstadual = new System.Windows.Forms.MaskedTextBox();
            this.mTextCnpj = new System.Windows.Forms.MaskedTextBox();
            this.textSite = new System.Windows.Forms.TextBox();
            this.textEmail = new System.Windows.Forms.TextBox();
            this.textResponsavel = new System.Windows.Forms.TextBox();
            this.textRazaoSocial = new System.Windows.Forms.TextBox();
            this.textNomeFantasia = new System.Windows.Forms.TextBox();
            this.formError = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureClose)).BeginInit();
            this.panelCommands.SuspendLayout();
            this.panelContainer.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.formError)).BeginInit();
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
            this.panelTitle.Size = new System.Drawing.Size(732, 30);
            this.panelTitle.TabIndex = 40;
            this.panelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitle_MouseDown);
            // 
            // pictureClose
            // 
            this.pictureClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureClose.Image = global::MCatalogos.Properties.Resources.IconClose20x20;
            this.pictureClose.Location = new System.Drawing.Point(709, 6);
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
            this.title.Size = new System.Drawing.Size(141, 14);
            this.title.TabIndex = 0;
            this.title.Text = "Cadastro do Distribuidor";
            // 
            // panelCommands
            // 
            this.panelCommands.Controls.Add(this.btnSalvar);
            this.panelCommands.Controls.Add(this.btnCancel);
            this.panelCommands.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCommands.Location = new System.Drawing.Point(0, 377);
            this.panelCommands.Name = "panelCommands";
            this.panelCommands.Size = new System.Drawing.Size(732, 45);
            this.panelCommands.TabIndex = 1;
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
            this.btnSalvar.Location = new System.Drawing.Point(512, 9);
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
            this.btnCancel.Location = new System.Drawing.Point(630, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 27);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.TabStop = false;
            this.btnCancel.Tag = "Pedidos";
            this.btnCancel.Text = "Fechar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.pictureClose_Click);
            // 
            // panelContainer
            // 
            this.panelContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(111)))), ((int)(((byte)(156)))));
            this.panelContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelContainer.Controls.Add(this.label8);
            this.panelContainer.Controls.Add(this.label7);
            this.panelContainer.Controls.Add(this.label6);
            this.panelContainer.Controls.Add(this.label3);
            this.panelContainer.Controls.Add(this.label2);
            this.panelContainer.Controls.Add(this.label5);
            this.panelContainer.Controls.Add(this.label4);
            this.panelContainer.Controls.Add(this.label1);
            this.panelContainer.Controls.Add(this.groupBox1);
            this.panelContainer.Controls.Add(this.mTextTelefone);
            this.panelContainer.Controls.Add(this.mTextInscricaoEstadual);
            this.panelContainer.Controls.Add(this.mTextCnpj);
            this.panelContainer.Controls.Add(this.textSite);
            this.panelContainer.Controls.Add(this.textEmail);
            this.panelContainer.Controls.Add(this.textResponsavel);
            this.panelContainer.Controls.Add(this.textRazaoSocial);
            this.panelContainer.Controls.Add(this.textNomeFantasia);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 30);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(732, 347);
            this.panelContainer.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(53, 166);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 14);
            this.label8.TabIndex = 4;
            this.label8.Text = "Telefone:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(80, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 14);
            this.label7.TabIndex = 4;
            this.label7.Text = "Site:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(66, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 14);
            this.label6.TabIndex = 4;
            this.label6.Text = "E-mail:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "Responsável:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "Razão Social:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(465, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 14);
            this.label5.TabIndex = 4;
            this.label5.Text = "Inscrição Estadual:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(542, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 14);
            this.label4.TabIndex = 4;
            this.label4.Text = "CNPJ:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nome Fantasia:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddBairro);
            this.groupBox1.Controls.Add(this.cbBairro);
            this.groupBox1.Controls.Add(this.cbCidade);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cbUf);
            this.groupBox1.Controls.Add(this.textNumero);
            this.groupBox1.Controls.Add(this.textComplemento);
            this.groupBox1.Controls.Add(this.mTextCep);
            this.groupBox1.Controls.Add(this.textLogradouro);
            this.groupBox1.Location = new System.Drawing.Point(64, 203);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(583, 114);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // btnAddBairro
            // 
            this.btnAddBairro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddBairro.Enabled = false;
            this.btnAddBairro.FlatAppearance.BorderSize = 0;
            this.btnAddBairro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddBairro.ForeColor = System.Drawing.Color.White;
            this.btnAddBairro.Image = global::MCatalogos.Properties.Resources.IconAdd20x20;
            this.btnAddBairro.Location = new System.Drawing.Point(409, 76);
            this.btnAddBairro.Name = "btnAddBairro";
            this.btnAddBairro.Size = new System.Drawing.Size(22, 22);
            this.btnAddBairro.TabIndex = 25;
            this.btnAddBairro.TabStop = false;
            this.btnAddBairro.Tag = "";
            this.btnAddBairro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddBairro.UseVisualStyleBackColor = false;
            this.btnAddBairro.Click += new System.EventHandler(this.btnAddBairro_Click);
            // 
            // cbBairro
            // 
            this.cbBairro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbBairro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbBairro.FormattingEnabled = true;
            this.cbBairro.Location = new System.Drawing.Point(432, 76);
            this.cbBairro.Name = "cbBairro";
            this.cbBairro.Size = new System.Drawing.Size(121, 22);
            this.cbBairro.TabIndex = 6;
            this.cbBairro.Enter += new System.EventHandler(this.cbBairro_Enter);
            this.cbBairro.Leave += new System.EventHandler(this.cbBairro_Leave);
            this.cbBairro.Validating += new System.ComponentModel.CancelEventHandler(this.cbBairro_Validating);
            // 
            // cbCidade
            // 
            this.cbCidade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbCidade.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbCidade.FormattingEnabled = true;
            this.cbCidade.Location = new System.Drawing.Point(242, 78);
            this.cbCidade.Name = "cbCidade";
            this.cbCidade.Size = new System.Drawing.Size(121, 22);
            this.cbCidade.TabIndex = 5;
            this.cbCidade.SelectedIndexChanged += new System.EventHandler(this.cbCidade_SelectedIndexChanged);
            this.cbCidade.Enter += new System.EventHandler(this.cbCidade_Enter);
            this.cbCidade.Leave += new System.EventHandler(this.cbCidade_Leave);
            this.cbCidade.Validating += new System.ComponentModel.CancelEventHandler(this.cbCidade_Validating);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(403, 52);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(28, 14);
            this.label13.TabIndex = 4;
            this.label13.Text = "CEP:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(408, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 14);
            this.label11.TabIndex = 4;
            this.label11.Text = "Nº:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(369, 82);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(43, 14);
            this.label16.TabIndex = 4;
            this.label16.Text = "Bairro:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(192, 82);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(48, 14);
            this.label15.TabIndex = 4;
            this.label15.Text = "Cidade:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(62, 82);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(24, 14);
            this.label14.TabIndex = 4;
            this.label14.Text = "UF:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 52);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 14);
            this.label12.TabIndex = 4;
            this.label12.Text = "Complemento:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(31, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 14);
            this.label10.TabIndex = 4;
            this.label10.Text = "Logradouro:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 14);
            this.label9.TabIndex = 4;
            this.label9.Text = "Endereço:";
            // 
            // cbUf
            // 
            this.cbUf.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbUf.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbUf.FormattingEnabled = true;
            this.cbUf.Location = new System.Drawing.Point(88, 78);
            this.cbUf.Name = "cbUf";
            this.cbUf.Size = new System.Drawing.Size(55, 22);
            this.cbUf.TabIndex = 4;
            this.cbUf.SelectedIndexChanged += new System.EventHandler(this.cbUf_SelectedIndexChanged);
            this.cbUf.Enter += new System.EventHandler(this.cbUf_Enter);
            this.cbUf.Leave += new System.EventHandler(this.cbUf_Leave);
            this.cbUf.Validating += new System.ComponentModel.CancelEventHandler(this.cbUf_Validating);
            // 
            // textNumero
            // 
            this.textNumero.Location = new System.Drawing.Point(432, 20);
            this.textNumero.Name = "textNumero";
            this.textNumero.Size = new System.Drawing.Size(46, 22);
            this.textNumero.TabIndex = 1;
            this.textNumero.Enter += new System.EventHandler(this.textNumero_Enter);
            this.textNumero.Leave += new System.EventHandler(this.textNumero_Leave);
            this.textNumero.Validating += new System.ComponentModel.CancelEventHandler(this.textNumero_Validating);
            // 
            // textComplemento
            // 
            this.textComplemento.Location = new System.Drawing.Point(103, 48);
            this.textComplemento.Name = "textComplemento";
            this.textComplemento.Size = new System.Drawing.Size(260, 22);
            this.textComplemento.TabIndex = 2;
            this.textComplemento.Enter += new System.EventHandler(this.textComplemento_Enter);
            this.textComplemento.Leave += new System.EventHandler(this.textComplemento_Leave);
            // 
            // mTextCep
            // 
            this.mTextCep.Location = new System.Drawing.Point(432, 48);
            this.mTextCep.Mask = "00,000-999";
            this.mTextCep.Name = "mTextCep";
            this.mTextCep.Size = new System.Drawing.Size(79, 22);
            this.mTextCep.TabIndex = 3;
            this.mTextCep.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mTextCep_MouseClick);
            this.mTextCep.Enter += new System.EventHandler(this.mTextCep_Enter);
            this.mTextCep.Leave += new System.EventHandler(this.mTextCep_Leave);
            // 
            // textLogradouro
            // 
            this.textLogradouro.Location = new System.Drawing.Point(103, 20);
            this.textLogradouro.Name = "textLogradouro";
            this.textLogradouro.Size = new System.Drawing.Size(260, 22);
            this.textLogradouro.TabIndex = 0;
            this.textLogradouro.Enter += new System.EventHandler(this.textLogradouro_Enter);
            this.textLogradouro.Leave += new System.EventHandler(this.textLogradouro_Leave);
            this.textLogradouro.Validating += new System.ComponentModel.CancelEventHandler(this.textLogradouro_Validating);
            // 
            // mTextTelefone
            // 
            this.mTextTelefone.Location = new System.Drawing.Point(112, 163);
            this.mTextTelefone.Mask = "(99) 9 0000-0000";
            this.mTextTelefone.Name = "mTextTelefone";
            this.mTextTelefone.Size = new System.Drawing.Size(95, 22);
            this.mTextTelefone.TabIndex = 7;
            this.mTextTelefone.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mTextTelefone_MouseClick);
            this.mTextTelefone.Enter += new System.EventHandler(this.mTextTelefone_Enter);
            this.mTextTelefone.Leave += new System.EventHandler(this.mTextTelefone_Leave);
            this.mTextTelefone.Validating += new System.ComponentModel.CancelEventHandler(this.mTextTelefone_Validating);
            // 
            // mTextInscricaoEstadual
            // 
            this.mTextInscricaoEstadual.Location = new System.Drawing.Point(576, 51);
            this.mTextInscricaoEstadual.Name = "mTextInscricaoEstadual";
            this.mTextInscricaoEstadual.Size = new System.Drawing.Size(121, 22);
            this.mTextInscricaoEstadual.TabIndex = 3;
            this.mTextInscricaoEstadual.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mTextInscricaoEstadual_MouseClick);
            this.mTextInscricaoEstadual.Enter += new System.EventHandler(this.mTextInscricaoEstadual_Enter);
            this.mTextInscricaoEstadual.Leave += new System.EventHandler(this.mTextInscricaoEstadual_Leave);
            // 
            // mTextCnpj
            // 
            this.mTextCnpj.Location = new System.Drawing.Point(576, 23);
            this.mTextCnpj.Mask = "00,000,000/0000-99";
            this.mTextCnpj.Name = "mTextCnpj";
            this.mTextCnpj.Size = new System.Drawing.Size(121, 22);
            this.mTextCnpj.TabIndex = 1;
            this.mTextCnpj.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mTextCnpj_MouseClick);
            this.mTextCnpj.Enter += new System.EventHandler(this.mTextCnpj_Enter);
            this.mTextCnpj.Leave += new System.EventHandler(this.mTextCnpj_Leave);
            this.mTextCnpj.Validating += new System.ComponentModel.CancelEventHandler(this.mTextCnpj_Validating);
            // 
            // textSite
            // 
            this.textSite.Location = new System.Drawing.Point(112, 135);
            this.textSite.Name = "textSite";
            this.textSite.Size = new System.Drawing.Size(216, 22);
            this.textSite.TabIndex = 6;
            this.textSite.Enter += new System.EventHandler(this.textSite_Enter);
            this.textSite.Leave += new System.EventHandler(this.textSite_Leave);
            // 
            // textEmail
            // 
            this.textEmail.Location = new System.Drawing.Point(112, 107);
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(217, 22);
            this.textEmail.TabIndex = 5;
            this.textEmail.Enter += new System.EventHandler(this.textEmail_Enter);
            this.textEmail.Leave += new System.EventHandler(this.textEmail_Leave);
            // 
            // textResponsavel
            // 
            this.textResponsavel.Location = new System.Drawing.Point(111, 79);
            this.textResponsavel.Name = "textResponsavel";
            this.textResponsavel.Size = new System.Drawing.Size(339, 22);
            this.textResponsavel.TabIndex = 4;
            this.textResponsavel.Enter += new System.EventHandler(this.textResponsavel_Enter);
            this.textResponsavel.Leave += new System.EventHandler(this.textResponsavel_Leave);
            this.textResponsavel.Validating += new System.ComponentModel.CancelEventHandler(this.textResponsavel_Validating);
            // 
            // textRazaoSocial
            // 
            this.textRazaoSocial.Location = new System.Drawing.Point(111, 51);
            this.textRazaoSocial.Name = "textRazaoSocial";
            this.textRazaoSocial.Size = new System.Drawing.Size(339, 22);
            this.textRazaoSocial.TabIndex = 2;
            this.textRazaoSocial.Enter += new System.EventHandler(this.textRazaoSocial_Enter);
            this.textRazaoSocial.Leave += new System.EventHandler(this.textRazaoSocial_Leave);
            this.textRazaoSocial.Validating += new System.ComponentModel.CancelEventHandler(this.textRazaoSocial_Validating);
            // 
            // textNomeFantasia
            // 
            this.textNomeFantasia.Location = new System.Drawing.Point(112, 23);
            this.textNomeFantasia.Name = "textNomeFantasia";
            this.textNomeFantasia.Size = new System.Drawing.Size(338, 22);
            this.textNomeFantasia.TabIndex = 0;
            this.textNomeFantasia.Enter += new System.EventHandler(this.textNomeFantasia_Enter);
            this.textNomeFantasia.Leave += new System.EventHandler(this.textNomeFantasia_Leave);
            this.textNomeFantasia.Validating += new System.ComponentModel.CancelEventHandler(this.textNomeFantasia_Validating);
            // 
            // formError
            // 
            this.formError.ContainerControl = this;
            // 
            // DistribuidorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 422);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelCommands);
            this.Controls.Add(this.panelTitle);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DistribuidorForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DistribuidorForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DistribuidorForm_FormClosing);
            this.Load += new System.EventHandler(this.DistribuidorForm_Load);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureClose)).EndInit();
            this.panelCommands.ResumeLayout(false);
            this.panelContainer.ResumeLayout(false);
            this.panelContainer.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.formError)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.PictureBox pictureClose;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Panel panelCommands;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.MaskedTextBox mTextInscricaoEstadual;
        private System.Windows.Forms.MaskedTextBox mTextCnpj;
        private System.Windows.Forms.TextBox textRazaoSocial;
        private System.Windows.Forms.TextBox textNomeFantasia;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbBairro;
        private System.Windows.Forms.ComboBox cbCidade;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbUf;
        private System.Windows.Forms.TextBox textNumero;
        private System.Windows.Forms.TextBox textComplemento;
        private System.Windows.Forms.MaskedTextBox mTextCep;
        private System.Windows.Forms.TextBox textLogradouro;
        private System.Windows.Forms.MaskedTextBox mTextTelefone;
        private System.Windows.Forms.TextBox textSite;
        private System.Windows.Forms.TextBox textEmail;
        private System.Windows.Forms.TextBox textResponsavel;
        private System.Windows.Forms.ErrorProvider formError;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button btnAddBairro;
    }
}