using DomainLayer.Models.Vendedora;

using System.Collections.Generic;

namespace ServiceLayer.Services.EstadoCivilServices
{
    public interface IEstadoCivilRepository
    {
        IEnumerable<IEstadoCivilModel> GetAll();
        EstadoCivilModel GetByEstadoCivil(string estadoCivil);
        EstadoCivilModel GetById(int estadoCivilId);
    }
}