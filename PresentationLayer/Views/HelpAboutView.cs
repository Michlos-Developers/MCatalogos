using CommonComponents;

using PresentationLayer.Common;

using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public partial class HelpAboutView : Form, IHelpAboutView
    {
        public event EventHandler HelpAboutViewLoadEventRaised;
        public HelpAboutView()
        {
            InitializeComponent();
        }

        public void SetAboutValues(string windowTitle,
                                   string productName,
                                   string version,
                                   string copyright,
                                   string companyName,
                                   string description)
        {
            this.Text = windowTitle;
            this.productLabel.Text = productName;
            this.versionLabel.Text = version;
            this.copyRightLabel.Text = copyright;
            this.companyLabel.Text = companyName;
            this.descriptionLabel.Text = description;
        }

        private void HelpAboutView_Load(object sender, EventArgs e)
        {
            FormHelper.SetDialogApparecne(this);

            EventHelpers.RaiseEvent(this, HelpAboutViewLoadEventRaised, e);
        }

        public void ShowHelpAboutView()
        {
            this.ShowDialog();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
