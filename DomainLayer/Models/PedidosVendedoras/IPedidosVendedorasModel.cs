using DomainLayer.Models.Vendedora;

using System;

namespace DomainLayer.Models.PedidosVendedoras
{
    public interface IPedidosVendedorasModel
    {
        DateTime DataRegistro { get; set; }
        int PedidoId { get; set; }
        int StatusPed { get; set; }
        double? ValorLucroDistribuidor { get; set; }
        double? ValorLucroVendedora { get; set; }
        double? ValorTotalPedido { get; set; }
        int VendedoraId { get; set; }
        VendedoraModel VendedoraModel { get; set; }
        int? QtdCatalogos { get; set; }
        double? ValorTaxaPedido { get; set; }
        double? ValorTotalPagar { get; }
        DateTime DataVencimento { get; }
    }
}