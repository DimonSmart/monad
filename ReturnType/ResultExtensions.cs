using System;

namespace ReturnType
{
    public static class ResultExtensions
    {
        public static Result<T2> Bind<T1, T2>(this Result<T1> value, Func<T1, Result<T2>> onSuccess)
        {
            if (value.State == ResultBase.ResultType.Error) return Result<T2>.FromError(value.Error);
            try
            {
                return onSuccess(value.Value);
            }
            catch (Exception exception)
            {
                return Result<T2>.FromError(new Error(exception));
            }
        }

        public static Result<T2> WrapAndBind<T1, T2>(this T1 value, Func<T1, Result<T2>> onSuccess)
        {
            return value.Wrap().Bind(onSuccess);
        }

        public static Result<T> Wrap<T>(this T value)
        {
            return value;
        }
    }
}