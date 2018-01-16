namespace ice3x_api
{
    public class ApiResponse<T> where T : class
    {
        public bool Errors { get; set; }
        public T Response { get; set; }
    }
}