using System;
using AnalisadorLexico.Exceptions;
using AnalisadorLexico.Tokens;

namespace AnalisadorLexico.FabricaTokens
{
    public class FabricaLexica : FabricaBase<Token, String, Int32>
    {
        /// <summary>
        /// Metodo que fornece acesso ao Criar 
        /// </summary>
        public Token CriaToken(String aComando, ref Int32 aPonteiro)
        {
            this.UltimoToken = this.Criar(aComando, ref aPonteiro);
            return UltimoToken;
        }

        /// <summary>
        /// Metodo que analisa apenas uma token por vez
        /// </summary>
        /// <param name="aComando">o comando que sera analisado</param>
        /// <param name="aUltimaToken">ultima token gerada caso nao exita null</param>
        /// <param name="aPonteiro">ponteiro de navegação do comando</param>
        /// <returns>retorna uma token</returns>
        protected override Token Criar(string aParametro, ref int aPonteiro)
        {
            if (aPonteiro == aParametro.Length)
                throw new FimDeLinha();

            //Trata espaços em branco e quebra de linha
            if(aParametro[aPonteiro].ECaracterLayout())
            {
                aPonteiro++;
                return Criar(aParametro, ref aPonteiro);
            }

            //Cria Identificador
            if (aParametro[aPonteiro].ELetra())
            {
                Token token = Identificador.CriaIdentificador(aParametro, ref aPonteiro);

                //O Identificador pode ser uma palavra reservada
                if (token.Lexame.EPalavraReservada())
                    token = PalavraReservada.CriaPalavraReservada(token.Lexame);

                return token;
            }

            //Cria Constante
            if(aParametro[aPonteiro].ENumero() || aParametro[aPonteiro].ESinal())
                return Constante.CriaConstante(aParametro, ref aPonteiro);
            
            //Cria Mulop
            if(aParametro[aPonteiro].EMulop())
                return Mulop.CriaMulop(aParametro, ref aPonteiro);

            //Cria Addop
            if(aParametro[aPonteiro].EAddop())
                return Addop.CriaAddop(aParametro, ref aPonteiro);

            //Cria Relop
            if (aParametro[aPonteiro].ERelop())
                return Relop.CriaRelop(aParametro, ref aPonteiro);

            //Cria Desconhecido
            return Desconhecido.CriaDesconhecido(aParametro, ref aPonteiro);
        }

        //Existem casos que e nescessario o ultimo token gerado
        public Token UltimoToken 
        { 
            get { return this.ProdutoCriado; }
            protected set { this.ProdutoCriado = value; }
        }
    }
}
