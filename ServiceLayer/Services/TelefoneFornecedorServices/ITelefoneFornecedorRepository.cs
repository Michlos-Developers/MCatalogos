using DomainLayer.Models.Fornecedores;

using System.Collections.Generic;

namespace ServiceLayer.Services.TelefoneFornecedorServices
{
    public interface ITelefoneFornecedorRepository
    {
        void Add(ITelefoneFornecedorModel telelefoneFornecedorModel);
        void Update(ITelefoneFornecedorModel telelefoneFornecedorModel);
        void Delete(ITelefoneFornecedorModel telelefoneFornecedorModel);
        IEnumerable<ITelefoneFornecedorModel> GetByFornecedorId(int fornecedorId);
        TelefoneFornecedorModel GetById(int id);

    }
}
