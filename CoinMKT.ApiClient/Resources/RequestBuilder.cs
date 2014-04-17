namespace CoinMKT.ApiClient.Resources
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Net;

    using CoinMKT.ApiClient.Types;

    using RestSharp;

    public class RequestBuilder: IRequestBuilder
    {
        private readonly string apiKey = ConfigurationManager.AppSettings["CoinMKTApiKey"];

        public RequestType RequestType { get; private set; }

        public string Action { get; private set; }

        private readonly List<string> _urlSegments;
        private readonly Dictionary<string, string> _queryStringParameters;
        private object _body;
        
        public RequestBuilder(RequestType requestType, string action)
        {
            this.RequestType = requestType;
            this.Action = action;
            this._urlSegments = new List<string>();
            this._queryStringParameters = new Dictionary<string, string>();
        }

        public IRequestBuilder AddUrlSegment(string segment)
        {
            this._urlSegments.Add(WebUtility.UrlEncode(segment));
            return this;
        }

        public IRequestBuilder AddUrlSegment(string[] segment)
        {
            this._urlSegments.Add(string.Join(";", segment));
            return this;
        }

        public IRequestBuilder AddUrlSegment(Enum segment)
        {
            this._urlSegments.Add(segment.ToString("d"));
            return this;
        }

        public IRequestBuilder AddUrlSegment(decimal segment)
        {
            this._urlSegments.Add(segment.ToString());
            return this;
        }

        public IRequestBuilder AddUrlSegment(CoinsPairSegment segment)
        {
            this._urlSegments.Add(segment.ToString());
            return this;
        }

        public IRequestBuilder AddQueryStringParameter(string name, string value)
        {
            this._queryStringParameters.Add(name, value);
            return this;
        }

        public IRequestBuilder AddBody(object body)
        {
            this._body = body;
            return this;
        }

        public RestRequest Build(string sessionToken = null)
        {
            var uri = this.Action + "/" + (string.IsNullOrEmpty(sessionToken) ? this.apiKey : sessionToken) + "/" + string.Join("/", this._urlSegments);
            if (this._queryStringParameters.Count > 0)
            {
                uri = uri + "?";
                uri = this._queryStringParameters.Aggregate(
                    uri,
                    (current, queryStringParameter) =>
                    current + string.Format("{0}={1}&", queryStringParameter.Key, WebUtility.UrlEncode(queryStringParameter.Value)));
            }
         
            return this.RequestFactory(uri);
        }

        private RestRequest RequestFactory(string uri)
        {
            var request = new RestRequest(uri) { RequestFormat = DataFormat.Json };
            switch (this.RequestType)
            {
                case RequestType.POST:
                    request.Method = Method.POST;
                    break;
                case RequestType.GET:
                    request.Method = Method.GET;
                    break;
                case RequestType.DELETE:
                    request.Method = Method.DELETE;
                    break;
                default:
                    throw new Exception("Not supported request type");
            }

            if (this._body != null)
            {
                request.AddBody(this._body);
            }

            return request;
        }
    }
}