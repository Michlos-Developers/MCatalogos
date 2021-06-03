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
using System.Drawing;
using System.Drawing.Text;
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
            Added,
            Updated,
            Delete
        }

        enum RotaLetraAddType
        {
            Added,
            Updated
        }

        QueryStringServices _queryString;

        private RotaServices _rotaNumeroServices;
        private RotaLetraServices _rotaLetraServices;
        private VendedoraServices _vendedoraServices;


        /// <summary>
        /// TODAS AS ALTERAÇÕES SÃO SALVAS NOS MODELS E NÃO DIRETO NO BANCO DE DADOS
        /// AS ÚNICAS ALTERAÇÕES FEITAS DIRETAMENTE NO BANCO, ALÉM DO MÉTODO SALVAR, 
        /// SÃO: ADIÇÃO DE LETRA DE ROTA / ADIÇÃO DE NÚMERO DE ROTA
        /// </summary>
        private RotaModel rotaNumeroModel;
        private VendedoraModel vendedoraModel;
        private RotaLetraModel rotaLetraModel;
        private RotaModel rotaAlvoAlteracao;


        /// <summary>
        /// INICIALIZA O FORMULÁRIO RECEBENDO A MODEL DA VENDEDORA
        /// </summary>
        /// <param name="vendedoraModel"></param>
        public RotasEditUC(VendedoraModel vendedoraModel)
        {
            _queryString = new QueryStringServices(new QueryString());
            _rotaNumeroServices = new RotaServices(new RotaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _rotaLetraServices = new RotaLetraServices(new RotaLetraRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _vendedoraServices = new VendedoraServices(new VendedoraRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());

            InitializeComponent();
            this.vendedoraModel = vendedoraModel;

        }

        /// <summary>
        /// LoadForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RotasEditUC_Load(object sender, EventArgs e)
        {
            this.btnSave.Enabled = false;
            LoadModels();
            FillCbLetraRota();
            FillFieds();
        }


        /// <summary>
        /// Carrega os daods nos Models RotaModel/RotaLetraModel
        /// </summary>
        /// <methods>GetVendedoraRotaNumero</methods>
        public void LoadModels()
        {

            //VERIFICA SE VENDEDORA TEM ROTANUMERO
            RotaModel checaRota = GetVendedoraRotaNumero(this.vendedoraModel);
            if (checaRota.RotaId != 0) //SE SIM VENDEDORA COM ROTA SENÃO VENDEDORA SEM ROTA
            {
                this.rotaNumeroModel = checaRota;
            }


            this.rotaLetraModel = _rotaLetraServices.GetById(this.vendedoraModel.RotaLetraId);


        }

        /// <summary>
        /// Busca a Rota da Vendedora
        /// </summary>
        /// <param name="vendedoraModel"></param>
        /// <returns>RotaModel</returns>
        public RotaModel GetVendedoraRotaNumero(VendedoraModel vendedoraModel)
        {
            RotaModel rotaNumeroModel = new RotaModel();
            rotaNumeroModel = _rotaNumeroServices.GetByVendedoraId(vendedoraModel.VendedoraId);

            return rotaNumeroModel;
        }

        /// <summary>
        /// Preenche os campos com os dados dos models coletados
        /// </summary>
        public void FillFieds()
        {
            this.textNomeVendedora.Text = this.vendedoraModel.Nome;
            this.cbLetraRota.Text = this.rotaLetraModel.RotaLetra;
            this.cbNumeroRota.Text = (this.rotaNumeroModel.Numero != 0) ? this.rotaNumeroModel.Numero.ToString() : "Nullo";
        }

        /// <summary>
        /// Gera Lista de RotasLetras para seleção no ComboBox
        /// </summary>
        public void FillCbLetraRota()
        {
            List<RotaLetraModel> modelList = (List<RotaLetraModel>)_rotaLetraServices.GetAll();

            cbLetraRota.DisplayMember = "RotaLetra";
            cbLetraRota.SelectedItem = null;
            cbLetraRota.Items.Clear();
            foreach (RotaLetraModel model in modelList)
            {
                cbLetraRota.Items.Add(model);
            }
        }


        /// <summary>
        /// IDENTIFICA O ITEM SELECIONADO E CHAMA O MÉTODO PARA PREENCHER OS ITENS DO COMBOX NUMERO.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <method name="FillCbNumeroRota"></method>
        private void cbLetraRota_SelectedIndexChanged(object sender, EventArgs e)
        {
            RotaLetraModel rotaLetra = new RotaLetraModel();

            //SE FOR NULL ACABOU DE CRIAR, ENTÃO TEM QUE SER DIFERENTE DE NULL
            //SE FOR DIFERENTE DA LETRA DA VENDEDORA SELECIONADA.
            if (cbLetraRota.SelectedItem != null && cbLetraRota.SelectedItem.ToString() != this.rotaLetraModel.RotaLetra.ToString())
            {

                rotaLetra = _rotaLetraServices.GetByLetra(cbLetraRota.SelectedItem.ToString());
                FillCbNumeroRota(rotaLetra);
            }//SE FOR IGUAL AO DA VENDEDORA VERIFICA SE TEM ROTA NA VENDEDORA E PEGA A MESMA QUE JÁ ESTÁ NELA.
            else if (cbLetraRota.SelectedItem.ToString() == this.rotaLetraModel.RotaLetra.ToString())
            {
                rotaLetra = _rotaLetraServices.GetByLetra(cbLetraRota.SelectedItem.ToString());
                FillCbNumeroRota(rotaLetra);
                cbNumeroRota.SelectedItem = (this.rotaNumeroModel.Numero != 0) ? this.rotaNumeroModel.Numero.ToString() : null;
            }
            else
            {
                //CHAMA O ALTERA LETRA
            }
        }

        /// <summary>
        /// PREENCHE OS ITEMS DO COMBOBOX NÚMERO CONFORME SELEÇÃO DO COMBOBOX LETRA.
        /// </summary>
        /// <param name="rotaLetra"></param>
        public void FillCbNumeroRota(RotaLetraModel rotaLetra)
        {
            List<RotaModel> modelList = (List<RotaModel>)_rotaNumeroServices.GetAllByLetraId(rotaLetra.RotaLetraId);

            cbNumeroRota.DisplayMember = "Numero";
            cbNumeroRota.SelectedItem = null;
            cbNumeroRota.Items.Clear();
            foreach (RotaModel model in modelList)
            {
                cbNumeroRota.Items.Add(model);

            }
        }


        /// <summary>
        /// Detecta a última letra de rotas existentes e aciona o método AddRotaLetra 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddLetraRota_Click(object sender, EventArgs e)
        {
            string lastLetra = _rotaLetraServices.GetLastLetra().RotaLetra;
            if (lastLetra != "Z")
            {
                string nextLetra = GetNextLetra(lastLetra);
                try
                {
                    AddRotaLetra(nextLetra);
                    MessageBox.Show($"Letra Adicionada com sucesso\nLetra: {nextLetra}", "Adicionar Rota", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.rotaLetraModel = _rotaLetraServices.GetByLetra(nextLetra);
                    FillCbLetraRota();
                    cbLetraRota.SelectedItem = this.rotaLetraModel.RotaLetra;
                    FillFieds();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível adicionar uma nova letra à lista de Rotas. \n" + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Já foram adicionadas todas as letras para a Rota.\nEntre em contato com o Suporte.");
            }
        }


        /// <summary>
        /// Chama o método Add do RotaLetraSerivces para criar a nova letra.
        /// </summary>
        /// <param name="nextLetra"></param>
        private void AddRotaLetra(string nextLetra)
        {

            RotaLetraModel model = new RotaLetraModel();
            try
            {
                model.RotaLetra = nextLetra;
                _rotaLetraServices.Add(model);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// IDENTIFICA AS ÚNICAS LETRAS DISPONÍVEIS PARA A ROTA E APONTA PARA A PRÓXIMA LETRA
        /// </summary>
        /// <param name="lastLetra"></param>
        /// <returns></returns>
        private string GetNextLetra(string lastLetra)
        {
            string nextLetra = string.Empty;
            string alfabeto = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            int pos = alfabeto.IndexOf(lastLetra) + 1;

            nextLetra = alfabeto[pos].ToString();

            return nextLetra;
        }


        /// <summary>
        /// CHAMA O MÉTODO AddNumeroRota
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddNumRota_Click(object sender, EventArgs e)
        {

            try
            {
                RotaNumeroAddType typeReturn = AddNumeroRota();
                if (typeReturn == RotaNumeroAddType.Added)
                {
                    MessageBox.Show("A rota foi Adicionada com sucesso", "Adição de Número de Rota", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if (typeReturn == RotaNumeroAddType.Updated)
                {
                    MessageBox.Show("A rota foi Alterada com sucesso", "Adição de Número de Rota", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.rotaNumeroModel = _rotaNumeroServices.GetByVendedoraId(this.vendedoraModel.VendedoraId);
                FillCbNumeroRota(this.rotaLetraModel);
                cbNumeroRota.SelectedItem = this.rotaNumeroModel.Numero;
                FillFieds();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível adicionar um novo número à rota da Vendedora. \n" + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// VERIFICA SE A VENDEDORA TEM ROTA.
        /// SE TIVER IDENTIFICAR AS PRÓXIMAS VENDEDORAS PARA SUBIR AS ROTAS 
        /// ALTERANDO A ROTA DA VENDEDORA SELECIONADA PARA A ÚLTIMA ROTA DA LETRA
        /// SE A VENDEDORA NÃO TIVER ROTA, APENAS ADICIONA.
        /// </summary>
        /// <returns></returns>
        private RotaNumeroAddType AddNumeroRota()
        {
            RotaNumeroAddType typeReturn = new RotaNumeroAddType();

            rotaAlvoAlteracao = _rotaNumeroServices.GetLastNumero(this.rotaLetraModel.RotaLetraId);


            int nextNumero = rotaAlvoAlteracao.Numero + 1;

            RotaModel rotaAtual = null;
            List<RotaModel> rotasNumeroList = null;

            //VENDEDORA NÃO TEM ROTA
            if (!ChecaRotaVendedora())
            {
                this.rotaNumeroModel.Numero = nextNumero;
                _rotaNumeroServices.Add(this.rotaNumeroModel);
                typeReturn = RotaNumeroAddType.Added;

            }
            else
            { //VENDEDORA TEM ROTA - TROCA VAI PARA A ÚLTIMA ROTA AS DEMAIS VENDEDORAS DEVEM SUBIR NA ROTA.
                var result = MessageBox.Show("Essa vendedora já possui uma rota cadastrada. " +
                                             "O passo correto é mudar a rota dessa vendedora para a última posição. " +
                                             $"\nDeseja alterar a rota da vendedora para {this.rotaLetraModel.RotaLetra} - {rotaAlvoAlteracao.Numero} ?",
                                             "Adição de Número da Rota", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    rotaAtual = this.rotaNumeroModel;
                    rotasNumeroList = (List<RotaModel>)_rotaNumeroServices.GetAllByLetraId(this.rotaLetraModel.RotaLetraId);
                    try
                    {
                        //ALTERA A ROTA DA VENDEDORA PARA A ÚLTIMA E JÁ SALVA OS DADOS NO BANCO DE DADOS
                        _rotaNumeroServices.RefatoraRotas(rotaAlvoAlteracao, this.vendedoraModel.VendedoraId, rotasNumeroList, rotaAtual);
                        typeReturn = RotaNumeroAddType.Updated;

                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Não foi possível refatorar as Rotas\nMessageError:" + e.Message, "Adição de Número de Rota");
                    }
                }
            }
            return typeReturn;
        }

        /// <summary>
        /// VERIFICA SE EXISTE ROTA CADASTRADA COM A ID DA VENDEDORA
        /// </summary>
        /// <returns></returns>
        private bool ChecaRotaVendedora()
        {
            bool vendedoraTemRota = false;

            List<RotaModel> modelList = (List<RotaModel>)_rotaNumeroServices.GetAll();

            foreach (RotaModel model in modelList)
            {
                if (model.VendedoraId == this.vendedoraModel.VendedoraId)
                {
                    vendedoraTemRota = true;
                }
            }

            return vendedoraTemRota;
        }


        /// <summary>
        /// ALTERAÇÃO DE NÚMERO DA ROTA DIRETO NO COMBOBOX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbNumeroRota_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNumeroRota.SelectedItem.ToString() != this.rotaNumeroModel.Numero.ToString())
            {
                try
                {
                    RotaNumeroAddType addType = new RotaNumeroAddType();
                    addType = RotaNumeroAddType.Updated;
                    AlteraRotaNumero(addType);
                    LoadModels();

                }
                catch (Exception)
                {
                    MessageBox.Show("Não foi possível alterar a Rota da Vendedora", "Alteração de Número da Rota", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void AlteraRotaNumero(RotaNumeroAddType addType)
        {
            /*
             * SALVA A ROTA ALVO
             * E FAZ A REFATORAÇÃO DE ROTAS.
             */

            this.rotaAlvoAlteracao = _rotaNumeroServices.GetByNumeroAndLetraId(int.Parse(cbNumeroRota.SelectedItem.ToString()), this.rotaLetraModel.RotaLetraId);

            List<RotaModel> rotasNumeroList = (List<RotaModel>)_rotaNumeroServices.GetAllByLetraId(this.rotaLetraModel.RotaLetraId);
            RotaModel rotaOrigem = new RotaModel();

            try
            {
                if (addType == RotaNumeroAddType.Updated)
                {
                    _rotaNumeroServices.RefatoraRotas(this.rotaAlvoAlteracao, this.vendedoraModel.VendedoraId, rotasNumeroList, this.rotaNumeroModel);
                    this.rotaNumeroModel = this.rotaAlvoAlteracao;

                }
                else if (addType == RotaNumeroAddType.Delete)
                {
                    if (this.rotaNumeroModel.RotaId != rotasNumeroList.LastIndexOf(this.rotaNumeroModel))
                    {
                        this.rotaAlvoAlteracao = this.rotaNumeroModel;
                        rotaOrigem = _rotaNumeroServices.GetByNumeroAndLetraId(this.rotaNumeroModel.Numero + 1, this.rotaLetraModel.RotaLetraId);
                        _rotaNumeroServices.RefatoraRotas(this.rotaAlvoAlteracao, this.vendedoraModel.VendedoraId, rotasNumeroList, rotaOrigem);
                        _rotaNumeroServices.Delete(this.rotaNumeroModel);
                        //CHAMAR O LOAD MODELS DEPOIS DISSO

                    }

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Não foi possível realizar a alteração da Rota da Vendedora.", "Alteração de Número da Rota", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        

        private void AlteraRotaLetra()
        {
            /*
             * VERIFICA SE A VENDEDORA TEM ROTA.
             * SE TIVER ROTA ELA IRÁ PERDER A ROTA.
             * 
             * SE A VENDEDORA TIVER VENDEDORAS ABAIXO DELA NA ROTA
             * ENTÃO AS VENDEDORAS ABAIXO DELA SUBIRÃO.
             * SENÃO A ROTA SIMPLESMENTE É APAGADA.
             * ENTÃO DEVEMOS FAZER A ALTERAÇÃO DO NÚMERO PRIMEIRO
             * LEMBRANDO QUE ELE PODERÁ SER CHAMADO POR ESSE.
             * 
             * 
             */
            if (this.rotaNumeroModel.Numero != 0)
            {

            }
        }

    }
}
