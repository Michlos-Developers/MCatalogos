using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models.Produtos
{
    public class ProdutoModel : IProdutoModel
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obrigatório (Referência)")]
        [StringLength(100, ErrorMessage = "Referência deve ter no máximo 100 caracteres")]
        public string Referencia { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obrigatório (Descrição)")]
        [StringLength(500, ErrorMessage = "Descrição de ter no máximo 500 caracteres")]
        public string Descricao { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obrigatório (Valor Catálogo)")]
        public float ValorCatalogo { get; set; }


        public float ValorCatalogo2 { get; set; }
        public int Pagina { get; set; }
        public string MargemVendedora { get; set; }
        public string MargemDistribuidor { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obrigatório (Produto Ativo)")]
        public bool Ativo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obrigatório. O produto deve estar vinculado a um Catálogo")]
        public int CatalogoId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obrigatório. O produto deve estar vinculado a uma Campanha")]
        public int CampanhaId { get; set; }


    }
}
