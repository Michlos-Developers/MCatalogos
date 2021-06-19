namespace DomainLayer.Models.Estoques
{
    public interface IEstoqueModel
    {
        int CampanhaId { get; set; }
        int CatalogoId { get; set; }
        int EstoqueId { get; set; }
        int ProdutoId { get; set; }
        int Quantidade { get; set; }
        float ValorCampanhaAtual { get; set; }
        float ValorCompra { get; set; }
    }
}