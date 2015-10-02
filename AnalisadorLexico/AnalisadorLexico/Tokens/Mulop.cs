using System;

namespace AnalisadorLexico.Tokens
{
    /// <summary>
    /// Classe que representa a Token Mulop
    /// </summary>
    public class Mulop : Token
    {
        /// <summary>
        /// Construtor da Classe Mulop
        /// </summary>
        /// <param name="aLexame">String Lexame correspondente ao token</param>
        protected Mulop(String aLexame) : base(aLexame) { }

        /// <summary>
        /// Propriedade Tipo da token
        /// </summary>
        public override TiposTokens Tipo
        {
            get { return TiposTokens.Mulop; }
            protected set { }
        }

        /// <summary>
        /// Verifica se String é um Mulop
        /// </summary>
        /// <param name="aComando">String que será analisado</param>
        /// <param name="aPosicao">Posição atual da string</param>
        /// <returns>Retorna Mulop criado</returns>
        public static Mulop CriaMulop(String aComando, ref int aPosicao)
        {
            //Lexame que será montado para o token
            String lexame = String.Empty;

            if (aPosicao < aComando.Length && aComando[aPosicao].EMulop())
                lexame += aComando[aPosicao++];

            return new Mulop(lexame);
        }
    }
}
