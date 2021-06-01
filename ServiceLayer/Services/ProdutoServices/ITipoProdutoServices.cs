using DomainLayer.Models.Produtos;

namespace ServiceLayer.Services.ProdutoServices
{
    public interface ITipoProdutoServices
    {
        void ValidateModel(ITipoProdutoModel tipoProduto);
    }
}
