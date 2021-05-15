using DomainLayer.Models.Validations;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.ValidationServices
{
    public interface IValidationCpfRespository
    {
        bool ValidaCpf(ICpfModel cpfModel);
    }
}
