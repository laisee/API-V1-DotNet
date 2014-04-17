
namespace CoinMKT.ApiClient.Trace
{
    using System;

    /// <summary>
    /// The tracer.
    /// </summary>
    public class NullCallTracer : ICallTracer
    {
        public TResponse Call<TResponse>(string actionName, Func<TResponse> action)
        {
            return action();
        }
    }
}

