namespace DomainLayer.Models.Reports.PedidosVendedoras
{
    public class RelatorioPedidosVendedorasDetalhesModel : IRelatorioPedidosVendedorasDetalhesModel
    {
        public int PedidoId { get; set; }
        public string CatalogoNome { get; set; }
        public string ItemReferencia { get; set; }
        public string ItemDescricao { get; set; }
        public int ItemQuantidade { get; set; }
        public double ItemValorUnitario { get; set; }
        public double ItemValorTotal { get; set; }
        public double ItemMargemVendedora { get; set; }
        public double ItemLucroVendedora { get; set; }
        public string ItemFalta { get; set; }
    }
}
