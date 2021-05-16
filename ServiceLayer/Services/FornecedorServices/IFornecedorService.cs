using DomainLayer.Models.Fornecedores;

namespace ServiceLayer.Services.FornecedorServices
{
    public interface IFornecedorService
    {
        void ValidateModel(IFornecedorModel fornecedorModel);
    }
}
