namespace CoinMKT.ApiClient.Responses
{
    using System.Collections.Generic;

    public class CancelOrdersResponse : ResponseBase
    {
        public Dictionary<string, int> Trades { get; set; }
    }
}