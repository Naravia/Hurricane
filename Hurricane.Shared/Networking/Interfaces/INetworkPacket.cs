using System;
using Hurricane.Shared.Objects.Interfaces;

namespace Hurricane.Shared.Networking.Interfaces
{
    public interface INetworkPacket : IHurricaneObject
    {
        Byte[] DataBytes { get; }
        Int32 Position { get; set; }
        void WriteByte(Byte data);
        void WriteBytes(Byte[] data);
        void WriteInt16(Int16 data, Boolean reverse);
        void WriteUInt16(UInt16 data, Boolean reverse);
        void WriteInt32(Int32 data, Boolean reverse);
        void WriteUInt32(UInt32 data, Boolean reverse);
        void WriteInt64(Int64 data, Boolean reverse);
        void WriteUInt64(UInt64 data, Boolean reverse);
        void WriteSingle(Single data, Boolean reverse);
        void WriteDouble(Double data, Boolean reverse);
        void WriteFixedString(String data, Int32 stringLength, Boolean reverse);
        void WriteCString(String data, Boolean reverse);
        void WriteBString(String data, Boolean reverse);
        void WriteWString(String data, Boolean reverse);
        Byte ReadByte();
        Byte[] ReadBytes(Int32 count);
        Byte[] ReadBytes(Int32 count, Int32 position);
        Int16 ReadInt16(Boolean reverse);
        UInt16 ReadUInt16(Boolean reverse);
        Int32 ReadInt32(Boolean reverse);
        UInt32 ReadUInt32(Boolean reverse);
        Int64 ReadInt64(Boolean reverse);
        UInt64 ReadUInt64(Boolean reverse);
        Single ReadSingle(Boolean reverse);
        Double ReadDouble(Boolean reverse);
        String ReadFixedString(Int32 stringLength, Boolean reverse);
        String ReadCString(Boolean reverse);
        String ReadBString(Boolean reverse);
        String ReadWString(Boolean reverse);
    }
}