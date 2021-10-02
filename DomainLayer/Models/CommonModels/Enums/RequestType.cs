using System;
using System.ComponentModel;
using System.Reflection;

namespace DomainLayer.Models.CommonModels.Enums
{
    public enum RequestType
    {
        [Description("Add")]
        Add = 1,
        [Description("Edit")]
        Edit = 2,
        [Description("Remove")]
        Remove = 3,
        [Description("Liquidar")]
        Liquidar = 4,
        [Description("Abater")]
        Abater = 5,
        [Description("Confere")]
        Confere = 6,
        [Description("Finaliza")]
        Finaliza = 7
    }

    public static class extetionClass
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
