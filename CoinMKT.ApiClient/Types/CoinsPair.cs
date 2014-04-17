namespace CoinMKT.ApiClient.Types
{
    public class CoinsPairSegment
    {
        public string FromCoin { get; private set; }

        public string ToCoin { get; private set; }

        public CoinsPairSegment(string fromCoin, string toCoin)
        {
            this.FromCoin = fromCoin;
            this.ToCoin = toCoin;
        }

        public override string ToString()
        {
            return string.Format("{0}_{1}", this.FromCoin, this.ToCoin);
        }
    }
}