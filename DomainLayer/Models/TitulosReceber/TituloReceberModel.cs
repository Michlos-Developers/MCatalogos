using DomainLayer.Models.CommonModels.Enums;
using DomainLayer.Models.PedidosVendedoras;
using DomainLayer.Models.Vendedora;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models.TitulosReceber
{
    public class TituloReceberModel : ITituloReceberModel 
    {
        [Key()]
        public int TituloId { get; set; }

        [Required()]
        [ForeignKey("VendedoraModel")]
        public int VendedoraId { get; set; }
        public virtual VendedoraModel VendedoraModel { get; set; }

        [Required()]
        [ForeignKey("PedidosVendedorasModel")]
        public int PedidoId { get; set; }
        public virtual PedidosVendedorasModel PedidosVendedorasModel { get; set; }

        [Required()]
        [ForeignKey("TipoTituloModel")]
        public int TipoTituloId { get; set; }
        public virtual TipoTituloModel TipoTituloModel { get; set; }

        [Required()]
        public double ValorTitulo { get; set; }

        [Required()]
        public double ValorParcela { get; set; }

        [Required()]
        public DateTime DataEmissao { get; set; }

        [Required()]
        public DateTime DataRegistro { get; set; }

        [Required()]
        public DateTime DataVencimento { get; set; }

        [Required()]
        public double ValorDesconto { get; set; }

        [Required()]
        public double ValorLiquidado { get; set; }

        [Required()]
        public int QtdParcelas { get; set; }

        [Required()]
        public bool Liquidado { get; set; }

        [Required()]
        public bool Cancelado { get; set; }

        [Required()]
        public bool Protestado { get; set; }

        [Required()]
        public bool Parcelado { get; set; }





    }
}
