using System;

namespace AnalisadorLexico.Exceptions
{
    /// <summary>
    /// Exception que representa o fim do comando
    /// </summary>
    public class FimDeLinha : Exception
    {
        private const String MessageException = "Fim de Linha Encontrado";

        public FimDeLinha()
            : base(MessageException) { }

        public FimDeLinha(Exception aInnerException)
            : base(MessageException, aInnerException) { }
    }
}
