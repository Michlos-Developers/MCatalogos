using DomainLayer.Models.Validations;

namespace ServiceLayer.Services.ValidationServices
{
    public class ValidationCpfServices : IValidationCpfRespository
    {
        private IValidationCpfRespository _validationCpfRespository;

        public ValidationCpfServices(IValidationCpfRespository validationCpfRespository)
        {
            _validationCpfRespository = validationCpfRespository;
        }

        public bool ValidaCpf(ICpfModel cpfModel)
        {
            return _validationCpfRespository.ValidaCpf(cpfModel);
        }
    }
}
