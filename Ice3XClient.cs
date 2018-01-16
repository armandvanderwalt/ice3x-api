using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ice3x_api
{
    public class Ice3XClient
    {
        private readonly string _privateKey;
        private readonly string _publicKey;

        public Ice3XClient(string privateKey, string publicKey)
        {
            _privateKey = privateKey;
            _publicKey = publicKey;
        }

        public void CreateNewOrder(string type, long pairId, decimal amount, decimal price)
        {

        }

        public void CancelOrder(long tradeId)
        {

        }

        public void GetPrivateTradeList()
        {

        }

        public void GetPrivateTradeInfo(long tradeId)
        {

        }

        public void GetBalanceList()
        {

        }

        public void GetBalanceInfo(long currencyId)
        {

        }

        public void GetTransactionList(long currencyId)
        {

        }

        public void GetTransactionInfo(long transactionId)
        {

        }

        public async Task<ApiPagingResponse<GetOrderListResponse>> GetOrderList()
        {
            var stringResult = await ExecutePostAsync("order/list");
            var result = JsonConvert.DeserializeObject<ApiPagingResponse<GetOrderListResponse>>(stringResult);
            return result;
        }

        public async Task<ApiPagingResponse<GetOrderInfoResponse>> GetOrderInfo(string orderId)
        {
            var stringResult = await ExecutePostAsync("order/info", new Dictionary<string, object>
            {
                ["order_id"] = orderId
            });
            var result = JsonConvert.DeserializeObject<ApiPagingResponse<GetOrderInfoResponse>>(stringResult);
            return result;
        }

        public async Task<ApiPagingResponse<GetMarketDepthFullResponse>> GetMarketDepthFull()
        {
            var stringResult = await ExecuteGetAsync("stats/marketdepthfull");
            var result = JsonConvert.DeserializeObject<ApiPagingResponse<GetMarketDepthFullResponse>>(stringResult);
            return result;
        }

        public async Task<ApiPagingResponse<GetMarketDepthBtcavResponse>> GetMarketDepthBtcav()
        {
            var stringResult = await ExecuteGetAsync("stats/marketdepthbtcav");
            var result = JsonConvert.DeserializeObject<ApiPagingResponse<GetMarketDepthBtcavResponse>>(stringResult);
            return result;
        }

        public async Task<ApiResponse<GetOrderbookInfoResponse>> GetOrderbookInfo(string pairId)
        {
            var stringResult = await ExecuteGetAsync("orderbook/info", new Dictionary<string, object>
            {
                ["pair_id"] = pairId
            });
            var result = JsonConvert.DeserializeObject<ApiResponse<GetOrderbookInfoResponse>>(stringResult);
            return result;
        }

        public async Task<ApiPagingResponse<GetCurrencyListResponse>> GetCurrencyList()
        {
            var stringResult = await ExecuteGetAsync("currency/list");
            var result = JsonConvert.DeserializeObject<ApiPagingResponse<GetCurrencyListResponse>>(stringResult);
            return result;
        }

        public async Task<ApiResponse<GetPairListResponse>> GetPairList()
        {
            var stringResult = await ExecuteGetAsync("pair/list");
            var result = JsonConvert.DeserializeObject<ApiResponse<GetPairListResponse>>(stringResult);
            return result;
        }

        public async Task<ApiResponse<GetPairInfoResponse>> GetPairInfo(string pairId)
        {
            var stringResult = await ExecuteGetAsync("pair/info", new Dictionary<string, object>
            {
                ["pair_id"] = pairId
            });
            var result = JsonConvert.DeserializeObject<ApiResponse<GetPairInfoResponse>>(stringResult);
            return result;
        }
        
        public async Task<ApiPagingResponse<GetPublicTradeListResponse>> GetPublicTradeList()
        {
            var stringResult = await ExecuteGetAsync("trade/list");
            var result = JsonConvert.DeserializeObject<ApiPagingResponse<GetPublicTradeListResponse>>(stringResult);
            return result;
        }

        public async Task<ApiResponse<GetPublicTradeInfoResponse>> GetPublicTradeInfo(string tradeId)
        {
            var stringResult = await ExecuteGetAsync("trade/info", new Dictionary<string, object>
            {
                ["trade_id"] = tradeId
            });
            var result = JsonConvert.DeserializeObject<ApiResponse<GetPublicTradeInfoResponse>>(stringResult);
            return result;
        }

        private async Task<string> ExecuteGetAsync(string path, Dictionary<string, object> paramaters = null)
        {
            var url = ConfigurationManager.AppSettings["Ice3XUrl"];

            if (paramaters != null)
            {
                var queryString = QueryStringBuilder.BuildQueryString(paramaters);
                path = $"{path}?{queryString}";
            }

            using (var client = new WebClient())
            {
                var result = await client.DownloadStringTaskAsync(new Uri($"{url}{path}"));
                return result;
            }
        }

        private async Task<string> ExecutePostAsync(string path, Dictionary<string, object> paramaters = null)
        {
            var url = ConfigurationManager.AppSettings["Ice3XUrl"];

            var queryString = string.Empty;

            if (paramaters != null)
            {
                queryString = JsonConvert.SerializeObject(paramaters);
            }

            using (var client = new WebClient())
            {
                // Get the Unix time
                var timeStamp = this.UnixTimeNow();
                var uri = new Uri(string.Format($"{url}{path}"));

                // Create the signature
                var signature = SignMessage(queryString);

                client.Headers.Add("accept-charset", "utf-8");
                client.Headers.Add("sign", signature);
                client.Headers.Add("key", _publicKey);
                client.Headers.Add("timestamp", timeStamp.ToString());

                var result = await client.UploadDataTaskAsync(uri, "POST", Encoding.UTF8.GetBytes(queryString));

                var stringResult = Encoding.UTF8.GetString(result);

                return stringResult;
            }
        }
        private long UnixTimeNow()
        {
            var timeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            return (long)timeSpan.TotalMilliseconds;
        }
        private string SignMessage(string message)
        {
            var keyByte = Encoding.UTF8.GetBytes(_privateKey);
            using (var hmacsha256 = new HMACSHA512(keyByte))
            {
                hmacsha256.ComputeHash(Encoding.UTF8.GetBytes(message));
                return BitConverter.ToString(hmacsha256.Hash).Replace("-", "").ToLower();
            }
        }
    }

    public class GetOrderInfoResponse
    {
    }

    public class GetOrderListResponse
    {
        public List<GetOrderListEntity> Entities { get; set; }
    }

    public class GetOrderListEntity
    {
        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        [JsonProperty("pair_id")]
        public string PairId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }

        [JsonProperty("volume")]
        public double Volume { get; set; }

        [JsonProperty("fee_percent")]
        public long FeePercent { get; set; }

        [JsonProperty("created")]
        public string Created { get; set; }
    }
}