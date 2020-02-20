using System;

namespace K.Bag.Cryptography
{
    /// <summary>
    /// Métodos rápidos de criptografia de string
    /// </summary>
    /// <example>
    /// <code>
    ///     //Para converter para MD5
    ///     CryptoHelper.ToMD5("senha")
    ///     //Para converter para SHA256
    ///     CryptoHelper.ToSHA256("senha")
    ///     //Para converter para criptografia simétrica
    ///     CryptoHelper.ToSymmetricEncrypt("senha", "chave")
    ///     //Para fazer a reversão da criptografia simétrica
    ///     CryptoHelper.ToSymmetricDecrypt("senha criptografada", "chave")
    /// </code>
    /// </example>
    public static class CryptographyStringExtension
    {
        /// <summary>
        /// Cria um string criptografada com o Algorítimo MD5
        /// </summary>
        /// <param name="self">Texto a ser criptografado</param>
        /// <returns>String criptografada em MD5</returns>
        public static string ToMD5(this string self)
        {
            return new HashString(self).GetHashString(HashStringType.MD5);
        }
        /// <summary>
        /// Cria um string criptografada com o Algorítimo SHA1
        /// </summary>
        /// <param name="self">Texto a ser criptografado</param>
        /// <returns>String criptografada em SHA1</returns>
        public static string ToSHA1(this string self)
        {
            return new HashString(self).GetHashString(HashStringType.SHA1);
        }
        /// <summary>
        /// Cria um string criptografada com o Algorítimo SHA256
        /// </summary>
        /// <param name="self">Texto a ser criptografado</param>
        /// <returns>String criptografada em SHA256</returns>
        public static string ToSHA256(this string self)
        {
            return new HashString(self).GetHashString(HashStringType.SHA256);
        }
        /// <summary>
        /// Cria um string criptografada com o Algorítimo SHA384
        /// </summary>
        /// <param name="self">Texto a ser criptografado</param>
        /// <returns>String criptografada em SHA384</returns>
        public static string ToSHA384(this string self)
        {
            return new HashString(self).GetHashString(HashStringType.SHA384);
        }
        /// <summary>
        /// Cria um string criptografada com o Algorítimo SHA512
        /// </summary>
        /// <param name="self">Texto a ser criptografado</param>
        /// <returns>String criptografada em SHA512</returns>
        public static string ToSHA512(this string self)
        {
            return new HashString(self).GetHashString(HashStringType.SHA512);
        }
        /// <summary>
        /// Cria um string criptografada com o Algorítimo Simétrico utilizando uma chave
        /// </summary>
        /// <param name="self">Texto a ser criptografado</param>
        /// <param name="secret">Chave de criptografia (Deve ser utilizada a mesma para que seja desfeita)</param>
        /// <returns>String criptografada</returns>
        public static string ToSymmetricEncrypt(this string self, string secret)
        {
			return SymmetricEncrypt.ToSymmetricEncrypt(self, secret);
        }
        /// <summary>
        /// Cria um string descriptografada com o Algorítimo Simétrico utilizando uma chave
        /// </summary>
        /// <param name="self">Texto a ser descriptografado</param>
        /// <param name="secret">Chave de criptografia (A mesma utilizada na criptografia)</param>
        /// <returns>String descriptografada</returns>
        public static string ToSymmetricDecrypt(this string self, string secret)
        {
            return SymmetricEncrypt.ToSymmetricDecrypt(self, secret);
        }
    }
}
