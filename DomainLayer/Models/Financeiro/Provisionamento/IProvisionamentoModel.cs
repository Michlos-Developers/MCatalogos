using DomainLayer.Models.Financeiro.Caixa.Enums;

using System;

namespace DomainLayer.Models.Financeiro.Provisionamento
{
    public interface IProvisionamentoModel
    {
        DateTime DataRegistro { get; set; }
        string Descricao { get; set; }
        int DestinoId { get; set; }
        int OrigemId { get; set; }
        int ProvisionamentoId { get; set; }
        double SaldoAnterior { get; set; }
        double SaldoAtual { get; set; }
        TipoMovimentacao TipoMovimentacao { get; set; }
        double ValorProvisionado { get; set; }
        bool Cancelado { get; set; }
    }
}