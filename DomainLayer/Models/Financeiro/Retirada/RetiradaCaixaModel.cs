using DomainLayer.Models.Financeiro.Caixa;
using DomainLayer.Models.Financeiro.Caixa.Enums;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models.Financeiro.Retirada
{
    public class RetiradaCaixaModel : IRetiradaCaixaModel
    {
        [Required()]
        public int RetiradaId { get; set; }

        public DateTime DataRegistro { get; set; }

        [Required()]
        public double ValorRetirada { get; set; }

        [Required()]
        public string Justificativa { get; set; }

        [Required()]
        public string Autor { get; set; }

        [Required()]
        public TipoMovimentacao TipoMovimentacao { get; set; }

        [Required()]
        [ForeignKey("Caixa")]
        public int CaixaId { get; set; }
        public virtual CaixaModel CaixaModel { get; set; }

        public bool Cancelado { get; set; }

    }
}
