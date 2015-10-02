using System;

namespace AnalisadorLexico.Tokens
{
    /// <summary>
    /// Classe que representa a Token Constante
    /// </summary>
    public class Constante : Token
    {
        /// <summary>
        /// Construtor da Classe Constante
        /// </summary>
        /// <param name="aLexame">String Lexame correspondente ao token</param>
        protected Constante(String aLexame) : base(aLexame) { }

        /// <summary>
        /// Propriedade Tipo da token
        /// </summary>
        public override TiposTokens Tipo
        {
            get { return TiposTokens.Constante; }
            protected set { }
        }

        /// <summary>
        /// Verifica se String é um Constante
        /// </summary>
        /// <param name="aComando">String que será analisado</param>
        /// <param name="aPosicao">Posição atual da string</param>
        /// <returns>Retorna Constante criado</returns>
        public static Token CriaConstante(String aComando, ref int aPosicao)
        {
            //Variaveis que compoe a constante
            String sign = String.Empty;
            String unsigned_real = String.Empty;

            if(aComando[aPosicao].ESinal())
            {            
                sign = aComando[aPosicao++].ToString();

                //Caso o proximo caracter for diferente este sinal é ADDOP
                if(!aComando[aPosicao].ENumero())
                    return Addop.CriaAddop(sign);
            }

            if (aPosicao < aComando.Length && aComando[aPosicao].ENumero())
                unsigned_real = CriaUnsignedInteger(aComando, ref aPosicao);

            if (aPosicao < aComando.Length && aComando[aPosicao].EPonto())
                unsigned_real += CriaParteReal(aComando, ref aPosicao);

            if (aPosicao < aComando.Length && aComando[aPosicao].EFatorEscala())
                unsigned_real += CriaScaleFactor(aComando, ref aPosicao);

            String lexame = String.Concat(sign, unsigned_real);
            return new Constante(lexame);
        }

        private static String CriaUnsignedInteger(String aComando, ref Int32 aPosicao)
        {
            String lexame = String.Empty;

            while (aPosicao < aComando.Length && aComando[aPosicao].ENumero())
                lexame += aComando[aPosicao++];

            return lexame;
        }

        private static String CriaParteReal(String aComando, ref Int32 aPosicao)
        {
            //recebe o ponto
            String lexame = aComando[aPosicao++].ToString();

            while (aPosicao < aComando.Length && aComando[aPosicao].ENumero())
                lexame += aComando[aPosicao++];

            return lexame;
        }

        private static String CriaScaleFactor(String aComando, ref Int32 aPosicao)
        {
            String lexame = String.Empty;

            if(ValidaScaleFactor(aComando, aPosicao))
            {
                //recebe o fator de escala (E)
                lexame = aComando[aPosicao++].ToString();

                //recebe o sinal
                lexame += aComando[aPosicao++].ToString();

                //recebe o primeiro digito
                lexame += aComando[aPosicao++].ToString();

                //recebe os outros digitos
                while (aPosicao < aComando.Length && aComando[aPosicao].ENumero())
                    lexame += aComando[aPosicao++];
            }            

            return lexame;
        }

        private static Boolean ValidaScaleFactor(String aComando, Int32 aPosicao)
        {
            if (!aComando[aPosicao++].EFatorEscala())
                return false;

            if (aPosicao <= aComando.Length && (aPosicao == aComando.Length || !aComando[aPosicao++].ESinal()))
                return false;

            if (aPosicao <= aComando.Length && (aPosicao == aComando.Length || !aComando[aPosicao++].ENumero()))
                return false;

            return true;
        }
    }
}
