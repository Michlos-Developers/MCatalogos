using DomainLayer.Models.Vendedora;

using System.Collections.Generic;

namespace ServiceLayer.Services.RotaServices
{
    public interface IRotaRepository
    {
        void Add(IRotaModel rotaModel);
        void Update(IRotaModel rotaModel);
        void Delete(IRotaModel rotaModel);
        IEnumerable<IRotaModel> GetAll();
        IEnumerable<IRotaModel> GetAllByLetraId(int letraId);
        RotaModel GetById(int id);
        RotaModel GetByNumeroAndLetraId(int numero, int letraId);
        RotaModel GetByVendedoraId(int vendedoraId);
        RotaModel GetLastNumero(int letraId);
        void RefatoraRotas(IRotaModel rotaAlvo, int vendedoraQueEntra, List<RotaModel> rotaList, IRotaModel rotaOrigem);
        void AlteraLetraId(int rotaId, int rotaLetraId);
    }
}
