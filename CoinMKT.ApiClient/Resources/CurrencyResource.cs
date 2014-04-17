namespace CoinMKT.ApiClient.Resources
{
    using CoinMKT.ApiClient.Responses;
    using CoinMKT.ApiClient.Types;

    public class CurrencyResource : ResourceBase
    {
        public GetCurrecniesResponse GetCurrencies()
        {
            return this.CallMethod<GetCurrecniesResponse>(new RequestBuilder(RequestType.GET, "currency"));
        }

        public GetValidPairsResponse GetValidPairs()
        {
            return this.CallMethod<GetValidPairsResponse>(new RequestBuilder(RequestType.GET, "currency/pairs"));
        }
    }
}