using DomainLayer.Models.CommonModels.Enums;
using DomainLayer.Models.Fornecedores;

using System;

namespace DomainLayer.Models.TitulosPagar
{
    public interface ITituloPagarModel
    {
        string CodigoBarras { get; set; }
        DateTime DataRegistro { get; set; }
        DateTime DataVencimento { get; set; }
        int FornecedorId { get; set; }
        FornecedorModel FornecedorModel { get; set; }
        bool Parcelado { get; set; }
        int QtdParcelas { get; set; }
        StatusTitulosModel StatusTitulo { get; set; }
        int TituloId { get; set; }
        double ValorAdicional { get; set; }
        double ValorPago { get; set; }
        double ValorParcela { get; set; }
        double ValorTitulo { get; set; }
    }
}