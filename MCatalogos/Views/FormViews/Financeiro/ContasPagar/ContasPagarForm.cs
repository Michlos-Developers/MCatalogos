using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCatalogos.Views.FormViews.Financeiro.ContasPagar
{
    public partial class ContasPagarForm : Form
    {
        #region INSTANCE TREATMENT
        private static ContasPagarForm aForm = null;
        internal static ContasPagarForm Instance(FinanceiroForm financeiroForm)
        {
            if (aForm == null)
            {
                aForm = new ContasPagarForm(financeiroForm);
            }
            else
            {
                aForm.BringToFront();
            }
            return aForm;
        }
        private void ContasPagarForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }

            base.Dispose(Disposing);
            aForm = null;
        }

        #endregion

        private FinanceiroForm FinanceiroForm;
        private List<string> MonthsList = new List<string>();
        public ContasPagarForm(FinanceiroForm financeiroForm)
        {
            InitializeComponent();
            FinanceiroForm = financeiroForm;
        }


        private void LoadComboBoxMonths()
        {

            for (int i = 1; i <= 13; i++)
            {
                MonthsList.Add(DateTimeFormatInfo.CurrentInfo.GetMonthName(i).ToUpper());
            }

            cbMesComercial.DataSource = MonthsList;
            cbMesComercial.SelectedItem = DateTimeFormatInfo.CurrentInfo.GetMonthName(DateTime.Now.Month).ToUpper();
        }

        #region EVENT BUTTONS
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void ContasPagarForm_Load(object sender, EventArgs e)
        {
            LoadComboBoxMonths();
        }
    }

}
