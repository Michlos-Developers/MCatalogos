using DomainLayer.Models.Modulos;

using System.Collections.Generic;

namespace ServiceLayer.Services.ModulosServices
{
    public interface IModuloCommandRepository
    {
        IEnumerable<IModuloCommandModel> GetAll();
        IEnumerable<IModuloCommandModel> GetAllByModuloId(int moduloId);

    }
}
