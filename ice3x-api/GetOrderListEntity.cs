using Newtonsoft.Json;

namespace ice3x_api
{
    public class GetOrderListEntity
    {
        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        [JsonProperty("pair_id")]
        public string PairId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }

        [JsonProperty("volume")]
        public double Volume { get; set; }

        [JsonProperty("fee_percent")]
        public long FeePercent { get; set; }

        [JsonProperty("created")]
        public string Created { get; set; }
    }
}