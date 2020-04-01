namespace ReturnType
{
    public sealed class Result<T> : ResultBase
    {
        public readonly IError Error;
        public readonly T Value;

        private Result(T value, IError error, ResultType successStatus)
        {
            Error = error;
            Value = value;
            State = successStatus;
        }

        public ResultType State { get; }

        public override string ToString()
        {
            return ExtractValue(this).ToString();
        }

        public static Result<T> FromError(IError error)
        {
            return new Result<T>(default, error, ResultType.Error);
        }

        public static Result<T> FromSuccess(T value)
        {
            return new Result<T>(value, null, ResultType.Value);
        }

        public static implicit operator Result<T>(T value)
        {
            return new Result<T>(value, null, ResultType.Value);
        }

        public static implicit operator T(Result<T> value)
        {
            return ExtractValue(value);
        }

        private static T ExtractValue(Result<T> value)
        {
            if (value.State == ResultType.Error) throw value.Error.GetException();
            return value.Value;
        }
    }
}