using DomainLayer.Models.Catalogos;
using DomainLayer.Models.Formatos;
using DomainLayer.Models.Produtos;
using DomainLayer.Models.Tamanho;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Specific.Catalogo;
using InfrastructureLayer.DataAccess.Repositories.Specific.Formato;
using InfrastructureLayer.DataAccess.Repositories.Specific.Produto;
using InfrastructureLayer.DataAccess.Repositories.Specific.Tamanho;

using MCatalogos.Views.FormViews.PedidoVendedora;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.CatalogoServices;
using ServiceLayer.Services.FormatoTamanhoServices;
using ServiceLayer.Services.ProdutoServices;
using ServiceLayer.Services.TamanhoServices;

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace MCatalogos.Views.FormViews.Produtos
{
    public partial class ProdutoAddForm : Form
    {

        public ProdutoModel ProdutoModel;
        private CampanhaModel CampanhaModel;
        private CatalogoModel CatalogoModel;
        private FormatosTamanhosModel FormatoModel;
        private TamanhosModel TamanhosModel;

        private QueryStringServices _queryString;
        private ProdutoServices _produtoServices;
        private CampanhaServices _campanhaServices;
        private CatalogoServices _catalogoServices;
        private TamanhoServices _tamanhoServices;
        private FormatoTamanhoServices _formatoServices;
        private Control controlOrigem;
        bool isClosing = false;

        private List<TamanhosModel> TamanhosList;

        public ProdutoAddForm(ProdutoModel produto, CatalogoModel catalogo, CampanhaModel campanha, Control control)
        {

            _queryString = new QueryStringServices(new QueryString());
            _produtoServices = new ProdutoServices(new ProdutoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _campanhaServices = new CampanhaServices(new CampanhaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _catalogoServices = new CatalogoServices(new CatalogoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _tamanhoServices = new TamanhoServices(new TamanhoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _formatoServices = new FormatoTamanhoServices(new FormatoTamanhoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());

            InitializeComponent();
            ProdutoModel = produto;
            CatalogoModel = catalogo;
            CampanhaModel = campanha;
            controlOrigem = control;


        }

        private void ProdutoAddForm_Load(object sender, EventArgs e)
        {
            CarregaFormato(TamanhosModel);
            ConfiguraDataGridView(TamanhosList);
            PreencheComboBoxFormato();
            if (ProdutoModel != null) //EDITANDO
            {
                CarregaListaTamanhosProduto(ProdutoModel);
                PreencheCampos(ProdutoModel, TamanhosList);
            }
            else
            {
                PreencheCampos(null, TamanhosList);
                
            }

            if (!CatalogoModel.VariacaoDeValor)
            {
                textValorGG.Enabled = false;
            }
            else
            {
                textValorGG.Enabled = true;
            }

            


        }

        private void CarregaFormato(TamanhosModel tamanho)
        {
            FormatoModel = tamanho != null ? _formatoServices.GetById(tamanho.FormatoId) : null;
        }

        private void CarregaListaTamanhosProduto(ProdutoModel produtoModel)
        {
            TamanhosList = (List<TamanhosModel>)_tamanhoServices.GetByProdutoModel(produtoModel);

            if (TamanhosList.Count != 0)
            {
                TamanhosModel = TamanhosList[0];
            }
            else
            {
                TamanhosModel = null;
                cbFormatoTamanho.SelectedIndex = -1;
            }

        }

        private void PreencheComboBoxFormato()
        {
            List<FormatosTamanhosModel> FormatosList = (List<FormatosTamanhosModel>)_formatoServices.GetAll();
            cbFormatoTamanho.DataSource = FormatosList;
            cbFormatoTamanho.DisplayMember = "NomeFormato";

        }

        private void PreencheCampos(ProdutoModel produto, List<TamanhosModel> tamanhos)
        {
            textCatalogo.Text = CatalogoModel.Nome;
            textCampanha.Text = CampanhaModel.Nome;

            if (produto != null)
            {
                textReferencia.Text = produto.Referencia;
                textDescricao.Text = produto.Descricao;
                textValor.Text = produto.ValorCatalogo.ToString();
                textValorGG.Text = produto.ValorCatalogo2.ToString();
                textPagina.Text = produto.Pagina.ToString();
                textMargemVendedora.Text = produto.MargemVendedora.ToString();
                textMargemDistribuidor.Text = produto.MargemDistribuidor.ToString();
                groupBoxTamanhos.Enabled = true;
            }

            if (tamanhos != null && tamanhos.Count > 0)
            {
                panelTamanhosUC.Enabled = true;
                cbFormatoTamanho.SelectedItem = FormatoModel;

                ConfiguraDataGridView(tamanhos);
            }


        }

        private void ConfiguraDataGridView(List<TamanhosModel> tamanhos)
        {

            //TEM QUE SER DATATABLE
            DataTable tableTamanhos = new DataTable();
            DataColumn column;
            DataRow row;

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "TamanhoId";
            tableTamanhos.Columns.Add(column);

            column = new DataColumn();
            column.DataType = FormatoModel != null ? Type.GetType(FormatoModel.Formato) : Type.GetType("System.String");
            column.ColumnName = "Tamanho";
            tableTamanhos.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "FormatoId";
            tableTamanhos.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "ProdutoId";
            tableTamanhos.Columns.Add(column);

            if (tamanhos != null && tamanhos.Count != 0)
            {
                foreach (var model in tamanhos)
                {
                    row = tableTamanhos.NewRow();
                    row["TamanhoId"] = model.TamanhoId;
                    row["Tamanho"] = model.Tamanho;
                    row["FormatoId"] = model.FormatoId;
                    row["ProdutoId"] = model.ProdutoId;

                    tableTamanhos.Rows.Add(row);
                }
            }







            dgvTamanhos.DataSource = tableTamanhos;

            dgvTamanhos.ForeColor = Color.Black;

            dgvTamanhos.Columns[0].Visible = false;
            dgvTamanhos.Columns[2].Visible = false;
            dgvTamanhos.Columns[3].Visible = false;

            if (tamanhos == null || tamanhos.Count == 0)
            {
                cbFormatoTamanho.SelectedIndex = -1;
                cbFormatoTamanho.Text = string.Empty;
            }
        }

        private void cbFormatoTamanho_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFormatoTamanho.SelectedIndex >= 0)
            {
                panelTamanhosUC.Enabled = true;
                dgvTamanhos.AllowUserToAddRows = true;
                FormatoModel = cbFormatoTamanho.SelectedItem as FormatosTamanhosModel;

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                if (ProdutoModel != null)//EDIT FOR UPDATE
                {
                    UpdateProduto(ProdutoModel);

                }
                else
                {
                    InsertProduto();
                }

                SaveTamanhos(ProdutoModel);
                ProdutoAddForm_Load(sender, e);

                if (controlOrigem is PedidoAddForm)
                {
                    this.Close();
                }
            }



        }

        private void UpdateProduto(ProdutoModel produtoModel)
        {
            produtoModel.Referencia = textReferencia.Text;
            produtoModel.Descricao = textDescricao.Text;
            produtoModel.ValorCatalogo = float.Parse(textValor.Text);
            produtoModel.ValorCatalogo2 = float.Parse(textValorGG.Text);
            produtoModel.Pagina = int.Parse(textPagina.Text);
            produtoModel.MargemVendedora = textMargemVendedora.Text;
            produtoModel.MargemDistribuidor = textMargemDistribuidor.Text;
            ProdutoModel.Ativo = true;

            if (textMargemVendedora.Text.ToString().Trim() == string.Empty)
            {
                _produtoServices.UpdateNoMargem(produtoModel);
            }
            else
            {
                _produtoServices.UpdateWithMargem(produtoModel);
            }

        }
        private void InsertProduto()
        {
            ProdutoModel produto = new ProdutoModel();
            produto.Referencia = textReferencia.Text;
            produto.Descricao = textDescricao.Text;
            produto.ValorCatalogo = float.Parse(textValor.Text);
            produto.ValorCatalogo2 = string.IsNullOrEmpty(textValorGG.Text) ? 0 : float.Parse(textValorGG.Text);
            produto.Pagina = int.Parse(textPagina.Text);
            produto.MargemVendedora = textMargemVendedora.Text;
            produto.MargemDistribuidor = textMargemDistribuidor.Text;
            produto.CatalogoId = CatalogoModel.CatalogoId;
            produto.CampanhaId = CampanhaModel.CampanhaId;
            produto.Ativo = true;

            if (textMargemVendedora.Text.ToString().Trim() == string.Empty)
            {
                this.ProdutoModel = _produtoServices.AddNoMargens(produto);
            }
            else
            {
                this.ProdutoModel = _produtoServices.AddWithMargens(produto);
            }
        }


        private void SaveTamanhos(ProdutoModel produtoModel)
        {
            if (cbFormatoTamanho.SelectedIndex >= 0)
            {
                if (dgvTamanhos.RowCount == 1)
                {
                    MessageBox.Show($"O Formato do Tamanho \"{cbFormatoTamanho.Text}\" foi selecionado.\nFavor Adicionar ao menos um tamanho ou Limpar o campo FormatoTamanho.");

                }
                else
                {
                    if (TamanhosList.Count > 0)
                    {
                        //TEM TAMANHOS NO BANCO DE DADOS
                        if (TamanhosList.Count == dgvTamanhos.RowCount - 1)
                        {
                            //DGV TEM MESMA QUANTIDADE DE LINHAS DO BANCO.
                            UpdateTamanhos(TamanhosList, dgvTamanhos.Rows);
                        }
                        else if (TamanhosList.Count > dgvTamanhos.RowCount - 1)
                        {
                            //DGV TEM MENOR QUANTIDADE QUE AS LINHAS DO BANCO
                            DeleteTamanhos(dgvTamanhos.Rows, TamanhosList);
                        }
                        else if (TamanhosList.Count < dgvTamanhos.RowCount - 1)
                        {
                            //DGV TEM MAIOR QUANTIDADE QUE AS LINHAS DO BANCO
                            InsertTamanhos(TamanhosList, dgvTamanhos.Rows);
                        }
                    }
                    else
                    {
                        //NÃO TEM TAMANHOS NO BANCO DE DADOS
                        InsertTamanhos(null, dgvTamanhos.Rows);
                    }
                }
            }
        }

        private void InsertTamanhos(List<TamanhosModel> tamanhosList, DataGridViewRowCollection rows)
        {
            if (tamanhosList != null)
            {

                //A LISTA ATUAL É MENOR QUE A DATAGRID.. FOI INSERIDO MAIS
                List<TamanhosModel> ListToCompare = new List<TamanhosModel>();

                foreach (DataGridViewRow row in rows)
                {
                    if (row.Cells[1].Value != null)
                    {
                        if (row.Cells[0].Value.ToString().Trim() != string.Empty)
                        {
                            TamanhosModel t = new TamanhosModel()
                            {
                                TamanhoId = row.Cells[0].Value != null ? int.Parse(row.Cells[0].Value.ToString()) : 0,
                                Tamanho = row.Cells[1].Value.ToString(),
                                FormatoId = int.Parse(row.Cells[2].Value.ToString()),
                                ProdutoId = int.Parse(row.Cells[3].Value.ToString())
                            };
                            ListToCompare.Add(t);
                        }
                        else
                        {
                            TamanhosModel t = new TamanhosModel()
                            {
                                //TamanhoId = 0,
                                Tamanho = row.Cells[1].Value.ToString(),
                                FormatoId = (cbFormatoTamanho.SelectedItem as FormatosTamanhosModel).FormatoId,
                                ProdutoId = ProdutoModel.ProdutoId
                            };
                            this.TamanhosModel = _tamanhoServices.Add(t);
                            this.TamanhosList.Add(this.TamanhosModel);
                        }

                    }
                }

                foreach (var model in tamanhosList)
                {

                    if (ListToCompare.Exists(x => x.TamanhoId == model.TamanhoId))
                    {
                        _tamanhoServices.Update(model);
                    }
                    else
                    {
                        this.TamanhosModel = _tamanhoServices.Add(model);
                        this.TamanhosList.Add(this.TamanhosModel);
                    }
                }
            }
            else
            {

                foreach (DataGridViewRow row in rows)
                {
                    if (row.Cells[1].Value != null)
                    {
                        TamanhosModel t = new TamanhosModel()
                        {
                            Tamanho = row.Cells[1].Value.ToString(),
                            FormatoId = (cbFormatoTamanho.SelectedItem as FormatosTamanhosModel).FormatoId,
                            ProdutoId = ProdutoModel.ProdutoId
                        };
                        this.TamanhosModel = _tamanhoServices.Add(t);
                        this.TamanhosList.Add(this.TamanhosModel);
                    }
                }
            }


        }

        private void DeleteTamanhos(DataGridViewRowCollection rows, List<TamanhosModel> tamanhosList)
        {
            List<TamanhosModel> ListToCompare = new List<TamanhosModel>();


            foreach (DataGridViewRow row in rows)
            {
                if (row.Cells[0].Value != null)
                {
                    TamanhosModel t = new TamanhosModel()
                    {
                        TamanhoId = int.Parse(row.Cells[0].Value.ToString()),
                        Tamanho = row.Cells[1].Value.ToString(),
                        FormatoId = int.Parse(row.Cells[2].Value.ToString()),
                        ProdutoId = int.Parse(row.Cells[3].Value.ToString())
                    };
                    ListToCompare.Add(t);
                }
            }

            foreach (var model in tamanhosList)
            {
                if (ListToCompare.Exists(x => x.TamanhoId == model.TamanhoId))
                {
                    _tamanhoServices.Update(model);
                }
                else
                {
                    _tamanhoServices.Delete(model);
                }
            }






        }

        private void UpdateTamanhos(List<TamanhosModel> tamanhos, DataGridViewRowCollection rows)
        {
            for (int t = 0; t < tamanhos.Count; t++)
            {
                TamanhosModel tamanho = new TamanhosModel();

                tamanho.FormatoId = FormatoModel.FormatoId;
                tamanho.ProdutoId = ProdutoModel.ProdutoId;
                tamanho.TamanhoId = tamanhos[t].TamanhoId;
                tamanho.Tamanho = rows[t].Cells[1].Value.ToString();

                _tamanhoServices.Update(tamanho);

            }

        }




        #region SET FOCUSED/UNFOCUSED
        private void SetBGColorFocused(Control control)
        {
            control.BackColor = SystemColors.GradientActiveCaption;

        }

        private void SetBGColorUnfocused(Control control)
        {
            control.BackColor = SystemColors.Window;
        }
        private void textReferencia_Enter(object sender, EventArgs e)
        {
            SetBGColorFocused(textReferencia);
        }

        private void textDescricao_Enter(object sender, EventArgs e)
        {
            SetBGColorFocused(textDescricao);
        }

        private void textValor_Enter(object sender, EventArgs e)
        {
            SetBGColorFocused(textValor);
        }

        private void textValorGG_Enter(object sender, EventArgs e)
        {
            SetBGColorFocused(textValorGG);
        }

        private void textPagina_Enter(object sender, EventArgs e)
        {
            SetBGColorFocused(textPagina);
        }

        private void textMargemVendedora_Enter(object sender, EventArgs e)
        {
            SetBGColorFocused(textMargemVendedora);
        }

        private void textMargemDistribuidor_Enter(object sender, EventArgs e)
        {
            SetBGColorFocused(textMargemDistribuidor);
        }

        private void cbFormatoTamanho_Enter(object sender, EventArgs e)
        {
            SetBGColorFocused(cbFormatoTamanho);
        }

        private void textReferencia_Leave(object sender, EventArgs e)
        {
            SetBGColorUnfocused(textReferencia);
        }

        private void textDescricao_Leave(object sender, EventArgs e)
        {
            SetBGColorUnfocused(textDescricao);
        }

        private void textValor_Leave(object sender, EventArgs e)
        {
            SetBGColorUnfocused(textValor);
        }

        private void textValorGG_Leave(object sender, EventArgs e)
        {
            SetBGColorUnfocused(textValorGG);
        }

        private void textPagina_Leave(object sender, EventArgs e)
        {
            SetBGColorUnfocused(textPagina);
        }

        private void textMargemVendedora_Leave(object sender, EventArgs e)
        {
            SetBGColorUnfocused(textMargemVendedora);
        }

        private void textMargemDistribuidor_Leave(object sender, EventArgs e)
        {
            SetBGColorUnfocused(textMargemDistribuidor);
        }

        private void cbFormatoTamanho_Leave(object sender, EventArgs e)
        {
            SetBGColorUnfocused(cbFormatoTamanho);
        }

        #endregion

        #region TRATAMENTO DE FORMATO DE VALORES DE PONTOS FLUTUANTES
        private void RetornarMarcarca(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt.Text != string.Empty)
                txt.Text = double.Parse(txt.Text).ToString("C2");

        }

        private void TirarMascara(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.Text = txt.Text.Replace("R$", "").Trim();
        }

        private void AenpasValorNumerico(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Back))
            {
                if (e.KeyChar == ',')
                {
                    e.Handled = (txt.Text.Contains(','));
                }
                else
                    e.Handled = true;

            }
        }

        private void AplicarEventos(TextBox txt)
        {
            txt.Enter += TirarMascara;
            txt.Leave += RetornarMarcarca;
            txt.KeyPress += AenpasValorNumerico;
        }

        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidaCampo(Control control)
        {
            bool eventArgs = false;
            if (!this.isClosing)
            {
                if (string.IsNullOrEmpty(control.Text.Trim()))
                {
                    eventArgs = true;
                    control.BackColor = Color.Red;
                    errorProvider.SetError(control, "Campo Obrigatório!");

                }
                else
                {
                    eventArgs = false;
                    errorProvider.SetError(control, null);
                }
            }
            return eventArgs;
        }

        private void textReferencia_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = ValidaCampo(textReferencia);
        }

        private void textDescricao_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = ValidaCampo(textDescricao);
        }

        private void textValor_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = ValidaCampo(textValor);
        }

        private void textValorGG_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (textValorGG.Enabled)
            {
                e.Cancel = ValidaCampo(textValor);
            }
        }

        private void textPagina_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = ValidaCampo(textPagina);
        }
    }
}
