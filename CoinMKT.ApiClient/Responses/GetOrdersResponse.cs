namespace CoinMKT.ApiClient.Responses
{
    using System;
    using System.Collections.Generic;

    public class GetOrdersResponse : ResponseBase
    {
        public List<Trade> Trades { get; set; }
    }
    
    public class Trade
    {
        public string TradeId { get; set; }

        public string Pair { get; set; }

        public int TradeSide { get; set; }

        public int TradeType { get; set; }

        public decimal Price { get; set; }

        public decimal Volume { get; set; }

        public int Status { get; set; }

        public int TradeLevel { get; set; }

        public DateTime Date { get; set; }

        public decimal Commission { get; set; }

        public string CommissionSymbol { get; set; }
    }
}