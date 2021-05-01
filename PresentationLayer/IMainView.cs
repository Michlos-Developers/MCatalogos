using System;
using System.Windows.Forms;

namespace PresentationLayer
{
    public interface IMainView
    {
        event EventHandler HelpAboutMenuClickEventRaised;
        event EventHandler MainViewLoadedEventRaised;
        event EventHandler VendedoraListBtnClickEventRaised;

        Panel GetUserControlPanel();
        void ShowMainVeiw();
        void ExpandUserControlPanel();
        void ResetUserControlPanelSizeAndLocation();
        //Panel GetOptionsPanel();
        //PictureBox GetUserInfoPictureBox();
    }
}