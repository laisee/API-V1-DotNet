### C# API for coinmkt.com
=======================

### Example

```
var apiClient = new CoinMKTClient();

apiClient.Currency.GetCurrencies();
apiClient.Currency.GetValidPairs();

apiClient.Ticker.GetTicker("BTC", "USD", TradeLevel.PlayMoney);
apiClient.TradeBook.Get("BTC", "USD", TradeLevel.RealMoney, 5);

apiClient.Session.SignIn(TradeLevel.PlayMoney);
apiClient.Trades.Get("BTC", "USD", TradeStatus.Completed, TradeLevel.PlayMoney);
apiClient.Orders.Get("BTC", "USD", TradeStatus.Open, TradeLevel.PlayMoney);

apiClient.Session.SignOff();
```

More details [https://api.coinmkt.com/Help](https://api.coinmkt.com/Help)
