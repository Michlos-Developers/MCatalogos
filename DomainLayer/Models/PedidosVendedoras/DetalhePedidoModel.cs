using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.PedidosVendedoras
{
    public class DetalhePedidoModel
    {
        public int DetalheId { get; set; }
        public int PedidoId { get; set; }
        public int CatalogoId { get; set; }

    }
}
