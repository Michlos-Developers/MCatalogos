using DomainLayer.Models.CommonModels.Address;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Commons;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.BairroServices;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCatalogos.Views.FormViews.Bairros
{
    public partial class BairroAddForm : Form
    {
        
        private CidadeModel CidadeModel = new CidadeModel();
        public BairroModel BairroModel = new BairroModel();


        private QueryStringServices _queryString;
        private BairroServices _bairroServices;


        public BairroAddForm(CidadeModel cidadeModel, BairroModel bairroModel)
        {
            this._queryString = new QueryStringServices(new QueryString());
            this._bairroServices = new BairroServices(new BairroRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());

            InitializeComponent();
            
            this.CidadeModel = cidadeModel;
            this.BairroModel = bairroModel;

        }
        private void SetBGColorFocused(Control control)
        {

            control.BackColor = SystemColors.GradientActiveCaption;
        }

        private void SetBgColorUnfocused(Control control)
        {
            control.BackColor = SystemColors.Window;
        }

        private void textBairro_Enter(object sender, EventArgs e)
        {
            SetBGColorFocused(textBairro);
        }

        private void textBairro_Leave(object sender, EventArgs e)
        {
            SetBgColorUnfocused(textBairro);
        }

        private BairroModel InsertBairro(BairroModel bairroModel)
        {
            BairroModel bairroAdded = new BairroModel();
            bairroAdded = _bairroServices.Add(bairroModel);

            return bairroAdded;
        }

        private void UpdateBairro(BairroModel bairroModel)
        {
            _bairroServices.Update(bairroModel);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (this.BairroModel.BairroId != 0)
            {
                //UPDATE
                this.BairroModel.Nome = textBairro.Text;
                UpdateBairro(this.BairroModel);

            }
            else
            {
                //INSERT
                BairroModel bairroAdded = new BairroModel();
                this.BairroModel.Nome = textBairro.Text;
                this.BairroModel.CidadeId = CidadeModel.CidadeId;
                bairroAdded = InsertBairro(this.BairroModel);
                this.BairroModel = bairroAdded;
                
            }

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BairroAddForm_Load(object sender, EventArgs e)
        {
            this.textBairroId.Text = this.BairroModel.BairroId.ToString();
            this.textCidade.Text = this.CidadeModel.Nome;
            this.textBairro.Text = this.BairroModel.Nome;
        }
    }
}
