using DomainLayer.Models.Vendedora;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models.PedidosVendedoras
{
    public class PedidosVendedorasModel : IPedidosVendedorasModel
    {
        [Key()]
        public int PedidoId { get; set; }

        [Required()]
        [ForeignKey("VendedoraModel")]
        public int VendedoraId { get; set; }
        public virtual VendedoraModel VendedoraModel { get; set; }



        [Required(AllowEmptyStrings = false, ErrorMessage = "Data do Registro do Pedido deve ser preenchida.")]
        public DateTime DataRegistro { get; set; }

        public DateTime? DataEnvio { get; set; }
        public DateTime? DataSeparacao { get; set; }
        public DateTime? DataConferencia { get; set; }
        public DateTime? DataDespacho { get; set; }
        public DateTime? DataCancelamento { get; set; }
        public DateTime? DataEntrega { get; set; }
        public double? ValotTotalPedido { get; set; }
        public double? ValorLucroVendedora { get; set; }
        public double? ValorLucroDistribuidor { get; set; }

        [Required()]
        public bool Enviado { get; set; }

        [Required()]
        public bool Separado { get; set; }

        [Required()]
        public bool Conferido { get; set; }

        [Required()]
        public bool Despachado { get; set; }

        [Required()]
        public bool Entregue { get; set; }

        [Required()]
        public bool Cancelado { get; set; }
    }
}
