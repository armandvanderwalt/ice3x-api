using System.Collections.Generic;
using Newtonsoft.Json;

namespace ice3x_api
{
    public class ApiResponse<T> where T : class
    {
        [JsonConverter(typeof(ErrorConverter<Dictionary<string, string>>))]
        public Dictionary<string, string> Errors { get; set; }

        [JsonConverter(typeof(ResponseConverter))]
        public T Response { get; set; }
    }
}