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
        RotaModel GetById(int id);
        
    }
}
