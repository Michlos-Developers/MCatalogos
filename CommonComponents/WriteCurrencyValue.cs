using System.Collections.Generic;

namespace CommonComponents
{
    public static class WriteCurrencyValue
    {
        public static string GetExtesionValue(double valorPagar)
        {
            //VARIÁVEL DE RETORNO
            string valorExtenso = string.Empty;

            //VARIÁVEIS DE CONTROLE
            int valorLenght = valorPagar.ToString("N2").Length;
            string[] unidades = { "", "um", "dois", "três", "quatro", "cinco", "seis", "sete", "oito", "nove" };
            string[] dezes = { "dez", "onze", "doze", "treze", "quatorze", "quinze", "dezesseis", "dezessete", "dezoito", "dezenove" };
            string[] dezenas = { "", "dez", "vinte", "trinta", "quarenta", "cinquenta", "sessenta", "setenta", "oitenta", "noventa" };
            string[] centenas = { "", "cento", "duzentos", "trezentos", "quatrocentos", "quinhentos", "seissentos", "setecentos", "oitocentos", "novecentos" };
            string unidadeCentavosStr = string.Empty, dezenaCentavosStr = string.Empty, unidadeRealStr = string.Empty, dezenaRealStr = string.Empty, centenaRealStr = string.Empty, milharRealStr = string.Empty;
            int unidadeCentavos = 0, dezenaCentavos = 0, unidadeReal = 0, dezenaReal = 0, centenaReal = 0, milharReal = 0;

            //LISTA QUE VAI RECEBER OS VALORES PARA INVERSÃO DOS NÚMEROS
            //ISSO FACILITA PARA IDENTIFICÃO DE ORDEM CRESCENTE...
            List<int> valoresInvertidosInteiros = new List<int>();


            //INVERTENDO VALORES NA LISTA
            for (int i = valorLenght; i > 0; i--)
            {
                string valorInverter = valorPagar.ToString("N2").Substring(i - 1, 1);

                if (valorInverter != "," && valorInverter != ".")
                {
                    valoresInvertidosInteiros.Add(int.Parse(valorInverter));
                }

            }

            int[] valoresArray = valoresInvertidosInteiros.ToArray();


            //ATRIBUINDO VALORES ÀS VARIAVEIS DE CADA LENGTH CONFORME A ORDEM
            for (int i = 0; i < valoresArray.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        unidadeCentavos = valoresArray[i];
                        break;
                    case 1:
                        dezenaCentavos = valoresArray[i];
                        break;
                    case 2:
                        unidadeReal = valoresArray[i];
                        break;
                    case 3:
                        dezenaReal = valoresArray[i];
                        break;
                    case 4:
                        centenaReal = valoresArray[i];
                        break;
                    case 5:
                        milharReal = valoresArray[i];
                        break;
                        ///PODE AUMENTAR CONFORME AUMENTAR A DEMANDA DO CLIENTE
                        ///DO JEITO QUE ESTÁ ACEITA ATÉ 9.999,99
                }
            }

            //TRATANDO UNIDADE CENTAVOS E DEZES
            //DEZ
            if (dezenaCentavos == 1)
            {
                if (unidadeCentavos == 0)
                {
                    dezenaCentavosStr = dezenas[dezenaCentavos];
                }
                else
                {
                    unidadeCentavosStr = dezes[unidadeCentavos];
                }

            }
            else //UM DOIS TRES... VINTE UM VINTE DOIS...  TRINTA UM TRINTA DOIS
            {
                unidadeCentavosStr = unidades[unidadeCentavos];
                dezenaCentavosStr = dezenas[dezenaCentavos];
            }


            //DEZENAS REAIS - COPIA DE DEZENAS CENTAVOS
            if (dezenaReal == 1)
            {
                if (unidadeReal == 0)
                {
                    dezenaRealStr = dezenas[dezenaReal];
                }
                else
                {
                    unidadeRealStr = dezes[unidadeReal];
                }
            }
            else
            {
                unidadeRealStr = unidades[unidadeReal];
                dezenaRealStr = dezenas[dezenaReal];
            }

