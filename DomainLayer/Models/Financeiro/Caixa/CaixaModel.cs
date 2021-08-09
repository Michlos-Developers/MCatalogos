using DomainLayer.Models.Financeiro.Caixa.Enums;

using System;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models.Financeiro.Caixa
{
    public class CaixaModel : ICaixaModel
    {
        [Required()]
        public int CaixaId { get; set; }
        [Required()]
        public DateTime DataRegistro { get; set; }
        [Required()]
        public double SaldoAnterior { get; set; }
        [Required()]
        public double SaldoAtual { get; set; }
        [Required()]
        public TipoMovimentacao TipoMovimentacao { get; set; }
        
        public int OrigemId { get; set; }
        public int DestinoId { get; set; }

    }
}
