using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public partial class ErrorMessageView : Form
    {
        public ErrorMessageView()
        {
            InitializeComponent();
        }


        public void ShowErrorMessageView(string windowsTitle, string errorMessage)
        {
            this.Text = windowsTitle;
            this.messageTextBox.Text = errorMessage;
            this.ShowDialog();
            this.Close();
        }
        private void BtnCopy_Click(object sender, EventArgs e)
        {
            if (messageTextBox.Text != "")
            {
                System.Windows.Forms.Clipboard.SetText(messageTextBox.Text);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
