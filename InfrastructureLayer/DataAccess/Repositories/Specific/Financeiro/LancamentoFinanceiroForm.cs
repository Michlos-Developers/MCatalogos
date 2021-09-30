using DomainLayer.Models.Financeiro.Caixa.Enums;
using DomainLayer.Models.Financeiro.Lancamentos;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfrastructureLayer.DataAccess.Repositories.Specific.Financeiro
{
    public partial class LancamentoFinanceiroForm : Form
    {
        #region DADOS DE INSTÂNCIA DO FORMULÁRIO PAI
        //FORMULÁRIO PAI CHAMADOR.
        Control Control;

        private static LancamentoFinanceiroForm aForm = null;
        public static LancamentoFinanceiroForm Instance(Control control)
        {
            if (aForm == null)
            {
                aForm = new LancamentoFinanceiroForm(control);
            }
            return aForm;
        }

        #endregion

        LancamentoDestino Destino;
        TipoMovimentacao TipoMovimentacao;

        //TODO: PREENCHER COMBOBOX DE DESTINO COM CAIXA/BANCO.
        //TODO: VER A POSSIBILIDADE DE USAR O TIPO DE LANÇAMENTO PARA FAZER O LANÇAMENTO UM FORM GENÉRICO 
        //TANTO PARA CONTAS A RECEBER QUANTO CONTAS A PAGAR.
        //TODO: CHECAR O TIPO DE MOVIMENTAÇÃO QUE ESTÁ SENDO FEITO.
            /*
             * SE FOR CONTAS A RECEBER O DESTINO PEGA BANCO E CAIXA E A ORIGEM É O TÍTULO
             * SE FOR CONTAS A PAGAR O DESTINO É O TÍTULO E A ORIGEM É O BANCO/CAIXA?? AINDA RESTA DÚVIDAS QUANTO A ESSA DEFINIÇÃO.
             */
        //TODO: SE BANCO HABILITAR COMBOBOX DA CONTA E LISTAR CONTAS BANCÁRIAS CADASTRADAS.
        //TODO: SE RESPOSTA FOR ABATER VALOR TOTAL TRAZ O VALOR A ABATER PREENCHIDO COM TOTAL EM ABERTO.
        //TODO: GERAR HISTÓRICO DO TÍTULO.

        


        public LancamentoFinanceiroForm(Control control)
        {
            InitializeComponent();
            LoadComboBoxDestino();
            LoadComboBoxTipoMovimentacao();
            LoadComboBoxConta();
        }


        private void LoadComboBoxDestino()
        {
            cbDestino.Items.AddRange(Enum.GetNames(typeof(LancamentoDestino)));          
        }

        private void cbDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            Destino = (LancamentoDestino)Enum.Parse(typeof(LancamentoDestino), cbDestino.SelectedItem.ToString());
            if (Destino == LancamentoDestino.BANCO)
            {
                cbConta.Enabled = true;
                cbConta.TabStop = true;
            }
            else
            {
                cbConta.Enabled = false;
                cbConta.TabStop = false;
            }
        }
        private void LoadComboBoxTipoMovimentacao()
        {
            cbTipoLancamento.Items.AddRange(Enum.GetNames(typeof(TipoMovimentacao)));
        }
        private void LoadComboBoxConta()
        {
            if (Destino == LancamentoDestino.BANCO)
            {
                //TODO: Ler as contas registradas no sistema.
            }
        }
    }
}
