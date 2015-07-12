using System;
using Hurricane.Shared.Networking.IPC;
using Hurricane.Shared.Networking.IPC.Interfaces;

namespace Hurricane.Networking.IPC.DevIPCMessage
{
    public class IPCMessage : IIPCMessage
    {
        public Guid ObjectGuid { get; private set; }
        public Guid SenderGuid { get; set; }
        public Guid TargetGuid { get; set; }
        public UInt64 SecurityToken { get; set; }
        public IPCOpcodeEnum Opcode { get; set; }

        public IPCMessage(Guid senderGuid, Guid targetGuid, UInt64 securityToken, IPCOpcodeEnum opcode)
        {
            this.ObjectGuid = Guid.NewGuid();
            this.SenderGuid = senderGuid;
            this.TargetGuid = targetGuid;
            this.SecurityToken = securityToken;
            this.Opcode = opcode;
        }
    }
}
