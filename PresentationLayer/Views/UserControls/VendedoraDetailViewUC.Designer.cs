
namespace PresentationLayer.Views.UserControls
{
    partial class VendedoraDetailViewUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.commandVendedoraDetailPanel = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSalve = new System.Windows.Forms.Button();
            this.vendedoraDetailViewPanel = new System.Windows.Forms.Panel();
            this.textInputVendedoraId = new CommonComponents.TextInputUnderlineNoBoxUC();
            this.textInputNome = new CommonComponents.TextInputUnderlineNoBoxUC();
            this.textInputRg = new CommonComponents.TextInputUnderlineNoBoxUC();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textInputEmissorRg = new CommonComponents.TextInputUnderlineNoBoxUC();
            this.comboxInputUnderlineNoBoxUC1 = new CommonComponents.ComboxInputUnderlineNoBoxUC();
            this.commandVendedoraDetailPanel.SuspendLayout();
            this.vendedoraDetailViewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // commandVendedoraDetailPanel
            // 
            this.commandVendedoraDetailPanel.Controls.Add(this.btnCancel);
            this.commandVendedoraDetailPanel.Controls.Add(this.btnSalve);
            this.commandVendedoraDetailPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.commandVendedoraDetailPanel.Location = new System.Drawing.Point(0, 438);
            this.commandVendedoraDetailPanel.Name = "commandVendedoraDetailPanel";
            this.commandVendedoraDetailPanel.Size = new System.Drawing.Size(820, 41);
            this.commandVendedoraDetailPanel.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(737, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 30);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSalve
            // 
            this.btnSalve.Image = global::PresentationLayer.Properties.Resources.iconSave20x20;
            this.btnSalve.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalve.Location = new System.Drawing.Point(651, 6);
            this.btnSalve.Name = "btnSalve";
            this.btnSalve.Size = new System.Drawing.Size(80, 30);
            this.btnSalve.TabIndex = 1;
            this.btnSalve.Text = "Salvar";
            this.btnSalve.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalve.UseVisualStyleBackColor = true;
            this.btnSalve.Click += new System.EventHandler(this.btnSalve_Click);
            // 
            // vendedoraDetailViewPanel
            // 
            this.vendedoraDetailViewPanel.Controls.Add(this.comboxInputUnderlineNoBoxUC1);
            this.vendedoraDetailViewPanel.Controls.Add(this.textInputEmissorRg);
            this.vendedoraDetailViewPanel.Controls.Add(this.pictureBox1);
            this.vendedoraDetailViewPanel.Controls.Add(this.textInputRg);
            this.vendedoraDetailViewPanel.Controls.Add(this.textInputNome);
            this.vendedoraDetailViewPanel.Controls.Add(this.textInputVendedoraId);
            this.vendedoraDetailViewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vendedoraDetailViewPanel.Location = new System.Drawing.Point(0, 0);
            this.vendedoraDetailViewPanel.Name = "vendedoraDetailViewPanel";
            this.vendedoraDetailViewPanel.Size = new System.Drawing.Size(820, 438);
            this.vendedoraDetailViewPanel.TabIndex = 1;
            // 
            // textInputVendedoraId
            // 
            this.textInputVendedoraId.InputBoxBackgroundColor = System.Drawing.SystemColors.Window;
            this.textInputVendedoraId.InputBoxFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textInputVendedoraId.InputBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.textInputVendedoraId.InputBoxHeight = 13;
            this.textInputVendedoraId.InputBoxLocation = new System.Drawing.Point(3, 16);
            this.textInputVendedoraId.InputBoxReadOnly = false;
            this.textInputVendedoraId.InputBoxText = "";
            this.textInputVendedoraId.InputBoxWidth = 337;
            this.textInputVendedoraId.InputLabelBackgroundColor = System.Drawing.SystemColors.Control;
            this.textInputVendedoraId.InputLabelColor = System.Drawing.SystemColors.ControlText;
            this.textInputVendedoraId.InputLabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textInputVendedoraId.InputLabelHeight = 13;
            this.textInputVendedoraId.InputLabelLocation = new System.Drawing.Point(1, -1);
            this.textInputVendedoraId.InputLabelText = "Código";
            this.textInputVendedoraId.InputLabelWidth = 46;
            this.textInputVendedoraId.InputLineLabelLocation = new System.Drawing.Point(5, 31);
            this.textInputVendedoraId.InputLineLabelWidth = 336;
            this.textInputVendedoraId.Location = new System.Drawing.Point(41, 15);
            this.textInputVendedoraId.Name = "textInputVendedoraId";
            this.textInputVendedoraId.Size = new System.Drawing.Size(343, 34);
            this.textInputVendedoraId.TabIndex = 36;
            this.textInputVendedoraId.Tag = "Código";
            // 
            // textInputNome
            // 
            this.textInputNome.InputBoxBackgroundColor = System.Drawing.SystemColors.Window;
            this.textInputNome.InputBoxFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textInputNome.InputBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.textInputNome.InputBoxHeight = 13;
            this.textInputNome.InputBoxLocation = new System.Drawing.Point(3, 16);
            this.textInputNome.InputBoxReadOnly = false;
            this.textInputNome.InputBoxText = "";
            this.textInputNome.InputBoxWidth = 334;
            this.textInputNome.InputLabelBackgroundColor = System.Drawing.SystemColors.Control;
            this.textInputNome.InputLabelColor = System.Drawing.SystemColors.ControlText;
            this.textInputNome.InputLabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textInputNome.InputLabelHeight = 13;
            this.textInputNome.InputLabelLocation = new System.Drawing.Point(1, -1);
            this.textInputNome.InputLabelText = "Nome";
            this.textInputNome.InputLabelWidth = 39;
            this.textInputNome.InputLineLabelLocation = new System.Drawing.Point(5, 31);
            this.textInputNome.InputLineLabelWidth = 333;
            this.textInputNome.Location = new System.Drawing.Point(44, 56);
            this.textInputNome.Name = "textInputNome";
            this.textInputNome.Size = new System.Drawing.Size(340, 34);
            this.textInputNome.TabIndex = 37;
            // 
            // textInputRg
            // 
            this.textInputRg.InputBoxBackgroundColor = System.Drawing.SystemColors.Window;
            this.textInputRg.InputBoxFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textInputRg.InputBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.textInputRg.InputBoxHeight = 13;
            this.textInputRg.InputBoxLocation = new System.Drawing.Point(3, 16);
            this.textInputRg.InputBoxReadOnly = false;
            this.textInputRg.InputBoxText = "";
            this.textInputRg.InputBoxWidth = 142;
            this.textInputRg.InputLabelBackgroundColor = System.Drawing.SystemColors.Control;
            this.textInputRg.InputLabelColor = System.Drawing.SystemColors.ControlText;
            this.textInputRg.InputLabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textInputRg.InputLabelHeight = 13;
            this.textInputRg.InputLabelLocation = new System.Drawing.Point(1, -1);
            this.textInputRg.InputLabelText = "RG";
            this.textInputRg.InputLabelWidth = 25;
            this.textInputRg.InputLineLabelLocation = new System.Drawing.Point(5, 31);
            this.textInputRg.InputLineLabelWidth = 141;
            this.textInputRg.Location = new System.Drawing.Point(44, 96);
            this.textInputRg.Name = "textInputRg";
            this.textInputRg.Size = new System.Drawing.Size(148, 34);
            this.textInputRg.TabIndex = 38;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(416, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(2, 397);
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // textInputEmissorRg
            // 
            this.textInputEmissorRg.InputBoxBackgroundColor = System.Drawing.SystemColors.Window;
            this.textInputEmissorRg.InputBoxFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textInputEmissorRg.InputBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.textInputEmissorRg.InputBoxHeight = 13;
            this.textInputEmissorRg.InputBoxLocation = new System.Drawing.Point(3, 16);
            this.textInputEmissorRg.InputBoxReadOnly = false;
            this.textInputEmissorRg.InputBoxText = "";
            this.textInputEmissorRg.InputBoxWidth = 69;
            this.textInputEmissorRg.InputLabelBackgroundColor = System.Drawing.SystemColors.Control;
            this.textInputEmissorRg.InputLabelColor = System.Drawing.SystemColors.ControlText;
            this.textInputEmissorRg.InputLabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textInputEmissorRg.InputLabelHeight = 13;
            this.textInputEmissorRg.InputLabelLocation = new System.Drawing.Point(1, -1);
            this.textInputEmissorRg.InputLabelText = "Expedidor";
            this.textInputEmissorRg.InputLabelWidth = 63;
            this.textInputEmissorRg.InputLineLabelLocation = new System.Drawing.Point(5, 31);
            this.textInputEmissorRg.InputLineLabelWidth = 68;
            this.textInputEmissorRg.Location = new System.Drawing.Point(198, 96);
            this.textInputEmissorRg.Name = "textInputEmissorRg";
            this.textInputEmissorRg.Size = new System.Drawing.Size(75, 34);
            this.textInputEmissorRg.TabIndex = 40;
            // 
            // comboxInputUnderlineNoBoxUC1
            // 
            this.comboxInputUnderlineNoBoxUC1.InputComboBoxBackgroundColor = System.Drawing.SystemColors.Window;
            this.comboxInputUnderlineNoBoxUC1.InputComboBoxColor = System.Drawing.SystemColors.WindowText;
            this.comboxInputUnderlineNoBoxUC1.InputComboBoxHeight = 21;
            this.comboxInputUnderlineNoBoxUC1.InputComboBoxLocation = new System.Drawing.Point(4, 15);
            this.comboxInputUnderlineNoBoxUC1.InputComboBoxValue = -1;
            this.comboxInputUnderlineNoBoxUC1.InputComboBoxWidth = 280;
            this.comboxInputUnderlineNoBoxUC1.InputComBoxFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboxInputUnderlineNoBoxUC1.InputLabelBackgrouindColor = System.Drawing.SystemColors.Control;
            this.comboxInputUnderlineNoBoxUC1.InputLabelColor = System.Drawing.SystemColors.ControlText;
            this.comboxInputUnderlineNoBoxUC1.InputLabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboxInputUnderlineNoBoxUC1.InputLabelHeight = 13;
            this.comboxInputUnderlineNoBoxUC1.InputLabelLocation = new System.Drawing.Point(2, 3);
            this.comboxInputUnderlineNoBoxUC1.InputLabelText = "label";
            this.comboxInputUnderlineNoBoxUC1.InputLabelWidth = 34;
            this.comboxInputUnderlineNoBoxUC1.InputLineLabelLocation = new System.Drawing.Point(6, 38);
            this.comboxInputUnderlineNoBoxUC1.InputLIneLabelWidth = 289;
            this.comboxInputUnderlineNoBoxUC1.Location = new System.Drawing.Point(279, 89);
            this.comboxInputUnderlineNoBoxUC1.Name = "comboxInputUnderlineNoBoxUC1";
            this.comboxInputUnderlineNoBoxUC1.Size = new System.Drawing.Size(299, 41);
            this.comboxInputUnderlineNoBoxUC1.TabIndex = 41;
            // 
            // VendedoraDetailViewUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.vendedoraDetailViewPanel);
            this.Controls.Add(this.commandVendedoraDetailPanel);
            this.Name = "VendedoraDetailViewUC";
            this.Size = new System.Drawing.Size(820, 479);
            this.commandVendedoraDetailPanel.ResumeLayout(false);
            this.vendedoraDetailViewPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel commandVendedoraDetailPanel;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSalve;
        private System.Windows.Forms.Panel vendedoraDetailViewPanel;
        private CommonComponents.TextInputUnderlineNoBoxUC textInputVendedoraId;
        private CommonComponents.TextInputUnderlineNoBoxUC textInputRg;
        private CommonComponents.TextInputUnderlineNoBoxUC textInputNome;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CommonComponents.ComboxInputUnderlineNoBoxUC comboxInputUnderlineNoBoxUC1;
        private CommonComponents.TextInputUnderlineNoBoxUC textInputEmissorRg;
    }
}
