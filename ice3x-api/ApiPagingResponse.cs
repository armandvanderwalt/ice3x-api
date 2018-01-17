namespace ice3x_api
{
    public class ApiPagingResponse<T> : ApiResponse<T> where T : class
    {
        public Pagination Pagination { get; set; }
    }
}