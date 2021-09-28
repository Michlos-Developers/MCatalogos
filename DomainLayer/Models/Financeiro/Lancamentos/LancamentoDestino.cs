
using System;
using System.ComponentModel;
using System.Reflection;

namespace DomainLayer.Models.Financeiro.Lancamentos
{
    public enum LancamentoDestino
    {
        [Description("BANCO")]
        BANCO = 1,
        [Description("CAIXA")]
        CAIXA = 2
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
