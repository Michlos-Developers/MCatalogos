using DomainLayer.Models.Distribuidor;

namespace ServiceLayer.Services.DistribuidorServices
{
    public interface IDistribuidorServices
    {
        void ValidateModel(IDistribuidorModel distribuidorModel);
    }
}
