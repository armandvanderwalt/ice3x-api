using Newtonsoft.Json;

namespace ice3x_api
{
    public class CreateNewOrderEntity
    {
        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }
    }
}