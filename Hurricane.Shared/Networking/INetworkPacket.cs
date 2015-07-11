using System;
using Hurricane.Shared.Objects;

namespace Hurricane.Shared.Networking
{
    public interface INetworkPacket : IHurricaneObject
    {
        Byte[] DataBytes { get; set; }
        UInt32 Position { get; set; }

        void WriteByte(Byte data);
        void WriteBytes(Byte[] data);
        void WriteBytes(Byte[] data, UInt32 position);
        void WriteInt16(Int16 data);
        void WriteUInt16(UInt16 data);
        void WriteInt32(Int32 data);
        void WriteUInt32(UInt32 data);
        void WriteInt64(Int64 data);
        void WriteUInt64(UInt64 data);
        void WriteSingle(Single data);
        void WriteDouble(Double data);
        void WriteCString(String data);
        void WriteWString(String data);

        Byte ReadByte();
        Byte[] ReadBytes();
        Byte[] ReadBytes(UInt32 position);
        Int16 ReadInt16();
        UInt16 ReadUInt16();
        Int32 ReadInt32();
        UInt32 ReadUInt32();
        Int64 ReadInt64();
        UInt64 ReadUInt64();
        Single ReadSingle();
        Double ReadDouble();
        String ReadCString();
        String ReadWString();
    }
}