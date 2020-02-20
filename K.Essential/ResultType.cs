namespace K.Essential
{
    /// <summary>
    /// <para>Tipo de resultado retornado para requisição.</para>
    /// </summary>
    public enum ResultType
    {
        /// <summary>
        /// O resultado foi satisfatório
        /// </summary>
        Success = 1,
        /// <summary>
        /// Ocorreu um erro que impossibilita o fim do processo
        /// </summary>
        Exception = 2,
        /// <summary>
        /// Um sucesso, entretanto não houve informação a retornar
        /// </summary>
        Empty = 3
    }
}
