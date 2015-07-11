using System;
using System.Linq;
using System.Net;
using System.Text;
using Hurricane.Shared.Networking;

namespace Hurricane.Networking.HurricaneNetworker
{
    internal class HurricanePacket : INetworkPacket
    {
        private Byte[] _internalBuffer = new Byte[0];

        public HurricanePacket()
        {
            this.ObjectGuid = Guid.NewGuid();
            this.Position = 0;
        }

        public Byte[] DataBytes
        {
            get { return this._internalBuffer; }
        }

        public Int32 Position { get; set; }

        public void WriteByte(Byte data)
        {
            this.WriteBytes(new[] {data});
        }

        public void WriteBytes(Byte[] data)
        {
            Array.Resize(ref this._internalBuffer, this._internalBuffer.Length + data.Length);
            Array.Copy(data, 0, this._internalBuffer, this.Position, data.Length);
            this.Position += data.Length;
        }

        public void WriteInt16(Int16 data)
        {
            var networkBytes = IPAddress.HostToNetworkOrder(data);
            this.WriteBytes(BitConverter.GetBytes(networkBytes));
        }

        public void WriteUInt16(UInt16 data)
        {
            var networkBytes = IPAddress.HostToNetworkOrder(data);
            this.WriteBytes(BitConverter.GetBytes(networkBytes));
        }

        public void WriteInt32(Int32 data)
        {
            var networkBytes = IPAddress.HostToNetworkOrder(data);
            this.WriteBytes(BitConverter.GetBytes(networkBytes));
        }

        public void WriteUInt32(UInt32 data)
        {
            var networkBytes = IPAddress.HostToNetworkOrder(data);
            this.WriteBytes(BitConverter.GetBytes(networkBytes));
        }

        public void WriteInt64(Int64 data)
        {
            var networkBytes = IPAddress.HostToNetworkOrder(data);
            this.WriteBytes(BitConverter.GetBytes(networkBytes));
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
            return this._internalBuffer[this.Position++];
        }

        public Byte[] ReadBytes(Int32 count)
        {
            var data = this.ReadBytes(count, this.Position);
            this.Position += count;
            return data;
        }

        public Byte[] ReadBytes(Int32 count, Int32 position)
        {
            var data = new Byte[count];
            Array.Copy(this._internalBuffer, position, data, 0, count);
            return data;
        }

        public Int16 ReadInt16()
        {
            var data = this.ReadBytes(2);
            return Convert.ToInt16(data.Reverse());
        }

        public UInt16 ReadUInt16()
        {
            var data = this.ReadBytes(2);
            return Convert.ToUInt16(data.Reverse());
        }

        public Int32 ReadInt32()
        {
            var data = this.ReadBytes(4);
            return Convert.ToInt32(data.Reverse());
        }

        public UInt32 ReadUInt32()
        {
            var data = this.ReadBytes(4);
            return Convert.ToUInt32(data.Reverse());
        }

        public Int64 ReadInt64()
        {
            var data = this.ReadBytes(8);
            return Convert.ToInt64(data.Reverse());
        }

        public UInt64 ReadUInt64()
        {
            var data = this.ReadBytes(8);
            return Convert.ToUInt64(data.Reverse());
        }

        public Single ReadSingle()
        {
            var data = this.ReadBytes(4);
            return Convert.ToSingle(data.Reverse());
        }

        public Double ReadDouble()
        {
            var data = this.ReadBytes(2);
            return Convert.ToDouble(data.Reverse());
        }

        public String ReadCString()
        {
            var sb = new StringBuilder();
            var b = this.ReadByte();
            while (b != 0x0)
            {
                sb.Append(b);
                b = this.ReadByte();
            }
            return sb.Length > 0 ? sb.ToString() : String.Empty;
        }

        public String ReadWString()
        {
            var stringLength = this.ReadUInt16();
            var stringBody = this.ReadBytes(stringLength);
            return Encoding.UTF8.GetString(stringBody);
        }

        public Guid ObjectGuid { get; private set; }
    }
}