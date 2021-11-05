using DomainLayer.Models.Validations;

namespace ServiceLayer.Services.ValidationServices
{
    public interface IValidationCnpjRepository
    {
        /// <summary>
        /// PROPRIEDADE DE VALIDAÇÃO DE CPF
        /// </summary>
        /// <param name="cnpjModel"></param>
        /// <returns type="Boolean"></returns>
        bool ValidaCnpj(ICnpjModel cnpjModel);
    }
}
