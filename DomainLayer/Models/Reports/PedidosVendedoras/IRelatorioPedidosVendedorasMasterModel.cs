using System;

namespace DomainLayer.Models.Reports.PedidosVendedoras
{
    public interface IRelatorioPedidosVendedorasMasterModel
    {
        DateTime PedidoDataVencimento { get; set; }
        int PedidoId { get; set; }
        double PedidoValorLucroVendedora { get; set; }
        double PedidoValorTotal { get; set; }
        double PedidoValorTotalPagar { get; set; }
        string VendedoraNome { get; set; }
        string VendedoraRota { get; set; }
        string DistribuidorNomeFantasia { get; set; }
    }
}