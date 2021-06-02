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
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCatalogos.Views.FormViews.Rotas
{
    public partial class RotasFormView : Form
    {
        #region PROPRIEDADES PARA MOVER A JANELA

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        #endregion

        MainView MainView;

        bool isClosing = false;

        private QueryStringServices _queryString;


        private RotaServices _rotaServices;
        private RotaLetraServices _rotaLetraServices;
        private VendedoraServices _vendedoraServices;
        private BairroServices _bairroServices;
        private int? idGrid = null;

        private VendedoraModel vendedora = null;
        private RotaModel rota = null;
        private RotaLetraModel rotaLetra = null;

        private static RotasFormView aForm = null;

        public static RotasFormView Instance(MainView mainView)
        {
            if (aForm == null)
            {
                aForm = new RotasFormView(mainView);
            }
            else
            {
                aForm.BringToFront();
            }
            return aForm;
        }
        public RotasFormView(MainView mainView)
        {
            _queryString = new QueryStringServices(new QueryString());
            _rotaServices = new RotaServices(new RotaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _rotaLetraServices = new RotaLetraServices(new RotaLetraRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _vendedoraServices = new VendedoraServices(new VendedoraRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _bairroServices = new BairroServices(new BairroRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());

            InitializeComponent();
            this.MainView = mainView;
        }

        //OWNER METHODS LOADS
        public void LoadRotasToDataGrid()
        {
            List<RotaModel> modelList = null;
            try
            {
                modelList = (List<RotaModel>)_rotaServices.GetAll();
            }
            catch (Exception e)
            {
                MessageBox.Show($"Não foi possível carregar a lista de Rotas.\nMessage:{e.Message}", "Error Access List");

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

            if (modelList.Count != 0)
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

            dgvRotas.DataSource = tableRotas;
        }
        private void LoadVendedorasSemRotasToDataGrid()
        {

            Task<List<VendedoraModel>> vendedoraModel = GetVendedorasSemRota();
            List<VendedoraModel> modelList = vendedoraModel.Result;

            DataTable tableVendedoras = new DataTable();
            DataColumn column;
            DataRow row;

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "VendedoraId";
            tableVendedoras.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Nome";
            tableVendedoras.Columns.Add(column);

            if (vendedoraModel.Result != null)
            {
                foreach (VendedoraModel model in modelList)
                {
                    row = tableVendedoras.NewRow();
                    row["VendedoraId"] = int.Parse(model.VendedoraId.ToString());
                    row["Nome"] = model.Nome;

                    tableVendedoras.Rows.Add(row);
                }
            }
            dgvVendedoraSemRota.DataSource = tableVendedoras;

        }
        private void LoadLetrasToComboBox()
        {
            List<RotaLetraModel> modelList = (List<RotaLetraModel>)_rotaLetraServices.GetAll();

            cbLetraRota.DisplayMember = "RotaLetra";
            cbLetraRota.SelectedIndex = -1;
            cbLetraRota.Items.Clear();
            foreach (RotaLetraModel model in modelList)
            {
                cbLetraRota.Items.Add(model);
            }
        }
        private void LoadNumeroToCombox(int rotaLetraId)
        {
            List<RotaModel> modelList = (List<RotaModel>)_rotaServices.GetAllByLetraId(rotaLetraId);

            cbNumeroRota.DisplayMember = "Numero";
            cbNumeroRota.Items.Clear();
            foreach (RotaModel model in modelList)
            {
                cbNumeroRota.Items.Add(model);
            }
        }
        private void ConfiguraDataGridRotas()
        {
            dgvRotas.Columns["RotaId"].Visible = false;
            dgvRotas.Columns["Vendedora"].Width = 200;
            dgvRotas.Columns["Bairro"].Width = 200;
            dgvRotas.Columns["Logradouro"].Width = 100;
            dgvRotas.Columns["Letra"].Width = 50;
            dgvRotas.Columns["Numero"].HeaderText = "Nº";
            dgvRotas.Columns["Numero"].Width = 30;
            dgvRotas.ForeColor = Color.Black;
        }
        private void ConfiguraDataGridVendedoras()
        {
            dgvVendedoraSemRota.Columns["VendedoraId"].Visible = false;
            dgvVendedoraSemRota.Columns["Nome"].Width = 290;
            dgvVendedoraSemRota.ForeColor = Color.Black;
        }

        private void ClearForm()
        {
            this.vendedora = null;
            this.rota = null;
            this.rotaLetra = null;
            textNomeVendedora.Text = string.Empty;
            cbLetraRota.Text = string.Empty;
            cbNumeroRota.Text = string.Empty;
            gboxEditRotas.Enabled = false;
        }


        //OWNER METHODS GETTINGS AND SETTINGS
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
                MessageBox.Show($"Não foi possível adicionar uma nova letra na rota \nErrorMessage:\n{e.Message}", "Falha na Rota");
            }
        }
        private void AddNumeroRota(int rotaLetraId, int vendedoraId)
        {
            int lastNumero = _rotaServices.GetLastNumero(rotaLetraId).Numero;
            int nextNumero = lastNumero + 1;
            RotaModel model = new RotaModel()
            {
                RotaLetraId = rotaLetraId,
                VendedoraId = vendedoraId,
                Numero = nextNumero
            };

            try
            {
                _rotaServices.Add(model);
                this.rota = model as RotaModel;
                this.vendedora = _vendedoraServices.GetById(model.VendedoraId);
                this.rotaLetra = _rotaLetraServices.GetById(model.RotaLetraId);
            }
            catch (Exception e)
            {
                MessageBox.Show("Não foi possível adicionar Novo Número de Rota para a Vendedora.\nErrorMessage: " + e.Message);
                throw e;
            }
            MessageBox.Show($"Nova rota adicionada na vendedora\n" +
                            $"Rota: {this.rotaLetra.RotaLetra} - {this.rota.Numero} " +
                            $"Vendedora: {this.vendedora.Nome}");

        }
        private void AlteraNumeroRota(int numeroRota)
        {
            RotaModel rotaNumero = _rotaServices.GetByNumeroAndLetraId(numeroRota, this.rotaLetra.RotaLetraId);
            RotaModel rotaAtual = null;
            List<RotaModel> rotaList = null;

            if (rotaNumero.VendedoraId != 0 && rotaNumero.VendedoraId != this.vendedora.VendedoraId)
            {
                VendedoraModel vendedoraNaRota = _vendedoraServices.GetById(rotaNumero.VendedoraId);
                var result = MessageBox.Show($"A Rota {this.rotaLetra.RotaLetra} - {rotaNumero.Numero} pertence a outra vendedora.\n" +
                                             $"Vendedora: {vendedoraNaRota.Nome} \n\n" +
                                             $"Caso prossiga o sistema irá alterar a rota de várias vendedoras.\n" +
                                             $"\bDeseja Continuar?",
                                             "Alteração de Rotas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    //VERIFICA SE A VENDEDORA TEM ROTA, CASO NAO TENHO CRIA
                    if (!VerificaRotaVendedora(this.vendedora.VendedoraId))
                    {
                        int lastNumero = _rotaServices.GetLastNumero(this.rotaLetra.RotaLetraId).Numero;
                        int nextNumero = lastNumero + 1;
                        RotaModel AddedRota = new RotaModel()
                        {
                            Numero = nextNumero,
                            RotaLetraId = this.rotaLetra.RotaLetraId,
                            VendedoraId = this.vendedora.VendedoraId
                        };
                        _rotaServices.Add(AddedRota);
                    }

                    //REFAZ AS DEMAIS ROTAS
                    rotaAtual = _rotaServices.GetByVendedoraId(this.vendedora.VendedoraId);
                    rotaList = (List<RotaModel>)_rotaServices.GetAllByLetraId(this.rotaLetra.RotaLetraId);
                    try
                    {
                        _rotaServices.RefatoraRotas(rotaNumero, vendedora.VendedoraId, rotaList, rotaAtual);
                        MessageBox.Show("Rotas recalculadas com sucesso");
                        LoadRotasToDataGrid();
                        ConfiguraDataGridRotas();
                        LoadVendedorasSemRotasToDataGrid();
                        ConfiguraDataGridVendedoras();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Não foi possível retornar a lista de rotas. \nMessageError: " + e.Message);
                    }
                }
            }
        }
        private void AlteraLetraRota(int rotaId, int rotaLetraId, int vendedoraId)
        {
            RotaLetraModel rotaLetra = _rotaLetraServices.GetByLetra(cbLetraRota.Text);
            var result = MessageBox.Show($"Essa ação alterará a Letra da Rota da Vendedora\n\n" +
                                         $"Deseja Continuar?", "Alteração de Rota", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _vendedoraServices.AlteraRota(vendedoraId, rotaLetraId);
                    _rotaServices.AlteraLetraId(rotaId, rotaLetraId);
                    MessageBox.Show("Rota alterada com sucesso");
                    LoadRotasToDataGrid();
                    ConfiguraDataGridRotas();
                    LoadVendedorasSemRotasToDataGrid();
                    ConfiguraDataGridVendedoras();
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Não foi possível alterar a rota da vendedora.\nMessage: {e.Message}");
                }


            }
            ClearForm();
        }
        private async Task<List<VendedoraModel>> GetVendedorasSemRota()
        {
            List<RotaModel> rotaList = (List<RotaModel>)_rotaServices.GetAll();
            List<VendedoraModel> vendedoraList = (List<VendedoraModel>)_vendedoraServices.GetAll();
            List<VendedoraModel> vendedoraSemRotaList = null;

            foreach (VendedoraModel modelVendededora in vendedoraList)
            {
                bool temRota = false;
                foreach (RotaModel modelRota in rotaList)
                {
                    if (modelRota.VendedoraId == modelVendededora.VendedoraId)
                    {
                        temRota = true;
                    }
                }
                if (!temRota)
                {
                    vendedoraSemRotaList.Add(modelVendededora);
                }
            }

            return vendedoraSemRotaList;
        }
        private string GetNextLetra(string lastLetra)
        {
            string nextLetra = string.Empty;
            string alfabeto = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int pos = alfabeto.IndexOf(lastLetra);

            pos++;
            nextLetra = alfabeto[pos].ToString();
            return nextLetra;
        }




        //OWNER METHOD CHECKING
        private bool VerificaRotaVendedora(int vendedoraId)
        {
            bool result = false;
            int rotaId = 0;
            rotaId = _rotaServices.GetByVendedoraId(vendedoraId).RotaLetraId;
            if (rotaId != 0)
            {
                result = true;
            }
            return result;
        }


        //EVENTS DATAGRIDS
        private void dgvRotas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idGrid = e.RowIndex;

            this.rota = _rotaServices.GetById(int.Parse(dgvRotas.CurrentRow.Cells["RotaId"].Value.ToString()));
            this.vendedora = _vendedoraServices.GetById(rota.VendedoraId);
            this.rotaLetra = _rotaLetraServices.GetById(rota.RotaLetraId);

            LoadLetrasToComboBox();

            this.textNomeVendedora.Text = this.vendedora.Nome;
            this.cbLetraRota.Text = this.rotaLetra.RotaLetra;
            this.cbNumeroRota.Text = this.rota.Numero.ToString();
            this.btnAddNumRota.Enabled = false;
            this.gboxEditRotas.Enabled = true;
        }
        private void dgvVendedoraSemRota_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idGrid = e.RowIndex;
            this.vendedora = _vendedoraServices.GetById(int.Parse(dgvVendedoraSemRota.CurrentRow.Cells["VendedoraId"].Value.ToString()));
            this.rotaLetra = _rotaLetraServices.GetById(vendedora.RotaLetraId);

            LoadLetrasToComboBox();

            this.textNomeVendedora.Text = this.vendedora.Nome;
            this.cbLetraRota.Text = this.rotaLetra.RotaLetra.ToString();
            this.cbNumeroRota.Text = "0";
            this.btnAddNumRota.Enabled = true;
            this.gboxEditRotas.Enabled = true;
        }


        //EVENTS COMBOBOXES
        private void cbNumeroRota_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNumeroRota.SelectedIndex > -1)
            {
                AlteraNumeroRota(int.Parse(cbNumeroRota.Text));

            }
        }
        private void cbLetraRota_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLetraRota.SelectedIndex > -1)
            {

                RotaLetraModel rotaLetra = _rotaLetraServices.GetByLetra(cbLetraRota.Text);
                LoadNumeroToCombox(rotaLetra.RotaLetraId);

                if (vendedora.RotaLetraId != rotaLetra.RotaLetraId)
                {

                    AlteraLetraRota(this.rota.RotaId, rotaLetra.RotaLetraId, this.vendedora.VendedoraId);
                }


            }
        }


        //EVENTS FORM
        private void RotasFormView_Load(object sender, EventArgs e)
        {
            ClearForm();
            LoadRotasToDataGrid();
            ConfiguraDataGridRotas();
            LoadVendedorasSemRotasToDataGrid();
            ConfiguraDataGridVendedoras();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            isClosing = true;
            this.Close();
        }
        private void btnAddLetraRota_Click(object sender, EventArgs e)
        {
            string lastLetra = _rotaLetraServices.GetLastLetra().RotaLetra;
            string nextLetra = GetNextLetra(lastLetra);
            if (lastLetra == "Z")
            {
                MessageBox.Show("Jà foram adicionadas todas as letras para Rotas.\nEntre em contato com o Suporte do Sistema.");
            }
            else
            {
                try
                {
                    AddRotaLetra(nextLetra);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível adicionar uma nova letra à lista de Rotas \nMessageError:" + ex.Message);

                }
                MessageBox.Show($"Letra {nextLetra} adicionada com sucesso.");
                LoadLetrasToComboBox();
                cbLetraRota.Text = _rotaLetraServices.GetLastLetra().RotaLetra;
            }
        }
        private void btnAddNumRota_Click(object sender, EventArgs e)
        {
            //TODO CHECAR SE VENDEDORA TEM ROTA. SE TEM NÃO DEIXA ADICIONAR NOVA.

            var result = MessageBox.Show($"Esse processo irá adiconar um novo número na Rota: {cbLetraRota.Text} \ne salvar na Vendedora: {textNomeVendedora.Text}.\nTem certeza que quer continuar?", "Adicionando Rota na Vendedora", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int rotaLetraId = _rotaLetraServices.GetByLetra(cbLetraRota.Text).RotaLetraId;
                AddNumeroRota(rotaLetraId, this.vendedora.VendedoraId);
                //cbNumeroRota.Text = _rotaServices.GetByVendedoraId(vendedora.VendedoraId).Numero.ToString();

            }
        }
        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void RotasFormView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            this.MainView.SetUnselectedButtons();
            base.Dispose(Disposing);
            aForm = null;
        }











    }
}
