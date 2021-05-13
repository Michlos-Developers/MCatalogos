using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Vendedora
{
    public class RotaLetraModel : IRotaLetraModel
    {
        public int RotaLetraId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "A Letra da Rota deve ser informada")]
        [StringLength(1, ErrorMessage = "Escolha apenas Uma Letra")]
        [MaxLength(1, ErrorMessage = "Apenas uma letra")]
        [RegularExpression(@"[A-Z]", ErrorMessage = "Utilize somente letras")]
        [Index("UX_ROTALETRA", IsClustered = false, IsUnique = true)]
        public string RotaLetra { get; set; }
    }
}
