using Newtonsoft.Json;

namespace ice3x_api
{
    public class GetCurrencyListEntity
    {
        [JsonProperty("iso")]
        public string Iso { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("currency_id")]
        public string CurrencyId { get; set; }
    }
}