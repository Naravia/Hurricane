using System;
using Hurricane.Shared.Networking;

namespace Hurricane.Components.Logon.LogonServer.Networking
{
    public class NetworkHandlers
    {
        public static void OnClientConnecting(Object sender, NetworkEventArgs e)
        {
            /* Not implemented */
            e.Cancel = true;
        }

        public static void OnClientConnected(Object sender, NetworkEventArgs e)
        {
            throw new NotImplementedException();
        }

        public static void OnReceiveData(Object sender, NetworkEventArgs e)
        {
            throw new NotImplementedException();
        }

        public static void OnClientDisconnecting(Object sender, NetworkEventArgs e)
        {
            throw new NotImplementedException();
        }

        public static void OnClientDisconnected(Object sender, NetworkEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
