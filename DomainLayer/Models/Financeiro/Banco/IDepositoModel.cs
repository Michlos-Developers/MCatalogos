using DomainLayer.Models.Financeiro.Caixa.Enums;
using DomainLayer.Models.Financeiro.Provisionamento;

using System;

namespace DomainLayer.Models.Financeiro.Banco
{
    public interface IDepositoModel
    {
        bool Cancelado { get; set; }
        int ContaId { get; set; }
        ContaModel ContaModel { get; set; }
        DateTime DataRegistro { get; set; }
        int DepositoId { get; set; }
        int ProvisionamentoId { get; set; }
        ProvisionamentoModel ProvisionamentoModel { get; set; }
        TipoMovimentacao TipoMovimentacao { get; set; }
        double ValorDeposito { get; set; }
    }
}