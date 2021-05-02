using PresentationLayer.Views.UserControls;

using ServiceLayer.Services.VendedoraServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Presenters.UserControls
{
    public class VendedoraListPresenter
    {
        public event EventHandler VendedoraListYesDeleteBtnClickEventRaised;

        private IVendedoraListViewUC _vendedoraListViewUC;
        private IVendedoraService _vendedoraServices;
    }
}
