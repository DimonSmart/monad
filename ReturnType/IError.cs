namespace ReturnType
{
    public interface IError
    {
        string ErrorCode { get; }

        string Message { get; }

        object ErrorModel { get; }
    }
}