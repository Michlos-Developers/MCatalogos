using DomainLayer.Models.Fornecedores;

using System.Collections.Generic;

namespace ServiceLayer.Services.FornecedorServices
{
    public interface IFornecedorRepository
    {
        FornecedorModel Add(IFornecedorModel fornecedorModel);
        void Update(IFornecedorModel fornecedorModel);
        void Delete(IFornecedorModel fornecedorModel);
        IEnumerable<IFornecedorModel> GetAll();
        FornecedorModel GetById(int fornecedorId);
    }
}
