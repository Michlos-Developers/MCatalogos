using DomainLayer.DataAttribute;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Vendedora
{
    public class TelefoneVendedoraModel : ITelefoneVendedoraModel
    {
        public enum TipoTelefone
        {
            Fixo,
            Oi,
            Claro,
            Vivo,
            Tim
        }

        [Key]
        public int TelefoneId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O número do telfone de ser informado")]
        [StringLength(11)]
        [Index("UK_TelVend", IsUnique = true)]
        public string Numero { get; set; }
        public TipoTelefone Tipo { get; set; }

        [Required]
        [CascadeDelete]
        public virtual VendedoraModel Vendedora { get; set; }

    }
}
