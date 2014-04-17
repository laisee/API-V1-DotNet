namespace CoinMKT.ApiClient.Trace
{
    public class CallTracerSingleton
    {
        private static ICallTracer instance;

        public static void Init(ICallTracer callTracer)
        {
            instance = callTracer;
        }

        public static ICallTracer Instance
        {
            get
            {
                return instance ?? (instance = new NullCallTracer());
            }
        }
    }
}