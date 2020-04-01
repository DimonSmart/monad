using System;

namespace ReturnType
{
    public class Error : IError
    {
        private readonly Exception _exception;

        public Error(string message)
        {
            _exception = new LogicalException(message);
        }

        public Error(Exception exception)
        {
            _exception = exception;
        }

        public string Message => _exception?.Message;

        public Exception GetException()
        {
            return _exception;
        }
    }
}