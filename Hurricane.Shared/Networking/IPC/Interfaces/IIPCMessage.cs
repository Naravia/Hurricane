using System;
using System.Collections.Generic;
using Hurricane.Shared.Objects.Interfaces;

namespace Hurricane.Shared.Networking.IPC.Interfaces
{
    public interface IIPCMessage : IHurricaneObject
    {
        Guid SenderGuid { get; set; }
        Guid TargetGuid { get; set; }
        UInt64 SecurityToken { get; set; }
        IPCOpcodeEnum Opcode { get; set; }
    }
}