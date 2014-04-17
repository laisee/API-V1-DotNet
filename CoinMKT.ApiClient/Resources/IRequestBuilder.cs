namespace CoinMKT.ApiClient.Resources
{
    using System;

    using CoinMKT.ApiClient.Types;

    using RestSharp;

    public interface IRequestBuilder
    {
        RequestType RequestType { get; }

        string Action { get; }

        IRequestBuilder AddUrlSegment(string segment);

        IRequestBuilder AddUrlSegment(string[] segment);

        IRequestBuilder AddUrlSegment(Enum segment);

        IRequestBuilder AddUrlSegment(decimal segment);

        IRequestBuilder AddUrlSegment(CoinsPairSegment segment);

        IRequestBuilder AddQueryStringParameter(string name, string value);

        IRequestBuilder AddBody(object body);

        RestRequest Build(string sessionToken = null);
    }
} 