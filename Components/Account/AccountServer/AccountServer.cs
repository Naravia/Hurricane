using System;
using Hurricane.Shared.Components.Account.Interfaces;
using Hurricane.Shared.Logging.Interfaces;

namespace Hurricane.Components.Account.DevAccountServer
{
    public class AccountServer : IAccountManager
    {
        public AccountServer(ILogger log)
        {
            this.Log = log;
            this.ObjectGuid = Guid.NewGuid();
        }

        public IAccountResult GetAccount(IAccountRequest account)
        {
            throw new NotImplementedException();
        }

        public Guid ObjectGuid { get; private set; }
        public ILogger Log { get; private set; }

        public void Initialise()
        {
            throw new NotImplementedException();
        }

        public void Boot()
        {
            throw new NotImplementedException();
        }

        public void Shutdown()
        {
            throw new NotImplementedException();
        }

        public void Tick(TimeSpan timeSinceLastTick)
        {
            throw new NotImplementedException();
        }
    }
}
