using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models.Estoques
{
    public class EstoqueModel : IEstoqueModel
    {
        [Key]
        public int EstoqueId { get; set; }

        [Required]
        [Range (0, int.MaxValue, ErrorMessage = "O produto tem que pertencer a um Catálogo")]
        public int CatalogoId { get; set; }

        [Required]
        [Range (0, int.MaxValue, ErrorMessage = "O produto em estoque tem que pertencer a uma Campanha")]
        public int CampanhaId { get; set; }

        [Required]
        [Range (0, int.MaxValue, ErrorMessage = "O produto em estoque tem que estar vinculado a um produto cadastrado")]
        public int ProdutoId { get; set; }

        [Required]
        [Range (0.0, float.MaxValue, ErrorMessage = "Valor de compra não pode ser 0")]
        public float ValorCompra { get; set; }

        [Required]
        [Range (0.0, float.MaxValue, ErrorMessage = "Valor do produto na Campanha Atual não pode ser 0")]
        public float ValorCampanhaAtual { get; set; }

        [Required]
        [Range (0, int.MaxValue, ErrorMessage = "Quantidade de produtos em estoque não pode ser 0")]
        public int Quantidade { get; set; }

    }
}
