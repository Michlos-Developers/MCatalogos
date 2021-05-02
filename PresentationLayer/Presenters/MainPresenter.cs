
using PresentationLayer.Views;
using PresentationLayer.Views.UserControls;

using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Presenters
{
    public class MainPresenter : BasePresenter, IMainPresenter
    {
        //public event EventHandler VendedoraDetailViewBindingDoneEventRaised;

        IMainView _mainView;
        Panel _userControlPanel;
        private IVendedoraListViewUC _vendedoraListViewUC;
        private IHelpAboutPresenter _helpAboutPresenter;

        private List<UserControl> _userControlList;

        public IMainView GetMainView() { return _mainView; }
        public void SetMainView(IMainView mainView) { _mainView = mainView; }

        public MainPresenter()
        {

        }

        public MainPresenter(IMainView mainView, IHelpAboutPresenter helpAboutPresenter, IErrorMessageView errorMessageView)
            : base(errorMessageView)
        {
            _mainView = mainView;
            _userControlPanel = _mainView.GetUserControlPanel();
            _helpAboutPresenter = helpAboutPresenter;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _mainView.MainViewLoadedEventRaised += new EventHandler(OnMainViewLoadedEventRaised);
            _mainView.HelpAboutMenuClickEventRaised += new EventHandler(OnHelpAboutMenuClickEventRaised);
        }

        public void OnMainViewLoadedEventRaised(object sender, EventArgs e)
        {
            _userControlList = new List<UserControl>();
            //_userControlList.Add((UserControl)_vendedoraListPresenter.GetVendedoraListViewUC());
            //_userControlList.Add((UserControl)_vendedoraDetailPresenter.GetVenedoraDetailViewUC());
        }

        public void OnHelpAboutMenuClickEventRaised(object sender, EventArgs e)
        {
            _helpAboutPresenter.GetHelpAboutView().ShowHelpAboutView();
        }

        public void OnVendedorasListBtnClickEventRaised(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

       
    }
}

//TODO: REVER ESSA CLASSE TODA DEPOIS QUE CRIAR AS CLASSES PARA VENDEDORA