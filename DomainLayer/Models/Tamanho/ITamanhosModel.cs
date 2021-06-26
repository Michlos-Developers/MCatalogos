namespace DomainLayer.Models.Tamanho
{
    public interface ITamanhosModel
    {
        int FormatoId { get; set; }
        string Tamanho { get; set; }
        int TamanhoId { get; set; }
        int ProdutoId { get; set; }
    }
}