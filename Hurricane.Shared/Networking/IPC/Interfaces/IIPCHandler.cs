using System;
using Hurricane.Shared.Networking.Interfaces;
using Hurricane.Shared.Objects.Interfaces;

namespace Hurricane.Shared.Networking.IPC.Interfaces
{
    public interface IIPCHandler : IIPCProtocol, IHurricaneObject
    {
        void SendIPCMessage(IIPCMessage message);
        void ReceiveIPCMessage(IIPCMessage message);
    }
}