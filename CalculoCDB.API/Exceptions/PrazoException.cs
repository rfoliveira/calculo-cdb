using System;

namespace CalculoCDB.API.Exceptions
{
    public class PrazoException: Exception
    {
        public PrazoException() { }

        public PrazoException(string message) : base("O prazo deve ser maior que 1 mês")
        {
        }
    }
}