namespace CoinMKT.ApiClient.Trace
{
    public class CallTracer
    {
        private static ICallTracer instance;

        public static void Init(ICallTracer tracer)
        {
            instance = tracer;
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