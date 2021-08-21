using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models.Financeiro.Banco
{
    public class BancoModel : IBancoModel
    {
        [Required()]
        public int BancoId { get; set; }
        [Required()]
        public int NumeroBanco { get; set; }
        [Required()]
        public string NomeBanco { get; set; }
        [Required()]
        public string NumeroConta { get; set; }
        [Required()]
        public string DvNumeroConta { get; set; }
        [Required()]
        public string NumeroAgencia { get; set; }

        public string DvNumeroAgencia { get; set; }

        [Required()]
        public double SaldoAnterior { get; set; }
        [Required()]
        public double SaldoAtual { get; set; }

        public bool Cancelado { get; set; }

    }
}
