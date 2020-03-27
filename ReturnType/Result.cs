namespace ReturnType
{
    public sealed class Result<T>
    {
        public enum ValueType
        {
            Value,
            Error
        }

        public readonly IError Error;

        public readonly T Value;

        private Result(T value, IError error, ValueType successStatus)
        {
            Error = error;
            Value = value;
        }

        public Result(T value)
        {
            Value = value;
            State = ValueType.Value;
        }

        public ValueType State { get; }

        public static Result<T> FromError(IError error)
        {
            return new Result<T>(default, error, ValueType.Error);
        }

        public static Result<T> FromSuccess(T value)
        {
            return new Result<T>(value, null, ValueType.Value);
        }

        public static implicit operator Result<T>(T value)
        {
            return new Result<T>(value);
        }
    }
}