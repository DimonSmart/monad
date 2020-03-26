using System;

namespace MonadSample
{
    public static class ResultExtensions
    {
        public static Result<T2> Bind<T1, T2>(this Result<T1> value, Func<T1, Result<T2>> onSuccess)
        {
            if (value.State == Result<T1>.ValueType.Error) return Result<T2>.FromError(value.Error);

            try
            {
                return onSuccess(value.Value);
            }
            catch (Exception exception)
            {
                return Result<T2>.FromError(new Error(exception));
            }
        }

        public static Result<T> ToResult<T>(this T value)
        {
            return new Result<T>(value);
        }
    }
}