using DomainLayer.Models.Financeiro.Caixa.Enums;

using System;

namespace DomainLayer.Models.Financeiro.Caixa
{
    public interface ICaixaModel
    {
        int CaixaId { get; set; }
        DateTime DataRegistro { get; set; }
        int DestinoId { get; set; }
        int OrigemId { get; set; }
        double SaldoAnterior { get; set; }
        double SaldoAtual { get; set; }
        TipoMovimentacao TipoMovimentacao { get; set; }
        double ValorRegistro { get; set; }
    }
}