using PresentationLayer.Views;

using System;

namespace PresentationLayer.Presenters
{
    public interface IHelpAboutPresenter
    {
        void OnHelpAboutViewLoadEventRaised(object sender, EventArgs e);
        IHelpAboutView GetHelpAboutView();
    }
}