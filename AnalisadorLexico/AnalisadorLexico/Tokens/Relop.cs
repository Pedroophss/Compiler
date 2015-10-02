using System;

namespace AnalisadorLexico.Tokens
{
    /// <summary>
    /// Classe que representa a Token Addop
    /// </summary>
    public class Relop : Token
    {
        /// <summary>
        /// Construtor da Classe Relop
        /// </summary>
        /// <param name="aLexame">String Lexame correspondente ao token</param>
        protected Relop(String aLexame) : base(aLexame) { }

        /// <summary>
        /// Propriedade Tipo da token
        /// </summary>
        public override TiposTokens Tipo
        {
            get { return TiposTokens.Relop; }
            protected set { }
        }

        /// <summary>
        /// Cria uma Token Relop
        /// </summary>
        /// <param name="aComando">String que será analisado</param>
        /// <param name="aPosicao">Posição atual da string</param>
        /// <returns>Retorna Relop criado</returns>
        public static Relop CriaRelop(String aComando, ref int aPosicao)
        {
            //Lexame que será montado para o token
            String lexame = String.Empty;

            if(aComando[aPosicao].ERelopExcessao())
            {
                lexame += aComando[aPosicao++];

                if (aPosicao < aComando.Length && aComando[aPosicao].ERelop() && lexame != aComando[aPosicao].ToString())
                    lexame += aComando[aPosicao++];

                return new Relop(lexame);
            }

            if (aComando[aPosicao].ERelop())
                lexame += aComando[aPosicao++];

            return new Relop(lexame);
        }
    }
}
