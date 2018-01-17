using Newtonsoft.Json;

namespace ice3x_api
{
    public class GetOrderbookInfoResponse
    {
        [JsonProperty("entities")]
        public GetOrderbookInfoEntitiy Entity { get; set; }
    }
}