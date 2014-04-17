namespace CoinMKT.ApiClient.Resources
{
    using System;
    using System.Net;

    using CoinMKT.ApiClient.Responses;
    using CoinMKT.ApiClient.Types;
    using CoinMKT.ApiClient.Utils;

    public class ThirdPartyResource : ProtectedResourceBase
    {
        public ThirdPartyResource(ISessionTokenHolder sessionTokenHolder)
            : base(sessionTokenHolder)
        {
        }

        public ThirdPartyMoveCoinResponse MoveCoin(string symbol, decimal amount, string apiPin, string usersThirdPartyAccountId)
        {
            var getMoveCoinKeyResponse = this.GetMoveCoinKey(usersThirdPartyAccountId);
            var decryptedKey = CryptoHelper.Decrypt(getMoveCoinKeyResponse.Key, apiSecret, false);
            var hashedPin = CryptoHelper.CreateSHA2512Hash(apiPin);
            var hashedMoveCoinKey = WebUtility.UrlEncode(CryptoHelper.CreateSHA2512Hash(String.Concat(decryptedKey, this.apiSecondaryKey, hashedPin)));
            return this.MoveCoinCore(symbol, amount, hashedMoveCoinKey, usersThirdPartyAccountId);
        }

        public ThirdPartyGetAddressesResponse GetAddresses(string usersThirdPartyAccountId)
        {
            return
                this.CallMethod<ThirdPartyGetAddressesResponse>(
                    new RequestBuilder(RequestType.GET, "thirdparty/addresses")
                    .AddUrlSegment(usersThirdPartyAccountId));
        }

        private GetThirdPartyMoveCoinKeyResponse GetMoveCoinKey(string usersThirdPartyAccountId)
        {
            return
                this.CallMethod<GetThirdPartyMoveCoinKeyResponse>(
                    new RequestBuilder(RequestType.GET, "thirdparty/movecoinkey")
                    .AddUrlSegment(usersThirdPartyAccountId));
        }

        private ThirdPartyMoveCoinResponse MoveCoinCore(string symbol, decimal amount, string hashedMoveCoinKey, string usersThirdPartyAccountId)
        {
            return
                this.CallMethod<ThirdPartyMoveCoinResponse>(
                    new RequestBuilder(RequestType.POST, "thirdparty/movecoin")
                    .AddUrlSegment(symbol)
                    .AddUrlSegment(amount)
                    .AddUrlSegment(usersThirdPartyAccountId)
                    .AddQueryStringParameter("hashedMoveCoinKey", hashedMoveCoinKey));
        }
    }
}