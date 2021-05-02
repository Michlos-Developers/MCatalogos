using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CommonComponents
{
    public partial class TextInputUnderlineNoBoxUC : UserControl
    {
        [Description("Data bindings for InputTextBox"), Category("Data")]
        public ControlBindingsCollection InputBoxDataBinding
        {
            get { return InputTextBox.DataBindings; }
        }

        [Description("Text for InputTextBox"), Category("Data")]
        public string InputBoxText
        {
            get { return InputTextBox.Text; }
            set { InputTextBox.Text = value; }
        }

        [Description("ReadOnly for InputTextBox"), Category("Data")]
        public bool InputBoxReadOnly
        {
            get { return InputTextBox.ReadOnly; }
            set { InputTextBox.ReadOnly = value; }
        }

        [Description("Font for InputTextBox"), Category("Appearance")]
        public Font InputBoxFont
        {
            get { return InputTextBox.Font; }
            set { InputTextBox.Font = value; }
        }


        [Description("ForeColor for InputTextBox"), Category("Appearance")]
        public Color InputBoxForeColor
        {
            get { return InputTextBox.ForeColor; }
            set { InputTextBox.ForeColor = value; }
        }

        [Description("BackgroundColor for InputTextBox"), Category("Appearance")]
        public Color InputBoxBackgroundColor
        {
            get { return InputTextBox.BackColor; }
            set { InputTextBox.BackColor = value; }
        }
        // ======================================

        [Description("Location for InputTextBox"), Category("Appearance")]
        public Point InputBoxLocation
        {
            get { return InputTextBox.Location; }
            set { InputTextBox.Location = value; }
        }

        [Description("Height for InputTextBox"), Category("Appearance")]
        public int InputBoxHeight
        {
            get { return InputTextBox.Height; }
            set { InputTextBox.Height = value; }
        }

        [Description("Width for InputTextBox"), Category("Appearance")]
        public int InputBoxWidth
        {
            get { return InputTextBox.Width; }
            set { InputTextBox.Width = value; }
        }

        // ======================

        [Description("Text for InputLabel"), Category("Data")]
        public string InputLabelText
        {
            get { return InputLabel.Text; }
            set { InputLabel.Text = value; }
        }

        [Description("Font for InputLabel"), Category("Appearance")]
        public Font InputLabelFont
        {
            get { return InputLabel.Font; }
            set { InputLabel.Font = value; }
        }

        [Description("ForeColor for InputLabel"), Category("Appearance")]
        public Color InputLabelColor
        {
            get { return InputLabel.ForeColor; }
            set { InputLabel.ForeColor = value; }
        }

        [Description("BackgroundColor for InputLabel"), Category("Appearance")]
        public Color InputLabelBackgroundColor
        {
            get { return InputLabel.BackColor; }
            set { InputLabel.BackColor = value; }
        }

        [Description("Location for InputLabel"), Category("Appearance")]
        public Point InputLabelLocation
        {
            get { return InputLabel.Location; }
            set { InputLabel.Location = value; }
        }

        [Description("Height for InputLabel"), Category("Appearance")]
        public int InputLabelHeight
        {
            get { return InputLabel.Height; }
            set { InputLabel.Height = value; }
        }

        [Description("Width for InputLabel"), Category("Appearance")]
        public int InputLabelWidth
        {
            get { return InputLabel.Width; }
            set { InputLabel.Width = value; }
        }
        // ======================

        [Description("Location for InputLineLabel"), Category("Appearance")]
        public Point InputLineLabelLocation
        {
            get { return InputLineLabel.Location; }
            set { InputLineLabel.Location = value; }
        }

        [Description("Width for InputLineLabel"), Category("Appearance")]
        public int InputLineLabelWidth
        {
            get { return InputLineLabel.Width; }
            set { InputLineLabel.Width = value; }
        }
        // ======================================
        public TextInputUnderlineNoBoxUC()
        {
            InitializeComponent();
        }

        public event EventHandler InputTextBoxEvent_KeyPress;

        private void InputTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (InputTextBoxEvent_KeyPress != null)
            {
                InputTextBoxEvent_KeyPress(this, e);
            }
        }
    }
}
