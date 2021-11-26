using System;

namespace DomainLayer.Models.Reports.PedidosVendedoras
{
    public class RelatorioPedidosVendedorasMasterModel : IRelatorioPedidosVendedorasMasterModel
    {
        public int PedidoId { get; set; }
        public double PedidoValorTotal { get; set; }
        public double PedidoValorTotalPagar { get; set; }
        public double PedidoValorLucroVendedora { get; set; }
        public DateTime PedidoDataVencimento { get; set; }
        public string VendedoraNome { get; set; }
        public string VendedoraRota { get; set; }
        public string DistribuidorNomeFantasia { get; set; }

    }
}
