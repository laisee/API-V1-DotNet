namespace CoinMKT.ApiClient.Responses
{
    using System.Collections.Generic;

    public class GetCurrecniesResponse : ResponseBase
    {
        public List<Coin> Symbols { get; set; }
    }

    public class Coin
    {
        public string Name { get; set; }

        public string Symbol { get; set; }

        public int DecimalPlaces { get; set; }

        public int Crypto { get; set; }

    }
}