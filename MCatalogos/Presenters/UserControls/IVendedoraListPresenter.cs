using MCatalogos.UserControls;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCatalogos.Presenters.UserControls
{
    public interface IVendedoraListPresenter
    {
        void GetAllVendedorasListForGridLoad();
        IVendedoraListViewUC GetVendedoraListViewUC();
        void LoadAllVendedorasFromDbToGrid();
    }
}
