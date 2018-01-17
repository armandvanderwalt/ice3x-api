using System.Threading.Tasks;

namespace ice3x_api
{
    public interface IIce3XClient
    {
        Task<ApiResponse<CancelOrderResponse>> CancelOrderAsync(string tradeId);
        Task<ApiPagingResponse<CreateNewOrderResponse>> CreateNewOrderAsync(string type, string pairId, decimal amount, decimal price);
        Task<ApiResponse<GetBalanceInfoResponse>> GetBalanceInfoAsync(string currencyId);
        Task<ApiPagingResponse<GetBalanceListResponse>> GetBalanceListAsync();
        Task<ApiPagingResponse<GetCurrencyListResponse>> GetCurrencyListAsync();
        Task<ApiPagingResponse<GetMarketDepthBtcavResponse>> GetMarketDepthBtcavAsync();
        Task<ApiPagingResponse<GetMarketDepthFullResponse>> GetMarketDepthFullAsync();
        Task<ApiResponse<GetOrderbookInfoResponse>> GetOrderbookInfoAsync(string pairId);
        Task<ApiResponse<GetOrderInfoResponse>> GetOrderInfoAsync(string orderId);
        Task<ApiPagingResponse<GetOrderListResponse>> GetOrderListAsync();
        Task<ApiResponse<GetPairInfoResponse>> GetPairInfoAsync(string pairId);
        Task<ApiResponse<GetPairListResponse>> GetPairListAsync();
        Task<ApiResponse<GetPublicTradeInfoResponse>> GetPrivateTradeInfoAsync(string tradeId);
        Task<ApiPagingResponse<GetTradeListResponse>> GetPrivateTradeListAsync();
        Task<ApiResponse<GetPublicTradeInfoResponse>> GetPublicTradeInfoAsync(string tradeId);
        Task<ApiPagingResponse<GetTradeListResponse>> GetPublicTradeListAsync();
        Task<ApiResponse<GetTransactionInfoResponse>> GetTransactionInfoAsync(string transactionId);
        Task<ApiPagingResponse<GetTransactionListResponse>> GetTransactionListAsync(string currencyId);
    }
}