namespace BaseWebApi.Result
{
    public class BaseResult<TResult>
    {

        public BaseResult()
        {
        }

        public BaseResult(bool error, string? message = "", TResult? data = default)
        {
            Error = error;
            Message = message;
            Data = data;
        }

        public bool Error { get; set; }
        public string? Message { get; set; }
        public TResult? Data { get; set; }
    }
    public class BaseResult : BaseResult<object>
    {
        public BaseResult() : base()
        {
        }

        public BaseResult(bool error, string? message = "") : base(error, message)
        {
        }
    }
}
