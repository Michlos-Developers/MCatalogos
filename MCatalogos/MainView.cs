﻿using DomainLayer.Models.Modulos;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Specific.Modulos;

using MCatalogos.Commons;
using MCatalogos.Views.FormViews.Catalogos;
using MCatalogos.Views.FormViews.Configuracoes;
using MCatalogos.Views.FormViews.Estoque;
using MCatalogos.Views.FormViews.Financeiro;
using MCatalogos.Views.FormViews.Fornecedores;
using MCatalogos.Views.FormViews.PedidoVendedora;
using MCatalogos.Views.FormViews.Produtos;
using MCatalogos.Views.FormViews.Rotas;
using MCatalogos.Views.FormViews.Vendedoras;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.ModulosServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MCatalogos
{
    public partial class MainView : Form
    {
        private MainView _obj;
        private ButtonHelper buttonHelper = new ButtonHelper();
        List<Button> btnCollection = new List<Button>();

        private QueryStringServices _queryString;
        private ModulosSerivces _modulosSerivces;


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

        public MainView()
        {
            _queryString = new QueryStringServices(new QueryString());
            _modulosSerivces = new ModulosSerivces(new ModulosRepository(_queryString.GetQueryApp()));

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
            
            _obj = this;

            GenerateButtons();
            
           
        }

        private void GenerateButtons()
        {
            IEnumerable<ModulosModel> modelList = null;
            try
            {
                modelList = (IEnumerable<ModulosModel>)_modulosSerivces.GetAll();
                modelList = modelList.Where(m => m.Ativo == true).OrderByDescending(c => c.ModuloId);
                foreach (var modulo in modelList)
                {
                    Button button = new Button();
                    button = buttonHelper.GenerateButtons(modulo.Nome, modulo.ModuloId);
                    button.Click += new EventHandler(OnClickButtonMenu);
                    btnCollection.Add(button);
                    panelButtons.Controls.Add(button);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Não foi possível recuperar a lista de módulos do sistema.");
                throw new Exception(e.Message, e.InnerException);
            }


        }

        private void OnClickButtonMenu(object sender, EventArgs e)
        {
            buttonHelper.SetUnselectedButtons(btnCollection);
            Button clickedButton = sender as Button;
            buttonHelper.SetSelectedButton(clickedButton);

            switch (int.Parse(clickedButton.Tag.ToString()))
            {
                case 1:
                    PedidosListForm pedididoListForm = PedidosListForm.Instance(this);
                    pedididoListForm.WindowState = FormWindowState.Normal;
                    pedididoListForm.MdiParent = this;
                    pedididoListForm.Show();
                    break;
                case 2:
                    VendedorasListForm vendedorasListForm = VendedorasListForm.Instance(this);
                    vendedorasListForm.Text = "Cadastro de Vendedoras";
                    vendedorasListForm.WindowState = FormWindowState.Normal;
                    vendedorasListForm.MdiParent = this;
                    vendedorasListForm.Show();
                    break;
                case 3:
                    FornecedoresListForm fornecedoresListForm = FornecedoresListForm.Instance(this);
                    fornecedoresListForm.WindowState = FormWindowState.Normal;
                    fornecedoresListForm.MdiParent = this;
                    fornecedoresListForm.Show();
                    break;
                case 4:
                    CatalogosListForm catalogosListForm = CatalogosListForm.Instance(this);
                    catalogosListForm.WindowState = FormWindowState.Normal;
                    catalogosListForm.MdiParent = this;
                    catalogosListForm.Show();
                    break;
                case 5:
                    ProdutosListForm produtosListForm = ProdutosListForm.Instance(this);
                    produtosListForm.MdiParent = this;
                    produtosListForm.Show();
                    break;
                case 6:
                    FinanceiroForm financeiroForm = FinanceiroForm.Instance(this);
                    financeiroForm.MdiParent = this;
                    financeiroForm.Show();
                    break;
                case 7:
                    EstoqueListForm estoqueListForm = EstoqueListForm.Instance(this);
                    estoqueListForm.MdiParent = this;
                    estoqueListForm.Show();
                    break;
                case 8:
                    RotasFormView rotasFormView = RotasFormView.Instance(this);
                    rotasFormView.MdiParent = this;
                    rotasFormView.Show();
                    break;
                case 9:
                    //TODO: montar formulário de relatórios
                    MessageBox.Show("Relatórios");
                    break;
                case 10:
                    ConfiguracoesForm configuracoesForm = ConfiguracoesForm.Instance(this);
                    configuracoesForm.WindowState = FormWindowState.Normal;
                    configuracoesForm.MdiParent = this;
                    configuracoesForm.Show();
                    break;
            }

        }
    }
}
