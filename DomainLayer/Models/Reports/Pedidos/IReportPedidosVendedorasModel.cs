using System;

namespace DomainLayer.Models.Reports.Pedidos
{
    public interface IReportPedidosVendedorasModel
    {
        int CampanhaId { get; set; }
        int CatalogoId { get; set; }
        string CatalogoNome { get; set; }
        DateTime DataRegistroPedido { get; set; }
        DateTime DataVencimento { get; set; }
        bool DetalheFalta { get; set; }
        double DetalheMargemVendedora { get; set; }
        string DetalheProdutoDescricao { get; set; }
        int DetalheProdutoId { get; set; }
        string DetalheProdutoReferencia { get; set; }
        double DetalheProdutoValor { get; set; }
        int DetalheQuantidade { get; set; }
        double DetalheValorTotalBruto { get; set; }
        double DetalheValorTotalItem { get; set; }
        double DetalheValorTotalLiquido { get; set; }
        int DetlhePedidoId { get; set; }
        int DistribuidorId { get; set; }
        string DistribuidorNome { get; set; }
        string NomeCampanha { get; set; }
        int PedidoId { get; set; }
        double PedidoValorLucroVendedora { get; set; }
        double PedidoValorTotal { get; set; }
        double PedidoValorTotalPagar { get; set; }
        int VendedoraId { get; set; }
        string VendedoraNome { get; set; }
        int RotaLetraIdVendedora { get; set; }
        string RotaLetraVendedora { get; set; }
        int RotaNumeroIdVendedora { get; set; }
        string RotaNumeroVendedora { get; set; }
        //int ReportPedidoVendedoraId { get; set; }
    }
}