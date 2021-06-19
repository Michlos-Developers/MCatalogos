using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models.Estoques
{
    public class EstoqueModel : IEstoqueModel
    {
        [Key]
        public int EstoqueId { get; set; }

        [Required]
        public int CatalogoId { get; set; }

        [Required]
        public int CampanhaId { get; set; }

        [Required]
        public int ProdutoId { get; set; }

        [Required]
        public float ValorCompra { get; set; }

        [Required]
        public float ValorCampanhaAtual { get; set; }

        [Required]
        public int Quantidade { get; set; }

    }
}
