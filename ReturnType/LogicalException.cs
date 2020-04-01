using System;

namespace ReturnType
{
    public class LogicalException : Exception
    {
        public LogicalException(string message) : base(message)
        {
        }
    }
}