using System;
using Hurricane.Shared.Networking;

namespace Hurricane.Networking.HurricaneNetworker
{
    internal class HurricanePacket : INetworkPacket
    {
        public HurricanePacket()
        {
            ObjectGuid = Guid.NewGuid();
            DataBytes = new Byte[0];
            Position = 0;
        }

        public Byte[] DataBytes { get; set; }
        public UInt32 Position { get; set; }

        public void WriteByte(Byte data)
        {
            throw new NotImplementedException();
        }

        public void WriteBytes(Byte[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteBytes(Byte[] data, UInt32 position)
        {
            throw new NotImplementedException();
        }

        public void WriteInt16(Int16 data)
        {
            throw new NotImplementedException();
        }

        public void WriteUInt16(UInt16 data)
        {
            throw new NotImplementedException();
        }

        public void WriteInt32(Int32 data)
        {
            throw new NotImplementedException();
        }

        public void WriteUInt32(UInt32 data)
        {
            throw new NotImplementedException();
        }

        public void WriteInt64(Int64 data)
        {
            throw new NotImplementedException();
        }

        public void WriteUInt64(UInt64 data)
        {
            throw new NotImplementedException();
        }

        public void WriteSingle(Single data)
        {
            throw new NotImplementedException();
        }

        public void WriteDouble(Double data)
        {
            throw new NotImplementedException();
        }

        public void WriteCString(String data)
        {
            throw new NotImplementedException();
        }

        public void WriteWString(String data)
        {
            throw new NotImplementedException();
        }

        public Byte ReadByte()
        {
            throw new NotImplementedException();
        }

        public Byte[] ReadBytes()
        {
            throw new NotImplementedException();
        }

        public Byte[] ReadBytes(UInt32 position)
        {
            throw new NotImplementedException();
        }

        public Int16 ReadInt16()
        {
            throw new NotImplementedException();
        }

        public UInt16 ReadUInt16()
        {
            throw new NotImplementedException();
        }

        public Int32 ReadInt32()
        {
            throw new NotImplementedException();
        }

        public UInt32 ReadUInt32()
        {
            throw new NotImplementedException();
        }

        public Int64 ReadInt64()
        {
            throw new NotImplementedException();
        }

        public UInt64 ReadUInt64()
        {
            throw new NotImplementedException();
        }

        public Single ReadSingle()
        {
            throw new NotImplementedException();
        }

        public Double ReadDouble()
        {
            throw new NotImplementedException();
        }

        public String ReadCString()
        {
            throw new NotImplementedException();
        }

        public String ReadWString()
        {
            throw new NotImplementedException();
        }

        public Guid ObjectGuid { get; private set; }
    }
}