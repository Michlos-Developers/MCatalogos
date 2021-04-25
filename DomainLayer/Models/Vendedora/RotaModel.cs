using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Vendedora
{
    public class RotaModel : IRotaModel
    {
        public int RotaId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "A Letra da Rota deve ser informada")]
        [StringLength(1, ErrorMessage = "Escolha apenas Uma Letra")]
        [MaxLength(1, ErrorMessage = "Apenas uma letra")]
        [RegularExpression(@"[A-Z]", ErrorMessage = "Utilize somente letras")]
        public string Letra { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O Número da Rota deve ser informado")]
        [StringLength(2, ErrorMessage = "Utilize números de 0 a 99, apenas")]
        [MaxLength(2, ErrorMessage = "Utilize apenas de 0 a 99. Não pode 3 dígitos.")]
        [RegularExpression(@"[0-9]{2}", ErrorMessage = "Utilize somente números")]
        public string Numero { get; set; }
    }
}
