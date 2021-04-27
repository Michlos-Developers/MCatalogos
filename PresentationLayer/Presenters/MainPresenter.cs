using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Presenters
{
    public class MainPresenter : IMainPresenter
    {
        public event EventHandler VendedoraDetailViewBindingDoneEventRaised;

        IMainView _mainView;

        public IMainView GetMainView() { return _mainView; }
        public MainPresenter(IMainView mainView)
        {
            _mainView = mainView;
        }
    }
}
