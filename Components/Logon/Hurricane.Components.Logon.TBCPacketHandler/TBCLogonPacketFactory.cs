using System;
using Hurricane.Shared.Components.Logon;
using Hurricane.Shared.Logging;
using Hurricane.Shared.Networking;

namespace Hurricane.Components.Logon.TBCPacketHandler
{
    public class TBCLogonPacketFactory : ILogonPacketFactory
    {
        public Guid ObjectGuid { get; private set; }

        public TBCLogonPacketFactory(ILogger log)
        {
            this.Log = log;
            this.ObjectGuid = Guid.NewGuid();
        }

        public ILogonPacket CreateLogonPacket(INetworkPacket packet)
        {
            var logonPacket = new TBCLogonPacket(packet, this.Log);
            return logonPacket;
        }

        public ILogger Log { get; private set; }
    }
}