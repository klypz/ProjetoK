namespace K.Bag.Cryptography
{
    /// <summary>
    /// Tipo de algorítimo "Hash" para realizar criptografias
    /// </summary>
    public enum HashStringType
    {
        /// <summary>
        /// MD5 = 128 bites
        /// </summary>
        MD5 = 128,
        /// <summary>
        /// SHA1 = 160 bites
        /// </summary>
        SHA1 = 160,
        /// <summary>
        /// SHA256 = 256 bites
        /// </summary>
        SHA256 = 256,
        /// <summary>
        /// SHA384 = 384 bites
        /// </summary>
        SHA384 = 384,
        /// <summary>
        /// SHA512 = 512 bites
        /// </summary>
        SHA512 = 512
    }
}