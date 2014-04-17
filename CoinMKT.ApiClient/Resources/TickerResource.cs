namespace CoinMKT.ApiClient.Resources
{
    using CoinMKT.ApiClient.Responses;
    using CoinMKT.ApiClient.Types;

    public class TickerResource : ResourceBase
    {
        public GetTickerResponse GetTicker(string fromCoin, string toCoin, TradeLevel tradeLevel)
        {
            return
                this.CallMethod<GetTickerResponse>(
                    new RequestBuilder(RequestType.GET, "ticker")
                    .AddUrlSegment(new CoinsPairSegment(fromCoin, toCoin))
                    .AddUrlSegment(tradeLevel));
            
        }
    }
}