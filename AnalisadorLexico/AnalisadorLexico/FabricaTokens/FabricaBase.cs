namespace AnalisadorLexico.FabricaTokens
{
    /// <summary>
    /// Classe base das fabricas
    /// </summary>
    /// <typeparam name="T">Tipo do que vai ser produzido</typeparam>
    /// <typeparam name="S">Parametro usado para a criação</typeparam>
    public abstract class FabricaBase<T, S>
    {
        /// <summary>
        /// Variavel que armazena ultima criação
        /// </summary>
        protected T ProdutoCriado;

        /// <summary>
        /// Metodo que Cria o produto T da fabrica
        /// </summary>
        /// <param name="aParametro">Parametro que identifica a criação</param>
        protected abstract T Criar(S aParametro);
    }

    /// <summary>
    /// Classe base das fabricas
    /// </summary>
    /// <typeparam name="T">Tipo do que vai ser produzido</typeparam>
    /// <typeparam name="S">Parametro usado para a criação</typeparam>
    /// <typeparam name="U">Paramentro de controle para a criação</typeparam>
    public abstract class FabricaBase<T, S, U>
    {
        /// <summary>
        /// Variavel que armazena ultima criação
        /// </summary>
        protected T ProdutoCriado;

        /// <summary>
        /// Metodo que Cria o produto T da fabrica
        /// </summary>
        /// <param name="aParametro">Parametro que identifica a criação</param>
        protected abstract T Criar(S aParametro, ref U aPonteiro);
    }
}
