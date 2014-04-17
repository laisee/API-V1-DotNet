namespace CoinMKT.ApiClient.Responses
{
    using System.Collections.Generic;

    public class ThirdPartyGetAddressesResponse : ResponseBase
    {
        public List<CoinAddress> Addresses { get; set; }
    }
}