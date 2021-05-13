using DomainLayer.Models.Vendedora;

namespace ServiceLayer.Services.EstadoCivilServices
{
    public interface IEstadoCivilServices
    {
        void ValidateModel(IEstadoCivilModel estadoCivil);
    }
}