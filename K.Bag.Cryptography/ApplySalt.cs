using System.Security.Cryptography;
using System.Text;

namespace K.Bag.Cryptography
{
    /// <summary>
    /// <para>Salt é uma técnica utilizada para evitar que uma senha seja exposta a ataque de dicionários.</para>
    /// <para>O salt "mistura" uma senha a um texto de forma a inviabilizar o descobrimento da senha original.</para>
    /// </summary>
    /// <example>
    /// <code>
    ///     string password = "1234";
    ///     string salt = "String utilizada para misturar-se a senha";
    ///     
    ///     ApplySalt passwordWithSalt = new ApplySalt(password, salt);
    ///     string newPass = passwordWithSalt.Get(HashStringType.SHA256, 9);
    ///     //sBR7-tlajLZhT9iyx4PwcCde-DmCNC7kAK-M_uIAWUitFUu99QgRZ0XuR2pl68iwtVgUFZ9jSoW4u3O4ceMg8A
    /// </code>
    /// </example>
    public class ApplySalt
    {
        private readonly string input = "";
        private readonly string salt = "";

        /// <param name="input">Senha do usuário</param>
        /// <param name="salt">Chave de Salt</param>
        public ApplySalt(string input, string salt)
        {
            this.input = input;
            this.salt = salt;
        }

        /// <summary>
        /// <para>Obtém o resultado da aplicação do salt em Base64 Reduzido</para>
        /// </summary>
        /// <param name="hashType">Padrão de criptografia utilizada</param>
        /// <param name="iterations">Número de vezes que a iteração utiliza a chave</param>
        /// <param name="keySize">Tamanho da chave</param>
        /// <returns>Retorna a aplicação do salt em Base64 Reduzido</returns>
        public string Get(HashStringType hashType = HashStringType.SHA1, int iterations = 10, int keySize = 64)
        {
            byte[] bSalt = Encoding.Default.GetBytes(salt);
            byte[] bInput = Encoding.Default.GetBytes(input);
            string hashName = hashType.ToString();

            PasswordDeriveBytes deriveBytes = new PasswordDeriveBytes(bInput, bSalt, hashName, iterations);

            var b = deriveBytes.GetBytes(keySize);
            return b.ToBase64UrlString();
        }
    }
}
