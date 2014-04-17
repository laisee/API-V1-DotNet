namespace CoinMKT.ApiClient.Resources
{
    using System.Collections.Generic;

    using CoinMKT.ApiClient.Responses;
    using CoinMKT.ApiClient.Types;

    public class OrderResource : ProtectedResourceBase
    {
        public OrderResource(ISessionTokenHolder sessionTokenHolder)
            : base(sessionTokenHolder)
        {
        }

        public CancelOrderResponse Cancel(string orderId)
        {
            return
                this.CallMethod<CancelOrderResponse>(
                    new RequestBuilder(RequestType.POST, "order/cancel")
                    .AddUrlSegment(orderId));
        }

        public CancelOrdersResponse CancelMany(TradeLevel tradeLevel, string[] orderIds)
        {
            return
                this.CallMethod<CancelOrdersResponse>(
                    new RequestBuilder(RequestType.POST, "order/cancel/many")
                    .AddUrlSegment(tradeLevel)
                    .AddUrlSegment(orderIds));
        }

        public CancelOrdersResponse CancelAll(TradeLevel tradeLevel)
        {
            return
                this.CallMethod<CancelOrdersResponse>(
                    new RequestBuilder(RequestType.POST, "order/cancel/all")
                    .AddUrlSegment(tradeLevel));
        }

        public GetOrderStatusResponse GetStatus(string orderId)
        {
            return
                this.CallMethod<GetOrderStatusResponse>(
                    new RequestBuilder(RequestType.GET, "order/status")
                    .AddUrlSegment(orderId));
        }

        public TradeCoinResponse New(string fromCoin, string toCoin, TradeType tradeType, TradeSide tradeSide, decimal tradePrice, decimal units, TradeLevel tradeLevel)
        {
            return
                this.CallMethod<TradeCoinResponse>(
                    new RequestBuilder(RequestType.POST, "order/new")
                    .AddUrlSegment(new CoinsPairSegment(fromCoin, toCoin))
                    .AddUrlSegment(tradeType)
                    .AddUrlSegment(tradeSide)
                    .AddUrlSegment(tradePrice)
                    .AddUrlSegment(units)
                    .AddUrlSegment(tradeLevel));
        }

        public TradeCoinsResponse New(List<TradeCoinRequest> trades)
        {
            return
                this.CallMethod<TradeCoinsResponse>(
                    new RequestBuilder(RequestType.POST, "order/new/many")
                    .AddBody(trades));
        }
    }
}