using System;
using Hurricane.Shared.Networking.Interfaces;

namespace Hurricane.Shared.Networking
{
    public class NetworkEventArgs : EventArgs
    {
        public Boolean Cancel;
        public INetworkClient Client;
        public Byte[] Data;
    }
}