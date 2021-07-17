
using DomainLayer.Models.Validations;

using ServiceLayer.Services.ValidationServices;

using System.Linq;
using System.Web;

namespace InfrastructureLayer.Validations
{
    public class CpfRepository : IValidationCpfRespository
    {
        string cpfStr = string.Empty;
        string cpfCalcula = string.Empty;
        int[] multiplicadorPrimeiroDigito = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicadorSegundoDigito = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        bool resultValida = false;
        public bool ValidaCpf(ICpfModel cpfModel)
        {
            cpfStr = cpfModel.Cpf;
            cpfCalcula = ReplaceCpfToLong(cpfStr);

            int primeiroDigito = int.Parse(cpfCalcula.ToString().Substring(9, 1));
            int segundoDigito = int.Parse(cpfCalcula.ToString().Substring(10, 1));

            int primeiroDigitoResult = 0;
            int segundoDigitoResult = 0;

            if ((primeiroDigitoResult = CalculaPrimeiroDigito(cpfCalcula)) != primeiroDigito
                || (segundoDigitoResult = CalculaSegundoDigito(cpfCalcula)) != segundoDigito)
            {
                return false;
            }
            else
            {
                resultValida = true;
            }
            return resultValida;
        }


        private int CalculaSegundoDigito(string cpf)
        {
            int segundoDigitoCalculado = 0;
            int resultMultiplicador = 0;
            int multiplicador = 0;
            int numeroCpf = 0;
            int resultMTemp = 0;
            int digitoValido = 0;

            for (int i = 0; i < multiplicadorSegundoDigito.Count(); i++)
            {
                numeroCpf = int.Parse(cpf.ToString().Substring(i, 1));
                multiplicador = multiplicadorSegundoDigito[i];
                resultMTemp = numeroCpf * multiplicador;
                resultMultiplicador += resultMTemp;
            }
            segundoDigitoCalculado = ((resultMultiplicador * 10) % 11);
            if (segundoDigitoCalculado == 10)
                digitoValido = 0;
            else
                digitoValido = segundoDigitoCalculado;

            return digitoValido;

        }

        private int CalculaPrimeiroDigito(string cpf)
        {
            int primeiroDigitoCalculado = 0;
            int resultMultiplicador = 0;
            int multiplicador = 0;
            int numeroCpf = 0;
            int resultMTemp = 0;
            int digitoValido = 0;

            for (int i = 0; i < multiplicadorPrimeiroDigito.Count(); i++)
            {

                numeroCpf = int.Parse(cpf.ToString().Substring(i, 1));
                multiplicador = multiplicadorPrimeiroDigito[i];
                resultMTemp = numeroCpf * multiplicador;
                resultMultiplicador += resultMTemp;
            }
            primeiroDigitoCalculado = ((resultMultiplicador*10) % 11);
            if (primeiroDigitoCalculado == 10)
                digitoValido = 0;
            else
                digitoValido = primeiroDigitoCalculado;

            return digitoValido;
        }

        private string ReplaceCpfToLong(string cpfStr)
        {
            cpfStr = cpfStr.Replace(".", "");
            cpfStr = cpfStr.Replace("-", "");
            cpfStr = cpfStr.Replace(" ", "");

            return cpfStr;
        }
    }
}
