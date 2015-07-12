using System;
using Hurricane.Shared.Objects.Interfaces;

namespace Hurricane.Shared.Networking.IPC.Interfaces
{
    public interface IIPCInterface : IHurricaneObject
    {
        Boolean Startup();
        Boolean Shutdown();

        Boolean SendIPCMessage(IIPCMessage message);

        event EventHandler<IPCEventArgs> OnReceiveData;
    }
}