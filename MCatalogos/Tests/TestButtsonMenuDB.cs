using DomainLayer.Models.Modulos;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Specific.Modulos;

using MCatalogos.Commons;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.ModulosServices;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCatalogos.Tests
{
    public partial class TestButtsonMenuDB : Form
    {
        BtnClass btn = new BtnClass();

        QueryStringServices _queryString;
        private ModulosSerivces _modulosSerivces;

        public TestButtsonMenuDB()
        {
            _queryString = new QueryStringServices(new QueryString());
            _modulosSerivces = new ModulosSerivces(new ModulosRepository(_queryString.GetQueryApp()));

            InitializeComponent();
        }

        private void TestButtsonMenuDB_Load(object sender, EventArgs e)
        {
            IEnumerable<ModulosModel> modelList = null;
            try
            {
                modelList = (IEnumerable<ModulosModel>)_modulosSerivces.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possível recuperar a lista de Módulos do sistema.\nMessage: {ex.Message}", "Erro Access List");
            }

            modelList = modelList.Where(m => m.Ativo == true).OrderByDescending(c => c.ModuloId);

            foreach (var modulo in modelList)
            {
                panelButtons.Controls.Add(btn.generateButtons(modulo.Nome, modulo.Nome));
            }
        }
    }
}
