namespace CoinMKT.ApiClient.Resources
{
    using CoinMKT.ApiClient.Responses;
    using CoinMKT.ApiClient.Types;

    public class BalancesResource : ProtectedResourceBase
    {
        public BalancesResource(ISessionTokenHolder sessionTokenHolder)
            : base(sessionTokenHolder)
        {
        }

        public GetBalancesResponse GetAccountBalances(TradeLevel tradeLevel)
        {
            return
                this.CallMethod<GetBalancesResponse>(new RequestBuilder(RequestType.GET, "account/balances")
                .AddUrlSegment(tradeLevel));
        }

        public GetBalanceResponse GetAccountBalance(string symbol, TradeLevel tradeLevel)
        {
            return
                this.CallMethod<GetBalanceResponse>(
                    new RequestBuilder(RequestType.GET, "account/balance")
                    .AddUrlSegment(symbol)
                    .AddUrlSegment(tradeLevel));
        }
        
    }
}