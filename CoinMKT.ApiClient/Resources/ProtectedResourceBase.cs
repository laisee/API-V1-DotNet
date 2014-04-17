namespace CoinMKT.ApiClient.Resources
{
    using System;

    public class ProtectedResourceBase: ResourceBase
    {
        private readonly ISessionTokenHolder sessionTokenHolder;

        public ProtectedResourceBase(ISessionTokenHolder sessionTokenHolder)
        {
            this.sessionTokenHolder = sessionTokenHolder;
        }

        protected override string GetSessionToken()
        {
            if (string.IsNullOrEmpty(this.sessionTokenHolder.SessionToken))
            {
                throw new Exception("SignIn need to be called first");
            }

            return this.sessionTokenHolder.SessionToken;
        }
    }
}