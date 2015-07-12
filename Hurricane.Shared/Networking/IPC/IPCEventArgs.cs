using System;
using Hurricane.Shared.Objects.Interfaces;

namespace Hurricane.Shared.Networking.IPC
{
    public class IPCEventArgs : IHurricaneObject
    {
        public Boolean Cancel;
        public Byte[] Data;
        public Guid ObjectGuid { get; private set; }

        public IPCEventArgs()
        {
            this.ObjectGuid = Guid.NewGuid();
        }

        public IPCEventArgs(IPCEventArgs ipcArgs)
        {
            this.ObjectGuid = ipcArgs.ObjectGuid;
            this.Data = ipcArgs.Data;
            this.Cancel = ipcArgs.Cancel;
        }
    }
}