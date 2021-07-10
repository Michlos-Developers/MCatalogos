using DomainLayer.Models.Catalogos;
using DomainLayer.Models.PedidosVendedoras;
using DomainLayer.Models.Produtos;
using DomainLayer.Models.Tamanho;
using DomainLayer.Models.Vendedora;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Specific.Catalogo;
using InfrastructureLayer.DataAccess.Repositories.Specific.PedidoVendedora;
using InfrastructureLayer.DataAccess.Repositories.Specific.Produto;
using InfrastructureLayer.DataAccess.Repositories.Specific.Tamanho;
using InfrastructureLayer.DataAccess.Repositories.Specific.Vendedora;

using MCatalogos.Views.FormViews.Produtos;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.CatalogoServices;
using ServiceLayer.Services.DetalhePedidoServices;
using ServiceLayer.Services.PedidosVendedorasServices;
using ServiceLayer.Services.ProdutoServices;
using ServiceLayer.Services.RotaServices;
using ServiceLayer.Services.TamanhoServices;
using ServiceLayer.Services.VendedoraServices;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCatalogos.Views.FormViews.PedidoVendedora
{
    public partial class PedidoAddForm : Form
    {
        PedidosListForm PedidoListForm;
        PedidosVendedorasModel PedidoModel = new PedidosVendedorasModel();
        public VendedoraModel VendedoraModel = new VendedoraModel();
        private CampanhaModel SelectedCampanha = null;
        private CatalogoModel SelectedCatalogo = null;

        private ProdutoModel ProdutoToAddGrid = null;
        private DetalhePedidoModel ItemPedido = new DetalhePedidoModel();

        private RotaModel rota = new RotaModel();
        private RotaLetraModel rotaLetra = new RotaLetraModel();

        private List<TamanhosModel> ListTamanhos = new List<TamanhosModel>();
        private List<CatalogoModel> ListCatalogos = new List<CatalogoModel>();
        private List<CampanhaModel> ListCampanhas = new List<CampanhaModel>();
        private List<PedidosVendedorasModel> ListPedidos = new List<PedidosVendedorasModel>();
        private List<DetalhePedidoModel> ListItemsDetalhe = new List<DetalhePedidoModel>();

        private QueryStringServices _queryString;
        private TamanhoServices _tamanhoServices;
        private DetalhePedidoSerivces _detalheServices;
        private ProdutoServices _produtoServices;
        private PedidosVendedorasServices _pedidoServices;
        private VendedoraServices _vendedoraServices;
        private RotaLetraServices _rotaLetraServices;
        private RotaServices _rotaServices;
        private CatalogoServices _catalogoServices;
        private CampanhaServices _campanhaServices;

        private static PedidoAddForm aForm = null;
        internal static PedidoAddForm Instance(VendedoraModel vendedoraModel, PedidosVendedorasModel pedidoModel, PedidosListForm pedidosListForm)
        {
            if (aForm == null)
            {
                aForm = new PedidoAddForm(vendedoraModel, pedidoModel, pedidosListForm);
            }

            return aForm;
        }

        public PedidoAddForm(VendedoraModel vendedoraModel, PedidosVendedorasModel pedidoModel, PedidosListForm pedidosListForm)
        {


            _queryString = new QueryStringServices(new QueryString());
            _tamanhoServices = new TamanhoServices(new TamanhoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _detalheServices = new DetalhePedidoSerivces(new DetalhePedidoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _produtoServices = new ProdutoServices(new ProdutoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
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
            { //NOVO PEDIDO

                VendedoraModel = SelecionarVendedora();
                if (VendedoraTemPedidoAberto(VendedoraModel))
                {
                    MessageBox.Show("A Vendedora selecionada já possui um pedido em aberto\nNão é pertido que a vendedora tenha mais de um pedido em Aberto.\nEdite o pedido ou finalize-o");
                    this.Close();
                }
                else
                {
                    Text = "Adicionando Novo Pedido - Vendedora: " + VendedoraModel.Nome;
                    SalvarPedido(VendedoraModel);
                    PreencheCampos(VendedoraModel, PedidoModel);

                }
            }
            else
            { //EDIT PEDIDO
                PreencheCampos(VendedoraModel, PedidoModel);
                LoadDetalhesPedido(PedidoModel, null);

            }
        }
        private VendedoraModel SelecionarVendedora()
        {
            SelectVendedoraForm selectVendedoraForm = SelectVendedoraForm.Instance(this);
            selectVendedoraForm.WindowState = FormWindowState.Normal;
            selectVendedoraForm.ShowDialog();

            return selectVendedoraForm.SelectedVendedora;

        }

        private void LoadComboBoxCatalogos()
        {
            ListCatalogos = (List<CatalogoModel>)_catalogoServices.GetAll();

            cbCatalogo.ValueMember = "Nome";
            cbCatalogo.DisplayMember = "Nome";
            cbCatalogo.Items.Clear();
            cbCatalogo.Items.Add("== Todos ==");
            foreach (CatalogoModel model in ListCatalogos)
            {
                if (model.Ativo)
                    cbCatalogo.Items.Add(model);
            }
            cbCatalogo.SelectedIndex = 0;
        }
        private void cbCatalogo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCatalogo.SelectedIndex > 0)
            {

                SelectedCatalogo = cbCatalogo.SelectedItem as CatalogoModel;
                LoadComboBoxCampanhas(SelectedCatalogo);
                LoadDetalhesPedido(PedidoModel, SelectedCatalogo);
                gbAddItem.Enabled = true;
            }
            else
            {
                LoadDetalhesPedido(PedidoModel, null);
                gbAddItem.Enabled = false;
                cbCampanha.DataSource = null;




            }
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
                cbCampanha.DataSource = null;
                //cbCampanha.SelectedIndex = -1;
                cbCampanha.Text = string.Empty;
            }
        }

        private void PreencheCampos(VendedoraModel vendedora, PedidosVendedorasModel pedido)
        {
            rota = _rotaServices.GetByVendedoraId(vendedora.VendedoraId);
            rotaLetra = _rotaLetraServices.GetById(vendedora.RotaLetraId);
            mTextCpfVendedora.Text = vendedora.Cpf;
            textNomeVendedora.Text = vendedora.Nome;
            textRotaVendedora.Text = rotaLetra.RotaLetra + "-" + rota.Numero.ToString();

            if (pedido != null)
            {
                //EDITA PEDIDO
                LoadDetalhesPedido(pedido, null); //preenche com todos os catálogos
            }
            else
            {
                //NOVO PEDIDO
                if (VendedoraTemPedidoAberto(vendedora))
                {
                    MessageBox.Show("A Vendedora selecionada já possui um pedido em aberto\nNão é pertido que a vendedora tenha mais de um pedido em Aberto.\nEdite o pedido ou finalize-o");
                    this.Close();
                }
            }
        }

        private void LoadDetalhesPedido(PedidosVendedorasModel pedidoModel, CatalogoModel catalogoModel)
        {

            if (catalogoModel != null)
            {
                //SELECIONOU O CATÁLOGO NO COMBOBOX
                ListItemsDetalhe = (List<DetalhePedidoModel>)_detalheServices.GetAllByPedidoCatalogo(pedidoModel, catalogoModel);
            }
            else
            {
                ListItemsDetalhe = (List<DetalhePedidoModel>)_detalheServices.GetAllByPedido(pedidoModel);

            }

            DataTable tableDetalhes = new DataTable();
            DataColumn column;
            DataRow row;


            //COLUMN 0
            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "DetalheId";
            tableDetalhes.Columns.Add(column);

            //COLUMN 1
            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "PedidoId";
            tableDetalhes.Columns.Add(column);

            //COLUMN 2
            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "CatalogoId";
            tableDetalhes.Columns.Add(column);

            //COLUMN 3
            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "ProdutoId";
            tableDetalhes.Columns.Add(column);

            //COLUMN 4
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Catalogo";
            tableDetalhes.Columns.Add(column);

            //COLUMN 5
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Referencia";
            tableDetalhes.Columns.Add(column);


            //COLUMN 6
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Descricao";
            tableDetalhes.Columns.Add(column);


            //COLUMN 7
            column = new DataColumn();
            column.DataType = Type.GetType("System.Double");
            column.ColumnName = "MargemVendedora";
            tableDetalhes.Columns.Add(column);

            //COLUMN 8
            column = new DataColumn();
            column.DataType = Type.GetType("System.Double");
            column.ColumnName = "MargemDistribuidor";
            tableDetalhes.Columns.Add(column);

            //COLUMN 9
            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "Quantidade";
            tableDetalhes.Columns.Add(column);

            //COLUMN 10
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Tamanho";
            tableDetalhes.Columns.Add(column);

            //COLUMN 11
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "ValorProduto";
            tableDetalhes.Columns.Add(column);

            //COLUMN 12
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "ValorTotalItem";
            tableDetalhes.Columns.Add(column);

            //COLUMN 13
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "ValorLucroVendedoraItem";
            tableDetalhes.Columns.Add(column);

            //COLUMN 14
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "ValorLucroDistribuidorItem";
            tableDetalhes.Columns.Add(column);

            //COLUMN 15
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "ValorPagarForencedorItem";
            tableDetalhes.Columns.Add(column);

            //COLUMN 16
            column = new DataColumn();
            column.DataType = Type.GetType("System.Boolean");
            column.ColumnName = "Faltou";
            tableDetalhes.Columns.Add(column);

            if (ListItemsDetalhe.Count != 0)
            {
                foreach (var model in ListItemsDetalhe)
                {
                    row = tableDetalhes.NewRow();
                    row["DetalheId"] = model.DetalheId;
                    row["PedidoId"] = model.PedidoId;
                    row["CatalogoId"] = model.CatalogoId;
                    row["ProdutoId"] = model.ProdutoId;
                    row["Catalogo"] = _catalogoServices.GetById(model.CatalogoId).Nome;
                    row["Referencia"] = model.Referencia;
                    row["Descricao"] = _produtoServices.GetById(model.ProdutoId).Descricao;
                    row["MargemVendedora"] = model.MargemVendedora;
                    row["MargemDistribuidor"] = model.MargemDistribuidor;
                    row["ValorProduto"] = double.Parse(model.ValorProduto.ToString()).ToString("C2");
                    row["Quantidade"] = model.Quantidade;
                    row["Tamanho"] = model.Tamanho;
                    row["ValorTotalItem"] = double.Parse(model.ValorTotalItem.ToString()).ToString("C2");
                    row["ValorLucroVendedoraItem"] = double.Parse(model.ValorLucroVendedoraItem.ToString()).ToString("C2");
                    row["ValorLucroDistribuidorItem"] = double.Parse(model.ValorLucroDistribuidorItem.ToString()).ToString("C2");
                    row["ValorPagarForencedorItem"] = double.Parse(model.ValorPagarFornecedorItem.ToString()).ToString("C2");
                    row["Faltou"] = model.Faltou;

                    tableDetalhes.Rows.Add(row);

                }
            }

            dgvDetalhePedido.DataSource = tableDetalhes;
            ConfiguraDataGridView();



        }

        private void ConfiguraDataGridView()
        {
            dgvDetalhePedido.ForeColor = Color.Black;

            dgvDetalhePedido.Columns["DetalheId"].Visible = false;
            dgvDetalhePedido.Columns["PedidoId"].Visible = false;
            dgvDetalhePedido.Columns["CatalogoId"].Visible = false;
            dgvDetalhePedido.Columns["ProdutoId"].Visible = false;
            dgvDetalhePedido.Columns["Catalogo"].Visible = cbCatalogo.SelectedIndex > 0 ? false : true;
            dgvDetalhePedido.Columns["Catalogo"].Width = 50;
            dgvDetalhePedido.Columns["Referencia"].HeaderText = "Ref.";
            dgvDetalhePedido.Columns["Referencia"].Width = 50;
            dgvDetalhePedido.Columns["Descricao"].HeaderText = "Produto";
            dgvDetalhePedido.Columns["Descricao"].Width = 123;
            dgvDetalhePedido.Columns["MargemVendedora"].Visible = false;
            dgvDetalhePedido.Columns["MargemDistribuidor"].Visible = false;
            dgvDetalhePedido.Columns["ValorProduto"].HeaderText = "Vlr.Unit.";
            dgvDetalhePedido.Columns["ValorProduto"].Width = 50;
            dgvDetalhePedido.Columns["Quantidade"].HeaderText = "Qtd.";
            dgvDetalhePedido.Columns["Quantidade"].Width = 20;
            dgvDetalhePedido.Columns["Tamanho"].HeaderText = "Tam.";
            dgvDetalhePedido.Columns["Tamanho"].Width = 25;
            dgvDetalhePedido.Columns["ValorTotalItem"].HeaderText = "Vlr.Total";
            dgvDetalhePedido.Columns["ValorTotalItem"].Width = 50;
            dgvDetalhePedido.Columns["ValorLucroVendedoraItem"].HeaderText = "Lucro Vend.";
            dgvDetalhePedido.Columns["ValorLucroVendedoraItem"].Width = 50;
            dgvDetalhePedido.Columns["ValorLucroDistribuidorItem"].HeaderText = "Lucro Dist.";
            dgvDetalhePedido.Columns["ValorLucroDistribuidorItem"].Width = 50;
            dgvDetalhePedido.Columns["ValorPagarForencedorItem"].HeaderText = "Custo";
            dgvDetalhePedido.Columns["ValorPagarForencedorItem"].Width = 50;
            dgvDetalhePedido.Columns["Faltou"].Visible = false;


        }

        private void PedidoAddForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (PedidoModel == null)
            {


                if (!VendedoraTemPedidoAberto(VendedoraModel))
                {


                    SalvarPedido(VendedoraModel);
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
            if (cbCatalogo.SelectedIndex > 0)
            {


                if (!string.IsNullOrEmpty(textReferencia.Text))
                {
                    if (ProdutoExiste(textReferencia.Text))
                    { //SE EXISTE ADICIONA VERIFICA SE TEM TAMANHO PARA DEPOIS ADI9CIONAR AO GRID.
                        ProdutoToAddGrid = _produtoServices.GetByReference(textReferencia.Text);

                        if (ProdutoToAddGrid.CatalogoId != SelectedCatalogo.CatalogoId)
                        {
                            MessageBox.Show("Produto não pertence ao catálogo selecionado.");
                            textReferencia.Focus();
                        }
                        else if (ProdutoToAddGrid.CampanhaId != SelectedCampanha.CampanhaId)
                        {
                            var result = MessageBox.Show($"Produto não pertence à campanha selecionada.\nDeseja Adicionar esse produto à campanha: \n{SelectedCampanha.Nome} ?", "Produto Fora da Campanha", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {//ADICIONAR O PRODUTO CADASTRADO NA CAMPANHA ATUAL
                                ProdutoModel produto = new ProdutoModel();
                                produto = _produtoServices.GetByReference(textReferencia.Text);
                                produto.CampanhaId = SelectedCampanha.CampanhaId;
                                if (produto.MargemVendedora != null)
                                    this.ProdutoToAddGrid = _produtoServices.AddWithMargens(produto);
                                else
                                    this.ProdutoToAddGrid = _produtoServices.AddNoMargens(produto);

                                result = MessageBox.Show($"O Produto {this.ProdutoToAddGrid.Referencia} foi adicionado à campanha {this.SelectedCampanha}.\n Deseja revisar o preço do produto agora?", "Adicionando Produto à Campanha Atual", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (result == DialogResult.Yes)
                                {   // ABRIR EDIÇÃO DE PRODUTO
                                    ProdutoAddForm editaProduto = new ProdutoAddForm(ProdutoToAddGrid, SelectedCatalogo, SelectedCampanha);
                                    editaProduto.StartPosition = FormStartPosition.CenterScreen;
                                    editaProduto.ShowDialog();
                                    this.ProdutoToAddGrid = editaProduto.ProdutoModel;
                                }
                                else
                                {
                                    MessageBox.Show("Não se equeça de revisar o preço do produto e em seguida editar esse pedido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else if (result == DialogResult.No)
                            {
                                textReferencia.Focus();
                            }


                        }

                    }
                    else
                    { //adicionar produto no catalogo.
                        ProdutoToAddGrid = AdicionarNovoProduto(textReferencia.Text);
                    }

                    ProdutoTemTamanho(ProdutoToAddGrid);

                }
                else
                {
                    MessageBox.Show("Preencha a referência do produto!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textReferencia.Focus();
                }
            }
        }

        private ProdutoModel AdicionarNovoProduto(string referencia)
        {
            ProdutoModel produtoAdded = new ProdutoModel();
            try
            {
                ProdutoAddForm produtoAddForm = new ProdutoAddForm(null, SelectedCatalogo, SelectedCampanha);
                produtoAddForm.Text = "Pedido - Adicionando Produto";
                produtoAddForm.StartPosition = FormStartPosition.CenterScreen;
                produtoAddForm.textReferencia.Text = referencia;
                produtoAddForm.ShowDialog();
                produtoAdded = produtoAddForm.ProdutoModel;

            }
            catch (Exception ex)
            {

                MessageBox.Show($"Não foi possível adicionar um novo Produto à Campanha\nMessageError: {ex.Message}\nStackTrace: {ex.StackTrace}\nInnerException: {ex.InnerException}");
            }

            return produtoAdded;
        }

        private bool ProdutoExiste(string referencia)
        {
            ProdutoModel produto = new ProdutoModel();
            produto = _produtoServices.GetByReference(referencia);
            if (produto.ProdutoId != 0)
                return true;
            else
                return false;
        }

        private void ProdutoTemTamanho(ProdutoModel produtoToAddGrid)
        {
            List<TamanhosModel> tamanhos = null;
            tamanhos = (List<TamanhosModel>)_tamanhoServices.GetByProdutoModel(produtoToAddGrid);
            if (tamanhos.Count > 0)
            {//SE PRODUTO TEM TAMANHO HABILITA E CARREGA O COMBOBOX DE TAMANHOS
                ListTamanhos = tamanhos;
                cbTamanho.Enabled = true;
                LoadComboBoxTamanhos(ListTamanhos);
            }
            else
            {//SE NÃO TEM TAMANHO DESABILITA O COMBOBOX E LIMPA SEUS DADOS
                cbTamanho.Items.Clear();
                cbTamanho.Enabled = false;
                cbTamanho.Text = string.Empty;
            }
        }

        private void LoadComboBoxTamanhos(List<TamanhosModel> listTamanhos)
        {

            cbTamanho.DataSource = ListTamanhos;
            cbTamanho.DisplayMember = "Tamanho";
            cbTamanho.SelectedItem = ListTamanhos.First();


        }


        private void textQtd_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textQtd.Text))
            {

                if (int.TryParse(textQtd.Text, out int result))
                {
                    if (result != 0)
                    {
                        if (!cbTamanho.Enabled)
                        {
                            AddProdutoInDGV(ProdutoToAddGrid, result, null);
                            LimpaAddPanel();
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Só é aceito valor numérico", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textQtd.Focus();
                }
            }
        }

        private void cbTamanho_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTamanho.SelectedIndex >= 0)
            {
                if (!string.IsNullOrEmpty(textQtd.Text))
                {

                    AddProdutoInDGV(ProdutoToAddGrid, int.Parse(textQtd.Text), cbTamanho.Text);
                    LimpaAddPanel();
                }

            }
        }

        private void LimpaAddPanel()
        {
            cbTamanho.SelectedIndex = -1;
            cbTamanho.Text = string.Empty;
            textReferencia.Text = string.Empty;
            textQtd.Text = string.Empty;
        }

        private void SalvarPedido(VendedoraModel vendedora)
        {
            PedidoModel = new PedidosVendedorasModel();
            PedidoModel.VendedoraId = vendedora.VendedoraId;
            PedidoModel.StatusPed = (((int)StatusPedido.Aberto));
            PedidoModel = (PedidosVendedorasModel)_pedidoServices.Add(PedidoModel);
        }
        private void AddProdutoInDGV(ProdutoModel produto, int quantidade, string tamanho)
        {

            double valorProduto = 0;
            if (tamanho != null)
            {   //TEM TAMANHO TRATAR VALOR DO PRODUTO E ADD TAMANHO NO ITEM.
                Tamanhos tamanhos = (Tamanhos)Enum.Parse(typeof(Tamanhos), tamanho);
                if (tamanhos >= Tamanhos.GG)
                {
                    valorProduto = produto.ValorCatalogo2 != 0 ? produto.ValorCatalogo2 : produto.ValorCatalogo;
                }
                else
                {
                    valorProduto = produto.ValorCatalogo;
                }

                ItemPedido.Tamanho = tamanho;


            }
            else
            { //NÃO TEM TAMANHO PASSAR O VALOR DO PRODUTO PADRÃO E NÃO ADICIOANR TAMNAHO NO ITEM
                valorProduto = produto.ValorCatalogo;
            }


            ItemPedido.PedidoId = PedidoModel.PedidoId;
            ItemPedido.CatalogoId = SelectedCatalogo.CatalogoId;
            ItemPedido.CampanhaId = SelectedCampanha.CampanhaId;
            ItemPedido.ProdutoId = produto.ProdutoId;
            ItemPedido.Referencia = produto.Referencia;
            ItemPedido.MargemVendedora = string.IsNullOrEmpty(produto.MargemVendedora) ? SelectedCatalogo.MargemPadraoVendedora : double.Parse(produto.MargemVendedora);
            ItemPedido.MargemDistribuidor = string.IsNullOrEmpty(produto.MargemDistribuidor) ? SelectedCatalogo.MargemPadraoDistribuidor : double.Parse(produto.MargemDistribuidor);
            ItemPedido.ValorProduto = valorProduto;
            ItemPedido.Quantidade = quantidade;
            ItemPedido.ValorTotalItem = quantidade * ItemPedido.ValorProduto;
            ItemPedido.ValorLucroVendedoraItem = (ItemPedido.ValorProduto * (ItemPedido.MargemVendedora / 100)) * ItemPedido.Quantidade;
            ItemPedido.ValorLucroDistribuidorItem = ((ItemPedido.ValorProduto * (ItemPedido.MargemDistribuidor / 100)) * ItemPedido.Quantidade) - ItemPedido.ValorLucroVendedoraItem;
            ItemPedido.ValorPagarFornecedorItem = ItemPedido.ValorTotalItem - ItemPedido.ValorLucroDistribuidorItem - ItemPedido.ValorLucroVendedoraItem;
            ItemPedido.Faltou = false;


            if (tamanho != null)
                _detalheServices.AddWithTamanho(ItemPedido);
            else
                _detalheServices.AddNoTamanho(ItemPedido);

            LoadDetalhesPedido(PedidoModel, SelectedCatalogo);
        }

        private void cbCampanha_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCampanha.SelectedIndex > -1)
            {
                SelectedCampanha = cbCampanha.SelectedItem as CampanhaModel;
            }
        }

        private void dgvDetalhePedido_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
