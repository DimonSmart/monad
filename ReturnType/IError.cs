using System;

namespace ReturnType
{
    public interface IError
    {
        string Message { get; }

        Exception GetException();
    }
}