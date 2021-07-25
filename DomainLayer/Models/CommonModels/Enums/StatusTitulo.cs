using System;
using System.ComponentModel;
using System.Reflection;

namespace DomainLayer.Models.CommonModels.Enums
{
    public enum StatusTitulo
    {
        [Description("Aberto")]
        Aberto = 1,
        [Description("Liquidado")]
        Liquidado = 2,
        [Description("Vencido")]
        Vencido = 3,
        [Description("Cancelado")]
        Cancelado = 4,
        [Description("Protestado")]
        Protestado  = 5
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
