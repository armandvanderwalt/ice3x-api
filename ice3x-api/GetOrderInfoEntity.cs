using Newtonsoft.Json;

namespace ice3x_api
{
    public class GetOrderInfoEntity
    {
        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        [JsonProperty("pair_id")]
        public string PairId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("volume")]
        public double Volume { get; set; }

        [JsonProperty("volume_start")]
        public double VolumeStart { get; set; }

        [JsonProperty("fee_percent")]
        public long FeePercent { get; set; }

        [JsonProperty("created")]
        public string Created { get; set; }
    }
}