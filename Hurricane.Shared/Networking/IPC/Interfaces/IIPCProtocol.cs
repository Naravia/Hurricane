using System;
using Hurricane.Shared.Networking.IPC.Packets.GetStatus;
using Hurricane.Shared.Networking.IPC.Packets.RegisterComponent;
using Hurricane.Shared.Networking.IPC.Packets.RegisterComponentResponse;

namespace Hurricane.Shared.Networking.IPC.Interfaces
{
    public interface IIPCProtocol
    {
        event EventHandler<RegisterComponentEventArgs> OnRegisterComponent;
        event EventHandler<RegisterComponentResponseEventArgs> OnRegisterComponentResponse;
        event EventHandler<GetStatusEventArgs> OnGetStatus;
    }
}