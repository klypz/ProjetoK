using System.Security.Cryptography;
using System.Text;

namespace K.Bag.Cryptography
{

    /// <summary>
    /// <para>Criptografa string utilizando os Algorítimos</para>
    /// <para>MD5, SHA1, SHA256, SHA384, SHA512</para>
    /// </summary>
    public sealed class HashString
    {
        private readonly string input = "";

        public HashString(string input)
        {
            this.input = input;
        }

        /// <summary>
        /// Obtém a "Hash" de um texto (input) com base no algorítimo informado
        /// </summary>
        /// <param name="hashStringType">Tipo de Algorítimo de hash</param>
        /// <returns>Retorna string criptografada</returns>
        public string GetHashString(HashStringType hashStringType)
        {
            HashAlgorithm hashAlgorithm = null;

            string output;
            switch (hashStringType)
            {
                case HashStringType.MD5:
                    hashAlgorithm = MD5.Create();
                    break;
                case HashStringType.SHA1:
                    hashAlgorithm = SHA1.Create();
                    break;
                case HashStringType.SHA256:
                    hashAlgorithm = SHA256.Create();
                    break;
                case HashStringType.SHA384:
                    hashAlgorithm = SHA384.Create();
                    break;
                case HashStringType.SHA512:
                    hashAlgorithm = SHA512.Create();
                    break;
                default:
                    break;
            }

            output = CommonHashString(hashAlgorithm, input);
            return output;
        }

        private string CommonHashString(HashAlgorithm hash, string input)
        {
            byte[] data = hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}