            //CENTENAS
            if (centenaReal == 1)
            {
                if (unidadeReal == 0 && dezenaReal == 0)
                {
                    centenaRealStr = "cem";
                }
                else
                {
                    centenaRealStr = centenas[centenaReal];
                }
            }
            else
            {
                centenaRealStr = centenas[centenaReal];
            }
            //MILHAR
            if (milharReal == 1)
            {
                milharRealStr = "hum";
            }
            else
            {
                milharRealStr = unidades[milharReal];
            }



            //MILHAR POR EXTENSO
            if (milharReal != 0)
            {
                valorExtenso = milharRealStr + " mil ";
                if (centenaReal == 0 && dezenaReal == 0 && unidadeReal == 0 && dezenaCentavos == 0 && unidadeCentavos == 0)
                {
                    valorExtenso += " reais";
                    return valorExtenso;
                }
            }


            //CENTENA POR EXTENSO //TESTE 200
            if (centenaReal != 0)
            {
                valorExtenso += centenaRealStr;
                if (dezenaReal == 0 && unidadeReal == 0)
                {
                    valorExtenso += " reais";
                    if (dezenaCentavos == 0 && unidadeCentavos == 0)
                    {
                        return valorExtenso;
                    }
                    else
                    {
                        valorExtenso += " e ";
                    }
                }
                else if (centenaReal == 1 && (dezenaReal != 0 || unidadeReal != 0))
                {
                    valorExtenso += " e ";
                }
                else if (centenaReal > 1 && (dezenaReal != 0 || unidadeReal != 0))
                {
                    valorExtenso += " e ";
                }
                else
                {
                    valorExtenso += " reais e";
                }

            }

            //DEZENA POR EXTENSO
            if (dezenaReal > 1)
            {
                valorExtenso += dezenaRealStr;
                if (unidadeReal == 0 && dezenaCentavos == 0 && unidadeCentavos == 0)
                {
                    valorExtenso += " reais";
                    return valorExtenso;
                }
                else if (unidadeReal == 0 && centenaReal != 0)
                {
                    valorExtenso += " reais e ";
                }
                else if (unidadeReal == 0 && dezenaReal != 0)
                {
                    valorExtenso += " reais e ";
                }
                else
                {
                    valorExtenso += " e ";
                }
            }
            else if (dezenaReal == 1 && unidadeReal == 0)
            {

                //dez
                valorExtenso += dezenaRealStr;
                if (unidadeReal == 0 && dezenaCentavos == 0 && unidadeCentavos == 0)
                {
                    valorExtenso += " reais";
                    return valorExtenso;
                }
                else
                {
                    valorExtenso += " reais e ";
                }
            }




            //UNIDADE POR EXTENSO
            if (unidadeReal != 0)
            {
                valorExtenso += unidadeRealStr;
                if (dezenaCentavos == 0 && unidadeCentavos == 0)
                {

                    valorExtenso += " reais";
                    return valorExtenso;
                }
                else
                {
                    valorExtenso += " reais e ";
                }
            }



            //DEZENA DE CENTAVOS POR EXTENSO
            if (dezenaCentavos > 1)
            {
                valorExtenso += dezenaCentavosStr;
                if (unidadeCentavos == 0)
                {
                    valorExtenso += " centavos";
                }
                else
                {
                    valorExtenso += " e ";
                }
            }
            else if (dezenaCentavos == 1 && unidadeCentavos == 0)
            {
                valorExtenso += dezenaCentavosStr;
                if (unidadeCentavos == 0)
                {
                    valorExtenso += " centavos";
                }
                else
                {
                    valorExtenso += " e ";
                }

            }



            //UNIDADE DE CENTAVOS POR EXTENSO
            if (unidadeCentavos != 0)
            {
                valorExtenso += unidadeCentavosStr + " centavos";

            }

            return valorExtenso;
        }
    
    }
}
