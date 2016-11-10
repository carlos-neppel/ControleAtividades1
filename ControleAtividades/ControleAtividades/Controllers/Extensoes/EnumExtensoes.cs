using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace ControleAtividades.Controllers.Extensoes
{
    public static class EnumExtensoes
    {
        public static DisplayAttribute GetDisplayAttributesFrom(this Enum enumValue, Type enumType)
        {
            return enumType.GetMember(enumValue.ToString())
                           .First()
                           .GetCustomAttribute<DisplayAttribute>();
        }

        public static string GetDisplayName(this Enum enumValue, Type enumType)
        {
            DisplayAttribute metadata = enumValue.GetDisplayAttributesFrom(enumType);

            string nome = metadata.Name;
            return nome;
        }

        
    }
}