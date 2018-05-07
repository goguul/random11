using System;

namespace Random11.Exceptions
{
    public class CreditNotAvailableException : Exception
    {
        public CreditNotAvailableException(string message) : base(message)
        {

        }
    }
}
