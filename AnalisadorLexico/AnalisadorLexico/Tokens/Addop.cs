using System;

namespace AnalisadorLexico.Tokens
{
    /// <summary>
    /// Classe que representa a Token Addop
    /// </summary>
    public class Addop : Token
    {
        /// <summary>
        /// Construtor da Classe Addop
        /// </summary>
        /// <param name="aLexame">String Lexame correspondente ao token</param>
        protected Addop(String aLexame) : base(aLexame) { }

        /// <summary>
        /// Propriedade Tipo da token
        /// </summary>
        public override TiposTokens Tipo
        {
            get { return TiposTokens.Addop; }
            protected set { }
        }

        /// <summary>
        /// Cria uma Token Addop
        /// </summary>
        /// <param name="aComando">String que será analisado</param>
        /// <param name="aPosicao">Posição atual da string</param>
        /// <returns>Retorna Addop criado</returns>
        public static Addop CriaAddop(String aComando, ref int aPosicao)
        {
            //Lexame que será montado para o token
            String lexame = String.Empty;

            if (aPosicao < aComando.Length && aComando[aPosicao].ELetraOuNumero())
                lexame += aComando[aPosicao++];

            return new Addop(lexame);
        }

        /// <summary>
        /// Cria uma Token Addop
        /// </summary>
        /// <param name="aLexame">String do Addop</param>
        /// <returns>Retorna Addop criado</returns>
        public static Addop CriaAddop(String aLexame)
        {
            return new Addop(aLexame);
        }
    }
}
