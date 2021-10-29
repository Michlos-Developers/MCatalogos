using DomainLayer.Models.Catalogos;
using DomainLayer.Models.Produtos;

namespace DomainLayer.Models.PedidosVendedoras
{
    public interface IDetalhePedidoModel
    {
        int CampanhaId { get; set; }
        CampanhaModel CampanhaModel { get; set; }
        int CatalogoId { get; set; }
        CatalogoModel CatalogoModel { get; set; }
        int DetalheId { get; set; }
        bool Faltou { get; set; }
        double MargemDistribuidor { get; set; }
        double MargemVendedora { get; set; }
        int PedidoId { get; set; }
        PedidosVendedorasModel PedidosVendedorasModel { get; set; }
        int ProdutoId { get; set; }
        ProdutoModel ProdutoModel { get; set; }
        int Quantidade { get; set; }
        string Referencia { get; set; }
        double ValorLucroDistribuidorItem { get; set; }
        double ValorLucroVendedoraItem { get; set; }
        double ValorPagarFornecedorItem { get; set; }
        double ValorProduto { get; set; }
        double ValorTotalItem { get; }
        int TamanhoId { get; set; }
        double ValorTaxaItem { get; set; }
    }
}