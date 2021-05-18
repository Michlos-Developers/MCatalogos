
using DomainLayer.Models.Validations;

using ServiceLayer.Services.ValidationServices;

using System.Linq;

namespace InfrastructureLayer.Validations
{
    public class CpfRepository : IValidationCpfRespository
    {
        string cpfStr = string.Empty;
        long cpfLong = 0;
        int[] multiplicadorPrimeiroDigito = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicadorSegundoDigito = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        bool resultValida = false;
        public bool ValidaCpf(ICpfModel cpfModel)
        {
            cpfStr = cpfModel.Cpf;
            cpfLong = ReplaceCpfToLong(cpfStr);

            int primeiroDigito = int.Parse(cpfLong.ToString().Substring(9, 1));
            int segundoDigito = int.Parse(cpfLong.ToString().Substring(10, 1));

            int primeiroDigitoResult = 0;
            int segundoDigitoResult = 0;

            if ((primeiroDigitoResult = CalculaPrimeiroDigito(cpfLong)) != primeiroDigito
                || (segundoDigitoResult = CalculaSegundoDigito(cpfLong)) != segundoDigito)
            {
                return false;
            }
            else
            {
                resultValida = true;
            }
            return resultValida;
        }


        private int CalculaSegundoDigito(long cpf)
        {
            int segundoDigitoCalculado = 0;
            int resultMultiplicador = 0;

            for (int i = 0; i < multiplicadorSegundoDigito.Count(); i++)
            {
                resultMultiplicador = (int.Parse(cpf.ToString().Substring(i, 1))) * multiplicadorSegundoDigito[i];
            }
            segundoDigitoCalculado = ((resultMultiplicador * 10) % 11);

            return segundoDigitoCalculado;

        }

        private int CalculaPrimeiroDigito(long cpf)
        {
            int primeiroDigitoCalculado = 0;
            int resultMultiplicador = 0;

            for (int i = 0; i < multiplicadorPrimeiroDigito.Count(); i++)
            {
                resultMultiplicador = (int.Parse(cpf.ToString().Substring(i, 1))) * multiplicadorPrimeiroDigito[i];
            }
            primeiroDigitoCalculado = ((resultMultiplicador*10) % 11);

            return primeiroDigitoCalculado;
        }

        private long ReplaceCpfToLong(string cpfStr)
        {
            cpfStr = cpfStr.Replace(".", "");
            cpfStr = cpfStr.Replace("-", "");
            cpfStr = cpfStr.Replace(" ", "");

            return long.Parse(cpfStr);
        }
    }
}
