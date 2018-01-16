using Newtonsoft.Json;

namespace ice3x_api
{
    public class GetMarketDepthBtcavEntity
    {
        [JsonProperty("pair_id")]
        public string PairId { get; set; }

        [JsonProperty("vol")]
        public string Vol { get; set; }

        [JsonProperty("pair_name")]
        public string PairName { get; set; }

        [JsonProperty("last_price")]
        public string LastPrice { get; set; }

        [JsonProperty("max_bid")]
        public string MaxBid { get; set; }

        [JsonProperty("min_ask")]
        public string MinAsk { get; set; }
    }
}