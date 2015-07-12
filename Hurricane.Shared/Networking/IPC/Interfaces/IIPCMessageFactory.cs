using System;

namespace Hurricane.Shared.Networking.IPC.Interfaces
{
    public interface IIPCMessageFactory
    {
        IIPCMessage CreateIPCMessage(IIPCSerialiser serialiser, Byte[] data);
    }
}