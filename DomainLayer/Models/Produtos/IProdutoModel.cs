namespace DomainLayer.Models.Produtos
{
    public interface IProdutoModel
    {
        bool Ativo { get; set; }
        int CampanhaId { get; set; }
        int CatalogoId { get; set; }
        string Descricao { get; set; }
        float MargemDistribuidor { get; set; }
        float MargemVendedora { get; set; }
        int Pagina { get; set; }
        int ProdutoId { get; set; }
        string Referencia { get; set; }
        int TipoProdutoId { get; set; }
        float ValorCatalogo { get; set; }
    }
}