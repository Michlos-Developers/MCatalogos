using DomainLayer.Models.CommonModels.Address;

using System.Collections.Generic;

namespace ServiceLayer.Services.CidadeServices
{
    public interface ICidadeRepository
    {
        IEnumerable<ICidadeModel> GetAll();
        IEnumerable<ICidadeModel> GetAllByUf(string uf);
        IEnumerable<ICidadeModel> GetAllByEstadoId(int estadoId);
        CidadeModel GetByNome(string nome);
        CidadeModel GetById(int cidadeId);
        CidadeModel GetByNomeAndEstadoId(string nome, int estadoId);
    }
}
