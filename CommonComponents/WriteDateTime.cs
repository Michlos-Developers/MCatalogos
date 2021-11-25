using System;
using System.Collections.Generic;

namespace CommonComponents
{
    public static class WriteDateTime
    {
        public static string GetDay(int day)
        {
            //VARIÁVEL DE RETORNO
            string dayExtenso = string.Empty;

            //VARIÁVEIS DE CONTROLE
            int dayLenth = day.ToString().Length;
            string[] unidades = { "", "um", "dois", "três", "quatro", "cinco", "seis", "sete", "oito", "nove" };
            string[] dezes = { "dez", "onze", "doze", "treze", "quatorze", "quinze", "dezesseis", "dezessete", "dezoito", "dezenove" };
            string[] dezenas = { "", "dez", "vinte", "trinta" };
            string unidadeStr = string.Empty, dezenaStr = string.Empty;
            int unidade = 0, dezena = 0;
            List<int> valuesDayInt = new List<int>();

            for (int i = dayLenth; i > 0; i--)
            {
                string dayValue = day.ToString().Substring(i-1, 1);
                valuesDayInt.Add(int.Parse(dayValue));

            }
            int[] daysArray = valuesDayInt.ToArray();

            //ATRIBUINDO VALORES ÀS VARIÁVEIS INTEIRAS CONFORME VALOR RECEBIDO
            for (int i = 0; i < daysArray.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        unidade = daysArray[i];
                        break;
                    case 1:
                        dezena = daysArray[i];
                        break;
                }
            }

            if (dezena != 0)
            {
                if (dezena == 1) //dez e dezes
                {
                    dezenaStr = dezes[unidade];
                }
                else //acima de 19
                {
                    dezenaStr = dezenas[dezena];
                }
            }

            if (unidade != 0)
            {
                if (dezena != 1)
                {
                    unidadeStr = unidades[unidade];
                }
            }



            //ATRIBUINDO DIA COMPLETO POR EXTENSO
            if (dezena != 0)
            {
                dayExtenso += dezenaStr;
                if (unidade != 0)
                {
                    if (dezena != 1)
                    {
                        dayExtenso += " e ";
                    }
                }
            }

            if (unidade != 0)
            {
                if (dezena != 1)
                {
                    dayExtenso += unidadeStr;
                }
            }

            return dayExtenso;
        }

        public static string GetMonth(int month)
        {

            //VARIÁVEIS DE CONTROLE
            string[] meses = { "", "janeiro", "fevereiro", "março", "abril", "maio", "junho", "julho", "agosto", "setembro", "outubro", "novembro", "dezembro" };

            string mesStr = meses[month];

            return mesStr;
        }

        public static string GetYear(int year)
        {
            //VARIÁVEL DE RETORNO
            string yearStr = string.Empty;

            //VARIÁVEIS DE CONTROLE
            string[] unidades = { "", "um", "dois", "três", "quatro", "cinco", "seis", "sete", "oito", "nove" };
            string[] dezes = { "dez", "onze", "doze", "treze", "quatorze", "quinze", "dezesseis", "dezessete", "dezoito", "dezenove" };
            string[] dezenas = { "", "dez", "vinte", "trinta", "quarenta", "cinquenta", "sessenta", "setenta", "oitenta", "noventa" };
            string[] centenas = { "", "cento", "duzentos", "trezentos", "quatrocentos", "quinhentos", "seissentos", "setecentos", "oitocentos", "novecentos" };
            string unidadeStr = string.Empty, dezenaStr = string.Empty, centenaStr = string.Empty, milharStr = string.Empty;
            int unidadeInt = 0, dezenaInt = 0, centenaInt = 0, milharInt = 0;

            //LISTA QUE VAI RECEBER OS VALORES PARA INVERSÃO DOS NÚMEROS
            //ISSO FACILITA PARA IDENTIFICÃO DE ORDEM CRESCENTE...
            List<int> valuesYearsInt = new List<int>();


            //INVERTENDO VALORES NA LISTA
            for (int i = 0; i < year.ToString().Length; i++)
            {
                string yearValue = year.ToString().Substring(i, 1);
                valuesYearsInt.Add(int.Parse(yearValue));
            }
            int[] valoresArray = valuesYearsInt.ToArray();


            //ATRIBUINDO VALORES ÀS VARIAVEIS DE CADA LENGTH CONFORME A ORDEM
            for (int i = 0; i < valoresArray.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        milharInt = valoresArray[i];
                        break;
                    case 1:
                        centenaInt = valoresArray[i];
                        break;
                    case 2:
                        dezenaInt = valoresArray[i];
                        break;
                    case 3:
                        unidadeInt = valoresArray[i];
                        break;

                        ///PODE AUMENTAR CONFORME AUMENTAR A DEMANDA DO CLIENTE
                        ///DO JEITO QUE ESTÁ ACEITA ATÉ 9.999
                }
            }

