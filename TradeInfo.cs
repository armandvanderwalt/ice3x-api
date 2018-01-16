using Newtonsoft.Json;

namespace ice3x_api
{
    public class TradeInfo
    {
        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }
    }
}