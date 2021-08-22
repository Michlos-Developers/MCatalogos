using DomainLayer.Models.Financeiro.Caixa.Enums;
using DomainLayer.Models.Financeiro.Provisionamento;
using DomainLayer.Models.TitulosPagar;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models.Financeiro.Caixa.ContasPagar
{
    public class ContasPagarModel : IContasPagarModel
    {
        [Required()]
        public int ContasPagarId { get; set; }
        [Required()]
        [ForeignKey("ProvisionamentoModel")]
        public int ProvisionamentoId { get; set; }
        public virtual ProvisionamentoModel ProvisionamentoModel { get; set; }

        [Required()]
        [ForeignKey("ParcelaTituloPagar")]
        public int OrigemId { get; set; }
        public virtual ParcelaTituloPagar ParcelaTituloPagar { get; set; }

        public DateTime DataRegistro { get; set; }

        [Required()]
        public double ValorPago { get; set; }

        [Required()]
        public TipoMovimentacao TipoMovimentacao { get; set; }

        public bool Cancelado { get; set; }

    }
}
