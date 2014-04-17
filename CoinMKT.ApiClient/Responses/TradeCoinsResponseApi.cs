namespace CoinMKT.ApiClient.Responses
{
    using System.Collections.Generic;

    public class TradeCoinsResponse : ResponseBase
    {
        public List<TradeCoinResponseItem> Trades { get; set; }
    }

    public class TradeCoinResponseItem : ResponseBase
    {
        public string TradeId { get; set; }

        public int Timestamp { get; set; }
    }
}