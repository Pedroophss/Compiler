using System;
using System.Collections.Generic;

namespace AnalisadorLexico
{
    public interface ICompiladorLexico
    {
        /// <summary>
        /// Analisa Arquivo todo
        /// </summary>
        /// <param name="aCaminhoArquivo">Caminho do arquivo que será analisado</param>
        /// <returns>Lista de tokens</returns>
        IEnumerable<Token> AnalisaArquivo(String aCaminhoArquivo);

        /// <summary>
        /// Faz a analise lexica de uma string
        /// </summary>
        /// <param name="aComando">String que será analisada</param>
        IEnumerable<Token> AnalisaString(String aComando);
    }
}
