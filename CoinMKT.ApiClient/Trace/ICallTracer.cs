namespace CoinMKT.ApiClient.Trace
{
    using System;

    public interface ICallTracer
    {
        TResponse Call<TResponse>(string actionName, Func<TResponse> action);
    }
}