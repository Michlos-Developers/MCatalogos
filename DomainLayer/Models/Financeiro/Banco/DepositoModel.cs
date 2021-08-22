using DomainLayer.Models.Financeiro.Caixa.Enums;
using DomainLayer.Models.Financeiro.Provisionamento;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models.Financeiro.Banco
{
    public class DepositoModel : IDepositoModel
    {
        [Required()]
        public int DepositoId { get; set; }
        public DateTime DataRegistro { get; set; }

        [Required()]
        [ForeignKey("BancoModel")]
        public int BancoId { get; set; }
        public virtual BancoModel BancoModel { get; set; }

        [Required()]
        [ForeignKey("ProvisionamentoModel")]
        public int ProvisionamentoId { get; set; }
        public virtual ProvisionamentoModel ProvisionamentoModel { get; set; }

        [Required()]
        public TipoMovimentacao TipoMovimentacao { get; set; }

        [Required()]
        public double ValorDeposito { get; set; }
        public bool Cancelado { get; set; }
    }
}
