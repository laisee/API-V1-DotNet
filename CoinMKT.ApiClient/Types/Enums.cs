namespace CoinMKT.ApiClient.Types
{
    using System;

    public enum TradeLevel
    {
        PlayMoney = 0,

        RealMoney = 1
    }

    public enum TradeType
    {
        Market = 0,

        Limit = 1
    }

    public enum TradeSide
    {
        Buy = 0,

        Sell = 1
    }

    public enum TradeStatus
    {
        Open = 0,

        Completed = 1,

        Cancelled = 2,

        Reversed = 3
    }
}
