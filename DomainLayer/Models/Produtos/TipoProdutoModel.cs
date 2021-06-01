using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models.Produtos
{
    public class TipoProdutoModel : ITipoProdutoModel
    {
        [Key]
        public int TipoProdutoId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obrigatório")]
        [StringLength(600)]
        public string Descricao { get; set; }
    }
}
