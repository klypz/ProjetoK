using System;
using System.Globalization;
using System.Linq;

namespace K.Bag
{
    /// <summary>
    /// <para>Extensão de enum da biblioteca [k.bag] para obter uma descrição com base no atributo [EnumDescription]</para>
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// Obtém a descrição definida para um item de enum com base no atributo [EnumDescription]
        /// </summary>
        /// <param name="enum">Enum que se deseja obter a descrição</param>
        /// <returns>Descrição definida ou null</returns>
        public static string GetDescription(this Enum @enum)
        {
            return GetDescription(@enum, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Obtém a descrição definida para um item de enum com base no atributo [EnumDescription]
        /// </summary>
        /// <param name="enum">Enum que se deseja obter a descrição</param>
        /// <param name="cultureInfo">Cultura da descrição</param>
        /// <param name="arbitraryCulture">
        /// <para>true: Caso não haja descrição para cultura solicitada o retorno é null</para>
        /// <para>false (default): aso não haja descrição para cultura solicitada o retorno será o primeiro atributo independente da cultura</para>
        /// </param>
        /// <returns>Descrição definida ou null</returns>
        public static string GetDescription(this Enum @enum, CultureInfo cultureInfo, bool arbitraryCulture = false)
        {
            if (@enum == null)
            {
                throw new ArgumentNullException(nameof(@enum));
            }

            if (!Enum.IsDefined(@enum.GetType(), @enum))
            {
                return "";
            }
            else
            {
                var field = @enum.GetType().GetFields().First(p => p.GetValue(@enum).Equals(@enum));

                var desc = (EnumDescriptionAttribute[])field.GetCustomAttributes(typeof(EnumDescriptionAttribute), true);

                return (desc?.FirstOrDefault(p=> p.CultureInfo.LCID == cultureInfo.LCID) ?? desc?.FirstOrDefault(p => p.CultureInfo.Parent.LCID == cultureInfo.Parent.LCID && !arbitraryCulture) ?? desc.FirstOrDefault(p => !arbitraryCulture))?.Description;
            }
        }
    }
}
