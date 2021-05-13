using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCatalogos.UserControls
{
    public interface IVendedoraListViewUC
    {
        event EventHandler DisplayAllVendedorasBtnClickEventRaised;
        event EventHandler LoadOfAllVendedorasIntoGridCompletedEventRaised;
        event EventHandler VendedoraListViewUCLoadEventRaised;

        void LoadAllVendedorasListToGrid(BindingSource _vendedoraListBindingSource, Dictionary<string, string> headingDictionary, Dictionary<string, float> gridColumnWidthsDictionary, int rowHeight);
        void RaisEventDisplayAllVendedorasBtnClicked(EventArgs e);
        void SetGridColumnWidths(Dictionary<string, float> gridColumnWidthsDictionary);
        void SetGridHeaderText(Dictionary<string, string> headingsDictionary);
        void ShowView();

        void SetParentSizeLocationAnchor(Panel parentPanel);
    }
}
