using Newtonsoft.Json;

namespace ice3x_api
{
    public class GetTransactionListEntity
    {
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("currency_id")]
        public string CurrencyId { get; set; }

        [JsonProperty("invoice_id")]
        public string InvoiceId { get; set; }

        [JsonProperty("volume")]
        public string Volume { get; set; }

        [JsonProperty("system_commission")]
        public decimal SystemCommission { get; set; }

        [JsonProperty("created")]
        public string Created { get; set; }
    }
}