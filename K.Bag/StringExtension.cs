using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace K.Bag
{

    /// <summary>
    /// <para>Extensão de string da biblioteca [k.bag] que facilita a transformação de textos</para>
    /// </summary>
    public static class StringExtension
    {
        private static string ToCamelCaseBase(this string self)
        {
            Regex regex = new Regex(@"[^a-zA-Z]([a-zA-Z\u00C0-\u00FF])");
            string transformMatch(Match match)
            {
                return match.Value.ToUpper();
            }

            return regex.Replace(self.ToLower(), transformMatch);
        }

        /// <summary>
        /// <para>Remove tudo que não seja alphanumérico ou _ (espaços também serão removidos)</para>
        /// <para>Regex: [^A-Za-z0-9_]+</para>
        /// </summary>
        /// <param name="self">Texto de origem</param>
        /// <returns>Texto em Code</returns>
        public static string ToCode(this string self)
        {
            Regex reg = new Regex(@"[^A-Za-z0-9_]+");
            return reg.Replace(self.NoAccents(), "");
        }

        /// <summary>
        /// <para>Notação "CamelCase" transforma todas as iniciais de cada palavra maiúscula</para>
        /// <para>e todas as outras minúsculas</para>
        /// <para>No modo "Code" o os espaços, acentos e caracteres especiais são removidos</para>
        /// </summary>
        /// <param name="self">Texto de origem</param>
        /// <param name="isCode">Aplicar modo de Código</param>
        /// <returns>Texto transformado em lowerCamelCase</returns>
        public static string ToCamelCase(this string self, bool isCode = false)
        {
            string result = self.ToCamelCaseBase();
            result = result[0].ToString().ToUpper() + result.Substring(1);

            if (isCode)
            {
                result = result.ToCode();
            }

            return result;
        }

        /// <summary>
        /// <para>Notação "LowerCamelCase" ou "PascalCase" transforma as iniciais, de cada palavra, a partir da segunda palavra, maiúscula</para>
        /// <para>e todas as outras minúsculas.</para>
        /// <para>No modo "Code" o os espaços, acentos e caracteres especiais são removidos</para>
        /// </summary>
        /// <param name="self">Texto de origem</param>
        /// <param name="isCode">Aplicar modo de Código</param>
        /// <returns>Texto transformado em lowerCamelCase</returns>
        public static string ToLowerCamelCase(this string self, bool isCode = false)
        {
            string result = self.ToCamelCaseBase();
            Regex regex = new Regex(@"^[^A-Za-z]+[a-zA-Z]");
            string transformMatch(Match match)
            {
                return match.Value.ToLower();
            };
            result = regex.Replace(result, transformMatch, 1);

            if (isCode)
            {
                result = result.ToCode();
            }

            return result;
        }

        /// <summary>
        /// <para>Notação "UpperCamelCase" ou "CamelCase" transforma as iniciais de cada palavra maiúscula</para>
        /// <para>e todas as outras minúsculas</para>
        /// <para>No modo "Code" o os espaços, acentos e caracteres especiais são removidos</para>
        /// </summary>
        /// <param name="self">Texto de origem</param>
        /// <param name="isCode">Aplicar modo de Código</param>
        /// <returns>Texto transformado em lowerCamelCase</returns>
        public static string ToUpperCamelCase(this string self, bool isCode = false)
        {
            return self.ToCamelCase(isCode);
        }

        /// <summary>
        /// Inverte o texto de origem
        /// </summary>
        /// <param name="self">Texto de origem</param>
        /// <returns>Texto invertido</returns>
        public static string ToReverse(this string self)
        {
            char[] result = self.ToCharArray();
            Array.Reverse(result);
            return string.Join("", result);
        }

        /// <summary>
        /// <para>Remove acentuação, espaços, caracteres especiais e converte tudo para minúsculo</para>
        /// </summary>
        /// <example>
        /// <code>
        ///     string frase = "Klypz é um conjunto de Peças que se encaixam.";
        ///     Console.WriteLine(frase.ToAlias());
        ///     //retorno klypz-e-um-conjunto-de-pecas-que-se-encaixam.
        /// </code>
        /// </example>
        /// <param name="self">String a ser transformada</param>
        /// <returns>Texto no formato de "alias"</returns>
        public static string ToAlias(this string self)
        {
            Regex reg = new Regex(@"[^A-Za-z0-9_\-]+");
            string result = self.Trim().Replace(' ', '-').NoAccents().ToLower();
            result = reg.Replace(result, "");

            return result;
        }

        /// <summary>
        /// <para>Remove acentuação e caracteres especiais</para>
        /// </summary>
        /// <example>
        /// <code>
        ///     string frase = "Klypz é um conjunto de Peças que se encaixam.";
        ///     Console.WriteLine(frase.NoSpecialCharacters());
        ///     //retorno Klypz e um conjunto de Pecas que se encaixam
        /// </code>
        /// </example>
        /// <param name="self">String a ser transformada</param>
        /// <returns>Texto sem caracteres especiais</returns>
        public static string NoSpecialCharacters(this string self)
        {
            Regex reg = new Regex(@"[^A-Za-z0-9 ]+");
            string result = self.NoAccents();
            result = reg.Replace(result, "");

            return result;
        }

        /// <summary>
        /// Remove acentos de uma string
        /// </summary>
        /// <param name="self">String a ser tratada</param>
        /// <returns>Texto sem acentuação</returns>
        public static string NoAccents(this string self)
        {
            var normalizedString = self.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
