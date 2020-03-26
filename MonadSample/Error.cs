using System;

namespace MonadSample
{
    public class Error : IError
    {
        private readonly Exception _exception;

        public Error(Exception exception)
        {
            _exception = exception;
        }

        public string Message => _exception.Message;
    }
}