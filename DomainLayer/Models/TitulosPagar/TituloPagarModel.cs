using DomainLayer.Models.CommonModels.Enums;
using DomainLayer.Models.Fornecedores;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models.TitulosPagar
{
    public class TituloPagarModel : ITituloPagarModel
    {
        [Required()]
        public int TituloId { get; set; }

        [Required()]
        [ForeignKey("FornecedorModel")]
        public int FornecedorId { get; set; }
        public virtual FornecedorModel FornecedorModel { get; set; }

        [Required()]
        public DateTime DataRegistro { get; set; }

        public DateTime DataVencimento { get; set; }

        [Required()]
        public double ValorTitulo { get; set; }

        public double ValorAdicional { get; set; }

        [Required()]
        public bool Parcelado { get; set; }

        public double ValorParcela { get; set; }
        public int QtdParcelas { get; set; }
        public double ValorPago { get; set; }
        public string CodigoBarras { get; set; }

        [Required()]
        public StatusTitulo StatusTitulo { get; set; }


    }
}
