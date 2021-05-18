using DomainLayer.Models.CommonModels.Address;

using InfrastructureLayer.DataAccess.Repositories.Commons;
using InfrastructureLayer.DataAccess.Repositories.Specific.Fornecedor;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.BairroServices;
using ServiceLayer.Services.CidadeServices;
using ServiceLayer.Services.EstadosServices;
using ServiceLayer.Services.FornecedorServices;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCatalogos.Views.FormViews.Fornecedores
{
    public partial class FornecedorForm : Form
    {
        FornecedoresListForm FornecedoresListForm;

        private FornecedorServices _fornecedorServices;
        private EstadoServices _estadoServices;
        private CidadeServices _cidadeServices;
        private BairroServices _bairroServices;

        private static string _connectionString = @"SERVER=.\SQLEXPRESS;DATABASE=MCatalogoDB;INTEGRATED SECURITY=SSPI";


        public FornecedorForm(FornecedoresListForm fornecedoresListForm)
        {
            _fornecedorServices = new FornecedorServices(new FornecedorRepository(_connectionString), new ModelDataAnnotationCheck());
            _estadoServices = new EstadoServices(new EstadoRepository(_connectionString), new ModelDataAnnotationCheck());
            _cidadeServices = new CidadeServices(new CidadeRepository(_connectionString), new ModelDataAnnotationCheck());
            _bairroServices = new BairroServices(new BairroRepository(_connectionString), new ModelDataAnnotationCheck());

            InitializeComponent();
            this.FornecedoresListForm = fornecedoresListForm;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FornecedorForm_Load(object sender, EventArgs e)
        {
            LoadEstadosToComboBox();
        }

        private void LoadEstadosToComboBox()
        {
            List<EstadoModel> modelList = (List<EstadoModel>)_estadoServices.GetAll();

            cbUf.DisplayMember = "Uf";
            cbUf.SelectedIndex = 0;
            cbUf.Items.Clear();
            foreach (EstadoModel model in modelList)
            {
                cbUf.Items.Add(model);
            }
        }




        private void LoadCidadesToComboBox(string uf)
        {
            List<CidadeModel> modelList = (List<CidadeModel>)_cidadeServices.GetAllByUf(uf);

            cbCidade.DisplayMember = "Nome";
            cbCidade.Items.Clear();
            foreach (CidadeModel model in modelList)
            {
                cbCidade.Items.Add(model);
            }
        }

        private void SetMaskInscricaoEstadual(string uf)
        {
            switch (uf)
            {
                case "AC":
                    mTextInscricaoEstadual.Mask = "00.000.000/000-00";
                    break;
                case "AL":
                    mTextInscricaoEstadual.Mask = "00000000#";
                    break;
                case "AP":
                    mTextInscricaoEstadual.Mask = "000000000";
                    break;
                case "AM":
                    mTextInscricaoEstadual.Mask = "00.000.000-0";
                    break;
                case "BA":
                    if (mTextInscricaoEstadual.Text.Length == 8)
                    {
                        mTextInscricaoEstadual.Mask = "000000-00";
                    }
                    else
                    {
                        mTextInscricaoEstadual.Mask = "0000000-00";
                    }
                    break;
                case "CE":
                    mTextInscricaoEstadual.Mask = "00000000-0";
                    break;
                case "DF":
                    mTextInscricaoEstadual.Mask = "00000000000-00";
                    break;
                case "ES":
                    mTextInscricaoEstadual.Mask = "00000000-0";
                    break;
                case "GO":
                    mTextInscricaoEstadual.Mask = "00.000.000-0";
                    break;
                case "MA":
                    mTextInscricaoEstadual.Mask = "00000000-0";
                    break;
                case "MT":
                    mTextInscricaoEstadual.Mask = "0000000000-0";
                    break;
                case "MS":
                    mTextInscricaoEstadual.Mask = "00000000-0";
                    break;
                case "MG":
                    mTextInscricaoEstadual.Mask = "000.000.000/0000";
                    break;
                case "PA":
                    mTextInscricaoEstadual.Mask = "00-000000-0";
                    break;
                case "PB":
                    mTextInscricaoEstadual.Mask = "00000000-0";
                    break;
                case "PE":
                    mTextInscricaoEstadual.Mask = "0000000-00";
                    break;
                case "PI":
                    mTextInscricaoEstadual.Mask = "0000000-00";
                    break;
                case "PR":
                    mTextInscricaoEstadual.Mask = "000.00000-00";
                    break;
                case "RJ":
                    mTextInscricaoEstadual.Mask = "00.000.00-0";
                    break;
                case "RN":
                    mTextInscricaoEstadual.Mask = "00.000.000-0";
                    break;
                case "RS":
                    mTextInscricaoEstadual.Mask = "000/0000000";
                    break;
                case "SP":
                    mTextInscricaoEstadual.Mask = "000.000.000.000";
                    break;
                case "SC":
                    mTextInscricaoEstadual.Mask = "000.000.000";
                    break;
                case "SE":
                    mTextInscricaoEstadual.Mask = "00000000-0";
                    break;
                case "TO":
                    mTextInscricaoEstadual.Mask = "0000000000-0";
                    break;
                default:
                    mTextInscricaoEstadual.Mask = "";
                    break;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

        }

        private void cbUf_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbUf.SelectedIndex > 0)
            {
                LoadCidadesToComboBox(cbUf.Text);
                SetMaskInscricaoEstadual(cbUf.Text);
            }
        }

        private void cbCidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBAirrosToComboBox(cbCidade.Text);
        }

        private void LoadBAirrosToComboBox(string text)
        {
            List<BairroModel> modelList = (List<BairroModel>)_bairroServices.GetByCidadeId(
                    _cidadeServices.GetByNomeAndEstadoId(
                    cbCidade.Text, 
                    _estadoServices.GetByUf(cbUf.Text).EstadoId).CidadeId);

            if (modelList != null)
            {
                cbBairro.DisplayMember = "Nome";
                cbBairro.Items.Clear();
                foreach (BairroModel model in modelList)
                {
                    cbBairro.Items.Add(model);
                }
            }
        }
    }
}
