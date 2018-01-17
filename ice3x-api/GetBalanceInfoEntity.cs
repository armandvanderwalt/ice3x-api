using System.Globalization;
using Newtonsoft.Json;

namespace ice3x_api
{
    public class GetBalanceInfoEntity
    {

        [JsonConstructor]
        public GetBalanceInfoEntity([JsonProperty("currency_id")]string currencyId, [JsonProperty("balance")]string balance, [JsonProperty("address")]string address)
        {
            CurrencyId = currencyId;
            Balance = decimal.Parse(balance, NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint,
                CultureInfo.InvariantCulture);
            Address = address;
        }

        [JsonProperty("currency_id")]
        public string CurrencyId { get; set; }

        [JsonProperty("balance")]
        public decimal Balance { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }
    }
}