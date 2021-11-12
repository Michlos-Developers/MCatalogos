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

        public double? ValorTaxaPedido { get; set; }
        public double? ValorTotalPedido { get; set; }
        public double? ValorLucroVendedora { get; set; }
        public double? ValorLucroDistribuidor { get; set; }

        public double? ValorTotalPagar => ValorTotalPedido - ValorLucroVendedora;
        public int? QtdCatalogos { get; set; }

        [Required()]
        public int StatusPed { get; set; }

    }
}
