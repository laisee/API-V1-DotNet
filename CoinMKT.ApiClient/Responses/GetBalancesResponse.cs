namespace CoinMKT.ApiClient.Responses
{
    using System;
    using System.Collections.Generic;

    public class GetBalancesResponse : ResponseBase
    {
        public List<BalanceCoin> Balances { get; set; }

        public List<PendingDeposit> PendingDeposits { get; set; }

        public List<InEscrow> InEscrow { get; set; }

        public List<DepositsWithdrawal> DepositsWithdrawals { get; set; }
    }

    public class BalanceCoin
    {
        public string Name { get; set; }

        public string Symbol { get; set; }

        public decimal Balance { get; set; }

        public int DecimalPlaces { get; set; }

        public int Crypto { get; set; }
    }

    public class PendingDeposit
    {
        public int Id { get; set; }

        public int Confirmations { get; set; }

        public int RequiredConfirmations { get; set; }

        public DateTime When { get; set; }

        public decimal Amount { get; set; }

        public string Symbol { get; set; }
    }

    public class DepositsWithdrawal
    {
        public int Id { get; set; }

        public int Confirmations { get; set; }

        public DateTime When { get; set; }

        public decimal Amount { get; set; }

        public string Symbol { get; set; }

        public string Address { get; set; }
    }

    public class InEscrow
    {
        public decimal Amount { get; set; }

        public string Symbol { get; set; }

    }
}