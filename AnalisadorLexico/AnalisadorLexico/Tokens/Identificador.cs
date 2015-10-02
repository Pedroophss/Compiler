using System;

namespace AnalisadorLexico
{
    /// <summary>
    /// Classe que representa a Token Identificador
    /// </summary>
    public class Identificador : Token
    {
        /// <summary>
        /// Construtor da Classe Identificador
        /// </summary>
        /// <param name="aLexame">String Lexame correspondente ao token</param>
        protected Identificador(String aLexame) : base(aLexame) { }

        /// <summary>
        /// Propriedade Tipo da token
        /// </summary>
        public override TiposTokens Tipo
        {
            get { return TiposTokens.Identificador; }
            protected set { }
        }        

        /// <summary>
        /// Verifica se String é um Identificador
        /// </summary>
        /// <param name="aComando">String que será analisado</param>
        /// <param name="aPosicao">Posição atual da string</param>
        /// <returns>Retorna identificador criado</returns>
        public static Identificador CriaIdentificador(String aComando, ref int aPosicao)
        {
            //Lexame que será montado para o token
            String lexame = String.Empty;

            while(aPosicao < aComando.Length && aComando[aPosicao].ELetraOuNumero())
            {
                lexame += aComando[aPosicao++];
            }

            return new Identificador(lexame);
        }
    }
}
