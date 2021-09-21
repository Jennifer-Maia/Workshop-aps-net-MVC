using System;

namespace SalesWebMvc.Services.Exceptions
{
    public class IntegrityException : ApplicationException
    {
        public IntegrityException(string message) : base(message) //Construtor pra erros de integridade referencial
        {
        }
    }
}
