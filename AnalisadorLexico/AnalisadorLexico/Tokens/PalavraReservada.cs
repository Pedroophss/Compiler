using System;

namespace AnalisadorLexico.Tokens
{
    public class PalavraReservada : Token
    {

        /// <summary>
        /// Contrutor Default
        /// </summary>
        /// <param name="aLexame">Lexame que criara o token</param>
        private PalavraReservada(String aLexame) : base(aLexame) { }

        /// <summary>
        /// Tipo da palavra reservada
        /// </summary>
        public override TiposTokens Tipo { get; protected set; }

        /// <summary>
        /// Metodo cria uma token de palavra reservada
        /// </summary>
        /// <param name="aTipo">Tipo da token</param>
        /// <returns>Retorna um token do tipo da palavra reservada</returns>
        public static Token CriaPalavraReservada(String aLexame)
        {
            var tipoPalavraReservada = ValidadoresAlfabeto.RetornaTipoPalavraReservada(aLexame);

            var palavraToken = new PalavraReservada(aLexame);
            palavraToken.Tipo = tipoPalavraReservada;

            return palavraToken;
        }
    }
}
