using System;
using System.Globalization;

namespace K.Bag
{
    [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = true)]
    public sealed class EnumDescriptionAttribute : Attribute
    {
        /// <summary>
        /// <para>Cultura (idioma) que está na descrição</para>
        /// <para>Caso não seja informado é utilizado a cultuta atual da aplicação</para>
        /// </summary>
        internal CultureInfo CultureInfo { get; private set; }
        /// <summary>
        /// Texto descritivo do item
        /// </summary>
        internal string Description { get; private set; }

        /// <summary>
        /// Escreva uma descrição para o item.
        /// </summary>
        /// <param name="description">Texto descritivo</param>
        public EnumDescriptionAttribute(string description) : this(description, CultureInfo.CurrentCulture.Name)
        {
        }


        /// <summary>
        /// Escreva uma descrição para o item.
        /// </summary>
        /// <param name="description">Texto descritivo</param>
        /// <param name="cultureInfo">Cultura (idioma) que está na descrição</param>
        public EnumDescriptionAttribute(string description, string cultureInfo)
        {
            Description = description;
            CultureInfo = new CultureInfo(cultureInfo);
        }
    }
}
