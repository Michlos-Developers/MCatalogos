using DomainLayer.Models.Vendedora;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Specific.Vendedora;
using InfrastructureLayer.Validations;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.VendedoraServices;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCatalogos.Views.FormViews.PedidoVendedora
{
    public partial class SelectVendedoraForm : Form
    {

        PedidoAddForm PedidoForm;
        public VendedoraModel SelectedVendedora = new VendedoraModel();
        private List<VendedoraModel> ListVendedoras;

        private QueryStringServices _queryString;
        private VendedoraServices _vendedoraServices;

        private static SelectVendedoraForm aForm = null;
        internal static SelectVendedoraForm Instance(PedidoAddForm pedidoForm)
        {
            if (aForm == null)
            {
                aForm = new SelectVendedoraForm(pedidoForm);
            }
            return aForm;
        }

        public SelectVendedoraForm(PedidoAddForm pedidoForm)
        {
            _queryString = new QueryStringServices(new QueryString());
            _vendedoraServices = new VendedoraServices(new VendedoraRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());

            InitializeComponent();
            PedidoForm = pedidoForm;
        }

        private void CarregaListaVendedoras()
        {
            ListVendedoras = (List<VendedoraModel>)_vendedoraServices.GetAll();
        }

        private void PopulaComboBoxVendedora()
        {
            cbNome.DataSource = ListVendedoras;
            cbNome.DisplayMember = "Nome";
            cbNome.SelectedIndex = -1;

        }

        private void SelectVendedoraForm_Load(object sender, EventArgs e)
        {
            CarregaListaVendedoras();
            PopulaComboBoxVendedora();
            mTextCpf.Focus();
        }

        private void mTextCpf_Leave(object sender, EventArgs e)
        {
            string cpf = ReplaceCpf(mTextCpf.Text);
            if (!string.IsNullOrEmpty(cpf))
            {
                SelecionaVendedoraCpf(cpf);

            }
        }

        private void SelecionaVendedoraCpf(string cpf)
        {
            SelectedVendedora = ListVendedoras.Where(v => v.Cpf == cpf).FirstOrDefault<VendedoraModel>();
            if (SelectedVendedora != null)
            {
                cbNome.SelectedItem = SelectedVendedora;
            }
            else
            {
                MessageBox.Show("Vendedora Não Encontrada");
            }
        }

        private string ReplaceCpf(string cpf)
        {
            cpf = cpf.Replace(".", "");
            cpf = cpf.Replace(",", "");
            cpf = cpf.Replace("-", "");
            cpf = cpf.Trim();

            return cpf;
        }

        private void cbNome_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNome.SelectedIndex > -1)
            {
                SelectedVendedora = cbNome.SelectedItem as VendedoraModel;
                mTextCpf.Text = SelectedVendedora.Cpf;
            }
            else
            {
                mTextCpf.Text = string.Empty;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (SelectedVendedora.VendedoraId != 0)
            {
                SelectedVendedora = cbNome.SelectedItem as VendedoraModel;
                this.Close();
            }
            else
            {
                MessageBox.Show("É necessário selecionar uma vendedora", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void SelectVendedoraForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SelectedVendedora = null;
            this.Close();
        }
    }
}
