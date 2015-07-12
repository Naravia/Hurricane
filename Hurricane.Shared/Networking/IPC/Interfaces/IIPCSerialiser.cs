using System;

namespace Hurricane.Shared.Networking.IPC.Interfaces
{
    public interface IIPCSerialiser
    {
        T DeserialiseIPCMessage<T>(Byte[] data);
        Byte[] SerialiseIPCMessage(IIPCMessage message);
    }
}