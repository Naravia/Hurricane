using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hurricane.Shared.Networking
{
    public class NetworkEventArgs : EventArgs
    {
        public INetworkClient Client;
        public NetworkEventEnum NetworkEvent;
    }
}
