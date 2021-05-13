using DomainLayer.Models.Vendedora;

using System.Collections.Generic;

namespace ServiceLayer.Services.RotaServices
{
    public interface IRotaLetraRepository
    {
        void Add(IRotaLetraModel rotaLetraModel);
        void Update(IRotaLetraModel rotaLetraModel);
        void Delete(IRotaLetraModel rotaLetraModel);
        IEnumerable<IRotaLetraModel> GetAll();
        RotaLetraModel GetById(int id);
        RotaLetraModel GetByLetra(string letra);

    }
}
