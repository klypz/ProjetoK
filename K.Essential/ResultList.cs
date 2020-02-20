using System;
using System.Collections.Generic;

namespace K.Essential
{

    /// <summary>
    /// Padrão de resposta a requisição quando é esperado uma lista. Mais utilizados para requisições que necessitem de uma validação da resposta.
    /// </summary>
    /// <example>
    /// <code>
    /// //...
    /// public ResultList&lt;Pessoa&gt; GetPessoas(){
    ///     try
    ///     {
    ///         int count = context.Pessoas.Count();
    ///         List&lt;Pessoa&gt; pessoas = context.Pessoas.Pagination(10, 0).ToList();
    ///         ResultList&lt;Pessoa&gt; result = new ResultList&lt;Pessoa&gt;(10, 0, pessoas);
    ///         
    ///         return result;
    ///     }
    ///     catch(Exception ex)
    ///     {
    ///         ResultList&lt;Pessoa&gt; result = new ResultList&lt;Pessoa&gt;(ex);
    ///         
    ///         return result;
    ///     }
    /// }
    /// //..
    /// </code>
    /// </example>
    /// <typeparam name="T">Classe esperada como resposta da requisição. A requisição espera como resposta uma Lista desta classe</typeparam>
    public class ResultList<T> : Result<List<T>>
    {
        /// <summary>
        /// <para>Utilizado para montar um objeto de retorno em tempo de execução.</para>
        /// </summary>
        /// <param name="type">Tipo de resultado</param>
        /// <param name="pageSize">Quantidade de registros por página</param>
        /// <param name="currentPage">Página atual</param>
        /// <param name="count">Quantidade total de registros na consulta</param>
        public ResultList(int pageSize, int currentPage, int count, ResultType type) : base(type)
        {
            Init(pageSize, currentPage, count);
        }

        /// <summary>
        /// <para>Utilizado para montar um objeto de retorno em tempo de execução.</para>
        /// </summary>
        /// <param name="type">Tipo de resultado</param>
        /// <param name="code">Um código definido para a resposta</param>
        /// <param name="pageSize">Quantidade de registros por página</param>
        /// <param name="currentPage">Página atual</param>
        /// <param name="count">Quantidade total de registros na consulta</param>
        public ResultList(int pageSize, int currentPage, int count, ResultType type, string code) : base(type, code)
        {
            Init(pageSize, currentPage, count);
        }

        /// <summary>
        /// <para>Utilizado para retornar um objeto requisitado.</para>
        /// </summary>
        /// <param name="type">Tipo de resultado</param>
        /// <param name="code">Um código definido para a resposta</param>
        /// <param name="data">Objeto da resposta</param>
        /// <param name="pageSize">Quantidade de registros por página</param>
        /// <param name="currentPage">Página atual</param>
        /// <param name="count">Quantidade total de registros na consulta</param>
        public ResultList(int pageSize, int currentPage, int count, ResultType type, string code, List<T> data) : base(type, code, data)
        {
            Init(pageSize, currentPage, count);
        }

        /// <summary>
        /// <para>Utilizado para retornar um objeto requisitado.</para>
        /// </summary>
        /// <param name="type">Tipo de resultado</param>
        /// <param name="data">Objeto da resposta</param>
        /// <param name="pageSize">Quantidade de registros por página</param>
        /// <param name="currentPage">Página atual</param>
        /// <param name="count">Quantidade total de registros na consulta</param>
        public ResultList(int pageSize, int currentPage, int count, ResultType type, List<T> data) : base(type, data)
        {
            Init(pageSize, currentPage, count);
        }

        /// <summary>
        /// <para>Utilizado para retornar um objeto requisitado.</para>
        /// <para>O Tipo de resultado é "Sucesso" (1) como padrão</para>
        /// </summary>
        /// <param name="code">Um código definido para a resposta</param>
        /// <param name="data">Objeto da resposta</param>
        /// <param name="pageSize">Quantidade de registros por página</param>
        /// <param name="currentPage">Página atual</param>
        /// <param name="count">Quantidade total de registros na consulta</param>
        public ResultList(int pageSize, int currentPage, int count, string code, List<T> data) : base(code, data)
        {
            Init(pageSize, currentPage, count);
        }

        /// <summary>
        /// <para>Utilizado para retornar um objeto requisitado.</para>
        /// <para>O Tipo de resultado é "Sucesso" (1) como padrão</para>
        /// </summary>
        /// <param name="data">Objeto da resposta</param>
        /// <param name="pageSize">Quantidade de registros por página</param>
        /// <param name="currentPage">Página atual</param>
        /// <param name="count">Quantidade total de registros na consulta</param>
        public ResultList(int pageSize, int currentPage, int count, List<T> data) : base(data)
        {
            Init(pageSize, currentPage, count);
        }

        /// <summary>
        /// <para>Utilizado para retornar uma exceção como resposta</para>
        /// </summary>
        /// <param name="type">Tipo de resultado</param>
        /// <param name="code">Um código definido para a resposta</param>
        /// <param name="exception">Objeto de exceção</param>
        public ResultList(ResultType type, string code, Exception exception) : base(type, code, exception)
        {
            Init(-1, -1, -1);
        }

        /// <summary>
        /// <para>Utilizado para retornar uma exceção como resposta</para>
        /// </summary>
        /// <param name="type">Tipo de resultado</param>
        /// <param name="exception">Objeto de exceção</param>
        public ResultList(ResultType type, Exception exception) : base(type, exception)
        {
            Init(-1, -1, -1);
        }

        /// <summary>
        /// <para>Utilizado para retornar uma exceção como resposta</para>
        /// <para>O Tipo de resultado é "Exceção" (2) como padrão</para>
        /// </summary>
        /// <param name="exception">Objeto de exceção</param>
        /// <param name="code">Um código definido para a resposta</param>
        public ResultList(string code, Exception exception) : base(code, exception)
        {
            Init(-1, -1, -1);
        }

        /// <summary>
        /// <para>Utilizado para retornar uma exceção como resposta</para>
        /// <para>O Tipo de resultado é "Exceção" (2) como padrão</para>
        /// </summary>
        /// <param name="exception">Objeto de exceção</param>
        public ResultList(Exception exception) : base(exception)
        {
            Init(-1, -1, -1);
        }

        private void Init(int pageSize, int currentPage, int count)
        {
            PageSize = pageSize;
            CurrentPage = currentPage;
            Count = count;
        }

        /// <summary>
        /// Quantidade de registros por página
        /// </summary>
        public int PageSize { get; private set; }
        /// <summary>
        /// Página atual
        /// </summary>
        public int CurrentPage { get; private set; }
        /// <summary>
        /// Quantidade total de páginas. Utiliza como base o tamanho da página e quantidade de registro
        /// </summary>
        public int Pages => Math.Abs(Count / PageSize) + (Math.Abs(Count / PageSize) < Count * 1.0 / PageSize * 1.0 ? 1 : 0);
        /// <summary>
        /// Quantidade total de registros na consulta
        /// </summary>
        public int Count { get; private set; }
    }
}