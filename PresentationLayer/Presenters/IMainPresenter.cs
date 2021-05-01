using System;

namespace PresentationLayer.Presenters
{
    public interface IMainPresenter
    {
        //event EventHandler VendedoraDetailViewBindingDoneEventRaised;
        void OnVendedorasListBtnClickEventRaised(object sender, EventArgs e);
        void OnMainViewLoadedEventRaised(object sender, EventArgs e);
        IMainView GetMainView();
        void SetMainView(IMainView mainView);
    }
}