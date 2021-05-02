
namespace CommonComponents
{
    partial class ComboxInputUnderlineNoBoxUC
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
            this.InputLineLabel = new System.Windows.Forms.Label();
            this.InputLabel = new System.Windows.Forms.Label();
            this.InputComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // InputLineLabel
            // 
            this.InputLineLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputLineLabel.BackColor = System.Drawing.Color.LightGray;
            this.InputLineLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.InputLineLabel.ForeColor = System.Drawing.Color.LightGray;
            this.InputLineLabel.Location = new System.Drawing.Point(6, 38);
            this.InputLineLabel.Name = "InputLineLabel";
            this.InputLineLabel.Size = new System.Drawing.Size(276, 2);
            this.InputLineLabel.TabIndex = 10;
            this.InputLineLabel.Text = "label1";
            // 
            // InputLabel
            // 
            this.InputLabel.AutoSize = true;
            this.InputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputLabel.Location = new System.Drawing.Point(2, 3);
            this.InputLabel.Name = "InputLabel";
            this.InputLabel.Size = new System.Drawing.Size(34, 13);
            this.InputLabel.TabIndex = 9;
            this.InputLabel.Text = "label";
            // 
            // InputComboBox
            // 
            this.InputComboBox.FormattingEnabled = true;
            this.InputComboBox.Location = new System.Drawing.Point(4, 15);
            this.InputComboBox.Name = "InputComboBox";
            this.InputComboBox.Size = new System.Drawing.Size(280, 21);
            this.InputComboBox.TabIndex = 11;
            this.InputComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputComboBox_KeyPress);
            // 
            // ComboxInputUnderlineNoBoxUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.InputComboBox);
            this.Controls.Add(this.InputLineLabel);
            this.Controls.Add(this.InputLabel);
            this.Name = "ComboxInputUnderlineNoBoxUC";
            this.Size = new System.Drawing.Size(286, 41);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InputLineLabel;
        private System.Windows.Forms.Label InputLabel;
        private System.Windows.Forms.ComboBox InputComboBox;
    }
}
