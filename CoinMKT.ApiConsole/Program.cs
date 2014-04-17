using System;

namespace CoinMKT.ApiConsole
{
    using System.Collections.Generic;

    using CoinMKT.ApiClient;
    using CoinMKT.ApiClient.Trace;
    using CoinMKT.ApiClient.Types;

    internal class Program
    {
        private static void Main(string[] args)
        {
            CallTracerSingleton.Init(new DefaultCallTracer());

            var apiClient = new CoinMKTClient();
            
            #region Currency

            apiClient.Currency.GetCurrencies();
            
            var response = apiClient.Currency.GetValidPairs();
            
            #endregion
            
            #region Tradebook

            apiClient.TradeBook.Get("ALL", "ALL", TradeLevel.PlayMoney, 5);
            
            #endregion

            #region Ticker

            apiClient.Ticker.GetTicker("BTC", "USD", TradeLevel.PlayMoney);

            #endregion*/

            apiClient.Session.SignIn(0);

            apiClient.Orders.Get("BTC", "USD", TradeStatus.Open, TradeLevel.PlayMoney);

            var test = apiClient.Order.New("BTC", "USD", TradeType.Limit, TradeSide.Buy, 1.0m, 1.0m, TradeLevel.PlayMoney);
            var trade = new TradeCoinRequest("BTC", "USD", TradeType.Limit, TradeSide.Sell, 1, 1, TradeLevel.PlayMoney);
            apiClient.Order.New(new List<TradeCoinRequest>() { { trade }, { trade }, { trade } });
            
            #region Deposit

            apiClient.Deposit.GetAccountAddresses();

            #endregion

            #region Withdraw

            try
            {
                apiClient.Withdraw.SendCoin("BTC", 1, "testaddress", "testpin", true);
            }
            catch (ApiClientException ex)
            {
                Console.WriteLine(ex.Message);
            }

            #endregion

            #region Language

            apiClient.Language.GetAccountLanguage();
            
            apiClient.Language.SetAccountLanguage("EN-US");
            
            #endregion

            #region Order

            var newOrderResponse = apiClient.Order.New("BTC", "USD", TradeType.Limit, TradeSide.Sell, 1.0m, 1.0m, TradeLevel.PlayMoney);

            var orderStatusResponse = apiClient.Order.GetStatus(newOrderResponse.TradeId);

            apiClient.Order.Cancel(newOrderResponse.TradeId);

            apiClient.Order.GetStatus(newOrderResponse.TradeId);

            apiClient.Order.New("BTC", "USD", TradeType.Limit, TradeSide.Sell, 1.0m, 1.0m, TradeLevel.PlayMoney);

            var newOrderResponse1 = apiClient.Order.New("BTC", "USD", TradeType.Limit, TradeSide.Buy, 1.0m, 1.0m, TradeLevel.PlayMoney);
            var newOrderResponse2 = apiClient.Order.New("BTC", "USD", TradeType.Limit, TradeSide.Sell, 1.0m, 1.0m, TradeLevel.PlayMoney);
            var newOrderResponse3 = apiClient.Order.New("BTC", "USD", TradeType.Limit, TradeSide.Sell, 1.0m, 1.0m, TradeLevel.PlayMoney);

            apiClient.Order.CancelMany(TradeLevel.PlayMoney, new string[] { newOrderResponse1.TradeId, newOrderResponse2.TradeId, newOrderResponse3.TradeId });

            /*var trade = new TradeCoinRequest("BTC", "USD", TradeType.Limit, TradeSide.Sell, 1, 1, TradeLevel.PlayMoney);
            apiClient.Order.New(new List<TradeCoinRequest>() { { trade }, { trade }, { trade } });*/
            
            #endregion

            #region Orders

            apiClient.Orders.Get("BTC", "USD", TradeStatus.Open, TradeLevel.PlayMoney);

            #endregion

            #region Trades

            apiClient.Trades.Get("BTC", "USD", TradeStatus.Completed, TradeLevel.PlayMoney);

            #endregion

            #region Balances

            apiClient.Balances.GetAccountBalances(TradeLevel.PlayMoney);

            apiClient.Balances.GetAccountBalance("BTC", TradeLevel.PlayMoney);

            apiClient.Balances.GetAccountBalance("BTC", TradeLevel.RealMoney);

            #endregion

            #region ThirdParty

            try
            {
                apiClient.ThirdParty.MoveCoin("BTC", 1, "testpin", "testThirdPartyId");
            }
            catch (ApiClientException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                apiClient.ThirdParty.GetAddresses("testThirdPartyId");
            }
            catch (ApiClientException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            #endregion

            apiClient.Session.SignOff();

            Console.ReadLine();
        }
    }
}
