using DomainLayer.Models.Catalogos;
using DomainLayer.Models.PedidosVendedoras;
using DomainLayer.Models.Produtos;
using DomainLayer.Models.Vendedora;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Specific.Catalogo;
using InfrastructureLayer.DataAccess.Repositories.Specific.PedidoVendedora;
using InfrastructureLayer.DataAccess.Repositories.Specific.Vendedora;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.CatalogoServices;
using ServiceLayer.Services.PedidosVendedorasServices;
using ServiceLayer.Services.ProdutoServices;
using ServiceLayer.Services.RotaServices;
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
    public partial class PedidoAddForm : Form
    {
        PedidosVendedorasModel PedidoModel = new PedidosVendedorasModel();
        public VendedoraModel VendedoraModel = new VendedoraModel();
        private CampanhaModel SelectedCampanha = null;
        private CatalogoModel SelectedCatalogo = null;

        private ProdutoModel ProdutoToAddGrid = null;

        private RotaModel rota = new RotaModel();
        private RotaLetraModel rotaLetra = new RotaLetraModel();
        PedidosListForm PedidoListForm;

        private List<CatalogoModel> ListCatalogos = new List<CatalogoModel>();
        private List<CampanhaModel> ListCampanhas = new List<CampanhaModel>();
        private List<PedidosVendedorasModel> ListPedidos = new List<PedidosVendedorasModel>();
        private List<DetalhePedidoModel> DetalhesPedido = new List<DetalhePedidoModel>();

        private ProdutoServices _produtoServices;
        private PedidosVendedorasServices _pedidoServices;
        private VendedoraServices _vendedoraServices;
        private RotaLetraServices _rotaLetraServices;
        private CatalogoServices _catalogoServices;
        private CampanhaServices _campanhaServices;
        private RotaServices _rotaServices;
        private QueryStringServices _queryString;

        public PedidoAddForm(VendedoraModel vendedoraModel, PedidosVendedorasModel pedidoModel, PedidosListForm pedidosListForm)
        {

            _queryString = new QueryStringServices(new QueryString());
            _pedidoServices = new PedidosVendedorasServices(new PedidoVendedoraRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _vendedoraServices = new VendedoraServices(new VendedoraRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _rotaLetraServices = new RotaLetraServices(new RotaLetraRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _rotaServices = new RotaServices(new RotaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _catalogoServices = new CatalogoServices(new CatalogoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _campanhaServices = new CampanhaServices(new CampanhaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            InitializeComponent();
            VendedoraModel = vendedoraModel;
            PedidoModel = pedidoModel;
            PedidoListForm = pedidosListForm;
            ListPedidos = (List<PedidosVendedorasModel>)_pedidoServices.GetAll();

        }

        private void PedidoAddForm_Load(object sender, EventArgs e)
        {
            LoadComboBoxCatalogos();
            if (PedidoModel == null)
            {

                VendedoraModel = SelecionarVendedora();
                if (VendedoraTemPedidoAberto(VendedoraModel))
                {
                    MessageBox.Show("A Vendedora selecionada já possui um pedido em aberto\nNão é pertido que a vendedora tenha mais de um pedido em Aberto.\nEdite o pedido ou finalize-o");
                    this.Close();
                }
                else
                {
                    Text = "Adicionando Novo Pedido - Vendedora: " + VendedoraModel.Nome;
                    PreencheCampos(VendedoraModel, null);
                }
            }
            else
            {
                VendedoraModel = _vendedoraServices.GetById(PedidoModel.VendedoraId);
                PreencheCampos(VendedoraModel, PedidoModel);
                LoadDetalhesPedido(PedidoModel);

            }
        }

        private void LoadComboBoxCatalogos()
        {
            ListCatalogos = (List<CatalogoModel>)_catalogoServices.GetAll();
            cbCatalogo.DataSource = ListCatalogos;
            cbCatalogo.DisplayMember = "Nome";
            cbCatalogo.SelectedIndex = -1;
        }
        private void cbCatalogo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCatalogo.SelectedIndex > -1)
            {

                SelectedCatalogo = cbCatalogo.SelectedItem as CatalogoModel;
                LoadComboBoxCampanhas(SelectedCatalogo);
                //HabilitaDesabilitaEdicaoDGV(SelectedCatalogo);
            }
            else
            {
                cbCampanha.DataSource = null;
            }
        }

        //private void HabilitaDesabilitaEdicaoDGV(CatalogoModel selectedCatalogo)
        //{
        //    if (selectedCatalogo.ImportaProdutos)
        //    {
        //        gbAddItem.Enabled = true;
        //        dgvDetalhePedido.ShowEditingIcon = false;
        //        dgvDetalhePedido.AllowUserToAddRows = false;
        //        dgvDetalhePedido.AllowUserToDeleteRows = false;
        //        dgvDetalhePedido.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        //    }
        //    else
        //    {
        //        gbAddItem.Enabled = false;
        //        dgvDetalhePedido.ShowEditingIcon = true;
        //        dgvDetalhePedido.AllowUserToAddRows = true;
        //        dgvDetalhePedido.AllowUserToDeleteRows = true;
        //        dgvDetalhePedido.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
        //    }
        //}

        private void LoadDataGridView()
        {

        }

        private void LoadComboBoxCampanhas(CatalogoModel catalogo)
        {
            if (catalogo != null)
            {

                ListCampanhas = (List<CampanhaModel>)_campanhaServices.GetByCatalogoModel(catalogo);
                cbCampanha.DataSource = ListCampanhas;
                cbCampanha.DisplayMember = "Nome";
                cbCampanha.SelectedItem = ListCampanhas.Last();
            }
            else
            {
                cbCampanha.SelectedIndex = -1;
                cbCampanha.Text = string.Empty;
            }
        }

        private void PreencheCampos(VendedoraModel vendedora, PedidosVendedorasModel pedido)
        {
            if (pedido != null)
            {

            }

            if (vendedora != null)
            {
                if (!VendedoraTemPedidoAberto(vendedora))
                {

                    rota = _rotaServices.GetByVendedoraId(vendedora.VendedoraId);
                    rotaLetra = _rotaLetraServices.GetById(vendedora.RotaLetraId);
                    mTextCpfVendedora.Text = vendedora.Cpf;
                    textNomeVendedora.Text = vendedora.Nome;
                    textRotaVendedora.Text = rotaLetra.RotaLetra + "-" + rota.Numero.ToString();
                }
                else
                {
                    MessageBox.Show("A Vendedora selecionada já possui um pedido em aberto\nNão é pertido que a vendedora tenha mais de um pedido em Aberto.\nEdite o pedido ou finalize-o");
                    this.Close();
                }
            }
        }

        private void LoadDetalhesPedido(PedidosVendedorasModel pedidoModel)
        {
            throw new NotImplementedException();
        }

        private VendedoraModel SelecionarVendedora()
        {
            SelectVendedoraForm selectVendedoraForm = SelectVendedoraForm.Instance(this);
            selectVendedoraForm.WindowState = FormWindowState.Normal;
            selectVendedoraForm.ShowDialog();

            return selectVendedoraForm.SelectedVendedora;

        }

        private static PedidoAddForm aForm = null;
        internal static PedidoAddForm Instance(VendedoraModel vendedoraModel, PedidosVendedorasModel pedidoModel, PedidosListForm pedidosListForm)
        {
            if (aForm == null)
            {
                aForm = new PedidoAddForm(vendedoraModel, pedidoModel, pedidosListForm);
            }

            return aForm;
        }

        private void PedidoAddForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (PedidoModel == null)
            {


                if (!VendedoraTemPedidoAberto(VendedoraModel))
                {


                    PedidoModel = new PedidosVendedorasModel();
                    PedidoModel.VendedoraId = VendedoraModel.VendedoraId;
                    PedidoModel.StatusPed = ((int)StatusPedido.Aberto);
                    _pedidoServices.Add(PedidoModel);
                }

            }

            if (Disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            //TODO: recarregar a lista de pedidos.
            base.Dispose(Disposing);
            aForm = null;
        }

        private bool VendedoraTemPedidoAberto(VendedoraModel vendedora)
        {
            IEnumerable<PedidosVendedorasModel> PedidosCollection = ListPedidos.Where(ped => ped.VendedoraId == vendedora.VendedoraId);
            PedidosCollection = PedidosCollection.Where(ped => ped.StatusPed == ((int)StatusPedido.Aberto));

            if (PedidosCollection.Any())
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textReferencia_Leave(object sender, EventArgs e)
        {
            if (cbCatalogo.SelectedIndex > -1)
            {


                if (!string.IsNullOrEmpty(textReferencia.Text))
                {
                    ProdutoToAddGrid = _produtoServices.GetByReference(textReferencia.Text);
                    if (ProdutoToAddGrid == null)
                    {
                        if (ProdutoToAddGrid.CatalogoId != SelectedCatalogo.CatalogoId)
                        {
                            MessageBox.Show("Produto não pertence ao catálogo selecionado.");
                        }
                        else
                        {
                            AddProdutoInDGV(ProdutoToAddGrid);
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Preencha a referência do produto!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textReferencia.Focus();
                }
            }
        }

        private void AddProdutoInDGV(ProdutoModel produtoToAddGrid)
        {
            throw new NotImplementedException();
        }
    }
}
