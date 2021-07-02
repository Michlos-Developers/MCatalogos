using DomainLayer.Models.Vendedora;

using System;

namespace DomainLayer.Models.PedidosVendedoras
{
    public interface IPedidosVendedorasModel
    {
        bool Cancelado { get; set; }
        bool Conferido { get; set; }
        DateTime? DataCancelamento { get; set; }
        DateTime? DataConferencia { get; set; }
        DateTime? DataDespacho { get; set; }
        DateTime? DataEnvio { get; set; }
        DateTime DataRegistro { get; set; }
        DateTime? DataSeparacao { get; set; }
        bool Despachado { get; set; }
        bool Entregue { get; set; }
        bool Enviado { get; set; }
        int PedidoId { get; set; }
        bool Separado { get; set; }
        double? ValorLucroDistribuidor { get; set; }
        double? ValorLucroVendedora { get; set; }
        double? ValotTotalPedido { get; set; }
        int VendedoraId { get; set; }
        VendedoraModel VendedoraModel { get; set; }
        DateTime? DataEntrega { get; set; }
    }
}