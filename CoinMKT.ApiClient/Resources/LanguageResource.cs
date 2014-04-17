namespace CoinMKT.ApiClient.Resources
{
    using CoinMKT.ApiClient.Responses;
    using CoinMKT.ApiClient.Types;

    public class LanguageResource : ProtectedResourceBase
    {
        public LanguageResource(ISessionTokenHolder sessionTokenHolder)
            : base(sessionTokenHolder)
        {
        }

        public GetLanguageResponse GetAccountLanguage()
        {
            return
                this.CallMethod<GetLanguageResponse>(
                    new RequestBuilder(RequestType.GET, "language"));

        }

        public SetLanguageResponse SetAccountLanguage(string languageCode)
        {
            return
                this.CallMethod<SetLanguageResponse>(
                    new RequestBuilder(RequestType.POST, "language").AddUrlSegment(languageCode));
        }
    }
}