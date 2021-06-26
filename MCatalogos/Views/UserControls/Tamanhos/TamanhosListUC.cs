using DomainLayer.Models.Formatos;
using DomainLayer.Models.Produtos;
using DomainLayer.Models.Tamanho;

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

        private FormatosTamanhosModel FormatoModel; //FORMATO JÁ É BUSCADO PELO COMBOBOX DO PRODUTOADDFORM
        private ProdutoModel ProdutoModel;
        private TamanhosModel TamanhosModel;
        public List<TamanhosModel> tamanhosListModel;

        private QueryStringServices _queryString;
        private TamanhoServices _tamanhoServices;

        public TamanhosListUC(FormatosTamanhosModel formatoModel, ProdutoModel produtoModel)
        {

            InitializeComponent();
            this.FormatoModel = formatoModel;
            this.ProdutoModel = produtoModel;
        }

        public void LoadTamanhos()
        {


            DataTable tableTamanhos = new DataTable();
            DataColumn column;
            DataRow row;

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "TamanhoId";
            tableTamanhos.Columns.Add(column);

            column = new DataColumn();
            column.DataType = this.FormatoModel != null ? Type.GetType(FormatoModel.Formato.ToString()) : Type.GetType("System.String");
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

            if (TamanhosModel != null)
            {

                this.tamanhosListModel = (List<TamanhosModel>)_tamanhoServices.GetByProdutoModel(this.ProdutoModel);
                foreach (TamanhosModel model in this.tamanhosListModel)
                {
                    row = tableTamanhos.NewRow();
                    row["TamanhoId"] = int.Parse(model.TamanhoId.ToString());
                    row["Tamanho"] = model.Tamanho.ToString();
                    row["FormatoId"] = int.Parse(model.FormatoId.ToString());
                    row["ProdutoId"] = int.Parse(model.ProdutoId.ToString());

                    tableTamanhos.Rows.Add(row);

                }
            }




            dgvTamanhos.DataSource = tableTamanhos;
            ConfuguraDGV();


        }

        private void ConfuguraDGV()
        {
            dgvTamanhos.ForeColor = Color.Black;

            dgvTamanhos.Columns[0].Visible = false;
            dgvTamanhos.Columns[2].Visible = false;
            dgvTamanhos.Columns[3].Visible = false;

            dgvTamanhos.Columns[1].HeaderText = "Tamanhos";
            dgvTamanhos.Columns[1].Width = 70;
        }

        private void TamanhosListUC_Load(object sender, EventArgs e)
        {
            LoadTamanhos();
        }
    }
}
