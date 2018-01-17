using Newtonsoft.Json;

namespace ice3x_api
{
    public class GetPairListEntity
    {
        [JsonProperty("pair_id")]
        public string PairId { get; set; }

        [JsonProperty("currency_id_from")]
        public string CurrencyIdFrom { get; set; }

        [JsonProperty("currency_id_to")]
        public string CurrencyIdTo { get; set; }
    }
}