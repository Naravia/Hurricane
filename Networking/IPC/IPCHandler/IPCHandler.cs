using System;
using Hurricane.Shared.Logging.Interfaces;
using Hurricane.Shared.Networking.IPC;
using Hurricane.Shared.Networking.IPC.Interfaces;
using Hurricane.Shared.Networking.IPC.Packets.GetStatus;
using Hurricane.Shared.Networking.IPC.Packets.RegisterComponent;
using Hurricane.Shared.Networking.IPC.Packets.RegisterComponentResponse;

namespace Hurricane.Networking.IPC.DevIPCHandler
{
    public class IPCHandler : IIPCHandler
    {
        public Guid ObjectGuid { get; private set; }

        internal Guid MasterGuid { get; private set; }
        internal IIPCInterface IPCInterface;
        internal IIPCSerialiser IPCSerialiser;
        internal ILogger Log;

        public IPCHandler(IIPCInterface ipcInterface, IIPCSerialiser ipcSerialiser, ILogger log, Guid masterGuid)
        {
            this.ObjectGuid = Guid.NewGuid();
            this.MasterGuid = masterGuid;

            this.IPCInterface = ipcInterface;
            this.IPCSerialiser = ipcSerialiser;
            this.Log = log;

            this.IPCInterface.OnReceiveData += this.ReceiveData;
        }

        private void ReceiveData(Object sender, IPCEventArgs e)
        {
            try
            {
                var message = this.IPCSerialiser.DeserialiseIPCMessage<IIPCMessage>(e.Data);
                /* Message parsed successfully, validate */

                /* TODO: Security token validation */

                /* GUID Validation */
                if (message.TargetGuid != this.MasterGuid)
                {
                    /* Message is for someone else's GUID, route it */
                    this.SendIPCMessage(message);
                    return;
                }

                /* Message is for us */
                try
                {
                    switch (message.Opcode)
                    {

                        case IPCOpcodeEnum.RegisterComponent:
                            if (this.OnRegisterComponent == null)
                                throw new NotImplementedException(String.Format("OnRegisterComponent handler not registered for {0}", this.ObjectGuid));

                            var registerComponentPacket =
                                this.IPCSerialiser.DeserialiseIPCMessage<RegisterComponentEventArgs>(e.Data);
                            this.OnRegisterComponent(sender, registerComponentPacket);
                            e.Cancel = registerComponentPacket.Cancel;
                            break;
                    }
                }
                catch (NotImplementedException ex)
                {
                    /* No handler registered - this isn't fatal, but unhandled packets should be registered to a NullHandler */
                    this.Log.WriteWarning(this.ObjectGuid, ex.ToString());
                    return;
                }
            }
            catch (Exception ex)
            {
                this.Log.WriteError(this.ObjectGuid, "Failed to parse IPC message {0}", e.ObjectGuid);
                this.Log.WriteError(this.ObjectGuid, ex.ToString());
                e.Cancel = true;
                return;
            }
        }

        public void SendIPCMessage(IIPCMessage message)
        {
            this.IPCInterface.SendIPCMessage(message);
        }

        public void ReceiveIPCMessage(IIPCMessage message)
        {
        }

        public event EventHandler<RegisterComponentEventArgs> OnRegisterComponent;
        public event EventHandler<RegisterComponentResponseEventArgs> OnRegisterComponentResponse;
        public event EventHandler<GetStatusEventArgs> OnGetStatus;
    }
}
