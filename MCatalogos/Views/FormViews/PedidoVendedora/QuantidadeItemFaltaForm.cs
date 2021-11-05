using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCatalogos.Views.FormViews.PedidoVendedora
{
    public partial class QuantidadeItemFaltaForm : Form
    {
        public int valorDigitado;
        private int qtdAtual;
        public QuantidadeItemFaltaForm(int qtdAtual)
        {
            InitializeComponent();
            this.qtdAtual = qtdAtual;
            textQtd.Focus();
        }

        private void textQuantidade_Leave(object sender, EventArgs e)
        {
            if (ValidaValorDigitado(textQtd.Text))
            {
                valorDigitado = int.Parse(textQtd.Text);
                this.Close();
            }
            else
            {
                textQtd.Focus();
            }
        }
        private void textQtd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ValidaValorDigitado(textQtd.Text))
                {
                    valorDigitado = int.Parse(textQtd.Text);
                    this.Close();
                }
                else
                {
                    textQtd.Focus();
                }
                
            }
        }

        private bool ValidaValorDigitado(string text)
        {
            try
            {

                if (int.TryParse(text, out int qtdParsed))
                {
                    if (qtdParsed >= qtdAtual)
                    {
                        throw new Exception("Tem que ser menor que a quantidade no pedido.");
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    throw new Exception("Deve ser numérica.");
                }

            }
            catch (Exception e)
            {
                MessageBox.Show($"Quantidade inválida \n{ e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;   

            }
        }

    }
}
