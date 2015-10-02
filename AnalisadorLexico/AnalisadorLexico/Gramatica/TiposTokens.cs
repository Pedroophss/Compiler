using System;
using System.Reflection;

namespace AnalisadorLexico
{
    /// <summary>
    /// Enumerador dos tipos de tokens
    /// </summary>
    public enum TiposTokens
    {
        [Descricao("Identificador")]
        Identificador = 1,

        [Descricao("Constante")]
        Constante = 2,

        [Descricao("Desconhecido")]
        Desconhecido = 3,

        [Descricao("MULOP")]
        Mulop = 4,

        [Descricao("ADDOP")]
        Addop = 5,

        [Descricao("Seno")]
        Sin = 6,

        [Descricao("Cosseno")]
        Cos = 7,

        [Descricao("Logaritmo")]
        Log = 8,

        [Descricao("RELOP")]
        Relop = 9
    }

    /// <summary>
    /// Classe atributo string do enumerador
    /// </summary>
    public class DescricaoAttribute : Attribute
    {
        //Propriedade recebe o valor string
        public string StringValue { get; set; }

        public DescricaoAttribute(string value)
        {
            StringValue = value;
        }
    }

    /// <summary>
    /// Classe que guarda os metodos dos enumeradores
    /// </summary>
    public static class EnumExtensao
    {
        /// <summary>
        /// Metodo de extensão para "imprimir" um enum
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetStringValue(this Enum value)
        {
            //Busca Tipo
            var tipo = value.GetType();

            //Busca informações do campo deste tipo
            FieldInfo campoInfo = tipo.GetField(value.ToString());

            //Busca todos os atributos deste campo
            var atributos = campoInfo.GetCustomAttributes(typeof(DescricaoAttribute), false) as DescricaoAttribute[];

            //Analisa se existe atributos
            var stringvalue = atributos != null && atributos.Length > 0
                              ? atributos[0].StringValue 
                              : value.ToString();

            return stringvalue;
        }
    }
}
