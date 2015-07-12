using Hurricane.Shared.Components;

namespace Hurricane.Shared.Networking.IPC.Packets.RegisterComponent
{
    public class RegisterComponentEventArgs : IPCEventArgs
    {
        public ComponentTypeEnum ComponentType;

        public RegisterComponentEventArgs(IPCEventArgs ipcEvent, ComponentTypeEnum componentType) : base(ipcEvent)
        {
            this.ComponentType = componentType;
        }
    }
}