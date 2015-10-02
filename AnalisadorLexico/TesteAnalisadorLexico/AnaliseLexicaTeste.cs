using System;
using System.Diagnostics;
using AnalisadorLexico;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnvDTE;
using EnvDTE80;
using System.Collections.Generic;


namespace TesteAnalisadorLexico
{
    [TestClass]
    public class AnaliseLexicaTeste
    {
        [TestMethod]
        public void TesteAnaliseLexicaFuncao()
        {
            //String comando = "* / teste123 teste div or sin cos 12. +12312E 123.45E-56 < > <> >= <= ++ - @# 12345.456123";
            String comando = "@ # $";

            ICompiladorLexico lexico = Lexam.CriaCompiladorLexico();           
            IEnumerable<Token> retorno = lexico.AnalisaString(comando);

            LimpaDebugConsole();

            #region .:Imprimi Tokens:.
            Debug.WriteLine("|------------ Analise Lexica ------------|");

            foreach (var item in retorno)
            {
                Debug.Write("-> ");
                Debug.Write(item.Tipo.GetStringValue());
                Debug.Write(" : ");
                Debug.WriteLine(item.Lexame);
            }

            Debug.WriteLine("|------------------FIM----------------|");
            #endregion
        }

        private void LimpaDebugConsole()
        {
            //Cria objeto IDE
            DTE2 ide = (DTE2)System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE.12.0");

            //Limpa DebugConsole
            ide.ToolWindows.OutputWindow.OutputWindowPanes.Item("Debug").Clear();
        }

        [TestMethod]
        public void TesteAnaliseLexicaArquivo()
        {
            var lexico = Lexam.CriaCompiladorLexico();
            String caminho = @"C:\teste.txt";

            var retorno = lexico.AnalisaArquivo(caminho);
        }
    }
}
