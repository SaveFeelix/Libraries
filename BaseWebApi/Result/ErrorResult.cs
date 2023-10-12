namespace BaseWebApi.Result
{
    public class ErrorResult : BaseResult
    {
        public ErrorResult(string? message = "") : base(true, message)
        {
        }
    }
}
