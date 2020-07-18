namespace ProductCatalog.Response
{
    public class Response<T>
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public T Result { get; set; }
    }
}
