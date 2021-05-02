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
    public partial class VendedoraListViewUC : BaseUserControlUC, IVendedoraListViewUC
    {
        public event EventHandler VendedoraListViewLoadEventRaised;
        public event EventHandler EditVendedoraBtnClickEventRaised;
        public event EventHandler AddNewVendedoraBtnClickEventRaised;
        public event EventHandler DeleteVendedoraBtnClickEventRaised;

        public VendedoraListViewUC()
        {
            InitializeComponent();
        }

        private void VendedoraListViewUC_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, VendedoraListViewLoadEventRaised, e);
        }

        public void ReloadVendedoraListGrid(BindingSource vendedoraListBindingSource)
        {
            this.VendedoraListDataGridView.DataSource = vendedoraListBindingSource;
        }

        public void LoadVendedoraListToGrid(BindingSource vendedoraListBindingSource,
            Dictionary<string, string> headingsDictionary,
            Dictionary<string, float> gridColumnWidthsDictionary,
            int rowHeight)
        {
            VendedoraListDataGridView.RowTemplate.Height = 32;
            VendedoraListDataGridView.DataSource = vendedoraListBindingSource;

            SetGridHeaderText(headingsDictionary);
            VendedoraListDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            VendedoraListDataGridView.AllowUserToAddRows = false;
            VendedoraListDataGridView.ReadOnly = true;

            int optionsWidth = 0;
            SetGridColumnWidths(gridColumnWidthsDictionary, ref optionsWidth);

        }

        private void SetGridHeaderText(Dictionary<string, string> headingsDictionary)
        {
            VendedoraListDataGridView.Columns["VendedoraId"].HeaderText = headingsDictionary["VendedoraId"];
            VendedoraListDataGridView.Columns["Nome"].HeaderText = headingsDictionary["Nome"];
            VendedoraListDataGridView.Columns["Cpf"].HeaderText = headingsDictionary["Cpf"];
            //VendedoraListDataGridView.Columns["Bairro"].HeaderText = headingsDictionary["Bairro"];


        }

        private void SetGridColumnWidths(Dictionary<string, float> gridColumWidthsDictionary, ref int optionsWidth)
        {
            int GridWidth = (VendedoraListDataGridView.Width - VendedoraListDataGridView.RowHeadersWidth - SystemInformation.VerticalScrollBarWidth);

            VendedoraListDataGridView.Columns["VendedoraId"].Width = (int)((GridWidth) * gridColumWidthsDictionary["VendedoraId"]);
            VendedoraListDataGridView.Columns["Nome"].Width = (int)((GridWidth) * gridColumWidthsDictionary["Nome"]);
            VendedoraListDataGridView.Columns["Cpf"].Width = (int)((GridWidth) * gridColumWidthsDictionary["Cpf"]);

            optionsWidth = 0;

        }

        private void VendedoraListDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OnAddNewVendedoraBtnClick(sender, e);
        }

        private void OnAddNewVendedoraBtnClick(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, AddNewVendedoraBtnClickEventRaised, e);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            OnUpdateSelectedVendedoraInGridBtnClick(sender, e);
        }

        private void OnUpdateSelectedVendedoraInGridBtnClick(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, EditVendedoraBtnClickEventRaised, e);
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, DeleteVendedoraBtnClickEventRaised, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void VendedoraListDataGridView_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void VendedoraListDataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
