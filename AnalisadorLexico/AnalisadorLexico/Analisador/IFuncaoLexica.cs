
namespace AnalisadorLexico
{
    public interface IFuncaoLexica
    {
        /// <summary>
        /// Metodo que analisa a proxima Token
        /// </summary>
        /// <returns>Retorna uma token</returns>
        Token RetornaProximaToken();
    }
}
