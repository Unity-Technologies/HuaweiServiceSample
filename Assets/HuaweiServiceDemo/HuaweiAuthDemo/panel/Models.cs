namespace HuaweiAuthDemo
{
    public class Error
    {
        public ErrorClass errorClass;

        public string type;
        public string message;
    }


    public enum ErrorClass
    {
        Unknown,
        NetworkError,
        ApiError,
        UserError,
        ActionCancelled,
    }
}