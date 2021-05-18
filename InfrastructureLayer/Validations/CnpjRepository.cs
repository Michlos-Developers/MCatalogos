using DomainLayer.Models.Validations;

using ServiceLayer.Services.ValidationServices;

using System.Linq;

namespace InfrastructureLayer.Validations
{
    public class CnpjRepository : IValidationCnpjRepository
    {
        string cnpjStr = string.Empty;
        long cnpjLong = 0;
        int[] multiplicadorPrimeiro = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicadorSegundo = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };


        public bool ValidaCnpj(ICnpjModel cnpjModel)
        {
            cnpjStr = cnpjModel.Cnpj;
            cnpjLong = ReplaceCnpjToLong(cnpjStr);
            int primeiroDigito = int.Parse(cnpjLong.ToString().Substring(12, 1));
            int segundoDigito = int.Parse(cnpjLong.ToString().Substring(13, 1));
            int primeiroDigitoResult = 0;
            int segundoDigitoResult = 0;
            bool resultValida = false;
            //primeiroDigitoResult = CalculaPrimeiroDigito(cnpjStr);

            if ((primeiroDigitoResult = CalculaPrimeiroDigito(cnpjLong))!= primeiroDigito 
                || (segundoDigitoResult = CalculaSegundoDigito(cnpjLong))!= segundoDigito)
            {
                return false;
            }
            else
            {
                resultValida = true;
            }
            return resultValida;
        }



        public int CalculaPrimeiroDigito(long cnpj)
        {
            int primeiroDigito = 0;
            int resultMultimplicador = 0;

            for (int i = 0; i < multiplicadorPrimeiro.Count() ; i++)
            {
                resultMultimplicador = (int.Parse(cnpj.ToString().Substring(i, 1))) * multiplicadorPrimeiro[i];
            }

            if (resultMultimplicador % 11 < 2)
            {
                primeiroDigito = 0;
            }
            else
            {
                primeiroDigito = resultMultimplicador % 11;
            }

            return primeiroDigito;
        }

        public int CalculaSegundoDigito(long cnpj)
        {
            int segundoDigito = 0;
            int resultMultiplicador = 0;
            for (int i = 0; i < multiplicadorSegundo.Count(); i++)
            {
                resultMultiplicador = (int.Parse(cnpj.ToString().Substring(i, 1))) * multiplicadorSegundo[i];
            }

            if (resultMultiplicador % 11 < 2)
            {
                segundoDigito = 0;
            }
            else
            {
                segundoDigito = resultMultiplicador % 2;
            }

            return segundoDigito;
        }

        public long ReplaceCnpjToLong(string cnpj)
        {
            cnpj = cnpj.Replace(".", "");
            cnpj = cnpj.Replace("/", "");
            cnpj = cnpj.Replace("-", "");
            cnpj = cnpj.Replace(" ", "");

            return long.Parse(cnpj);
        }

    }
}
