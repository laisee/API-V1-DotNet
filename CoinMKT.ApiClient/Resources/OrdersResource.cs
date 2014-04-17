namespace CoinMKT.ApiClient.Resources
{
    using CoinMKT.ApiClient.Responses;
    using CoinMKT.ApiClient.Types;

    public class OrdersResource : ProtectedResourceBase
    {
        public OrdersResource(ISessionTokenHolder sessionTokenHolder)
            : base(sessionTokenHolder)
        {
        }

        public GetOrdersResponse Get(string fromCoin, string toCoin, TradeStatus tradeStatus, TradeLevel tradeLevel)
        {
            return
                this.CallMethod<GetOrdersResponse>(
                    new RequestBuilder(RequestType.GET, "orders")
                    .AddUrlSegment(new CoinsPairSegment(fromCoin, toCoin))
                    .AddUrlSegment(tradeStatus)
                    .AddUrlSegment(tradeLevel));
            

        }
    }
}