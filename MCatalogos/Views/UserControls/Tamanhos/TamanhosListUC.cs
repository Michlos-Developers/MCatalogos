using DomainLayer.Models.Formatos;
using DomainLayer.Models.Produtos;
using DomainLayer.Models.Tamanho;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Specific.Tamanho;

using ServiceLayer.CommonServices;
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

namespace MCatalogos.Views.UserControls.Tamanhos
{
    public partial class TamanhosListUC : UserControl
    {

        private FormatosTamanhosModel FormatoModel; //FORMATO JÁ É BUSCADO PELO COMBOBOX DO ProdutoAddForm
        private ProdutoModel ProdutoModel;
        public List<TamanhosModel> TamanhosListModel;

        private QueryStringServices _queryString;
        private TamanhoServices _tamanhoServices;

        public TamanhosListUC(FormatosTamanhosModel formatoModel, ProdutoModel produtoModel)
        {

            _queryString = new QueryStringServices(new QueryString());
            _tamanhoServices = new TamanhoServices(new TamanhoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            InitializeComponent();
            this.FormatoModel = formatoModel; //somente se estiver inserindo.
            this.ProdutoModel = produtoModel; //para busca
        }

        public void LoadTamanhos()
        {


            DataTable tableTamanhos = new DataTable();
            DataColumn column;
            DataRow row;

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "TamanhoIdColumn";
            tableTamanhos.Columns.Add(column);

            column = new DataColumn();
            column.DataType = this.FormatoModel != null ? Type.GetType(FormatoModel.Formato.ToString()) : Type.GetType("System.String");
            column.ColumnName = "TamanhoColumn";
            tableTamanhos.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "FormatoIdColumn";
            tableTamanhos.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "ProdutoIdColumn";
            tableTamanhos.Columns.Add(column);


            if (this.TamanhosListModel.Count > 0)
            {
                foreach (TamanhosModel model in this.TamanhosListModel)
                {
                    row = tableTamanhos.NewRow();
                    row["TamanhoIdColumn"] = int.Parse(model.TamanhoId.ToString());
                    row["TamanhoColumn"] = model.Tamanho.ToString();
                    row["FormatoIdColumn"] = int.Parse(model.FormatoId.ToString());
                    row["ProdutoIdColumn"] = int.Parse(model.ProdutoId.ToString());

                    tableTamanhos.Rows.Add(row);

                }
            }

            dgvTamanhos.DataSource = tableTamanhos;
        }

        private void ConfiguraDGV()
        {
            dgvTamanhos.ForeColor = Color.Black;

            dgvTamanhos.Columns[0].Visible = false;
            dgvTamanhos.Columns[2].Visible = false;
            dgvTamanhos.Columns[3].Visible = false;

            dgvTamanhos.Columns[1].HeaderText = "Tamanhos";
            dgvTamanhos.Columns[1].Width = 70;
            dgvTamanhos.Columns[1].CellTemplate.Value = CharacterCasing.Upper.ToString();
        }

        private void TamanhosListUC_Load(object sender, EventArgs e)
        {
            this.TamanhosListModel = (List<TamanhosModel>)_tamanhoServices.GetByProdutoModel(this.ProdutoModel);
            LoadTamanhos();//LENDO OS TAMANHOS EXISTENTES
            ConfiguraDGV();
        }
    }
}
