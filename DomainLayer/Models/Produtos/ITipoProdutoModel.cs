namespace DomainLayer.Models.Produtos
{
    public interface ITipoProdutoModel
    {
        int CatalogoId { get; set; }
        string Descricao { get; set; }
        int TipoProdutoId { get; set; }
    }
}