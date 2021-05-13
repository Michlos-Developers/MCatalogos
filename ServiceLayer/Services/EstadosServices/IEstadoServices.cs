using DomainLayer.Models.CommonModels.Address;

namespace ServiceLayer.Services.EstadosServices
{
    public interface IEstadoServices
    {
        void ValidateModel(IEstadoModel estadoModel);
    }
}
