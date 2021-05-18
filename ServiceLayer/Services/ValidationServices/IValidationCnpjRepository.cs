using DomainLayer.Models.Validations;

namespace ServiceLayer.Services.ValidationServices
{
    public interface IValidationCnpjRepository
    {
        bool ValidaCnpj(ICnpjModel cnpjModel);
    }
}
