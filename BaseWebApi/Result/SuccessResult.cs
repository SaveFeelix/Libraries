namespace BaseWebApi.Result
{
    public class SuccessResult<TResult> : BaseResult<TResult>
    {
        public SuccessResult(string? message = "", TResult? data = default) : base(false, message, data)
        {
        }
    }
    public class SuccessResult : BaseResult
    {
        public SuccessResult(string? message = "") : base(false, message)
        {
        }
    }
}
