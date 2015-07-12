using System;

namespace Hurricane.Shared.Networking.IPC.Packets.RegisterComponentResponse
{
    public class RegisterComponentResponseEventArgs : IPCEventArgs
    {
        public Boolean Success;

        public RegisterComponentResponseEventArgs(IPCEventArgs ipcEvent, Boolean success) : base(ipcEvent)
        {
            this.Success = success;
        }
    }
}