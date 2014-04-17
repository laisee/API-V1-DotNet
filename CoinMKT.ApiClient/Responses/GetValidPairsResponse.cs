namespace CoinMKT.ApiClient.Responses
{
    using System.Collections.Generic;

    public class GetValidPairsResponse : ResponseBase
    {
        public List<CoinsPair> Pairs { get; set; }
    }

    public class CoinsPair
    {
        public string Pair { get; set; }
    }
}