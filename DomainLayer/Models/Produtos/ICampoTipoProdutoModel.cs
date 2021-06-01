namespace DomainLayer.Models.Produtos
{
    public interface ICampoTipoProdutoModel
    {
        int CampoTipoId { get; set; }
        int FormatoId { get; set; }
        string Nome { get; set; }
        int TipoProdutoId { get; set; }
    }
}