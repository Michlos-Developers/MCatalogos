using DomainLayer.Models.Financeiro.Caixa.Enums;
using DomainLayer.Models.TitulosReceber;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models.Financeiro.Caixa.ContasReceber
{
    public class ContasReceberModel : IContasReceberModel
    {
        [Required()]
        public int ContasReceberId { get; set; }

        [Required()]
        [ForeignKey("CaixaModel")]
        public int CaixaId { get; set; }
        public virtual CaixaModel CaixaModel { get; set; }

        [Required()]
        [ForeignKey("TituloReceberModel")]
        public int OrigemId { get; set; }
        public virtual TituloReceberModel TituloReceberModel { get; set; }

        public DateTime DataRegistro { get; set; }

        [Required()]
        public double ValorRecebido { get; set; }

        [Required()]
        public TipoMovimentacao TipoMovimentacao { get; set; }

        public bool Cancelado { get; set; }


    }
}
