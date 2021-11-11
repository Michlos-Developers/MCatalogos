using DomainLayer.Models.Catalogos;
using DomainLayer.Models.Distribuidor;
using DomainLayer.Models.PedidosVendedoras;
using DomainLayer.Models.Vendedora;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Reports.Pedidos
{
    public class ReportPedidosVendedorasModel
    {
        public string NomeFantasiaDistribuidor { get; set; }
        public string NomeVendedora { get; set; }
        public string NomeCatalogo { get; set; }
        public string NomeCampanha { get; set; }
        public int PedidoId { get; set; }
        public int DetlhePedidoId { get; set; }

    }
}

