using DomainLayer.Models.Financeiro.Caixa.Enums;
using DomainLayer.Models.Financeiro.Provisionamento;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models.Financeiro.Banco
{
    public class SaqueModel : ISaqueModel
    {
        [Required()]
        public int SaqueId { get; set; }

        public DateTime DataRegistro { get; set; }

        [Required()]
        [ForeignKey("ContaModel")]
        public int ContaId { get; set; }
        public virtual ContaModel ContaModel { get; set; }

        [Required()]
        [ForeignKey("ProvisionamentoModel")]
        public int ProvisionamentoId { get; set; }
        public virtual ProvisionamentoModel ProvisionamentoModel { get; set; }

        [Required()]
        public double ValorSaque { get; set; }

        [Required()]
        public TipoMovimentacao TipoMovimentacao { get; set; }

        public bool Cancelado { get; set; }
    }
}
