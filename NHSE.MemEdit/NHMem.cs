using Memory;

namespace NHSE.MemEdit
{
    public class NHMem : Mem
    {
        public byte ReadByte( long address )
        {
            return ( byte )ReadByte( address.ToHex() );
        }

        public short ReadShort( long address )
        {
            return (short)Read2Byte( address.ToHex() );
        }

        public int ReadInt( long address )
        {
            return ReadInt( address.ToHex() );
        }

        public long ReadLong( long address )
        {
            return ReadLong( address.ToHex() );
        }

    }
}
