using System;
using System.Runtime.Serialization;

namespace K.Essential
{
    /// <summary>
    /// CodeException é herdada da classe Exception, onde inclui uma propriedade "Code" que pode ser utilizada como identificador da exceção.
    /// </summary>
    [Serializable]
    public class CodeException : Exception
    {
        /// <summary>
        /// Código de identificação da exceção
        /// </summary>
        public string Code { get; private set; }

        /// <param name="code">Código da Exceção</param>
        public CodeException(string code)
        {
            Code = code;
        }

        /// <param name="code">Código da Exceção</param>
        /// <param name="message">Mensagem da Exceção</param>
        public CodeException(string code, string message) : base(message)
        {
            Code = code;
        }

        /// <param name="code">Código da Exceção</param>
        /// <param name="message">Mensagem da Exceção</param>
        /// <param name="innerException">Exceção interna ou origem</param>
        public CodeException(string code, string message, Exception innerException) : base(message, innerException)
        {
            Code = code;
        }

        /// <param name="info"></param>
        /// <param name="context"></param>
        /// <param name="code">Código da Exceção</param>
        protected CodeException(string code, SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Code = code;
        }
    }
}