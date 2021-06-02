using DomainLayer.Models.Vendedora;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Commons;
using InfrastructureLayer.DataAccess.Repositories.Specific.Vendedora;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.BairroServices;
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

namespace MCatalogos.Views.FormViews.Configuracoes.Rotas
{
    public partial class RefatoraRotasFormList : Form
    {
        QueryStringServices _queryString;
        private RotaServices _rotaServices;
        private RotaLetraServices _rotaLetraServices;
        private VendedoraServices _vendedoraServices;
        private BairroServices _bairroServices;

        public RefatoraRotasFormList()
        {
            _queryString = new QueryStringServices(new QueryString());
            _rotaServices = new RotaServices(new RotaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _rotaLetraServices = new RotaLetraServices(new RotaLetraRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _vendedoraServices = new VendedoraServices(new VendedoraRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _bairroServices = new BairroServices(new BairroRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());

            InitializeComponent();
        }

        public void LoadRotasAtuaisToDataGrid()
        {
            List<RotaModel> modelList = null;
            try
            {
                modelList = (List<RotaModel>)_rotaServices.GetAll();
            }
            catch (Exception e)
            {
                MessageBox.Show($"Não foi possível trazer a lista de Rotas Atuais.\nMessage: {e.Message}", "Error Access List");

            }

            DataTable tableRotas = new DataTable();
            DataColumn column;
            DataRow row;

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "RotaId";
            tableRotas.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Vendedora";
            tableRotas.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Bairro";
            tableRotas.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Logradouro";
            tableRotas.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Letra";
            tableRotas.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "Numero";
            tableRotas.Columns.Add(column);

            if (modelList.Count!=0)
            {
                foreach (RotaModel model in modelList)
                {
                    row = tableRotas.NewRow();
                    row["RotaId"] = int.Parse(model.RotaId.ToString());
                    row["Vendedora"] = _vendedoraServices.GetById(model.VendedoraId).Nome.ToString();
                    row["Bairro"] = _bairroServices.GetById(_vendedoraServices.GetById(model.VendedoraId).BairroId).Nome.ToString();
                    row["Logradouro"] = _vendedoraServices.GetById(model.VendedoraId).Logradouro.ToString();
                    row["Letra"] = _rotaLetraServices.GetById(model.RotaLetraId).RotaLetra.ToString();
                    row["Numero"] = int.Parse(model.Numero.ToString());

                    tableRotas.Rows.Add(row);
                }
            }

            dgvRotasAntuais.DataSource = tableRotas;


        }

        private void ConfiguraDgvRotaAtual()
        {
            dgvRotasAntuais.Columns["RotaId"].Visible = false;
            dgvRotasAntuais.Columns["Vendedora"].Width = 200;
            dgvRotasAntuais.Columns["Bairro"].Width = 200;
            dgvRotasAntuais.Columns["Logradouro"].Width = 100;
            dgvRotasAntuais.Columns["Letra"].Width = 50;
            dgvRotasAntuais.Columns["Numero"].HeaderText = "Nº";
            dgvRotasAntuais.Columns["Numero"].Width = 30;
            dgvRotasAntuais.ForeColor = Color.Black;
        }

        private void RefatoraRotasFormList_Load(object sender, EventArgs e)
        {
            LoadRotasAtuaisToDataGrid();
            ConfiguraDgvRotaAtual();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
