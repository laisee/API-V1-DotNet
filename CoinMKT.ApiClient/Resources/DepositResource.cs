namespace CoinMKT.ApiClient.Resources
{
    using CoinMKT.ApiClient.Responses;
    using CoinMKT.ApiClient.Types;

    public class DepositResource : ProtectedResourceBase
    {
        public DepositResource(ISessionTokenHolder sessionTokenHolder)
            : base(sessionTokenHolder)
        {
        }

        public GetAddressesResponse GetAccountAddresses()
        {
            return
                this.CallMethod<GetAddressesResponse>(
                    new RequestBuilder(RequestType.GET, "account/addresses"));
        }
    }
}