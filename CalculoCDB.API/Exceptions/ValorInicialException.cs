using System;

namespace CalculoCDB.API.Exceptions
{
    public class ValorInicialException : Exception
    {
        public ValorInicialException()
        {
        }

        public ValorInicialException(string message) : base("O valor inicial deve ser maior que zero")
        {
        }
    }
}