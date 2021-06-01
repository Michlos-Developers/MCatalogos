namespace DomainLayer.Models.Produtos
{
    public interface IFormatoCampoModel
    {
        string Formato { get; set; }
        int FormatoId { get; set; }
        string Nome { get; set; }
    }
}