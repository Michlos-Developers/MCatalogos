using DomainLayer.Models.Produtos;

namespace ServiceLayer.Services.ProdutoServices
{
    public interface IFormatoModelServices
    {
        void ValidateModel(IFormatoCampoModel formatoCampo);
    }
}
