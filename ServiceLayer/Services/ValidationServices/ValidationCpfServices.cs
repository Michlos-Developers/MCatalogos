using DomainLayer.Models.Validations;

namespace ServiceLayer.Services.ValidationServices
{
    public class ValidationCpfServices : IValidationCpfRespository
    {
        /// <summary>
        /// PROPRIEDADE PARA VALIDAÇÃO DE CPF
        /// </summary>
        private IValidationCpfRespository _validationCpfRespository;

        /// <summary>
        /// MÉTODO PRINCIPAL
        /// </summary>
        /// <param name="validationCpfRespository"></param>
        public ValidationCpfServices(IValidationCpfRespository validationCpfRespository)
        {
            _validationCpfRespository = validationCpfRespository;
        }

        /// <summary>
        /// CHAMA O VALIDADOR DE CPF NO REPOSITÓRIO
        /// SE CPF VÁLIDO RETORNA TRUE
        /// SE CPF INVÁLIDO RETORNA FALSE
        /// </summary>
        /// <param name="cpfModel"></param>
        /// <returns type="Boolean"></returns>
        public bool ValidaCpf(ICpfModel cpfModel)
        {
            return _validationCpfRespository.ValidaCpf(cpfModel);
        }
    }
}
