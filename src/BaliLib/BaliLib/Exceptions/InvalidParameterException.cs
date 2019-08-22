using System;

namespace BaleLib.Exceptions
{
    public class InvalidParameterException : Exception
    {
        public InvalidParameterException()
        {

        }

        public InvalidParameterException(string message) : base(message)
        {
        }
    }
}
