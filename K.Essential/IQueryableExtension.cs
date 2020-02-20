using System.Linq;

namespace K.Essential
{
    public static class IQueryableExtension
    {
        /// <summary>
        /// <para>Facilita a operação de paginar um IEnumerable.</para>
        /// <para>É necessário determinar a quantidade de registro por página e qual a página que deve ser retornada.</para>
        /// </summary>
        /// <example>
        /// <code>
        /// //Retorna uma lista de pessoa com no máximo 10 registro contanto a partir do registro de número 30
        /// //Quando se existe um Filtro (Where) é necessário um ordenamento (OrderBy)
        /// List&lt;Pessoa&gt; pessoa = context.Pessoas.Where(p =&gt; p.Nome.Contains("N") ).Pagination(10, 2).OrderBy(o =&gt; new { o.Nome }).ToList()
        /// </code>
        /// </example>
        /// <typeparam name="TSource">Classe que servirá como base do IEnumerable tratado</typeparam>
        /// <param name="self">IEnumerable a ser tratado</param>
        /// <param name="pageSize">Quantidade de registro por página</param>
        /// <param name="page">Número da página a ser retornado. O registro inicial da paginação é (pageSize * page)</param>
        /// <returns>IEnumerable paginado</returns>
        public static IQueryable<TSource> Pagination<TSource>(this IQueryable<TSource> self, int pageSize, int page)
        {
            int initial = page * pageSize;
            int final = pageSize;

            if (final > self.Count())
            {
                final = self.Count();
            }

            return self.Skip(initial).Take(final);
        }
    }
}
