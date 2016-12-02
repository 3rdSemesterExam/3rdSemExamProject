using System;

namespace dsr_betalling.exception
{
    class HttpErrorException : Exception
    {
        /// <summary>
        /// Gør så man kan lave en custom Exception, med http exceptions
        /// </summary>
        public HttpErrorException()
        {}

        public HttpErrorException(string message) : base(message){}
    }
}
