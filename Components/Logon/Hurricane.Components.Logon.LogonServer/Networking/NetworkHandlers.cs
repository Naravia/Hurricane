using System;
using System.Text;
using Hurricane.Shared.Components.Logon;
using Hurricane.Shared.Logging;
using Hurricane.Shared.Networking;

namespace Hurricane.Components.Logon.LogonServer.Networking
{
    public static class NetworkHandlers
    {
        internal static ILogger Log { get; set; }

        public static void OnClientConnecting(Object sender, NetworkEventArgs e)
        {
            /* TODO: IP blacklist support */
        }

        public static void OnClientConnected(Object sender, NetworkEventArgs e)
        {
            var client = LogonServer.ClientFactory.CreateLogonClient(e.Client);
            LogonServer.ObjectManager.Store(client);
        }

        public static void OnReceiveData(Object sender, NetworkEventArgs e)
        {
            var packet = LogonServer.PacketFactory.CreateNetworkPacket(e.Data);
            Log.WriteTrace(packet.ObjectGuid, "Dumping packet output");
            var bytes = packet.ReadBytes(packet.DataBytes.Length);
            var sb = new StringBuilder();
            foreach (var b in bytes)
            {
                sb.Append((Char) b);
            }
            Log.WriteTrace(packet.ObjectGuid, "[{0}]", sb.ToString());

            var logonPacket = LogonServer.LogonPacketHandler.ParseNetworkPacket(packet);
            Log.WriteDebug(packet.ObjectGuid, "Received packet [opcode: {0}] [error: 0x{1:x2}] [length: {2}]", logonPacket.Opcode, logonPacket.Error, logonPacket.Size);

            switch (LogonServer.LogonPacketHandler.GetOpcodeEnum(opcode: logonPacket.Opcode))
            {
                case LogonPacketOpcodeEnum.AuthLogonChallenge:
                    LogonServer.LogonPacketHandler.HandleAuthLogonChallenge(logonPacket, Log);
                    break;
            }

            /* Actual packet handling NYI so kick client */
            e.Cancel = true;
        }

        public static void OnClientDisconnecting(Object sender, NetworkEventArgs e)
        {

        }

        public static void OnClientDisconnected(Object sender, NetworkEventArgs e)
        {

        }
    }
}
