using System.Collections.Generic;
using Newtonsoft.Json;

namespace ice3x_api
{
    public class GetOrderbookInfoEntitiy
    {
        [JsonProperty("asks")]
        public List<TradeInfo> Asks { get; set; }

        [JsonProperty("bids")]
        public List<TradeInfo> Bids { get; set; }
    }
}