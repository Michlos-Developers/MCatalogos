using DomainLayer.Models.CommonModels.Address;

using System.Collections.Generic;

namespace ServiceLayer.Services.BairroServices
{
    public interface IBairroRepository
    {
        BairroModel Add(IBairroModel bairroModel);
        void Update(IBairroModel bairroModel);
        void Delete(IBairroModel bairroModel);
        BairroModel GetById(int id);
        IEnumerable<IBairroModel> GetAll();
        IEnumerable<IBairroModel> GetByCidadeId(int cidadeId);
        BairroModel GetByNomeAndCidadeId(string nome, int cidadeId);
    }
}
