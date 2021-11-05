using DomainLayer.Models.Validations;

namespace ServiceLayer.Services.ValidationServices
{

    public interface IValidationCpfRespository
    {
        /// <summary>
        /// PROPRIEDADE DE VALIDAÇÃO DE CPF
        /// </summary>
        /// <param name="cpfModel"></param>
        /// <returns type="Boolean"></returns>
        bool ValidaCpf(ICpfModel cpfModel);
    }
}
