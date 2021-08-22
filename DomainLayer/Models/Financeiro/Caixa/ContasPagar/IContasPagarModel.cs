using DomainLayer.Models.Financeiro.Caixa.Enums;
using DomainLayer.Models.Financeiro.Provisionamento;
using DomainLayer.Models.TitulosPagar;

using System;

namespace DomainLayer.Models.Financeiro.Caixa.ContasPagar
{
    public interface IContasPagarModel
    {
        bool Cancelado { get; set; }
        int ContasPagarId { get; set; }
        DateTime DataRegistro { get; set; }
        int OrigemId { get; set; }
        ParcelaTituloPagar ParcelaTituloPagar { get; set; }
        int ProvisionamentoId { get; set; }
        ProvisionamentoModel ProvisionamentoModel { get; set; }
        TipoMovimentacao TipoMovimentacao { get; set; }
        double ValorPago { get; set; }
    }
}