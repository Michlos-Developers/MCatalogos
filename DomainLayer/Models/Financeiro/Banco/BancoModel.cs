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
        

    }
}
