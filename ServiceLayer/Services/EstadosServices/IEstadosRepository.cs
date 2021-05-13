using DomainLayer.Models.CommonModels.Address;

using System.Collections.Generic;

namespace ServiceLayer.Services.EstadosServices
{
    public interface IEstadosRepository
    {
        IEnumerable<IEstadoModel> GetAll();
        EstadoModel GetById(int estadoId);
        EstadoModel GetByUf(string uf);

    }
}
