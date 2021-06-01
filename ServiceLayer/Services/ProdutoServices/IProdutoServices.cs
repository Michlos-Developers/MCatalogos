using DomainLayer.Models.Produtos;

namespace ServiceLayer.Services.ProdutoServices
{
    public interface IProdutoServices
    {
        void ValidateModel(IProdutoModel produto);
    }
}
