namespace CoinMKT.ApiClient.Resources
{
    using System;
    using System.Configuration;
    using System.Net;
    using CoinMKT.ApiClient.Responses;
    using CoinMKT.ApiClient.Trace;
    using CoinMKT.ApiClient.Types;

    using RestSharp;

    public abstract class ResourceBase
    {
        protected readonly string apiKey = ConfigurationManager.AppSettings["CoinMKTApiKey"];
        protected readonly string apiSecret = ConfigurationManager.AppSettings["CoinMKTApiSecret"];
        protected readonly string apiSecondaryKey = ConfigurationManager.AppSettings["CoinMKTApiSecondaryKey"];
        protected readonly string apiVersion = ConfigurationManager.AppSettings["CoinMKTApiVersion"];
        protected readonly string apiBaseAddress = ConfigurationManager.AppSettings["CoinMKTApiBaseAddress"];

        protected TResponse CallMethod<TResponse>(IRequestBuilder requestBuilder) where TResponse : ResponseBase, new()
        {
            return CallTracerSingleton.Instance.Call(
                string.Format("{0} {1}", requestBuilder.RequestType, requestBuilder.Action),
                () => this.CallMethodCore<TResponse>(requestBuilder));
        }

        private TResponse CallMethodCore<TResponse>(IRequestBuilder requestBuilder) where TResponse : ResponseBase, new()
        {
            var restClient = new RestClient(this.apiBaseAddress + "/v" + this.apiVersion);
            var request = requestBuilder.Build(this.GetSessionToken());
            var response = restClient.Execute<TResponse>(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                if (response.Data.Code == 0)
                {
                    return response.Data;
                }

                throw new ApiClientException(response.Data.Err);
            }

            throw new Exception(
                string.Format("Unexpected status code: {0}, content: {1}", response.StatusCode, response.Content));

        }

        protected virtual string GetSessionToken()
        {
            return null;
        }
    }
}