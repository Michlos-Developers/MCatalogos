using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Vendedora
{
    public class EstadoCivilModel : IEstadoCivilModel
    {
        public enum EstadoCivilDescricao
        {
            Solteiro,
            Casado,
            Viúvo,
            Separado,
            Divorciado
        }
        public int EstadoCivilId { get; set; }
        public string EstadoCivil { get; set; }

    }
}
