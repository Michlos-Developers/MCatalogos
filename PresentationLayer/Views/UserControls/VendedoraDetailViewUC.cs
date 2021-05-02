using CommonComponents;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public partial class VendedoraDetailViewUC : UserControl
    {
        private AccessTypeEventArgs _accessTypeEventArgs;

        public event EventHandler<AccessTypeEventArgs> VendedoraDetailSaveBtnClickEventRaised;
        public event EventHandler VendedoraDetailCancelBtnClickEventRaised;

        public AccessTypeEventArgs AccessTypeEventArgs
        {
            get { return _accessTypeEventArgs; }
            set
            {
                if (value== _accessTypeEventArgs) return;
                _accessTypeEventArgs = value;
            }
        }
        
        public VendedoraDetailViewUC()
        {
            InitializeComponent();
            _accessTypeEventArgs = new AccessTypeEventArgs();
        }

        public void SetUpVendedoraDetailView(Dictionary<string, Binding> bindingDictionjary, AccessTypeEventArgs accessTypeEventArgs)
        {
            
        }

        public void BindingVendedoraModelToView(Dictionary<string, Binding> bindigDictionary)
        {
            
        }

        public void ClearExistingBindings()
        {
            
        }

        private void btnSalve_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
