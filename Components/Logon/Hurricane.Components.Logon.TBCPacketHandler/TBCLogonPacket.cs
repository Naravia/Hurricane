using System;
using Hurricane.Shared.Components.Logon.Packets;
using Hurricane.Shared.Logging.Interfaces;
using Hurricane.Shared.Networking.Interfaces;

namespace Hurricane.Components.Logon.TBCPacketHandler
{
    public class TBCLogonPacket : ILogonPacket
    {
        private readonly INetworkPacket _networkPacket;

        public TBCLogonPacket(INetworkPacket networkPacket, ILogger log)
        {
            this.ObjectGuid = Guid.NewGuid();

            networkPacket.Position = 0;
            this._networkPacket = networkPacket;
            this.Log = log;
            this.Opcode = this.ReadByte();
            this.Error = this.ReadByte();
            this.Size = this.ReadUInt16(false);
        }

        public Byte Opcode { get; set; }
        public Byte Error { get; set; }
        public UInt16 Size { get; set; }
        public Guid ObjectGuid { get; private set; }
        public Byte[] DataBytes { get; private set; }
        public Int32 Position { get; set; }

        public void WriteByte(Byte data)
        {
            this._networkPacket.WriteByte(data: data);
        }

        public void WriteBytes(Byte[] data)
        {
            this._networkPacket.WriteBytes(data: data);
        }

        public void WriteInt16(Int16 data, Boolean reverse)
        {
            this._networkPacket.WriteInt16(data: data, reverse: reverse);
        }

        public void WriteUInt16(UInt16 data, Boolean reverse)
        {
            this._networkPacket.WriteUInt16(data: data, reverse: reverse);
        }

        public void WriteInt32(Int32 data, Boolean reverse)
        {
            this._networkPacket.WriteInt32(data: data, reverse: reverse);
        }

        public void WriteUInt32(UInt32 data, Boolean reverse)
        {
            this._networkPacket.WriteUInt32(data: data, reverse: reverse);
        }

        public void WriteInt64(Int64 data, Boolean reverse)
        {
            this._networkPacket.WriteInt64(data: data, reverse: reverse);
        }

        public void WriteUInt64(UInt64 data, Boolean reverse)
        {
            this._networkPacket.WriteUInt64(data: data, reverse: reverse);
        }

        public void WriteSingle(Single data, Boolean reverse)
        {
            this._networkPacket.WriteSingle(data: data, reverse: reverse);
        }

        public void WriteDouble(Double data, Boolean reverse)
        {
            this._networkPacket.WriteDouble(data: data, reverse: reverse);
        }

        public void WriteFixedString(String data, Int32 stringLength, Boolean reverse)
        {
            this._networkPacket.WriteFixedString(data: data, stringLength: stringLength, reverse: reverse);
        }

        public void WriteCString(String data, Boolean reverse)
        {
            this._networkPacket.WriteCString(data: data, reverse: reverse);
        }

        public void WriteBString(String data, Boolean reverse)
        {
            this._networkPacket.WriteBString(data: data, reverse: reverse);
        }

        public void WriteWString(String data, Boolean reverse)
        {
            this._networkPacket.WriteWString(data: data, reverse: reverse);
        }

        public Byte ReadByte()
        {
            return this._networkPacket.ReadByte();
        }

        public Byte[] ReadBytes(Int32 count)
        {
            return this._networkPacket.ReadBytes(count: count);
        }

        public Byte[] ReadBytes(Int32 count, Int32 position)
        {
            return this._networkPacket.ReadBytes(count: count, position: position);
        }

        public Int16 ReadInt16(Boolean reverse)
        {
            return this._networkPacket.ReadInt16(reverse: reverse);
        }

        public UInt16 ReadUInt16(Boolean reverse)
        {
            return this._networkPacket.ReadUInt16(reverse: reverse);
        }

        public Int32 ReadInt32(Boolean reverse)
        {
            return this._networkPacket.ReadInt32(reverse: reverse);
        }

        public UInt32 ReadUInt32(Boolean reverse)
        {
            return this._networkPacket.ReadUInt32(reverse: reverse);
        }

        public Int64 ReadInt64(Boolean reverse)
        {
            return this._networkPacket.ReadInt64(reverse: reverse);
        }

        public UInt64 ReadUInt64(Boolean reverse)
        {
            return this._networkPacket.ReadUInt64(reverse: reverse);
        }

        public Single ReadSingle(Boolean reverse)
        {
            return this._networkPacket.ReadSingle(reverse: reverse);
        }

        public Double ReadDouble(Boolean reverse)
        {
            return this._networkPacket.ReadDouble(reverse: reverse);
        }

        public String ReadFixedString(Int32 stringLength, Boolean reverse)
        {
            return this._networkPacket.ReadFixedString(stringLength: stringLength, reverse: reverse);
        }

        public String ReadCString(Boolean reverse)
        {
            return this._networkPacket.ReadCString(reverse: reverse);
        }

        public String ReadBString(Boolean reverse)
        {
            return this._networkPacket.ReadBString(reverse: reverse);
        }

        public String ReadWString(Boolean reverse)
        {
            return this._networkPacket.ReadWString(reverse: reverse);
        }

        public ILogger Log { get; private set; }
    }
}