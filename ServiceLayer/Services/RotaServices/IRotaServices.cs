using DomainLayer.Models.Vendedora;

namespace ServiceLayer.Services.RotaServices
{
    public interface IRotaServices
    {
        void ValidateModel(IRotaModel rotaModel);
    }
}