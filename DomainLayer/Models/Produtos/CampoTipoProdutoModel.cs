using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models.Produtos
{
    public class CampoTipoProdutoModel : ICampoTipoProdutoModel
    {
        [Key]
        public int CampoTipoId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obrigatório (Nome).")]
        [StringLength(100, ErrorMessage = "Não pode ter mais que 100 caracteres.")]
        public string Nome { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obrigatório. Deve estar vinculado a um Tipo de Produto")]
        public int TipoProdutoId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obrigatório. Deve estar vinculado a um Formato.")]
        public int FormatoId { get; set; }

    }
}
