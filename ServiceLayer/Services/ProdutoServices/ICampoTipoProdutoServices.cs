using DomainLayer.Models.Produtos;

namespace ServiceLayer.Services.ProdutoServices
{
    public interface ICampoTipoProdutoServices
    {
        void ValidateModel(ICampoTipoProdutoModel campo);
    }
}
