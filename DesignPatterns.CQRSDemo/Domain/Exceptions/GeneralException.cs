using System;

namespace DesignPatterns.CQRSDemo.Domain.Exceptions
{
    public class GeneralException : Exception
    {
        public GeneralException()
        { }

        public GeneralException(string message) : base(message)
        { }

        public GeneralException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
