using System;

namespace Hurricane.Shared.Components.Logon
{
    // ReSharper disable once InconsistentNaming
    public struct IPv4AddressStruct
    {
        public Byte Block1;
        public Byte Block2;
        public Byte Block3;
        public Byte Block4;

        public override String ToString()
        {
            return String.Format("{0}.{1}.{2}.{3}", this.Block1, this.Block2, this.Block3, this.Block4);
        }
    }
}