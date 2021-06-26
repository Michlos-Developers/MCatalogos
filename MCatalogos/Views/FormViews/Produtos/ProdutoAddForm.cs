using DomainLayer.Models.Catalogos;
using DomainLayer.Models.Formatos;
using DomainLayer.Models.Produtos;
using DomainLayer.Models.Tamanho;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Specific.Catalogo;
using InfrastructureLayer.DataAccess.Repositories.Specific.Formato;
using InfrastructureLayer.DataAccess.Repositories.Specific.Produto;
using InfrastructureLayer.DataAccess.Repositories.Specific.Tamanho;

using MCatalogos.Views.UserControls.Tamanhos;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.CatalogoServices;
using ServiceLayer.Services.FormatoTamanhoServices;
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

namespace MCatalogos.Views.FormViews.Produtos
{
    public partial class ProdutoAddForm : Form
    {
        public ProdutoModel ProdutoModel;
        private CatalogoModel CatalogoModel;
        private CampanhaModel CampanhaModel;
        private TamanhosModel TamanhosModel;
        private FormatosTamanhosModel FormatoModel;

        private QueryStringServices _queryString;
        private CatalogoServices _catalogoServices;
        private CampanhaServices _campanhaServices;
        private ProdutoServices _produtoServices;
        private TamanhoServices _tamanhoServices;
        private FormatoTamanhoServices _formatoServices;

        private List<TamanhosModel> tamanhosList;
        private List<FormatosTamanhosModel> formatosList;

        private TamanhosListUC tamanhosUC;


