using System;

namespace DomainLayer.Models.Reports.PedidosVendedoras
{
    public interface IRelatorioPromissoriasModel
    {
        DateTime DataEmissao { get; set; }
        DateTime DataVencimento { get; set; }
        string DistribuidorCidade { get; set; }
        string DistribuidorCnpj { get; set; }
        string DistribuidorRazao { get; set; }
        string ExtensoDataVencimento { get; set; }
        string ExtensoValor { get; set; }
        int PedidoId { get; set; }
        double ValorPagar { get; set; }
        string VendedoraCpf { get; set; }
        string VendedoraEndereco { get; set; }
        int VendedoraId { get; set; }
        string VendedoraNome { get; set; }
    }
}