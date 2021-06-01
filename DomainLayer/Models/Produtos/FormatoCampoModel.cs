namespace DomainLayer.Models.Produtos
{
    public class FormatoCampoModel : IFormatoCampoModel
    {
        public int FormatoId { get; set; }
        public string Nome { get; set; }
        public string Formato { get; set; }
    }
}
