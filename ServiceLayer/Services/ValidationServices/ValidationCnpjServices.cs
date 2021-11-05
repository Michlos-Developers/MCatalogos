using DomainLayer.Models.Validations;

namespace ServiceLayer.Services.ValidationServices
{
    public class ValidationCnpjServices : IValidationCnpjRepository
    {
        /// <summary>
        /// PROPRIEDADE PARA VALIDAÇÃO DE CPF
        /// </summary>
        private IValidationCnpjRepository _validationCnpjRepository;


        /// <summary>
        /// MÉTODO PRINCIPAL
        /// </summary>
        /// <param name="validationCnpjRepository"></param>
        public ValidationCnpjServices(IValidationCnpjRepository validationCnpjRepository)
        {
            _validationCnpjRepository = validationCnpjRepository;
        }


        /// <summary>
        /// RETORNA VALIDAÇÃO DE CPF
        /// SE VÁLIDO RETORNA TRUE;
        /// SE INVÁLIDO RETORNA FALSE;
        /// </summary>
        /// <param name="cnpjModel"></param>
        /// <returns type="Boolean"></returns>
        public bool ValidaCnpj(ICnpjModel cnpjModel)
        {
            return _validationCnpjRepository.ValidaCnpj(cnpjModel);
        }
    }
}
