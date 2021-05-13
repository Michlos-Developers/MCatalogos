using DomainLayer.Models.CommonModels.Address;

namespace ServiceLayer.Services.BairroServices
{
    public interface IBairroServices
    {
        void ValidateModel(IBairroModel bairro);
    }
}
