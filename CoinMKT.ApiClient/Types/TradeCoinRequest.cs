namespace CoinMKT.ApiClient.Types
{
    public class TradeCoinRequest
    {
        public TradeCoinRequest(string fromCoin, string toCoin, TradeType tradeType, TradeSide tradeSide, decimal tradePrice, decimal units, TradeLevel tradeLevel)
        {
            this.FromCoinSymbol = fromCoin;
            this.ToCoinSymbol = toCoin;
            this.TradeType = (int)tradeType;
            this.TradeSide = (int)tradeSide;
            this.TradePrice = tradePrice;
            this.Units = units;
            this.TradeLevel = (int)tradeLevel;
        }

        public string FromCoinSymbol { get; set; }

        public string ToCoinSymbol { get; set; }

        public int TradeType { get; set; }

        public int TradeSide { get; set; }

        public decimal TradePrice { get; set; }

        public decimal Units { get; set; }

        public int TradeLevel { get; set; }
    }
}