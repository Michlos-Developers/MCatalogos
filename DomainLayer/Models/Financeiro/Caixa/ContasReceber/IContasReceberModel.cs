using DomainLayer.Models.Financeiro.Caixa.Enums;
using DomainLayer.Models.TitulosReceber;

using System;

namespace DomainLayer.Models.Financeiro.Caixa.ContasReceber
{
    public interface IContasReceberModel
    {
        int CaixaId { get; set; }
        CaixaModel CaixaModel { get; set; }
        bool Cancelado { get; set; }
        int ContasReceberId { get; set; }
        DateTime DataRegistro { get; set; }
        int OrigemId { get; set; }
        TipoMovimentacao TipoMovimentacao { get; set; }
        TituloReceberModel TituloReceberModel { get; set; }
        double ValorRecebido { get; set; }
    }
}