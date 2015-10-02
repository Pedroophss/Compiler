using System;
using System.Collections.Generic;
using System.Reflection;

namespace AnalisadorLexico.Tokens
{
    public class Desconhecido : Token
    {
        /// <summary>
        /// Construtor da Classe Desconhecido
        /// </summary>
        /// <param name="aLexame">String Lexame correspondente ao token</param>
        private Desconhecido(String aLexame) : base(aLexame) {}

        /// <summary>
        /// Propriedade Tipo da token
        /// </summary>
        public override TiposTokens Tipo
        {
            get { return TiposTokens.Desconhecido; }
            protected set { }
        }

        /// <summary>
        /// Propriedade que representa a token usada pelo analisador sintatico
        /// </summary>
        public override string Token
        {
            get { return this.Lexame; }
            protected set { }
        }

        /// <summary>
        /// Verifica se String é um Desconhecido
        /// </summary>
        /// <param name="aComando">String que será analisado</param>
        /// <param name="aPosicao">Posição atual da string</param>
        /// <returns>Retorna Desconhecido criado</returns>
        public static Desconhecido CriaDesconhecido(String aComando, ref int aPosicao)
        {
            //Lexame que será montado para o token
            String lexame = String.Empty;
            lexame += aComando[aPosicao++];

            var tokenDesconhecida = new Desconhecido(lexame);

            return tokenDesconhecida.AlteraTipo();
        }

        private Desconhecido AlteraTipo()
        {
            Type tipoDesconhecido = this.Tipo.GetType();

            FieldInfo enumDesconhecido = tipoDesconhecido.GetField("Desconhecido");

            DescricaoAttribute descricaoAtributo = enumDesconhecido.GetCustomAttribute<DescricaoAttribute>();

            descricaoAtributo.StringValue = this.Lexame;

            return this;
        }

        public override string ToString()
        {
            return String.Concat(this.Lexame, " : ", this.Lexame);
        }
    }
}
