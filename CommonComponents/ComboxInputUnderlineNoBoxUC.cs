using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommonComponents
{
    public partial class ComboxInputUnderlineNoBoxUC : UserControl
    {
        [Description("Data bindings for InputComboBox"), Category("Data")]
        public ControlBindingsCollection InputComboBoxDataBinding
        {
            get { return InputComboBox.DataBindings; }
        }

        [Description("Text for InputComboBox"), Category("Data")]
        public int InputComboBoxValue
        {
            get { return InputComboBox.SelectedIndex; }
            set { InputComboBox.SelectedIndex = value; }
        }

        [Description("Font for InputComboBox"), Category("Appearance")]
        public Font InputComBoxFont
        {
            get { return InputComboBox.Font; }
            set { InputComboBox.Font = value; }
        }

        [Description("ForeColor for InputComboBox"), Category("Appearance")]
        public Color InputComboBoxColor
        {
            get { return InputComboBox.ForeColor; }
            set { InputComboBox.ForeColor = value; }
        }

        [Description("BackgroundColor for InputComboBox"), Category("Appearance")]
        public Color InputComboBoxBackgroundColor
        {
            get { return InputComboBox.BackColor; }
            set { InputComboBox.BackColor = value; }
        }

        [Description("Location for InputComboBox"), Category("Appearance")]
        public Point InputComboBoxLocation
        {
            get { return InputComboBox.Location; }
            set { InputComboBox.Location = value; }
        }

        [Description("Heignt for InputComboBox"), Category("Appearance")]
        public int InputComboBoxHeight
        {
            get { return InputComboBox.Height; }
            set { InputComboBox.Height = value; }
        }

        [Description("Width for InputComboBox"), Category("Appearance")]
        public int InputComboBoxWidth
        {
            get { return InputComboBox.Width; }
            set { InputComboBox.Width = value; }
        }

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
        public Color InputLabelBackgrouindColor
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

        [Description("Location for InputLineLabel"), Category("Appearance")]
        public Point InputLineLabelLocation
        {
            get { return InputLineLabel.Location; }
            set { InputLineLabel.Location = value; }
        }

        [Description("Width for InputLineLabel"), Category("Appearance")]
        public int InputLIneLabelWidth
        {
            get { return InputLineLabel.Width; }
            set { InputLineLabel.Width = value; }
        }

        public ComboxInputUnderlineNoBoxUC()
        {
            InitializeComponent();
        }

        public event EventHandler InputComboBoxEvent_KeyPress;


        private void InputComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (InputComboBoxEvent_KeyPress != null)
            {
                InputComboBoxEvent_KeyPress(this, e);
            }
        }
    }
}
