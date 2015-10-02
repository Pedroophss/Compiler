using System;
using System.Collections.Generic;
using AnalisadorLexico.Exceptions;
using AnalisadorLexico.FabricaTokens;

namespace AnalisadorLexico
{
    /// <summary>
    /// Classe que faz a analise lexica
    /// </summary>
    public class Lexam : ICompiladorLexico, IFuncaoLexica
    {
        #region .:Construtor:.

        /// <summary>
        /// No caso do compilador não é nescessario mais de uma instancia
        /// </summary>
        private static Lexam InstanciaCompilador { get; set; }

        /// <summary>
        /// Construtor Padrão
        /// </summary>
        private Lexam()
        {
            //Private pois será instanciado atravez dos metodos staticos
        }

        /// <summary>
        /// Cria um Compilador lexico
        /// </summary>
        /// <returns>Retorna ICompiladorLexico</returns>
        public static ICompiladorLexico CriaCompiladorLexico()
        {
            if (InstanciaCompilador == null)
            {
                Lexam.InstanciaCompilador = new Lexam();
                return Lexam.InstanciaCompilador;
            }
            else
                return InstanciaCompilador;
        }

        /// <summary>
        /// Cria um Funcao lexica
        /// </summary>
        /// <returns>Retorna IFuncaoLexica</returns>
        public static IFuncaoLexica CriaFuncaoLexica()
        {
            Lexam retorno = new Lexam();

            retorno.PonteiroLexico = 0;
            return retorno;
        }

        #endregion

        //Metodos de implementação da Interface "ICompiladorLexico"
        #region .:ICompiladorLexico:.

        /// <summary>
        /// Faz a analise lexica de um arquivo
        /// </summary>
        /// <param name="aCaminhoArquivo">Caminho do arquivo</param>
        public IEnumerable<Token> AnalisaArquivo(String aCaminhoArquivo)
        {
            List<Token> listaTokenRetorno = new List<Token>();
            IEnumerable<String> comandos = this.LerArquivo(aCaminhoArquivo);

            foreach(string item in comandos)
            {
                listaTokenRetorno.AddRange(this.AnalisaString(item));
            }

            return listaTokenRetorno;
        }

        /// <summary>
        /// Le um arquivo
        /// </summary>
        /// <param name="aCaminho">Caminho do arquivo que será lido</param>
        /// <exception cref="New Exception">Caso não seja possivel ler o arquivo</exception>
        /// <returns>IEnumerable com as linhas do arquivo</returns>
        private IEnumerable<String> LerArquivo(String aCaminho)
        {
            try 
            {
                return System.IO.File.ReadAllLines(@aCaminho);
            }
            catch(Exception e)
            {
                throw new Exception("Não foi possivel ler o arquivo no caminho especificado", e);
            }
        }

        /// <summary>
        /// Faz a analise lexica de uma string
        /// </summary>
        /// <param name="aComando">String que será analisada</param>
        /// <returns>Lista de tokens</returns>
        public IEnumerable<Token> AnalisaString(String aComando)
        {
            List<Token> listaTokensRetorno = new List<Token>();

            //Caso o comando não seja valido não é necessario a analise
            if (this.ValidaComando(aComando))
            {
                Int32 ponteiro = 0;
                var fabricaLexica = new FabricaLexica();
                
                while (ponteiro < aComando.Length)
                {
                    try
                    {
                        listaTokensRetorno.Add(fabricaLexica.CriaToken(aComando, ref ponteiro));
                    }
                    catch(FimDeLinha)
                    {
                        //caso acabe a linha apena termina o laço
                        break;
                    }
                }
            }

            return listaTokensRetorno;
        }

        /// <summary>
        /// Faz a verificação da string comando à ser avaliada
        /// </summary>
        /// <param name="aComando">Comando que Séra avaliado</param>
        /// <returns>True para valido | False para invalido</returns>
        private Boolean ValidaComando(String aComando)
        {
            Boolean comandoValido = true;

            if (String.IsNullOrEmpty(aComando))
                comandoValido = false;

            if (String.IsNullOrWhiteSpace(aComando))
                comandoValido = false;

            return comandoValido;
        }
        #endregion

        //Metodos de implementação da Interface "IFuncaoLexica"
        #region .:IFuncaoLexica:.

        /// <summary>
        /// Ponteiro que varre o arquivo ou string
        /// </summary>
        public Int32 PonteiroLexico{ get; private set; }

        /// <summary>
        /// Metodo que analisa a proxima Token
        /// </summary>
        /// <returns>Retorna uma token</returns>
        public Token RetornaProximaToken()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
