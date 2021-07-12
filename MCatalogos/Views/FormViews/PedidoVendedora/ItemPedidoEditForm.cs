using DomainLayer.Models.PedidosVendedoras;
using DomainLayer.Models.Produtos;
using DomainLayer.Models.Tamanho;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Specific.PedidoVendedora;
using InfrastructureLayer.DataAccess.Repositories.Specific.Produto;
using InfrastructureLayer.DataAccess.Repositories.Specific.Tamanho;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.DetalhePedidoServices;
using ServiceLayer.Services.ProdutoServices;
using ServiceLayer.Services.TamanhoServices;

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
    public partial class ItemPedidoEditForm : Form
    {
        private QueryStringServices _queryString;
        private DetalhePedidoSerivces _detalheServices;
        private TamanhoServices _tamanhoServices;
        private ProdutoServices _produtoServices;




        public DetalhePedidoModel ItemPedido;
        private List<TamanhosModel> ListTamanhos;
        private ProdutoModel Produto;

        public ItemPedidoEditForm(DetalhePedidoModel itemPedido)
        {
            _queryString = new QueryStringServices(new QueryString());
            _detalheServices = new DetalhePedidoSerivces(new DetalhePedidoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _tamanhoServices = new TamanhoServices(new TamanhoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _produtoServices = new ProdutoServices(new ProdutoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());


            InitializeComponent();
            ItemPedido = itemPedido;
        }

        private void ItemPedidoEditForm_Load(object sender, EventArgs e)
        {


            Produto = _produtoServices.GetById(ItemPedido.ProdutoId);
            LoadComboBoxTamanho(Produto);

            textReferencia.Text = ItemPedido.Referencia;
            textDescricao.Text = Produto.Descricao;
            textQtd.Text = ItemPedido.Quantidade.ToString();
            if (ListTamanhos != null)
                cbTamanho.SelectedItem = ListTamanhos.Where(tamanho => tamanho.Tamanho == ItemPedido.Tamanho);

        }

        private void LoadComboBoxTamanho(ProdutoModel produto)
        {
            List<TamanhosModel> tamanhos = (List<TamanhosModel>)_tamanhoServices.GetByProdutoModel(produto);
            if (tamanhos.Count > 0)
            {
                ListTamanhos = tamanhos;
                cbTamanho.Enabled = true;
                cbTamanho.DataSource = ListTamanhos;
                cbTamanho.DisplayMember = "Tamanho";
            }
            else
            {
                cbTamanho.Items.Clear();
                cbTamanho.Enabled = false;
                cbTamanho.Text = string.Empty;
            }
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ItemPedido.Quantidade = int.Parse(textQtd.Text);
            ItemPedido.Tamanho = cbTamanho.Text;
            SaveItemPedido(ItemPedido);
            this.Close();


        }

        private void SaveItemPedido(DetalhePedidoModel itemPedido)
        {
            try
            {
                _detalheServices.Update(itemPedido);
                MessageBox.Show("Item alterado com sucesso");

            }
            catch (Exception e)
            {
                MessageBox.Show($"Não foi possível salvar alterações do item do pedido\nEntre em contato com o Suporte.\nErrorMessage: {e.Message}\nStackTrace: {e.StackTrace}", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
