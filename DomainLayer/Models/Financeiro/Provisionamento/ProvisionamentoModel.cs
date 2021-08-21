using DomainLayer.Models.Financeiro.Caixa.Enums;

using System;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models.Financeiro.Provisionamento
{
    public class ProvisionamentoModel : IProvisionamentoModel
    {
        [Required()]
        public int ProvisionamentoId { get; set; }

        public DateTime DataRegistro { get; set; }

        [Required()]
        public double SaldoAnterior { get; set; }

        [Required()]
        public double SaldoAtual { get; set; }

        [Required()]
        public double ValorProvisionado { get; set; }

        [Required()]
        public TipoMovimentacao TipoMovimentacao { get; set; }

        public int OrigemId { get; set; }

        public int DestinoId { get; set; }

        [Required()]
        public string Descricao { get; set; }

        public bool Cancelado { get; set; }
    }
}
