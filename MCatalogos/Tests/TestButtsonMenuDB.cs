using DomainLayer.Models.Modulos;

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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCatalogos.Tests
{
    public partial class TestButtsonMenuDB : Form
    {
        MainView MainView = new MainView();
        BtnClass btn = new BtnClass();
        List<Button> btnCollection = new List<Button>();

        QueryStringServices _queryString;
        private ModulosSerivces _modulosSerivces;
        ButtonHelper buttonHelper = new ButtonHelper();
        public TestButtsonMenuDB()
        {
            _queryString = new QueryStringServices(new QueryString());
            _modulosSerivces = new ModulosSerivces(new ModulosRepository(_queryString.GetQueryApp()));

            InitializeComponent();
        }

        private void TestButtsonMenuDB_Load(object sender, EventArgs e)
        {
            IEnumerable<ModulosModel> modelList = null;
            try
            {
                modelList = (IEnumerable<ModulosModel>)_modulosSerivces.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possível recuperar a lista de Módulos do sistema.\nMessage: {ex.Message}", "Erro Access List");
            }

            modelList = modelList.Where(m => m.Ativo == true).OrderByDescending(c => c.ModuloId);

            foreach (var modulo in modelList)
            {

                BtnClass btn = new BtnClass();
                Button button = new Button();
                button = btn.generateButtons(modulo.Nome, modulo.ModuloId);
                button.Click += new EventHandler(onClickButton);
                btnCollection.Add(button);
                panelButtons.Controls.Add(button);
            }
        }

        private void onClickButton(object sender, EventArgs e)
        {

            buttonHelper.SetUnselectedButtons(btnCollection);
            Button clickedButton = sender as Button;
            buttonHelper.SetSelectedButton(clickedButton);
            
            switch (int.Parse(clickedButton.Tag.ToString()))
            {
                case 1:
                    //PedidosListForm pedididoListForm = PedidosListForm.Instance(this);
                    //pedididoListForm.WindowState = FormWindowState.Normal;
                    //pedididoListForm.MdiParent = this;
                    //pedididoListForm.Show();
                    break;
                case 2:
                    //VendedorasListForm vendedorasListForm = VendedorasListForm.Instance(this);
                    //vendedorasListForm.Text = "Cadastro de Vendedoras";
                    //vendedorasListForm.WindowState = FormWindowState.Normal;
                    //vendedorasListForm.MdiParent = this;
                    //vendedorasListForm.Show();
                    break;
                case 3:
                    //FornecedoresListForm fornecedoresListForm = FornecedoresListForm.Instance(this);
                    //fornecedoresListForm.WindowState = FormWindowState.Normal;
                    //fornecedoresListForm.MdiParent = this;
                    //fornecedoresListForm.Show();
                    break;
                case 4:
                    //CatalogosListForm catalogosListForm = CatalogosListForm.Instance(this);
                    //catalogosListForm.WindowState = FormWindowState.Normal;
                    //catalogosListForm.MdiParent = this;
                    //catalogosListForm.Show();
                    break;
                case 5:
                    //ProdutosListForm produtosListForm = ProdutosListForm.Instance(this);
                    //produtosListForm.MdiParent = this;
                    //produtosListForm.Show();
                    break;
                case 6:
                    //FinanceiroForm financeiroForm = FinanceiroForm.Instance(this);
                    //financeiroForm.MdiParent = this;
                    //financeiroForm.Show();
                    break;
                case 7:
                    //EstoqueListForm estoqueListForm = EstoqueListForm.Instance(this);
                    //estoqueListForm.MdiParent = this;
                    //estoqueListForm.Show();
                    break;
                case 8:
                    //RotasFormView rotasFormView = RotasFormView.Instance(this);
                    //rotasFormView.MdiParent = this;
                    //rotasFormView.Show();
                    break;
                case 9:
                    //TODO: montar formulário de relatórios
                    MessageBox.Show("Relatórios");
                    break;
                case 10:
                    //ConfiguracoesForm configuracoesForm = ConfiguracoesForm.Instance(this);
                    //configuracoesForm.WindowState = FormWindowState.Normal;
                    //configuracoesForm.MdiParent = this;
                    //configuracoesForm.Show();
                    break;
            }

            
        }



        
    }
}