            //ATRIBUINDO VALORES ÀS STRINGS INDIVIDUALMENTE
            //MILHAR STRING
            milharStr = unidades[milharInt];

            //CENTENA STRING
            if (centenaInt != 0)
            {
                if (centenaInt == 1)
                {
                    if (unidadeInt == 0 && dezenaInt == 0)
                    {
                        centenaStr = "cem";
                    }
                    else
                    {
                        centenaStr = centenas[centenaInt];
                    }
                }
                else
                {
                        centenaStr = centenas[centenaInt];
                }
            }

            //DEZENAS STRING
            if (dezenaInt != 0)
            {
                if (dezenaInt == 1)
                {
                    if (unidadeInt != 0)
                    {
                        dezenaStr = "";
                    }
                    else
                    {
                        dezenaStr = dezenas[dezenaInt];
                    }
                }
                else
                {
                        dezenaStr = dezenas[dezenaInt];
                }
            }

            //UNIDADES STRING
            if (unidadeInt != 0)
            {
                unidadeStr = unidades[unidadeInt];
            }




            //ATRIBUINDO ANO COMPLETO POR EXTENSO
            //MILHAR
            if (milharInt != 0)
            {
                yearStr += milharStr + " mil ";

            }


            //CENTENA
            if (centenaInt != 0)
            {
                if (dezenaInt != 0 || unidadeInt != 0)
                {
                    yearStr += centenaStr + " e ";
                }
                else
                {
                    if (centenaInt == 1)
                    {
                        yearStr += " cem";
                    }
                    else
                    {
                        if (dezenaInt != 0 || unidadeInt != 0)
                        {

                            yearStr += centenaStr + " e ";
                        }
                        else
                        {
                            yearStr += centenaStr;
                        }
                    }
                }
            }
            else
            {
                yearStr += " e ";
            }

            //DEZENA
            if (dezenaInt != 0)
            {
                if (dezenaInt == 1)
                {
                    if (unidadeInt != 0)
                    {
                        yearStr += dezenaStr;
                    }
                    else
                    {
                        yearStr += dezenaStr;
                    }
                }
                else
                {
                    if (unidadeInt != 0)
                    {

                        yearStr += dezenaStr + " e ";
                    }
                    else
                    {
                        yearStr += dezenaStr;
                    }
                }
            }

            //UNIDADE
            if (unidadeInt != 0)
            {
                if (dezenaInt != 1)
                {
                    yearStr += unidadeStr;
                }
            }

            return yearStr;
        }

        public static string GetCompleteDate(DateTime date)
        {
            int day = date.Day, month = date.Month, year = date.Year;
            string dateStr = string.Empty;
            if (day == 1)
            {
                dateStr = GetDay(day) + " dia do mês de " + GetMonth(month) + " do ano de " + GetYear(year);
            }
            else
            {
                dateStr = GetDay(day) + " dias do mês de " + GetMonth(month) + " do ano de " + GetYear(year);

            }

            return dateStr;

        }

    }
}
