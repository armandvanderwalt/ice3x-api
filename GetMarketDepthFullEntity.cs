using Newtonsoft.Json;

namespace ice3x_api
{
    public class GetMarketDepthFullEntity
    {
        [JsonProperty("pair_id")]
        public string PairId { get; set; }

        [JsonProperty("min")]
        public string Min { get; set; }

        [JsonProperty("max")]
        public string Max { get; set; }

        [JsonProperty("avg")]
        public string Avg { get; set; }

        [JsonProperty("vol")]
        public string Vol { get; set; }

        [JsonProperty("pair_name")]
        public string PairName { get; set; }

        [JsonProperty("last_price")]
        public string LastPrice { get; set; }
    }
}