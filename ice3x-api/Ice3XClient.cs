using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ice3x_api
{
    public class Ice3XClient : IIce3XClient
    {
        private readonly string _privateKey;
        private readonly string _publicKey;

        public Ice3XClient(string privateKey, string publicKey)
        {
            _privateKey = privateKey;
            _publicKey = publicKey;
        }

        public async Task<ApiPagingResponse<CreateNewOrderResponse>> CreateNewOrderAsync(string type, string pairId, decimal amount, decimal price)
        {
            var stringResult = await ExecutePostAsync("order/new", new Dictionary<string, string>
            {
                ["type"] = type,
                ["pair_id"] = pairId,
                ["amount"] = amount.ToString(CultureInfo.InvariantCulture),
                ["price"] = price.ToString(CultureInfo.InvariantCulture)
            });
            var result = JsonConvert.DeserializeObject<ApiPagingResponse<CreateNewOrderResponse>>(stringResult);
            return result;
        }

        public async Task<ApiResponse<CancelOrderResponse>> CancelOrderAsync(string tradeId)
        {
            var stringResult = await ExecutePostAsync("order/cancel", new Dictionary<string, string>
            {
                ["order_id"] = tradeId
            });
            var result = JsonConvert.DeserializeObject<ApiResponse<CancelOrderResponse>>(stringResult);
            return result;
        }

        public async Task<ApiPagingResponse<GetTradeListResponse>> GetPrivateTradeListAsync()
        {
            var stringResult = await ExecutePostAsync("trade/list");
            var result = JsonConvert.DeserializeObject<ApiPagingResponse<GetTradeListResponse>>(stringResult);
            return result;
        }

        public async Task<ApiResponse<GetPublicTradeInfoResponse>> GetPrivateTradeInfoAsync(string tradeId)
        {
            var stringResult = await ExecutePostAsync("trade/info", new Dictionary<string, string>
            {
                ["trade_id"] = tradeId
            });
            var result = JsonConvert.DeserializeObject<ApiResponse<GetPublicTradeInfoResponse>>(stringResult);
            return result;
        }

        public async Task<ApiPagingResponse<GetBalanceListResponse>> GetBalanceListAsync()
        {
            var stringResult = await ExecutePostAsync("balance/list");
            var result = JsonConvert.DeserializeObject<ApiPagingResponse<GetBalanceListResponse>>(stringResult);
            return result;
        }

        public async Task<ApiResponse<GetBalanceInfoResponse>> GetBalanceInfoAsync(string currencyId)
        {
            var stringResult = await ExecutePostAsync("balance/info", new Dictionary<string, string>
            {
                ["currency_id"] = currencyId
            });
            var result = JsonConvert.DeserializeObject<ApiResponse<GetBalanceInfoResponse>>(stringResult);
            return result;
        }

        public async Task<ApiPagingResponse<GetTransactionListResponse>> GetTransactionListAsync(string currencyId)
        {
            var stringResult = await ExecutePostAsync("transaction/list", new Dictionary<string, string>
            {
                ["currency_id"] = currencyId
            });
            var result = JsonConvert.DeserializeObject<ApiPagingResponse<GetTransactionListResponse>>(stringResult);
            return result;
        }

        public async Task<ApiResponse<GetTransactionInfoResponse>> GetTransactionInfoAsync(string transactionId)
        {
            var stringResult = await ExecutePostAsync("transaction/info", new Dictionary<string, string>
            {
                ["transaction_id"] = transactionId
            });
            var result = JsonConvert.DeserializeObject<ApiResponse<GetTransactionInfoResponse>>(stringResult);
            return result;
        }

        public async Task<ApiPagingResponse<GetOrderListResponse>> GetOrderListAsync()
        {
            var stringResult = await ExecutePostAsync("order/list");
            var result = JsonConvert.DeserializeObject<ApiPagingResponse<GetOrderListResponse>>(stringResult);
            return result;
        }

        public async Task<ApiResponse<GetOrderInfoResponse>> GetOrderInfoAsync(string orderId)
        {
            var stringResult = await ExecutePostAsync("order/info", new Dictionary<string, string>
            {
                ["order_id"] = orderId
            });
            var result = JsonConvert.DeserializeObject<ApiPagingResponse<GetOrderInfoResponse>>(stringResult);
            return result;
        }

        public async Task<ApiPagingResponse<GetMarketDepthFullResponse>> GetMarketDepthFullAsync()
        {
            var stringResult = await ExecuteGetAsync("stats/marketdepthfull");
            var result = JsonConvert.DeserializeObject<ApiPagingResponse<GetMarketDepthFullResponse>>(stringResult);
            return result;
        }

        public async Task<ApiPagingResponse<GetMarketDepthBtcavResponse>> GetMarketDepthBtcavAsync()
        {
            var stringResult = await ExecuteGetAsync("stats/marketdepthbtcav");
            var result = JsonConvert.DeserializeObject<ApiPagingResponse<GetMarketDepthBtcavResponse>>(stringResult);
            return result;
        }

        public async Task<ApiResponse<GetOrderbookInfoResponse>> GetOrderbookInfoAsync(string pairId)
        {
            var stringResult = await ExecuteGetAsync("orderbook/info", new Dictionary<string, object>
            {
                ["pair_id"] = pairId
            });
            var result = JsonConvert.DeserializeObject<ApiResponse<GetOrderbookInfoResponse>>(stringResult);
            return result;
        }

        public async Task<ApiPagingResponse<GetCurrencyListResponse>> GetCurrencyListAsync()
        {
            var stringResult = await ExecuteGetAsync("currency/list");
            var result = JsonConvert.DeserializeObject<ApiPagingResponse<GetCurrencyListResponse>>(stringResult);
            return result;
        }

        public async Task<ApiResponse<GetPairListResponse>> GetPairListAsync()
        {
            var stringResult = await ExecuteGetAsync("pair/list");
            var result = JsonConvert.DeserializeObject<ApiResponse<GetPairListResponse>>(stringResult);
            return result;
        }

        public async Task<ApiResponse<GetPairInfoResponse>> GetPairInfoAsync(string pairId)
        {
            var stringResult = await ExecuteGetAsync("pair/info", new Dictionary<string, object>
            {
                ["pair_id"] = pairId
            });
            var result = JsonConvert.DeserializeObject<ApiResponse<GetPairInfoResponse>>(stringResult);
            return result;
        }
        
        public async Task<ApiPagingResponse<GetTradeListResponse>> GetPublicTradeListAsync()
        {
            var stringResult = await ExecuteGetAsync("trade/list");
            var result = JsonConvert.DeserializeObject<ApiPagingResponse<GetTradeListResponse>>(stringResult);
            return result;
        }

        public async Task<ApiResponse<GetPublicTradeInfoResponse>> GetPublicTradeInfoAsync(string tradeId)
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

        private async Task<string> ExecutePostAsync(string path, Dictionary<string, string> paramaters = null)
        {
            var url = ConfigurationManager.AppSettings["Ice3XUrl"];

            var queryString = string.Empty;
            var keyValueParams = new List<KeyValuePair<string, string>>();

            if (paramaters != null)
            {
                queryString = QueryStringBuilder.BuildQueryString(paramaters);

                foreach (var paramatersKey in paramaters.Keys)
                {
                    keyValueParams.Add(new KeyValuePair<string, string>(paramatersKey, paramaters[paramatersKey]));
                }
            }

            var httpClient = new HttpClient();

            var timeStamp = UnixTimeNow();
            var uri = new Uri(string.Format($"{url}{path}"));
            var signature = SignMessage(queryString);
            
            var requestContent = new FormUrlEncodedContent(keyValueParams);

            var request = new HttpRequestMessage()
            {
                RequestUri = uri,
                Method = HttpMethod.Post,
                Content = requestContent
            };

            request.Headers.Add("accept-charset", "utf-8");
            request.Headers.Add("sign", signature);
            request.Headers.Add("key", _publicKey);
            request.Headers.Add("timestamp", timeStamp.ToString());
            
            var response = await httpClient.SendAsync(request);
            
            var responseContent = response.Content;
            
            using (var reader = new StreamReader(await responseContent.ReadAsStreamAsync()))
            {
                return await reader.ReadToEndAsync();
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
}