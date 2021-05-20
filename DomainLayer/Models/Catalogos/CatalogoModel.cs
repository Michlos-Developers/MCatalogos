using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Catalogos
{
    public class CatalogoModel : ICatalogoModel
    {
        public int CatalogoId { get; set; }
        public string Nome { get; set; }
        public float MargemPadraoVendedora { get; set; }
        public float MargemPadraoDistribuidor { get; set; }
        public bool Ativo { get; set; }
        public int FornecedorId { get; set; }

    }
}
