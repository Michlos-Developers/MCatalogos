using System;

namespace DomainLayer.Models.Produtos
{
    public interface IProdutoModel : IDisposable
    {
        bool Ativo { get; set; }
        int CampanhaId { get; set; }
        int CatalogoId { get; set; }
        string Descricao { get; set; }
        string MargemDistribuidor { get; set; }
        string MargemVendedora { get; set; }
        int Pagina { get; set; }
        int ProdutoId { get; set; }
        string Referencia { get; set; }
        float ValorCatalogo { get; set; }
        float ValorCatalogo2 { get; set; }
    }
}