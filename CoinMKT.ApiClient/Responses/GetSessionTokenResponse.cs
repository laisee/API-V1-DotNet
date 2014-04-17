namespace CoinMKT.ApiClient.Responses
{
    public class GetSessionTokenResponse: ResponseBase
    {
        public string SessionToken { get; set; }
        
        public string UserId { get; set; }
    }
}