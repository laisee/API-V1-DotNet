namespace CoinMKT.ApiClient.Resources
{
    using CoinMKT.ApiClient.Responses;
    using CoinMKT.ApiClient.Types;

    public class TradeBookResource : ResourceBase
    {
        public GetTradeBookResponse Get(string fromCoin, string toCoin, TradeLevel tradeLevel, int count = 50)
        {
            return
                this.CallMethod<GetTradeBookResponse>(
                    new RequestBuilder(RequestType.GET, "book")
                    .AddUrlSegment(new CoinsPairSegment(fromCoin, toCoin))
                    .AddUrlSegment(tradeLevel)
                    .AddQueryStringParameter("count", count.ToString()));
            }
    }
}