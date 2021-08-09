using System;
using System.ComponentModel;
using System.Reflection;

namespace DomainLayer.Models.Financeiro.Caixa.Enums
{
    public enum TipoMovimentacao
    {
        [Description("ContasPagar")]
        ContasPagar = 1, //SUBTRAI
        [Description("Provisionamento")]
        Provisionamento = 2, //SUBTRAI
        [Description("ContasReceber")]
        ContasReceber = 3, //SOMA
        [Description("Devolução")]
        Devolucao = 4, //SOMA DEVOLUÇÃO DE PROVISIONAMENTO
        [Description("Retirada")]
        Retirada = 5, //SUBTRAI RETIRADA DO CAIXA
        [Description("Depósito Bancário")]
        DepositoBancario = 6, //SUBTRAI CAIXA SOMA  BANCO
        [Description("Saque Bancário")]
        SaqueBancario = 5 //SOMA CAIXA SUBTRAI BANCO

    }
    
    public static class extentionClass
    {
        public static string getDescription(this Enum e)
        {
            Type eType = e.GetType();
            string eName = Enum.GetName(eType, e);
            if (eName != null)
            {
                FieldInfo fieldInfo = eType.GetField(eName);
                if (fieldInfo != null)
                {
                    DescriptionAttribute descriptionAttribute =
                        Attribute.GetCustomAttribute(fieldInfo,
                        typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (descriptionAttribute != null)
                    {
                        return descriptionAttribute.Description;
                    }
                }
            }
            return null;
        }

        public static string getName(this Enum e)
        {
            Type eType = e.GetType();
            string eName = Enum.GetName(eType, e);
            if (eName != null)
            {
                return eName.ToString();
            }
            return null;
        }
    }
}
