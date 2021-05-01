using System;

namespace PresentationLayer.Views
{
    public interface IHelpAboutView
    {
        event EventHandler HelpAboutViewLoadEventRaised;

        void SetAboutValues(string windowTitle, string productName, string version, string copyright, string companyName, string description);
        void ShowHelpAboutView();
    }
}