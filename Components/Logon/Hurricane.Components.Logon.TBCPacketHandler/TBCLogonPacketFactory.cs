using System;
using Hurricane.Shared.Components.Logon;
using Hurricane.Shared.Networking;

namespace Hurricane.Components.Logon.TBCPacketHandler
{
    public class TBCLogonPacketFactory : ILogonPacketFactory
    {
        public Guid ObjectGuid { get; private set; }

        public TBCLogonPacketFactory()
        {
            this.ObjectGuid = Guid.NewGuid();
        }

        public ILogonPacket CreateLogonPacket(INetworkPacket packet)
        {
            var logonPacket = new TBCLogonPacket(packet);
            return logonPacket;
        }
    }
}