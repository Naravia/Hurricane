using System;
using Hurricane.Shared.Components.Logon.Interfaces;
using Hurricane.Shared.Components.Logon.Packets;
using Hurricane.Shared.Logging.Interfaces;
using Hurricane.Shared.Networking.Interfaces;

namespace Hurricane.Components.Logon.TBCPacketHandler
{
    public class TBCLogonPacketFactory : ILogonPacketFactory
    {
        public TBCLogonPacketFactory(ILogger log)
        {
            this.Log = log;
            this.ObjectGuid = Guid.NewGuid();
        }

        public Guid ObjectGuid { get; private set; }

        public ILogonPacket CreateLogonPacket(INetworkPacket packet)
        {
            var logonPacket = new TBCLogonPacket(packet, this.Log);
            return logonPacket;
        }

        public ILogger Log { get; private set; }
    }
}