using Hurricane.Shared.Components;

namespace Hurricane.Shared.Networking.IPC.Packets.GetStatus
{
    public class GetStatusEventArgs : IPCEventArgs
    {
        public ComponentStatusEnum Status;

        public GetStatusEventArgs(IPCEventArgs ipcEvent, ComponentStatusEnum status) : base(ipcEvent)
        {
            this.Status = status;
        }
    }
}