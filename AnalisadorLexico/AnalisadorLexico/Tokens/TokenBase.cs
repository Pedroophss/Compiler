using System;

namespace AnalisadorLexico
{
    /// <summary>
    /// Classe base das Tokens
    /// </summary>
    public abstract class Token
    {
        /// <summary>
        /// Propriedade que representa o tipo da token facilitando a analise sintatica
        /// </summary>
        public abstract TiposTokens Tipo { get; protected set; }

        /// <summary>
        /// Propriedade que representa a token usada pelo analisador sintatico
        /// </summary>
        public virtual String Token
        {
            get { return this.Tipo.GetStringValue(); }
            protected set;
        }

        /// <summary>
        /// Propriedade que representa o lexame gerador da token
        /// </summary>
        public String Lexame { get; set; }

        /// <summary>
        /// Construtor dos tokens
        /// </summary>
        /// <param name="aLexame">lexame do token</param>
        public Token(String aLexame)
        {
            this.Lexame = aLexame;
        }

        public override string ToString()
        {
            return String.Concat(this.Tipo.GetStringValue(), " : ", this.Lexame);
        }
    }
}
