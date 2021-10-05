using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models.Modulos
{
    public class ModuloCommandModel : IModuloCommandModel
    {
        [Key()]
        public int CommandId { get; set; }

        [Required()]
        public string CommandName { get; set; }

        [Required()]
        public string Command { get; set; }

        [Required()]
        [ForeignKey("ModulosModel")]
        public int ModuloId { get; set; }
        public virtual ModulosModel ModulosModel { get; set; }

    }
}
