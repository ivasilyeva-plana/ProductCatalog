namespace ProductCatalog.Response
{
    public class OkResult<T> : Response<T>
    {
        public OkResult(T result)
        {
            IsSuccess = true;
            ErrorMessage = string.Empty;
            Result = result;
        }
    }
}
