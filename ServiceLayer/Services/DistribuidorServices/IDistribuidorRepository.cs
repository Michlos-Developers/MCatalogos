using DomainLayer.Models.Distribuidor;

namespace ServiceLayer.Services.DistribuidorServices
{
    public interface IDistribuidorRepository
    {
        DistribuidorModel Add(IDistribuidorModel distribuidorModel);
        void Update(IDistribuidorModel distribuidorModel);
        DistribuidorModel GetById(int id);
        
    }
}
