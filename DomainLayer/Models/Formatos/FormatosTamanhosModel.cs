using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models.Formatos
{
    public class FormatosTamanhosModel : IFormatosTamanhosModel
    {
        [Key]
        public int FormatoId { get; set; }

        [Required]
        public string NomeFormato { get; set; }

        [Required]
        public string Formato { get; set; }
    }
}
