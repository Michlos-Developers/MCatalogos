using DomainLayer.Models.Financeiro.Caixa;
using DomainLayer.Models.Financeiro.Caixa.Enums;

using System;

namespace DomainLayer.Models.Financeiro.Retirada
{
    public interface IRetiradaCaixaModel
    {
        string Autor { get; set; }
        DateTime DataRegistro { get; set; }
        string Justificativa { get; set; }
        int RetiradaId { get; set; }
        TipoMovimentacao TipoMovimentacao { get; set; }
        double ValorRetirada { get; set; }
        int CaixaId { get; set; }
        CaixaModel CaixaModel { get; set; }
        bool Cancelado { get; set; }
    }
}