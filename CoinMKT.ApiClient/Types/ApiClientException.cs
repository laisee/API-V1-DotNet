namespace CoinMKT.ApiClient.Types
{
    using System;

    public class ApiClientException : Exception
    {
        public ApiClientException(string message) : base(message)
        {
            
        }
    }
}