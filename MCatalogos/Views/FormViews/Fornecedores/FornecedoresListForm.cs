using DomainLayer.Models.Catalogos;
using DomainLayer.Models.Financeiro.Caixa.ContasPagar;
using DomainLayer.Models.Fornecedores;
using DomainLayer.Models.PedidosVendedoras;
using DomainLayer.Models.Produtos;
using DomainLayer.Models.TitulosPagar;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Specific.Catalogo;
using InfrastructureLayer.DataAccess.Repositories.Specific.Financeiro.Caixa;
using InfrastructureLayer.DataAccess.Repositories.Specific.Fornecedor;
using InfrastructureLayer.DataAccess.Repositories.Specific.PedidoVendedora;
using InfrastructureLayer.DataAccess.Repositories.Specific.Produto;
using InfrastructureLayer.DataAccess.Repositories.Specific.TituloPagar;

using Microsoft.Win32;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.CatalogoServices;
using ServiceLayer.Services.DetalhePedidoServices;
using ServiceLayer.Services.FinanceiroServices.CaixaServices.ContasPagar;
using ServiceLayer.Services.FornecedorServices;
using ServiceLayer.Services.PedidosVendedorasServices;
using ServiceLayer.Services.ProdutoServices;
using ServiceLayer.Services.TelefoneFornecedorServices;
using ServiceLayer.Services.TitulosPagarServices;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MCatalogos.Views.FormViews.Fornecedores
{
    public partial class FornecedoresListForm : Form
    {
        #region PROPRIEDADES PARA MOVER A JANELA

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        #endregion


        MainView MainView;

        //Instância de MainView. Evita que mais de uma janela seja aberta.
        private static FornecedoresListForm aForm = null;
        public static FornecedoresListForm Instance(MainView mainView)
        {
            if (aForm == null)
            {
                aForm = new FornecedoresListForm(mainView);
            }
            else
            {
                aForm.BringToFront();
            }
            return aForm;
        }

        QueryStringServices _queryString;
        private FornecedorServices _fornecedorServices;
        private TelefoneFornecedorServices _telefoneFornecedorServices;
        private CatalogoServices _catalogoServices;
        private CampanhaServices _campanhaServices;
        private ProdutoServices _produtoServices;
        private DetalhePedidoSerivces _detalhePedidoServices;
        private TituloPagarServices _tituloPagarServices;


        private IEnumerable<TelefoneFornecedorModel> TelefonesList;
        private IEnumerable<CatalogoModel> CatalogosList;
        private IEnumerable<CampanhaModel> CampanhasList;
        private IEnumerable<ProdutoModel> ProdutosList;
        private IEnumerable<DetalhePedidoModel> DetalhesPedidosList;
        private IEnumerable<TituloPagarModel> TitulosPagarList;



        private int indexDGV = 0;

        public FornecedoresListForm(MainView mainView)
        {
            _queryString = new QueryStringServices(new QueryString());
            _fornecedorServices = new FornecedorServices(new FornecedorRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _telefoneFornecedorServices = new TelefoneFornecedorServices(new TelefoneFornecedorRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _catalogoServices = new CatalogoServices(new CatalogoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _campanhaServices = new CampanhaServices(new CampanhaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _produtoServices = new ProdutoServices(new ProdutoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _detalhePedidoServices = new DetalhePedidoSerivces(new DetalhePedidoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _tituloPagarServices = new TituloPagarServices(new TituloPagarRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());



            InitializeComponent();
            this.MainView = mainView;
        }
        public void FornecedoresListForm_Load(object sender, EventArgs e)
        {
            LoadFornecedoresToDataGrid();

        }

        private void FornecedoresListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            //this.MainView.SetUnselectedButtons();
            base.Dispose(Disposing);
            aForm = null;
        }


        private void LoadFornecedoresToDataGrid()
        {
            List<FornecedorModel> modelList = null;
            try
            {
                modelList = (List<FornecedorModel>)_fornecedorServices.GetAll();

            }
            catch (Exception ex)
            {

                MessageBox.Show($"Não foi possível trazer a lista de fornecedores.\nMessage: {ex.Message}", "Error Acess List");
            }

            DataTable tableFornecedores = ModelaTableGrid();
            ModelaRowTable(tableFornecedores, modelList);

            dgvFornecedores.DataSource = tableFornecedores;
            ConfigraDataGridView();
        }

        private void ModelaRowTable(DataTable tableFornecedores, List<FornecedorModel> modelList)
        {
            DataRow row;

            if (modelList.Count != 0)
            {
                foreach (FornecedorModel model in modelList)
                {
                    row = tableFornecedores.NewRow();
                    row["FornecedorId"] = int.Parse(model.FornecedorId.ToString());
                    row["RazaoSocial"] = model.RazaoSocial.ToString();
                    row["NomeFantasia"] = model.NomeFantasia.ToString();
                    row["Cnpj"] = model.Cnpj.ToString();

                    tableFornecedores.Rows.Add(row);
                }
            }

        }

        private DataTable ModelaTableGrid()
        {
            DataTable table = new DataTable();

            table.Columns.Add("FornecedorId", typeof(int));
            table.Columns.Add("RazaoSocial", typeof(string));
            table.Columns.Add("NomeFantasia", typeof(string));
            table.Columns.Add("Cnpj", typeof(string));

            return table;

        }

        public void ConfigraDataGridView()
        {
            dgvFornecedores.Columns[0].HeaderText = "Código";
            dgvFornecedores.Columns[0].Width = 50;

            dgvFornecedores.Columns[1].HeaderText = "Razao Social";
            dgvFornecedores.Columns[1].Width = 275;

            dgvFornecedores.Columns[2].HeaderText = "Nome Fantasia";
            dgvFornecedores.Columns[2].Width = 225;

            dgvFornecedores.Columns[3].HeaderText = "CNPJ";
            dgvFornecedores.Columns[3].Width = 213;

            if (indexDGV != 0)
            {
                dgvFornecedores.Rows[0].Selected = false;
                dgvFornecedores.Rows[indexDGV].Selected = true;
            }

        }

        private void dgvFornecedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFornecedores.CurrentRow != null)
            {
                indexDGV = e.RowIndex;
            }
        }

        private void dgvFornecedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FornecedorForm fornecedorForm = new FornecedorForm(this);
            fornecedorForm.textFornecedorId.Text = this.dgvFornecedores.CurrentRow.Cells[0].Value.ToString();
            fornecedorForm.mTextCnpj.ReadOnly = true;
            fornecedorForm.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FornecedorForm fornecedorForm = new FornecedorForm(this);
            fornecedorForm.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            FornecedorForm fornecedorForm = new FornecedorForm(this);
            fornecedorForm.textFornecedorId.Text = this.dgvFornecedores.CurrentRow.Cells[0].Value.ToString();
            fornecedorForm.mTextCnpj.ReadOnly = true;
            fornecedorForm.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show($"CUIDADO!!\nVocê está prestes a apgar o cadastro do Fornecedor\n{dgvFornecedores.CurrentRow.Cells[1].Value.ToString()}.\n" +
                $"Isso implicará em apagar todos os Catálogos/Campanhas/Produtos desse fornecedor.\n " +
                $"\nDeseja continuar?", "CUIDADO!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                FornecedorModel model = new FornecedorModel();
                model = _fornecedorServices.GetById(int.Parse(dgvFornecedores.CurrentRow.Cells[0].Value.ToString()));

                //coletando dados para deleção
                TelefonesList = (List<TelefoneFornecedorModel>)_telefoneFornecedorServices.GetByFornecedorId(model.FornecedorId);
                CatalogosList = (List<CatalogoModel>)_catalogoServices.GetByFornecedorId(model.FornecedorId);
                TitulosPagarList = (List<TituloPagarModel>)_tituloPagarServices.GetAllByFornecedorId(model.FornecedorId);

                //CAMPANHAS PRODUTOS E PEDIDOS
                foreach (var catalogo in CatalogosList)
                {
                    //SE NÃO TEM CAMPANHA NÃO PRODUTO NEM PEDIDO

                    IEnumerable<CampanhaModel> campanhas = (List<CampanhaModel>)_campanhaServices.GetByCatalogoId(catalogo.CatalogoId);
                    foreach (var campanha in campanhas)
                    {
                        CampanhasList.Append(campanha);
                        //PRODUTOS
                        IEnumerable<ProdutoModel> produtos = (List<ProdutoModel>)_produtoServices.GetAllByCampanhaId(campanha.CampanhaId);
                        foreach (var produto in produtos)
                        {
                            ProdutosList.Append(produto);
                        }

                        //ITENS DE PEDIDOS
                        IEnumerable<DetalhePedidoModel> detalhesPedidos = (List<DetalhePedidoModel>)_detalhePedidoServices.GetAllByCampanha(campanha);
                        foreach (var detalhe in detalhesPedidos)
                        {
                            DetalhesPedidosList.Append(detalhe);
                        }
                    }
                }


                try
                {
                    if (DetalhesPedidosList != null && DetalhesPedidosList.Any())
                    {
                        throw new Exception("O Fornecedor possui pedido cadastro em um de seus catálogos. Impossível Deletar o Registro.");
                    }
                    else if (TitulosPagarList != null && TitulosPagarList.Any())
                    {
                        throw new Exception("Existe um título a Pagar registrado em nome desse fornecedor. Impossível Deletar o Registro.");
                    }


                    if (TelefonesList != null && TelefonesList.Any())
                    {
                        foreach (TelefoneFornecedorModel telModel in TelefonesList)
                        {
                            _telefoneFornecedorServices.Delete(telModel);
                        }
                    }


                    if (ProdutosList != null && ProdutosList.Any())
                    {
                        foreach (var item in ProdutosList)
                        {
                            _produtoServices.Delete(item);
                        }
                    }

                    if (CampanhasList != null && CampanhasList.Any())
                    {
                        foreach (var item in CampanhasList)
                        {
                            _campanhaServices.Delete(item);
                        }
                    }

                    if (CatalogosList != null && CatalogosList.Any())
                    {
                        foreach (var item in CatalogosList)
                        {
                            _catalogoServices.Delete(item);
                        }
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Não foi possível apagar o registro do forneceddor.\nErrorMessage: \n{ex.Message}.", "Error");
                }

                _fornecedorServices.Delete(model);
                MessageBox.Show($"Fornecedor {model.NomeFantasia} excluído com sucesso.");
                indexDGV -= 1;


                this.FornecedoresListForm_Load(sender, e);
                
            }
        }

        private void dgvFornecedores_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.ColumnIndex == 3) && (e.RowIndex != dgvFornecedores.NewRowIndex))
            {
                e.Value = string.Format(@"{0:##\.###\.###\/####\-##}", Int64.Parse(e.Value.ToString()));
            }
        }

        private void titlePanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
