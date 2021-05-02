using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public interface IVendedoraListViewUC
    {
        event EventHandler AddNewVendedoraBtnClickEventRaised;
        event EventHandler DeleteVendedoraBtnClickEventRaised;
        event EventHandler EditVendedoraBtnClickEventRaised;
        event EventHandler VendedoraListViewLoadEventRaised;

        void LoadVendedoraListToGrid(BindingSource vendedoraListBindingSource, Dictionary<string, string> headingsDictionary, Dictionary<string, float> gridColumnWidthsDictionary, int rowHeight);
        //void ReloadVendedoraListGrid(BindingSource vendedoraListBindingSource);
    }
}