        public ProdutoAddForm(CatalogoModel catalogoModel, CampanhaModel campanhaModel, ProdutoModel produtoModel)
        {
            _queryString = new QueryStringServices(new QueryString());
            _catalogoServices = new CatalogoServices(new CatalogoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _campanhaServices = new CampanhaServices(new CampanhaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _produtoServices = new ProdutoServices(new ProdutoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _tamanhoServices = new TamanhoServices(new TamanhoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _formatoServices = new FormatoTamanhoServices(new FormatoTamanhoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());



            InitializeComponent();
            this.CatalogoModel = catalogoModel;
            this.CampanhaModel = campanhaModel;
            this.ProdutoModel = produtoModel;
            AplicarEventos(textValor);
            AplicarEventos(textValorGG);

        }

        private void SetBGColorFocused(Control control)
        {
            control.BackColor = SystemColors.GradientActiveCaption;

        }

        private void SetBGColorUnfocused(Control control)
        {
            control.BackColor = SystemColors.Window;
        }
        private void ProdutoAddForm_Load(object sender, EventArgs e)
        {
            LoadComboBoxFormato();
            LoadUserControlTamanhos();
            FillFields();
        }

        private void LoadUserControlTamanhos()
        {

            if (cbFormatoTamanho.SelectedIndex != 0)
            {
                this.FormatoModel = _formatoServices.GetById((cbFormatoTamanho.SelectedItem as FormatosTamanhosModel).FormatoId);
            }

            tamanhosUC = new TamanhosListUC(this.FormatoModel, this.ProdutoModel);
            panelTamanhosUC.Controls.Clear();
            panelTamanhosUC.Controls.Add(tamanhosUC);
            tamanhosUC.Dock = DockStyle.Fill;




        }
        private void LoadComboBoxFormato()
        {
            this.formatosList = (List<FormatosTamanhosModel>)_formatoServices.GetAll();

            cbFormatoTamanho.DisplayMember = "NomeFormato";
            cbFormatoTamanho.Items.Clear();
            cbFormatoTamanho.Items.Add("Selecione");
            foreach (FormatosTamanhosModel model in this.formatosList)
            {
                cbFormatoTamanho.Items.Add(model);
            }
            cbFormatoTamanho.SelectedIndex = 0;

        }

        public void FillFields()
        {
            this.textCampanha.Text = this.CampanhaModel.Nome;
            this.textCatalogo.Text = this.CatalogoModel.Nome;

            if (this.ProdutoModel != null)
            {
                this.groupBoxTamanhos.Enabled = true;

                textReferencia.Text = this.ProdutoModel.Referencia;
                textDescricao.Text = this.ProdutoModel.Descricao;
                textValor.Text = this.ProdutoModel.ValorCatalogo.ToString();
                textValorGG.Text = this.ProdutoModel.ValorCatalogo2.ToString();
                textPagina.Text = this.ProdutoModel.Pagina.ToString();
                textMargemVendedora.Text = this.ProdutoModel.MargemVendedora != null ? this.ProdutoModel.MargemVendedora.ToString() : string.Empty;
                textMargemDistribuidor.Text = this.ProdutoModel.MargemDistribuidor != null ? this.ProdutoModel.MargemDistribuidor.ToString() : string.Empty;



            }

            //this.FormatoModel = _formatoServices.GetById((cbFormatoTamanho.SelectedItem as FormatosTamanhosModel).FormatoId);
            //cbFormatoTamanho.SelectedItem = this.FormatoModel;
        }

        private void cbFormatoTamanho_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFormatoTamanho.SelectedIndex > 0)
            {
                this.FormatoModel = cbFormatoTamanho.SelectedItem as FormatosTamanhosModel;
                LoadUserControlTamanhos();
                tamanhosUC.dgvTamanhos.Enabled = true;

            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (textMargemVendedora.Text == string.Empty && textMargemDistribuidor.Text != string.Empty)
            {
                MessageBox.Show("Se a Margem do Distribuidor foi preenchida, a \"Margem da Vendedora\" também deve ser preenchida.");
            }
            else if (textMargemVendedora.Text != string.Empty && textMargemDistribuidor.Text == string.Empty)
            {
                MessageBox.Show("Se a Margem da Vendedora foi preenchida, a \"Marge do Distribuidor\" também deve ser preenchida.");
            }
            else if (textMargemDistribuidor.Text == string.Empty && textMargemVendedora.Text == string.Empty)
            {
                //INSERT SEM MARGENS
                if (this.ProdutoModel == null)  //INSERT
                {
                    this.ProdutoModel = ChangePrudutoModelNoMargem();
                    try
                    {
                        this.ProdutoModel = _produtoServices.AddNoMargens(this.ProdutoModel);
                        FillFields();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                else   //UPDATE  NO MARGEM
                {
                    _produtoServices.UpdateNoMargem(this.ProdutoModel);
                }
            }
            else
            {
                if (this.ProdutoModel == null)//INSERT
                {
                    //INSET COM MARGENS
                    this.ProdutoModel = ChangeProdutoModelWithMargem();
                    try
                    {
                        this.ProdutoModel = _produtoServices.Add(this.ProdutoModel);
                        FillFields();

                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                else   //UPDATE WITH MARGEM
                {
                    if (cbFormatoTamanho.SelectedIndex > 0)
                    {
                        this.FormatoModel = cbFormatoTamanho.SelectedItem as FormatosTamanhosModel;
                        
                        
                    }
                    _produtoServices.Update(this.ProdutoModel);

                }

            }

            if (cbFormatoTamanho.SelectedIndex > 0)
            {

            }


        }

        private ProdutoModel ChangeProdutoModelWithMargem()
        {
            ProdutoModel produto = new ProdutoModel();
            float valor1 = float.Parse(textValor.Text.Replace("R$", ""));
            float valor2 = textValorGG.Text != string.Empty ? float.Parse(textValorGG.Text.Replace("R$", "")) : 0;
            produto.Referencia = textReferencia.Text;
            produto.Descricao = textDescricao.Text;

            produto.ValorCatalogo = valor1;
            produto.ValorCatalogo2 = valor2;
            produto.Pagina = int.Parse(textPagina.Text);
            produto.MargemVendedora = textMargemVendedora.Text;
            produto.MargemDistribuidor = textMargemDistribuidor.Text;
            produto.Ativo = true;
            produto.CatalogoId = this.CatalogoModel.CatalogoId;
            produto.CatalogoId = this.CampanhaModel.CampanhaId;

            return produto;
        }

        private ProdutoModel ChangePrudutoModelNoMargem()
        {
            ProdutoModel produto = new ProdutoModel();
            float valor1 = float.Parse(textValor.Text.Replace("R$", ""));
            float valor2 = textValorGG.Text != string.Empty ? float.Parse(textValorGG.Text.Replace("R$", "")) : 0;
            produto.Referencia = textReferencia.Text;
            produto.Descricao = textDescricao.Text;

            produto.ValorCatalogo = valor1;
            produto.ValorCatalogo2 = valor2;
            produto.Pagina = int.Parse(textPagina.Text);
            produto.Ativo = true;
            produto.CatalogoId = this.CatalogoModel.CatalogoId;
            produto.CampanhaId = this.CampanhaModel.CampanhaId;

            return produto;
        }


        #region SET FOCUSED/UNFOCUSED
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
    }
}
