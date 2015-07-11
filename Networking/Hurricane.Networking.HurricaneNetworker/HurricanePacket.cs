using System;
using System.Linq;
using System.Net;
using System.Text;
using Hurricane.Networking.HurricaneNetworker.Extensions;
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

        public void WriteInt16(Int16 data, Boolean reverse)
        {
            var bytes = BitConverter.GetBytes(data);
            if (reverse) Array.Reverse(bytes);
            this.WriteBytes(bytes);
        }

        public void WriteUInt16(UInt16 data, Boolean reverse)
        {
            var bytes = BitConverter.GetBytes(data);
            if (reverse) Array.Reverse(bytes);
            this.WriteBytes(bytes);
        }

        public void WriteInt32(Int32 data, Boolean reverse)
        {
            var bytes = BitConverter.GetBytes(data);
            if (reverse) Array.Reverse(bytes);
            this.WriteBytes(bytes);
        }

        public void WriteUInt32(UInt32 data, Boolean reverse)
        {
            var bytes = BitConverter.GetBytes(data);
            if (reverse) Array.Reverse(bytes);
            this.WriteBytes(bytes);
        }

        public void WriteInt64(Int64 data, Boolean reverse)
        {
            var bytes = BitConverter.GetBytes(data);
            if (reverse) Array.Reverse(bytes);
            this.WriteBytes(bytes);
        }

        public void WriteUInt64(UInt64 data, Boolean reverse)
        {
            var bytes = BitConverter.GetBytes(data);
            if (reverse) Array.Reverse(bytes);
            this.WriteBytes(bytes);
        }

        public void WriteSingle(Single data, Boolean reverse)
        {
            var bytes = BitConverter.GetBytes(data);
            if (reverse) Array.Reverse(bytes);
            this.WriteBytes(bytes);
        }

        public void WriteDouble(Double data, Boolean reverse)
        {
            var bytes = BitConverter.GetBytes(data);
            if (reverse) Array.Reverse(bytes);
            this.WriteBytes(bytes);
        }

        public void WriteFixedString(String data, Int32 stringLength, Boolean reverse)
        {
            if (reverse)
                data = data.ReverseString();

            for (var i = 0; i < stringLength; ++i)
            {
                if (i < data.Length)
                    this.WriteByte((Byte)data[i]);
                else
                    this.WriteByte(0x0);
            }
        }

        public void WriteCString(String data, Boolean reverse)
        {
            var bytes = new Byte[data.Length + 1];
            if (reverse)
                data = data.ReverseString();

            Array.Copy(sourceArray: data.ToCharArray(), destinationArray: bytes, length: bytes.Length - 1);
            bytes[bytes.Length - 1] = 0x0;
            this.WriteBytes(data: bytes);
        }

        public void WriteBString(String data, Boolean reverse)
        {
            if (reverse)
                data = data.ReverseString();

            this.WriteByte(data: Convert.ToByte(value: data.Length));
            this.WriteFixedString(data: data, stringLength: data.Length, reverse: false);
        }

        public void WriteWString(String data, Boolean reverse)
        {
            if (reverse)
                data = data.ReverseString();

            this.WriteUInt16(data: Convert.ToUInt16(value: data.Length), reverse: reverse);
            this.WriteFixedString(data: data, stringLength: data.Length, reverse: false);
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

        public Int16 ReadInt16(Boolean reverse)
        {
            var data = this.ReadBytes(2);
            if (reverse) data = data.Reverse().ToArray();
            return BitConverter.ToInt16(data, 0);
        }

        public UInt16 ReadUInt16(Boolean reverse)
        {
            var data = this.ReadBytes(2);
            if (reverse) Array.Reverse(data);
            return BitConverter.ToUInt16(data, 0);
        }

        public Int32 ReadInt32(Boolean reverse)
        {
            var data = this.ReadBytes(4);
            if (reverse) Array.Reverse(data);
            return BitConverter.ToInt32(data, 0);
        }

        public UInt32 ReadUInt32(Boolean reverse)
        {
            var data = this.ReadBytes(4);
            if (reverse) Array.Reverse(data);
            return BitConverter.ToUInt32(data, 0);
        }

        public Int64 ReadInt64(Boolean reverse)
        {
            var data = this.ReadBytes(8);
            if (reverse) Array.Reverse(data);
            return BitConverter.ToInt64(data, 0);
        }

        public UInt64 ReadUInt64(Boolean reverse)
        {
            var data = this.ReadBytes(8);
            if (reverse) Array.Reverse(data);
            return BitConverter.ToUInt64(data, 0);
        }

        public Single ReadSingle(Boolean reverse)
        {
            var data = this.ReadBytes(4);
            if (reverse) Array.Reverse(data);
            return BitConverter.ToSingle(data, 0);
        }

        public Double ReadDouble(Boolean reverse)
        {
            var data = this.ReadBytes(8);
            if (reverse) Array.Reverse(data);
            return BitConverter.ToDouble(data, 0);
        }

        public String ReadFixedString(Int32 stringLength, Boolean reverse)
        {
            var data = this.ReadBytes(stringLength);
            var str = Encoding.UTF8.GetString(data);
            if (reverse) str = str.ReverseString();
            return str;
        }

        public String ReadCString(Boolean reverse)
        {
            var sb = new StringBuilder();
            var b = this.ReadByte();
            while (b != 0x0)
            {
                sb.Append(b);
                b = this.ReadByte();
            }
            var str =  sb.Length > 0 ? sb.ToString() : String.Empty;
            if (reverse) str = str.ReverseString();
            return str;
        }

        public String ReadBString(Boolean reverse)
        {
            var stringLength = this.ReadByte();
            var stringBody = this.ReadBytes(stringLength);
            var str = Encoding.UTF8.GetString(stringBody);
            if (reverse) str = str.ReverseString();
            return str;
        }

        public String ReadWString(Boolean reverse)
        {
            var stringLength = this.ReadUInt16(reverse);
            var stringBody = this.ReadBytes(stringLength);
            var str = Encoding.UTF8.GetString(stringBody);
            if (reverse) str = str.ReverseString();
            return str;
        }

        public Guid ObjectGuid { get; private set; }
    }
}