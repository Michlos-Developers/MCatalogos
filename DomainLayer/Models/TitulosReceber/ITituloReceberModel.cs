using DomainLayer.Models.CommonModels.Enums;
using DomainLayer.Models.PedidosVendedoras;
using DomainLayer.Models.Vendedora;

using System;

namespace DomainLayer.Models.TitulosReceber
{
    public interface ITituloReceberModel
    {
        DateTime DataEmissao { get; set; }
        DateTime DataRegistro { get; set; }
        DateTime DataVencimento { get; set; }
        bool Parcelado { get; set; }
        int PedidoId { get; set; }
        PedidosVendedorasModel PedidosVendedorasModel { get; set; }
        int QtdParcelas { get; set; }
        int TipoTituloId { get; set; }
        TipoTituloModel TipoTituloModel { get; set; }
        int TituloId { get; set; }
        double ValorLiquidado { get; set; }
        double ValorDesconto { get; set; }
        double ValorTitulo { get; set; }
        int VendedoraId { get; set; }
        VendedoraModel VendedoraModel { get; set; }
        double ValorParcela { get; set; }
        StatusTitulo StatusTitulo { get; set; }
    }
}