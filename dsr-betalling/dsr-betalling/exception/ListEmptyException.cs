using System;

namespace dsr_betalling.exception
{
    class ListEmptyException : Exception
    {
        /// <summary>
        /// Gør så man kan lave en custom Exception, med ListEmpty exceptions
        /// </summary>
        public ListEmptyException()
        { }

        public ListEmptyException(string message) : base(message) { }
    }
}
