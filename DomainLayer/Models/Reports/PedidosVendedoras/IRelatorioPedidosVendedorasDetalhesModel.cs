namespace DomainLayer.Models.Reports.PedidosVendedoras
{
    public interface IRelatorioPedidosVendedorasDetalhesModel
    {
        string ItemDescricao { get; set; }
        string ItemFalta { get; set; }
        double ItemLucroVendedora { get; set; }
        double ItemMargemVendedora { get; set; }
        int ItemQuantidade { get; set; }
        string ItemReferencia { get; set; }
        double ItemValorTotal { get; set; }
        double ItemValorUnitario { get; set; }
        int PedidoId { get; set; }
        string CatalogoNome { get; set; }
    }
}