namespace CoinMKT.ApiClient
{
    using CoinMKT.ApiClient.Resources;

    public class CoinMKTClient
    {
        public SessionResource Session { get; private set; }

        public LanguageResource Language { get; private set; }

        public CurrencyResource Currency { get; private set; }

        public TickerResource Ticker { get; private set; }
        
        public OrderResource Order { get; private set; }
        
        public OrdersResource Orders { get; private set; }
        
        public TradesResource Trades { get; private set; }
        
        public TradeBookResource TradeBook { get; private set; }
        
        public BalancesResource Balances { get; private set; }
        
        public WithdrawResource Withdraw { get; private set; }
        
        public ThirdPartyResource ThirdParty { get; private set; }
        
        public DepositResource Deposit { get; private set; }

        public CoinMKTClient()
        {
            this.Session = new SessionResource();
            this.Language = new LanguageResource(this.Session);
            this.Currency = new CurrencyResource();
            this.Ticker = new TickerResource();
            this.Order = new OrderResource(this.Session);
            this.Orders = new OrdersResource(this.Session);
            this.Trades = new TradesResource(this.Session);
            this.TradeBook = new TradeBookResource();
            this.Balances = new BalancesResource(this.Session);
            this.Withdraw = new WithdrawResource(this.Session);
            this.Deposit = new DepositResource(this.Session);
            this.ThirdParty = new ThirdPartyResource(this.Session);
        }
    }
}