
using DomainLayer.Models.Validations;

using ServiceLayer.Services.ValidationServices;

using System.Linq;

namespace InfrastructureLayer.Validations
{
    public class CpfRepository : IValidationCpfRespository
    {

        public bool ValidaCpf(ICpfModel cpfModel)
        {
            //exemplo de string do cpf (999.999.999-99)
            //exemplo de long do cpf (99999999999)


            CpfModel model = new CpfModel();
            //multiplicadores dos 9 primeiros dídigos.
            int[] multiplicadorPrimeiroDigito = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicadorSegundoDigito = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            
            //capta o cpf para uma string local
            string cpf = model.Cpf;

            //substitui caracteres especiais do cpf se tiver
            cpf = cpf.Replace(".", "");
            cpf = cpf.Replace(".", "");
            cpf = cpf.Replace("-", "");
            
            
            
            
            //reservando o dígito verificador para cálculo final
            int digitoVerificador = int.Parse(cpf.Substring(9, 2));

            //cria o array que vai receber todos os 11 dígitos do cpf.
            int[] cpfArray = new int[11];
            for (int i = 0; i < 10; i++)
            {
                cpfArray[i] = int.Parse(cpf.Substring(i, 1));
            }

            //verificação dos 9 dígitos

            //variável de resultado da multiplicação
            int resultMultPrimeiroDigito = 0;
            for (int i = 0; i < multiplicadorPrimeiroDigito.Count(); i++)
            {
                resultMultPrimeiroDigito += multiplicadorPrimeiroDigito[i] * cpfArray[i];
            }

            int valorPrimeiroDigito = (resultMultPrimeiroDigito * 10) % 11;

            if (valorPrimeiroDigito != int.Parse(cpf.Substring(9,1)))
            {
                return false;
            }

            //validação do segundo dígito
            int resultMultSegundoDigito = 0;
            for (int i = 0; i < multiplicadorSegundoDigito.Count(); i++)
            {
                resultMultSegundoDigito += multiplicadorSegundoDigito[i] * cpfArray[i];
            }

            //recebe o mode do calculo
            int valorSegundoDigito = (resultMultSegundoDigito * 10) % 11;
            if (valorSegundoDigito != int.Parse(cpf.Substring(10,1)))
            {
                return false;
            }
            return true;

        }
    }
}
