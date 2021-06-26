using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models.Tamanho
{
    public class TamanhosModel : ITamanhosModel
    {
        [Key]
        public int TamanhoId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Nome do Tamanho deve ser informato")]
        public string Tamanho { get; set; }

        [Required]
        public int FormatoId { get; set; }

        [Required]
        public int ProdutoId { get; set; }

    }
}
