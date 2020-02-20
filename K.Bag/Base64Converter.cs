using K.Bag.Base64ConverterUtility;
using System;
using System.IO;
using System.Text;

namespace K.Bag
{
    public static class Base64Converter
    {
        static readonly Func<string, string> FormatToBase64Url = delegate (string input)
        {
            return string.IsNullOrEmpty(input) ? null : input.Replace('+', '-').Replace('/', '_').Replace("=", "");
        };

        static readonly Func<string, string> FormatFromBase64Url = delegate (string input)
        {
            return (input.Replace("_", "/").Replace("-", "+")).PadRight(input.Length + (4 - input.Length % 4) % 4, '=');
        };

        /// <summary>
        /// Encripta um texto em base64 (Encoding UTF8)
        /// </summary>
        /// <param name="input">Texto de origem</param>
        /// <returns>String Base64</returns>
        public static string ToBase64String(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("message", nameof(input));
            }

            byte[] bResult = Encoding.UTF8.GetBytes(input);
            string result = Convert.ToBase64String(bResult);

            return result;
        }

        /// <summary>
        /// Encripta um objeto [Stream] convetendo-o para uma string base64
        /// </summary>
        /// <param name="stream">Objeto de origem</param>
        /// <returns>String encriptado em base64</returns>
        public static string ToBase64String(this Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            byte[] inArray = new byte[(int)stream.Length];
            char[] outArray = new char[(int)(stream.Length * 1.34)];
            stream.Read(inArray, 0, (int)stream.Length);
            return Convert.ToBase64String(inArray);
        }

        /// <summary>
        /// Encripta um objeto [FileStream] convetendo-o para uma string base64
        /// </summary>
        /// <param name="stream">Objeto de origem</param>
        /// <returns>String encriptado em base64</returns>
        public static string ToBase64String(this FileStream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            byte[] inArray = new byte[(int)stream.Length];
            char[] outArray = new char[(int)(stream.Length * 1.34)];
            stream.Read(inArray, 0, (int)stream.Length);
            return Convert.ToBase64String(inArray);
        }

        /// <summary>
        /// Encripta um objeto [byte[]] convetendo-o para uma string base64Url
        /// </summary>
        /// <param name="stream">Objeto de origem</param>
        /// <returns>String encriptado em base64</returns>
        public static string ToBase64UrlString(this byte[] input)
        {
            return FormatToBase64Url(Convert.ToBase64String(input));
        }

        /// <summary>
        /// Decodifica o base64 para o objeto desejado
        /// </summary>
        /// <param name="input">String base64</param>
        /// <param name="mime">Tipo de objeto resultante da Decodificação</param>
        /// <returns>Objeto decodificado</returns>
        public static object FromBase64Object(string input, out IMimeType mime)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("message", nameof(input));
            }

            byte[] result = Convert.FromBase64String(input);

            if (FinderMimeType.IsString(result))
            {
                mime = new MimeType("#string#", "", null);
                return Encoding.UTF8.GetString(result);
            }
            else
            {
                var _mime = FinderMimeType.GetMimeType(result);
                MemoryStream m = new MemoryStream(result);
                mime = _mime;
                return m;
            }
        }

        /// <summary>
        /// Decodifica o base64 para string. Caso a encriptação não tenha uma string como origem o retorno é null
        /// </summary>
        /// <param name="input">String base64</param>
        /// <returns>String decodificada</returns>
        public static string FromBase64String(string input)
        {
            object result = FromBase64Object(input, out IMimeType mime);

            if (mime.Extension == "#string#")
            {
                return (string)result;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Encripta um texto em base64Url (Encoding UTF8)
        /// </summary>
        /// <param name="input">Texto de origem</param>
        /// <returns>String Base64</returns>
        public static string ToBase64UrlString(this string input) => FormatToBase64Url(ToBase64String(input));

        /// <summary>
        /// Encripta um objeto [Stream] convetendo-o para uma string base64Url
        /// </summary>
        /// <param name="stream">Objeto de origem</param>
        /// <returns>String encriptado em base64Url</returns>
        public static string ToBase64UrlString(this Stream stream) => FormatToBase64Url(ToBase64String(stream));

        /// <summary>
        /// Encripta um objeto [FileStream] convetendo-o para uma string base64Url
        /// </summary>
        /// <param name="stream">Objeto de origem</param>
        /// <returns>String encriptado em base64Url</returns>
        public static string ToBase64UrlString(this FileStream stream) => FormatToBase64Url(ToBase64String(stream));

        /// <summary>
        /// Decodifica o base64 para o objeto desejado
        /// </summary>
        /// <param name="input">String base64</param>
        /// <param name="mime">Tipo de objeto resultante da Decodificação</param>
        /// <returns>Objeto decodificado</returns>
        public static object FromBase64UrlObject(string input, out IMimeType mime) => FromBase64Object(FormatFromBase64Url(input), out mime);

        /// <summary>
        /// Decodifica o base64Url para string. Caso a encriptação não tenha uma string como origem o retorno é null
        /// </summary>
        /// <param name="input">String base64Url</param>
        /// <returns>String decodificada</returns>
        public static string FromBase64UrlString(this string input) => FromBase64String(FormatFromBase64Url(input));

		/// <summary>
		/// Decodifica o base64Url para string. Caso a encriptação não tenha uma string como origem o retorno é null
		/// </summary>
		/// <param name="input">String base64Url</param>
		/// <returns>Equivalente a entrada em base64</returns>
		public static string FromBase64UrlToBase64(this string input) => FormatFromBase64Url(input);


		/// <summary>
		/// Decodifica o base64 para base64Url. Caso a encriptação não tenha uma string como origem o retorno é null
		/// </summary>
		/// <param name="input">String base64</param>
		/// <returns>Equivalente a entrada em base64Url</returns>
		public static string FromBase64ToBase64Url(this string input) => FormatToBase64Url(input);
	}
}
