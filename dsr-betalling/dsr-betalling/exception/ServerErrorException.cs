using System;

namespace dsr_betalling.exception
{
    class ServerErrorException : Exception
    {
        /// <summary>
        /// Gør så man kan lave en custom Exception, med ServerError exceptions
        /// </summary>
        public ServerErrorException()
        { }

        public ServerErrorException(string message) : base(message) { }
    }
}
