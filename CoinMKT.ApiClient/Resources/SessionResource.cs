namespace CoinMKT.ApiClient.Resources
{
    using System;
    using System.Net;

    using CoinMKT.ApiClient.Responses;
    using CoinMKT.ApiClient.Types;
    using CoinMKT.ApiClient.Utils;

    public class SessionResource: ResourceBase, ISessionTokenHolder
    {

        public void SignIn(TradeLevel tradeLevel)
        {
            var getSignInKeyResponse = this.GetSignInKey();
            var result = CryptoHelper.Decrypt(getSignInKeyResponse.Key, apiSecret, false);
            var hasedSignedKey = CryptoHelper.CreateSHA2512Hash(String.Concat(result, this.apiSecondaryKey));
            hasedSignedKey = WebUtility.UrlEncode(hasedSignedKey);
            var getNewSessionResonse = this.GetSessionToken(hasedSignedKey, tradeLevel);
            this.SessionToken = getNewSessionResonse.SessionToken;
        }

        public EndSessionResponse SignOff()
        {
            return this.CallMethod<EndSessionResponse>(new RequestBuilder(RequestType.GET, "session/end"));
        }

        protected override string GetSessionToken()
        {
            return this.SessionToken;
        }

        private GetSessionTokenResponse GetSessionToken(string hashedSignInKey, TradeLevel tradeLevel)
        {
            return
                this.CallMethod<GetSessionTokenResponse>(
                    new RequestBuilder(RequestType.GET, "session/new")
                    .AddUrlSegment(tradeLevel)
                    .AddQueryStringParameter("hashedSignInKey", hashedSignInKey));
        }

        private GetSignInKeyResponse GetSignInKey()
        {
            return this.CallMethod<GetSignInKeyResponse>(new RequestBuilder(RequestType.GET, "session/signinkey"));
        }

        public string SessionToken { get; private set; }
    }
}