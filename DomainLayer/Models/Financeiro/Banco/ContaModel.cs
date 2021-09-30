using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models.Financeiro.Banco
{
    public class ContaModel : IContaModel
    {
        [Required()]
        public int ContaId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obrigatório")]
        [ForeignKey("BancoModel")]
        public int BancoId { get; set; }
        public virtual BancoModel BancoModel { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obrigatório")]
        public string NumeroConta { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obrigatório")]
        public string DvNumeroConta { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obrigatório")]
        public string NumeroAgencia { get; set; }

        public string DvNumeroAgencia { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obrigatório")]
        public double SaldoAnterior { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obrigatório")]
        public double SaldoAtual { get; set; }

        public bool Cancelado { get; set; }

    }
}
