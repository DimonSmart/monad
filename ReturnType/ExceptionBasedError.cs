using System;

namespace ReturnType
{
    public class Error : IError
    {
        public Error(string message, string errorCode)
        {
            Message = message;
            ErrorCode = errorCode;
        }

        public string Message { get; }
        public string ErrorCode { get; }
        public object ErrorModel { get; }
    }




    public class ExceptionBasedError : IError
    {
        private readonly Exception _exception;

        public ExceptionBasedError(Exception exception)
        {
            _exception = exception;
        }

        public string Message => _exception.Message;
        public string ErrorCode => _exception.HResult.ToString();
        object IError.ErrorModel => this;
    }
}