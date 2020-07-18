namespace ProductCatalog.Response
{
    public class ErrorResult : Response<string>
    {
        public ErrorResult(string message)
        {
            IsSuccess = false;
            ErrorMessage = message;
            Result = null;
        }
    }
}
