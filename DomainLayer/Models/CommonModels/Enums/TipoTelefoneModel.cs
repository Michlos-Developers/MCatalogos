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

        public TipoTelefoneModel(int tipoId)
        {
            TipoId = tipoId;            
        }

        public TipoTelefoneModel(string tipoTelefone)
        {
            TipoTelefone = tipoTelefone;
        }

        public TipoTelefoneModel()
        {

        }

        public override string ToString()
        {
            return $"{TipoId}";
        }
    }
}
