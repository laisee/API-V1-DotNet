namespace CoinMKT.ApiClient.Responses
{
    using System;

    public class GetTickerResponse: ResponseBase
    {
        public decimal Bid { get; set; }

        public decimal Ask { get; set; }

        public decimal Mid { get; set; }

        public decimal Last { get; set; }

        public DateTime When { get; set; }
    }
}