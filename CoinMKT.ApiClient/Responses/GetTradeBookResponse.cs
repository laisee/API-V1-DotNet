namespace CoinMKT.ApiClient.Responses
{
    using System;
    using System.Collections.Generic;

    public class GetTradeBookResponse: ResponseBase
    {
        public List<TradeBookItem> Bids { get; set; }

        public List<TradeBookItem> Asks { get; set; }
    }

    public class TradeBookItem
    {
        public string TradeId { get; set; }

        public string Pair { get; set; }

        public int TradeSide { get; set; }

        public decimal Price { get; set; }

        public decimal Volume { get; set; }

        public int Status { get; set; }

        public int TradeLevel { get; set; }

        public DateTime Date { get; set; }

        public decimal Commission { get; set; }

        public string CommissionCoinSymbol { get; set; }
    }

}