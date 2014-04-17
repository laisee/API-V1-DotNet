
namespace CoinMKT.ApiClient.Trace
{
    using System;
    using System.Diagnostics;

    using CoinMKT.ApiClient.Types;

    using Newtonsoft.Json;

    public class DefaultCallTracer : ICallTracer
    {
        public TResponse Call<TResponse>(string actionName, Func<TResponse> action)
        {
            var stopwatch = Stopwatch.StartNew();
            this.LogInfo(actionName, "Calling");
            var response = action();
            this.LogInfo(actionName, "Response" + Environment.NewLine + JsonConvert.SerializeObject(response, Formatting.Indented));
            this.LogInfo(actionName, string.Format("Completed in {0}ms.", stopwatch.ElapsedMilliseconds));

            return response;
        }

        private void LogInfo(string actionName, string message)
        {
            Console.WriteLine("{0} [{1}] - {2}", DateTime.Now.ToString("hh:mm:ss"), actionName, message);
        }
    }
}

