using DomainLayer.Models.Validations;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
