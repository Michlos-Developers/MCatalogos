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

        //[Required(AllowEmptyStrings = false, ErrorMessage = "A Letra da Rota deve ser informada")]
        //[StringLength(1, ErrorMessage = "Escolha apenas Uma Letra")]
        //[MaxLength(1, ErrorMessage = "Apenas uma letra")]
        //[RegularExpression(@"[A-Z]", ErrorMessage = "Utilize somente letras")]
        //public string Letra { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O Número da Rota deve ser informado")]
        //[RegularExpression(@"\d{2}", ErrorMessage = "Utilize somente números. Dois caracteres.")]
        public int Numero { get; set; }

        public int RotaLetraId { get; set; }
        public virtual RotaLetraModel RotaLetra { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "A Vendedora deve ser indicada na rota" )]
        public int VendedoraId { get; set; }
        public virtual VendedoraModel Vendedora { get; set; }
    }
}
