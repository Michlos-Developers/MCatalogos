using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCatalogos.Views.FormViews.Financeiro.ContasReceber
{
    public partial class ValorReceberForm : Form
    {
        ContasReceberForm ContasReceberForm;
        
        /*
         * VALOR PARA ABATER. - OK
         * VALOR EM ABERTO PARA ABATER. - 
         * VALOR A ABATER NÃO PODE SER MAIOR QUE O VALOR EM ABERTO.
         * DESTINO P/ CAIXA OU P/ BANCO
         * 
         */
        
        public double valorAbater;
        public double valorAberto;

        

        private static ValorReceberForm aForm = null;
        internal static ValorReceberForm Instance(ContasReceberForm contasReceberForm)
        {
            if (aForm == null)
            {
                aForm = new ValorReceberForm(contasReceberForm);
            }
            return aForm;
        }
        public ValorReceberForm(ContasReceberForm contasReceberForm)
        {
            InitializeComponent();
            ContasReceberForm = contasReceberForm;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }
    }
}
