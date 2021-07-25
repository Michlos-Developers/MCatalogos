using DomainLayer.Models.CommonModels.Enums;

using System;

namespace DomainLayer.Models.TitulosPagar
{
    public interface IParcelaTituloPagar
    {
        string CodigoBarras { get; set; }
        DateTime DataVencimento { get; set; }
        int NParcela { get; set; }
        int ParcelaId { get; set; }
        int QtdParcelas { get; set; }
        StatusTitulo StatusParcela { get; set; }
        int TituloPagarId { get; set; }
        TituloPagarModel TituloPagarModel { get; set; }
        double ValorAdicional { get; set; }
        double ValorPago { get; set; }
        double ValorParcela { get; set; }
    }
}