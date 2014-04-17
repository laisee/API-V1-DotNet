namespace CoinMKT.ApiClient.Responses
{
    using System.Collections.Generic;

    public class GetAddressesResponse : ResponseBase
    {
        public List<CoinAddress> Addresses { get; set; }
    }

    public class CoinAddress
    {
        public string Name { get; set; }

        public string Symbol { get; set; }

        public string Address { get; set; }
    }
}