using System;

namespace PresentationLayer.Presenters
{
    interface IMainPresenter
    {
        event EventHandler VendedoraDetailViewBindingDoneEventRaised;

        IMainView GetMainView();
    }
}