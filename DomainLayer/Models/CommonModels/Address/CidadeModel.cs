using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.CommonModels.Address
{
    public class CidadeModel : ICidadeModel
    {
        public int CidadeId { get; set; }
        public string Nome { get; set; }
        public string CodIbge { get; set; }
        public string Uf { get; set; }
        public int EstadoId { get; set; }
        public EstadoModel Estado { get; set; }
    }
}
