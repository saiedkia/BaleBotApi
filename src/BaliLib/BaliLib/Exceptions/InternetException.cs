using System;

namespace BaleLib.Exceptions
{
    public class InternetException : Exception
    {
        public InternetException()
        {

        }

        public InternetException(string message) : base(message)
        {
        }
    }
}
