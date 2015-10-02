using System;
using System.Collections.Generic;
using System.Linq;

namespace AnalisadorLexico
{
    /// <summary>
    /// Classe que controla a identificação das variaveis da gramatica
    /// </summary>
    public static class ValidadoresAlfabeto
    {

        /// <summary>
        /// Metodo construtor que inicializa todas as propriedades do alfabeto
        /// </summary>
        static ValidadoresAlfabeto()
        {
            //Iniciando Palavras Reservadas
            PalavrasReservadas.Add("div", TiposTokens.Mulop);
            PalavrasReservadas.Add("mod", TiposTokens.Mulop);
            PalavrasReservadas.Add("and", TiposTokens.Mulop);
            PalavrasReservadas.Add("or", TiposTokens.Addop);
            PalavrasReservadas.Add("sin", TiposTokens.Sin);
            PalavrasReservadas.Add("log", TiposTokens.Log);
            PalavrasReservadas.Add("cos", TiposTokens.Cos);

            //Iniciando Operadores Mulop
            Mulop.Add("*");
            Mulop.Add("/");

            //Iniciando Sinais
            Sign.Add("+");
            Sign.Add("-");

            //Iniciando Addops
            Addop.Add("+");
            Addop.Add("-");

            //Iniciando Relops
            Relop.Add("=");
            Relop.Add("<");
            Relop.Add(">");
        }

        #region .:Propriedades:.

        //Lista de Palavras Reservadas
        private static IDictionary<String, TiposTokens> PalavrasReservadas = new Dictionary<String, TiposTokens>();

        //Lista de operadores MULLOP
        private static IList<String> Mulop = new List<String>();

        //Lista de sinais
        private static IList<String> Sign = new List<String>();

        //Lista de operadores ADDOP
        private static IList<String> Addop = new List<String>();

        //Lista de Operadores RELOP
        private static IList<String> Relop = new List<String>();

        #endregion

        #region .:Metodo validadores:.

        /// <summary>
        /// Metodo que verifica se caracter é uma letra
        /// </summary>
        /// <param name="aChar">Caracter que será analisado</param>
        public static Boolean ELetra(this Char aChar)
        {
            return Char.IsLetter(aChar);
        }

        /// <summary>
        /// Metodo que verifica se caracter é um numero
        /// </summary>
        /// <param name="aChar">Caracter que será analisado</param>
        public static Boolean ENumero(this Char aChar)
        {
            return Char.IsDigit(aChar);
        }

        /// <summary>
        /// Metodo que verifica se é uma letra ou numero
        /// </summary>
        /// <param name="aChar">Caracter que será analisado</param>
        public static Boolean ELetraOuNumero(this Char aChar)
        {
            return Char.IsLetterOrDigit(aChar);
        }

        /// <summary>
        /// Metodo que verifica se caracter é um operador mulop
        /// </summary>
        /// <param name="aChar">Caracter que será analisado</param>
        public static Boolean EMulop(this Char aChar)
        {
            return ValidadoresAlfabeto.Mulop.Contains(aChar.ToString());
        }

        /// <summary>
        /// Metodo que verifica se string é uma palavra reservada
        /// </summary>
        /// <param name="aString">String que será avaliada</param>
        public static Boolean EPalavraReservada(this String aString)
        {
            return ValidadoresAlfabeto.PalavrasReservadas.ContainsKey(aString);
        }

        /// <summary>
        /// Metodo que verifica se lexame é uma palavra reservada
        /// </summary>
        /// <param name="aLexame">lexame que será avaliado</param>
        public static TiposTokens RetornaTipoPalavraReservada(String aLexame)
        {
            if(aLexame.EPalavraReservada())
                return PalavrasReservadas.Where(w => w.Key == aLexame).Select(s => s.Value).First();

            return TiposTokens.Desconhecido;
        }

        /// <summary>
        /// Metodo que verifica se Caracter é um sinal
        /// </summary>
        /// <param name="aLexame">Caracter que será analisado<</param>
        public static Boolean ESinal(this Char aChar)
        {
            return Sign.Contains(aChar.ToString());
        }

        /// <summary>
        /// Metodo que verifica se Caracter é um Fator de Escala
        /// </summary>
        /// <param name="aLexame">Caracter que será analisado<</param>
        public static Boolean EFatorEscala(this Char aChar)
        {
            return aChar == 'E';
        }

        /// <summary>
        /// Metodo que verifica se Caracter é um Fator de Escala
        /// </summary>
        /// <param name="aLexame">Caracter que será analisado<</param>
        public static Boolean EPonto(this Char aChar)
        {
            return Char.IsPunctuation(aChar);
        }

        /// <summary>
        /// Metodo que verifica se caracter é algum tipo de caracter de layout de texto
        /// Como por exemplo espaços em brancos, paragrafos e separadores de linha
        /// </summary>
        /// <param name="aChar">Caracter que será analisado</param>
        public static Boolean ECaracterLayout(this Char aChar)
        {
            return Char.IsSeparator(aChar);
        }

        /// <summary>
        /// Metodo que verifica se Caracter é um Addop
        /// </summary>
        /// <param name="aLexame">Caracter que será analisado<</param>
        public static Boolean EAddop(this Char aChar)
        {
            return Addop.Contains(aChar.ToString());
        }

        /// <summary>
        /// Metodo que verifica se Caracter é um Relop
        /// </summary>
        /// <param name="aLexame">Caracter que será analisado<</param>
        public static Boolean ERelop(this Char aChar)
        {
            return Relop.Contains(aChar.ToString());
        }

        /// <summary>
        /// Metodo que verifica se Caracter é um Relop que possui tratamento diferente
        /// </summary>
        /// <param name="aLexame">Caracter que será analisado<</param>
        public static Boolean ERelopExcessao(this Char aChar)
        {
            return Relop.Where(w => (w == ">" || w == "<")).Contains(aChar.ToString());
        }

        #endregion
    }
}
