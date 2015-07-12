using System;
using Hurricane.Shared.Networking.IPC.Interfaces;

namespace Hurricane.Networking.IPC.DevIPCMessage
{
    public class IPCMessageFactory : IIPCMessageFactory
    {
        public IIPCMessage CreateIPCMessage(IIPCSerialiser serialiser, Byte[] data)
        {
            return serialiser.DeserialiseIPCMessage<IIPCMessage>(data);
        }
    }
}