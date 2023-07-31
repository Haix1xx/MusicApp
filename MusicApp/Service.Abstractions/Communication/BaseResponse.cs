namespace MusicApp.Service.Abstractions.Communication
{
    public class BaseResponse
    {
        public bool IsSuccess { get; set; }
        public string? Error { get; set; }
        public BaseResponse(bool isSuccess, string? error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public BaseResponse(bool isSuccess) : this(isSuccess, null)  { }
        public BaseResponse(string message) : this(false, message) { }
    }
}
