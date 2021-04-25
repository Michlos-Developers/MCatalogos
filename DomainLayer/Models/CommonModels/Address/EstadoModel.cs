using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.CommonModels.Address
{
    public class EstadoModel : IEstadoModel
    {
        public int EstadoId { get { return this.EstadoId; } set { this.EstadoId = value; } }
        public string Nome { get; set; }
        public string Uf { get; set; }
        public string CodIbge { get; set; }


    }
}
