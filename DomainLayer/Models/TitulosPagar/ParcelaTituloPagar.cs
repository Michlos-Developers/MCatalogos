using DomainLayer.Models.CommonModels.Enums;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models.TitulosPagar
{
    public class ParcelaTituloPagar : IParcelaTituloPagar
    {
        [Required()]
        public int ParcelaId { get; set; }

        [Required()]
        [ForeignKey("TituloPagarModel")]
        public int TituloPagarId { get; set; }
        public virtual TituloPagarModel TituloPagarModel { get; set; }

        [Required()]
        public DateTime DataVencimento { get; set; }

        [Required()]
        public double ValorParcela { get; set; }

        public double ValorAdicional { get; set; }

        [Required()]
        public int NParcela { get; set; }

        [Required()]
        public int QtdParcelas { get; set; }

        public string CodigoBarras { get; set; }
        public double ValorPago { get; set; }

        [Required()]
        public StatusTitulo StatusParcela { get; set; }


    }
}
