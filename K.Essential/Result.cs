using System;

namespace K.Essential
{

    /// <summary>
    /// Padrão de resposta a requisição. Mais utilizados para requisições que necessitem de uma validação da resposta.
    /// </summary>
    /// <example>
    /// <code>
    /// //...
    /// public Result&lt;Pessoa&gt; GetPessoa(int id){
    ///     try
    ///     {
    ///         Pessoa pessoa = context.Pessoas.FirstOrDefault(p => p.Id == id);
    ///         Result&lt;Pessoa&gt; result = new Result&lt;Pessoa&gt;(pessoa);
    ///         
    ///         return result;
    ///     }
    ///     catch(Exception ex)
    ///     {
    ///         Result&lt;Pessoa&gt; result = new Result&lt;Pessoa&gt;(ex);
    ///         
    ///         return result;
    ///     }
    /// }
    /// //..
    /// </code>
    /// </example>
    /// <typeparam name="T">Classe esperada como resposta da requisição.</typeparam>
    public class Result<T>
    {
        /// <summary>
        /// <para>Utilizado para montar um objeto de retorno em tempo de execução.</para>
        /// </summary>
        /// <param name="type">Tipo de resultado</param>
        public Result(ResultType type)
        {
            Type = type;
        }

        /// <summary>
        /// <para>Utilizado para montar um objeto de retorno em tempo de execução.</para>
        /// </summary>
        /// <param name="type">Tipo de resultado</param>
        /// <param name="code">Um código definido para a resposta</param>
        public Result(ResultType type, string code) : this(type)
        {
            Code = code;
        }

        /// <summary>
        /// <para>Utilizado para retornar um objeto requisitado.</para>
        /// </summary>
        /// <param name="type">Tipo de resultado</param>
        /// <param name="code">Um código definido para a resposta</param>
        /// <param name="data">Objeto da resposta</param>
        public Result(ResultType type, string code, T data) : this(type, code)
        {
            Data = data;
        }

        /// <summary>
        /// <para>Utilizado para retornar um objeto requisitado.</para>
        /// </summary>
        /// <param name="type">Tipo de resultado</param>
        /// <param name="data">Objeto da resposta</param>
        public Result(ResultType type, T data) : this(type)
        {
            Data = data;
        }

        /// <summary>
        /// <para>Utilizado para retornar um objeto requisitado.</para>
        /// <para>O Tipo de resultado é "Sucesso" (1) como padrão</para>
        /// </summary>
        /// <param name="code">Um código definido para a resposta</param>
        /// <param name="data">Objeto da resposta</param>
        public Result(string code, T data) : this(ResultType.Success, code)
        {
            Data = data;
        }


        /// <summary>
        /// <para>Utilizado para retornar um objeto requisitado.</para>
        /// <para>O Tipo de resultado é "Sucesso" (1) como padrão</para>
        /// </summary>
        /// <param name="data">Objeto da resposta</param>
        public Result(T data) : this(ResultType.Success)
        {
            Data = data;
        }

        /// <summary>
        /// <para>Utilizado para retornar uma exceção como resposta</para>
        /// </summary>
        /// <param name="type">Tipo de resultado</param>
        /// <param name="code">Um código definido para a resposta</param>
        /// <param name="exception">Objeto de exceção</param>
        public Result(ResultType type, string code, Exception exception) : this(type, code)
        {
            Exception = exception;
        }

        /// <summary>
        /// <para>Utilizado para retornar uma exceção como resposta</para>
        /// </summary>
        /// <param name="type">Tipo de resultado</param>
        /// <param name="exception">Objeto de exceção</param>
        public Result(ResultType type, Exception exception) : this(type)
        {
            Exception = exception;
        }

        /// <summary>
        /// <para>Utilizado para retornar uma exceção como resposta</para>
        /// <para>O Tipo de resultado é "Exceção" (2) como padrão</para>
        /// </summary>
        /// <param name="exception">Objeto de exceção</param>
        /// <param name="code">Um código definido para a resposta</param>
        public Result(string code, Exception exception) : this(ResultType.Exception, code)
        {
            Exception = exception;
        }

        /// <summary>
        /// <para>Utilizado para retornar uma exceção como resposta</para>
        /// <para>O Tipo de resultado é "Exceção" (2) como padrão</para>
        /// </summary>
        /// <param name="exception">Objeto de exceção</param>
        public Result(Exception exception) : this(ResultType.Exception)
        {
            Exception = exception;
        }

        /// <summary>
        /// Código próprio do retorno
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Tipo de resposta
        /// </summary>
        public ResultType? Type { get; set; }

        /// <summary>
        /// Tipo de resposta em string, necessário para serialização
        /// </summary>
        public string TypeString { get { return Type.HasValue ? Enum.GetName(typeof(ResultType), Type.Value) : string.Empty; } }
        /// <summary>
        /// Objeto esperado pela requisição
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// Objeto de exceção em caso de erro.
        /// </summary>
        public Exception Exception { get; set; }
    }
}