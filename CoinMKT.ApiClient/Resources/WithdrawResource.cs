namespace CoinMKT.ApiClient.Resources
{
    using System;
    using System.Net;

    using CoinMKT.ApiClient.Responses;
    using CoinMKT.ApiClient.Types;
    using CoinMKT.ApiClient.Utils;

    public class WithdrawResource: ProtectedResourceBase
    {
        public WithdrawResource(ISessionTokenHolder sessionTokenHolder)
            : base(sessionTokenHolder)
        {
        }

        public SendCoinResponse SendCoin(string symbol, decimal amount, string destinationAddress, string apiPin, bool addTxFee)
        {
            var getSendCoinKeyResponse = this.GetSendCoinKey();
            var decryptedKey = CryptoHelper.Decrypt(getSendCoinKeyResponse.Key, apiSecret, false);
            var hashedPin = CryptoHelper.CreateSHA2512Hash(apiPin);
            var hashedSendCoinKey =
                WebUtility.UrlEncode(
                    CryptoHelper.CreateSHA2512Hash(String.Concat(decryptedKey, this.apiSecondaryKey, hashedPin)));
            return this.SendCoinCore(symbol, amount, destinationAddress, hashedSendCoinKey, addTxFee);
        }

        private GetSendCoinKeyResponse GetSendCoinKey()
        {
            return
                this.CallMethod<GetSendCoinKeyResponse>(new RequestBuilder(RequestType.POST, "wallet/sendcoinkey/new"));
        }

        private SendCoinResponse SendCoinCore(string symbol, decimal amount, string destinationAddress, string hashedSendCoinKey, bool addTxFee)
        {
            return
                this.CallMethod<SendCoinResponse>(
                    new RequestBuilder(RequestType.POST, "wallet/sendcoin")
                    .AddUrlSegment(symbol)
                    .AddUrlSegment(amount)
                    .AddUrlSegment(destinationAddress)
                    .AddUrlSegment(addTxFee ? 1 : 0)
                    .AddQueryStringParameter("hashedSendCoinKey", hashedSendCoinKey));
        }
    }
}