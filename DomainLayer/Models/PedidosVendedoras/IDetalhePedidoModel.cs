using DomainLayer.Models.Catalogos;
using DomainLayer.Models.Produtos;

using System;

namespace DomainLayer.Models.PedidosVendedoras
{
    public interface IDetalhePedidoModel : IDisposable
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
        double ValorLucroDistribuidorItem { get;  }
        double ValorLucroVendedoraItem { get; }
        double ValorPagarFornecedorItem { get;  }
        double ValorProduto { get; set; }
        double ValorTotalItem { get; }
        int TamanhoId { get; set; }
        double ValorTaxaItem { get; set; }
        double ValorTotalBruto { get; }
        string Descricao { get; set; }
    }
}