using System;
using System.Text;
using Hurricane.Shared.Networking;

namespace Hurricane.Components.Logon.LogonServer.Networking
{
    public class NetworkHandlers
    {
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
            LogonServer.Log.WriteTrace(packet.ObjectGuid, "Dumping packet output");
            var bytes = packet.ReadBytes(packet.DataBytes.Length);
            var sb = new StringBuilder();
            foreach (var b in bytes)
            {
                sb.Append((Char) b);
            }
            LogonServer.Log.WriteTrace(packet.ObjectGuid, "[{0}]", sb.ToString());
            
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
