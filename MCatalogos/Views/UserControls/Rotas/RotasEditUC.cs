using DomainLayer.Models.Vendedora;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Specific.Vendedora;

using MCatalogos.Views.FormViews.Rotas;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.RotaServices;
using ServiceLayer.Services.VendedoraServices;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.SymbolStore;
using System.Drawing;
using System.Drawing.Text;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCatalogos.Views.UserControls.Rotas
{

    public partial class RotasEditUC : UserControl
    {

        enum RotaNumeroAddType
        {
            Add,
            Update,
            Delete
        }

        enum RotaLetraAddType
        {
            Add,
            Update
        }

        QueryStringServices _queryString;

        private RotaServices _rotaNumeroServices;
        private RotaLetraServices _rotaLetraServices;
        private VendedoraServices _vendedoraServices;

        private VendedoraModel vendedoraModel = new VendedoraModel();
        private RotasFormView rotasFormView;
        private RotaModel collectedNumeroRota;
        private RotaLetraModel collectedLetraRota;

        private RotaModel rotaNumeroModel = new RotaModel();
        private RotaLetraModel rotaLetraModel = new RotaLetraModel();
        private RotaModel rotaAlvoAlteracao;
        private RotaModel rotaOrigemAlteracao;
        private List<RotaModel> rotasListaParaAlteracao = new List<RotaModel>();




        /// <summary>
        /// INICIALIZA O FORMULÁRIO RECEBENDO A MODEL DA VENDEDORA
        /// </summary>
        /// <param name="vendedoraModel"></param>
        public RotasEditUC(VendedoraModel vendedoraModel, RotasFormView rotasFormView)
        {
            _queryString = new QueryStringServices(new QueryString());
            _rotaNumeroServices = new RotaServices(new RotaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _rotaLetraServices = new RotaLetraServices(new RotaLetraRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _vendedoraServices = new VendedoraServices(new VendedoraRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());

            InitializeComponent();
            this.vendedoraModel = vendedoraModel;
            this.rotasFormView = rotasFormView;

        }

        private void RotasEditUC_Load(object sender, EventArgs e)
        {
            LoadModelsFromVendedora();
            LoadLetrasRotasToComboBox();
            PreencheCampos();
            LoadNumerosRotasToComboBox();
        }

        private void PreencheCampos()
        {
            this.textNomeVendedora.Text = this.vendedoraModel != null ? this.vendedoraModel.Nome : string.Empty;
            this.cbLetraRota.Text = this.vendedoraModel != null ? this.rotaLetraModel.RotaLetra : string.Empty;
            this.cbNumeroRota.Text = this.rotaNumeroModel != null ? this.rotaNumeroModel.Numero.ToString() : string.Empty;
            this.btnAddNumRota.Enabled = true;
            this.btnAddLetraRota.Enabled = true;
        }

        private void LimpaCampos()
        {
            this.textNomeVendedora.Text = string.Empty;
            this.cbLetraRota.Text = string.Empty;
            this.cbNumeroRota.Text = string.Empty;
            this.btnAddLetraRota.Enabled = false;
            this.btnAddNumRota.Enabled = false;
            this.rotasFormView.gboxEditRotas.Enabled = false;
        }

        private void LoadLetrasRotasToComboBox()
        {
            List<RotaLetraModel> modelList = (List<RotaLetraModel>)_rotaLetraServices.GetAll();

            cbLetraRota.DisplayMember = "RotaLetra";
            cbLetraRota.Items.Clear();
            foreach (RotaLetraModel model in modelList)
            {
                cbLetraRota.Items.Add(model);
            }
        }

        private void LoadModelsFromVendedora()
        {
            this.rotaLetraModel = this.vendedoraModel != null ? _rotaLetraServices.GetById(this.vendedoraModel.RotaLetraId) : null;

            RotaModel rotaModel = null;
            rotaModel = VendedoraTemRota();
            if (rotaModel != null)
            {

                this.rotaNumeroModel = rotaModel;
                this.collectedNumeroRota = this.rotaNumeroModel;

            }
            this.collectedLetraRota = this.rotaLetraModel;





        }

        private RotaModel VendedoraTemRota()
        {
            RotaModel model = null;
            try
            {
                model = this.vendedoraModel != null ? _rotaNumeroServices.GetByVendedoraId(this.vendedoraModel.VendedoraId) : null;

            }
            catch (Exception)
            {

                MessageBox.Show("Não foi possível verificar a rota da vendedora.");
            }

            return model;
        }

        private void cbLetraRota_SelectionChangeCommitted(object sender, EventArgs e)
        {
            RotaLetraModel selectedLetraRota = cbLetraRota.SelectedItem as RotaLetraModel;

            if (this.rotaLetraModel.RotaLetraId != selectedLetraRota.RotaLetraId)
            {

                this.rotaLetraModel = cbLetraRota.SelectedItem as RotaLetraModel;
                LoadNumerosRotasToComboBox();
                //ALTERAR SEMPRE NA TROCA
                //SE TROCAR A LETRA
                //1- VERIFICA SE A VENDEDORA TEM ROTA
                //1.1- SE TIVER ROTA ELE DEVE SER ALTERADA PARA O ÚLTIMO NÚMERO DA ROTA.
                //1.2- DEPOIS DISSO ESSA ROTA DEVE SER APAGADA.
                //2- SE NÃO TIVER ROTA
                //3- ALTERA A LETRA DA VENDEDORA
                this.rotaOrigemAlteracao = VendedoraTemRota();

                if (this.rotaOrigemAlteracao.RotaId != 0) //1.1vendedora tem rota
                {
                    this.rotaAlvoAlteracao = _rotaNumeroServices.GetLastNumero(this.vendedoraModel.RotaLetraId);
                    this.rotasListaParaAlteracao = (List<RotaModel>)_rotaNumeroServices.GetAllByLetraId(this.vendedoraModel.RotaLetraId);

                    //ALTERA PARA A ÚLTIMA
                    AlteraNumeroRota(this.rotaAlvoAlteracao, this.rotaOrigemAlteracao);
                    //_rotaNumeroServices.RefatoraRotas(this.rotaAlvoAlteracao, this.vendedoraModel.VendedoraId, this.rotasListaParaAlteracao, this.rotaOrigemAlteracao);

                    this.rotaAlvoAlteracao = _rotaNumeroServices.GetByVendedoraId(this.vendedoraModel.VendedoraId);

                    //DEPOIS DE ALTERADO APAGA
                    DeleteNumeroRota(this.rotaAlvoAlteracao);

                    //A ROTALETRAMODEL ESTÁ COM A ROTA SELECIONADA
                    //ALTERA A ROTA NA VENDEDORA
                    _vendedoraServices.AlteraRotaLetra(this.vendedoraModel.VendedoraId, this.rotaLetraModel.RotaLetraId);


                }
                else
                {
                    _vendedoraServices.AlteraRotaLetra(this.vendedoraModel.VendedoraId, this.rotaLetraModel.RotaLetraId);

                }
                LimpaCampos();
                ReloadDataGridFormView();
            }


        }

        private void DeleteNumeroRota(RotaModel rotaAlvo)
        {
            _rotaNumeroServices.Delete(rotaAlvo);
        }

        private void LoadNumerosRotasToComboBox()
        {
            List<RotaModel> modelList = new List<RotaModel>();
            modelList = this.vendedoraModel != null ? (List<RotaModel>)_rotaNumeroServices.GetAllByLetraId(this.rotaLetraModel.RotaLetraId) : null;

            cbNumeroRota.DisplayMember = "Numero";
            cbNumeroRota.Items.Clear();
            if (modelList != null)
            {
                if (modelList.Count > 0)
                {
                    foreach (RotaModel model in modelList)
                    {
                        cbNumeroRota.Items.Add(model);
                    }
                }
                else
                {
                    cbNumeroRota.Text = string.Empty;
                }
            }
        }

        private void cbNumeroRota_SelectionChangeCommitted(object sender, EventArgs e)
        {
            RotaModel selectedNumeroRota = this.cbNumeroRota.SelectedItem as RotaModel;

            if (this.rotaNumeroModel.RotaId != selectedNumeroRota.RotaId)
            {
                this.rotaAlvoAlteracao = this.cbNumeroRota.SelectedItem as RotaModel;
                AlteraNumeroRota(this.rotaAlvoAlteracao, this.rotaNumeroModel);
                ReloadDataGridFormView();
                LimpaCampos();
            }
        }

        private void AlteraNumeroRota(RotaModel rotalAlvo, RotaModel rotaOrigem)
        {
            //ver se a a vendedora tem não tem rota.
            List<RotaModel> rotaList = (List<RotaModel>)_rotaNumeroServices.GetAllByLetraId(this.rotaLetraModel.RotaLetraId);

            if (rotaOrigem.Numero == 0)
            {
                AddNumeroRota();
                rotaOrigem = this.rotaNumeroModel;
            }

            try
            {
                _rotaNumeroServices.RefatoraRotas(rotalAlvo, this.vendedoraModel.VendedoraId, rotaList, rotaOrigem);
                MessageBox.Show("Rota Alterada");
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível alterar o Número da Rota da Vendedora");
            }
        }


        private void ReloadDataGridFormView()
        {

            this.rotasFormView.LoadRotasToDataGrid();
            this.rotasFormView.dgvRotas.ClearSelection();
            this.rotasFormView.pictureArrowRight.Visible = false;

            this.rotasFormView.LoadVendedorasSemRotasToDataGrid();
            this.rotasFormView.dgvVendedoraSemRota.ClearSelection();
            this.rotasFormView.pictureArrowUp.Visible = false;
        }

        private void btnAddNumRota_Click(object sender, EventArgs e)
        {
            //ADICIONAR NÚMERO NA ROTA COM A VENDEDORA SEM ROTA.
            RotaModel vendedoraTemRota = VendedoraTemRota();
            if (vendedoraTemRota.RotaId == 0)
            {
                AddNumeroRota();
                ReloadDataGridFormView();
                LimpaCampos();

            }
            else
            {
                this.rotaAlvoAlteracao = _rotaNumeroServices.GetLastNumero(this.rotaLetraModel.RotaLetraId);
                var result = MessageBox.Show($"A vendedora \"{this.vendedoraModel.Nome}\" já possui uma rota cadastrada. " +
                    $"Não será permitido criar uma nova rota para ela. " +
                    $"Ao invés disso você pode colocá-la na última rota da Letra \"{this.rotaLetraModel.RotaLetra}\" " +
                    $"que pertence a \"{_vendedoraServices.GetById(rotaAlvoAlteracao.VendedoraId).Nome}\".\n\n" +
                    $"Deseja realizar realizar a alteração da rota?",
                    "Adicionando número de rota", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    AlteraNumeroRota(this.rotaAlvoAlteracao, vendedoraTemRota);
                    ReloadDataGridFormView();
                    LimpaCampos();
                }
            }

        }

        private void AddNumeroRota()
        {
            RotaModel lastNumeroRotaModel = _rotaNumeroServices.GetLastNumero(this.rotaLetraModel.RotaLetraId);
            int nextNumero = lastNumeroRotaModel.Numero + 1;
            this.rotaNumeroModel = new RotaModel()
            {
                RotaLetraId = this.rotaLetraModel.RotaLetraId,
                VendedoraId = this.vendedoraModel.VendedoraId,
                Numero = nextNumero
            };

            try
            {
                _rotaNumeroServices.Add(this.rotaNumeroModel);
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível adicionar um novo número à rota");
                throw;
            }

        }

        private void btnAddLetraRota_Click(object sender, EventArgs e)
        {
            //ADICIONAR LETRA NA ROTA DA VENDEDORA
            try
            {

                AddLetraRota();
                ReloadDataGridFormView();
                LimpaCampos();
                MessageBox.Show("Letra Adicionada");

            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível adicionar uma nova Letra");
            }

        }

        private void AddLetraRota()
        {
            string lastLetra = _rotaLetraServices.GetLastLetra().RotaLetra;
            string nextLetra = GetNextLetra(lastLetra);
            if (lastLetra == "Z")
            {
                MessageBox.Show("Já foram adicionadas todas as letras disponíveis para Rota.\nEntre em contato com o Suporte");
            }
            else
            {
                RotaLetraModel addRotaLetra = new RotaLetraModel() { RotaLetra = nextLetra };
                _rotaLetraServices.Add(addRotaLetra);
                this.rotaLetraModel = _rotaLetraServices.GetByLetra(addRotaLetra.RotaLetra);
                _vendedoraServices.AlteraRotaLetra(this.vendedoraModel.VendedoraId, this.rotaLetraModel.RotaLetraId);
                this.vendedoraModel = _vendedoraServices.GetById(this.vendedoraModel.VendedoraId);
            }
        }

        private string GetNextLetra(string lastLetra)
        {
            string alfabeto = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int pos = alfabeto.IndexOf(lastLetra);
            string nextLetra = string.Empty;
            pos++;
            nextLetra = alfabeto[pos].ToString();
            return nextLetra;
        }




        //VERIFICAR O QUE FAZER SE O USUÁRIO SELECIONAR UM NÚMERO AO INVÉS DE ADICIONAR.

    }
}
