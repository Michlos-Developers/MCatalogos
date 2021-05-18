using DomainLayer.Models.Validations;

namespace ServiceLayer.Services.ValidationServices
{
    public class ValidationCnpjServices : IValidationCnpjRepository
    {
        private IValidationCnpjRepository _validationCnpjRepository;

        public ValidationCnpjServices(IValidationCnpjRepository validationCnpjRepository)
        {
            _validationCnpjRepository = validationCnpjRepository;
        }

        public bool ValidaCnpj(ICnpjModel cnpjModel)
        {
            return _validationCnpjRepository.ValidaCnpj(cnpjModel);
        }
    }
}
