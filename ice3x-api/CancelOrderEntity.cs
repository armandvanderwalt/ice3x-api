using Newtonsoft.Json;

namespace ice3x_api
{
    public class CancelOrderEntity
    {
        [JsonProperty("transaction_id")]
        public long TransactionId { get; set; }
    }
}