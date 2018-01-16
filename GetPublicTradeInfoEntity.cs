using Newtonsoft.Json;

namespace ice3x_api
{
    public class GetPublicTradeInfoEntity
    {
        [JsonProperty("trade_id")]
        public string TradeId { get; set; }

        [JsonProperty("pair_id")]
        public string PairId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("volume")]
        public double Volume { get; set; }

        [JsonProperty("created")]
        public string Created { get; set; }
    }
}