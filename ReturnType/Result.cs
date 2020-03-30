namespace ReturnType
{
    public sealed class Result<T>
    {
        public enum ResultType
        {
            Value,
            Error
        }

        public readonly IError Error;

        public readonly T Value;

        private Result(T value, IError error, ResultType successStatus)
        {
            Error = error;
            Value = value;
            State = successStatus;
        }

        public Result(T value)
        {
            Value = value;
            State = ResultType.Value;
        }

        public ResultType State { get; }

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
            return new Result<T>(value);
        }

       
    }
}