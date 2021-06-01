namespace DomainLayer.Models.Produtos
{
    public interface ITipoProdutoModel
    {
        string Descricao { get; set; }
        int TipoProdutoId { get; set; }
    }
}