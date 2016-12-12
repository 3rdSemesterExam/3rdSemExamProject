using System;

namespace dsr_betalling.exception
{
    internal class HttpErrorException : Exception
    {
        /// <summary>
        ///     Enables a Custom Exception to handle HTTP errors in the Facade
        /// </summary>
        public HttpErrorException()
        {
        }

        public HttpErrorException(string message) : base(message)
        {
        }
    }
}