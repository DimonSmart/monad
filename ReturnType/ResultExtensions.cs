using System;

namespace ReturnType
{
    public static class ResultExtensions
    {
        public static Result<T2> Bind<T1, T2>(this Result<T1> value, Func<T1, Result<T2>> onSuccess)
        {
            if (value.State == Result<T1>.ResultType.Error) return Result<T2>.FromError(value.Error);

            try
            {
                return onSuccess(value.Value);
            }
            catch (Exception exception)
            {
                return Result<T2>.FromError(new ExceptionBasedError(exception));
            }
        }

        public static Result<T> WrapValue<T>(this T value)
        {
            return new Result<T>(value);
        }
    }
}