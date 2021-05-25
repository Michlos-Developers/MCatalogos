using MCatalogos.Commons;
using MCatalogos.UserControls;
using MCatalogos.Views.FormViews;
using MCatalogos.Views.FormViews.Catalogos;
using MCatalogos.Views.FormViews.Configuracoes;
using MCatalogos.Views.FormViews.Fornecedores;
using MCatalogos.Views.FormViews.Vendedoras;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace MCatalogos
{
    public partial class MainView : Form
    {
        private MainView _obj;


        public MainView Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new MainView();
                }
                return _obj;
            }

        }



        public Button ButtonVendedoras
        {
            get { return btnVendedoras; }
            set { btnVendedoras = value; }
        }

        public Button ButtonPedidos
        {
            get { return btnPedidos; }
            set { btnPedidos = value; }
        }

        public Button ButtonFornecedores
        {
            get { return btnFornecedores; }
            set { btnFornecedores = value; }
        }

        public Button ButtonCatalogos
        {
            get { return btnCatalogos; }
            set { btnCatalogos = value; }
        }

        public Button ButtonFinanceiro
        {
            get { return btnFinanceiro; }
            set { btnFinanceiro = value; }
        }

        public Button ButtonEstoque
        {
            get { return btnEstoque; }
            set { btnEstoque = value; }
        }

        public Button ButtonRotas
        {
            get { return btnRotas; }
            set { btnRotas = value; }
        }
        public Button ButtonConfiguracoes
        {
            get { return btnConfiguracoes; }
            set { btnConfiguracoes = value; }
        }




        public MainView()
        {
            IsMdiContainer = true;
            InitializeComponent();
        }

        private void pictureMenuMobile_Click(object sender, EventArgs e)
        {
            if (panelMenu.Width == 48)
            {
                panelMenu.Width = 168;
            }
            else
            {
                panelMenu.Width = 48;
            }
        }

        private void pictureMenuMobile_MouseHover(object sender, EventArgs e)
        {
            if (panelMenu.Width == 48)
            {
                toolTipMain.SetToolTip(pictureMenuMobile, "Expandir");
            }
            else
            {
                toolTipMain.SetToolTip(pictureMenuMobile, "Reduzir");
            }
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            SetUnselectedButtons();
            _obj = this;
           
        }

        public void SetUnselectedButtons()
        {
            List<Button> buttons = new List<Button>();
            buttons.Add(ButtonVendedoras);
            buttons.Add(ButtonPedidos);
            buttons.Add(ButtonFornecedores);
            buttons.Add(ButtonCatalogos);
            buttons.Add(ButtonFinanceiro);
            buttons.Add(ButtonEstoque);
            buttons.Add(ButtonRotas);
            buttons.Add(ButtonConfiguracoes);

            ButtonHelper bh = new ButtonHelper();
            bh.SetUnselectedButtons(buttons);
        }

        private void SetSelectedButton(Button button)
        {
            ButtonHelper bh = new ButtonHelper();
            bh.SetSelectedButton(button);

        }

        private void btnVendedoras_Click(object sender, EventArgs e)
        {

            SetUnselectedButtons();
            SetSelectedButton(btnVendedoras);

            VendedorasListForm formVendedorasList = VendedorasListForm.Instance(this);
            formVendedorasList.Text = "Cadastro de Vendedoras";
            formVendedorasList.WindowState = FormWindowState.Normal;
            formVendedorasList.MdiParent = this;
            formVendedorasList.Show();
        }

        private void btnFornecedores_Click(object sender, EventArgs e)
        {
            SetUnselectedButtons();
            SetSelectedButton(btnFornecedores);
            FornecedoresListForm formFornecedoresList = FornecedoresListForm.Instance(this);
            formFornecedoresList.WindowState = FormWindowState.Normal;
            formFornecedoresList.MdiParent = this;
            formFornecedoresList.Show();

        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {

        }

        private void btnCatalogos_Click(object sender, EventArgs e)
        {
            SetUnselectedButtons();
            SetSelectedButton(btnCatalogos);

            CatalogosListForm formCatalogosList = CatalogosListForm.Instance(this);
            formCatalogosList.WindowState = FormWindowState.Normal;
            formCatalogosList.MdiParent = this;
            formCatalogosList.Show();
        }

        private void btnConfiguracoes_Click(object sender, EventArgs e)
        {
            SetUnselectedButtons();
            SetSelectedButton(btnConfiguracoes);

            ConfiguracoesForm configuracoesForm = ConfiguracoesForm.Instance(this);
            configuracoesForm.WindowState = FormWindowState.Normal;
            configuracoesForm.MdiParent = this;
            configuracoesForm.Show();
        }
    }
}
