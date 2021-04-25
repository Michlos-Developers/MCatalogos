using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.CommonModels.Enums
{
    public class TipoTelefoneModel : ITipoTelefoneModel
    {
        public int TipoId { get; set; }
        public string TipoTelefone { get; set; }

    }
}
