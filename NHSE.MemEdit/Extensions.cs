namespace NHSE.MemEdit
{
    public static class Extensions
    {
        public static string ToHex( this byte value )
        {
            return value.ToString( "X" );
        }

        public static string ToHex( this short value )
        {
            return value.ToString( "X" );
        }

        public static string ToHex( this int value )
        {
            return value.ToString( "X" );
        }

        public static string ToHex( this long value )
        {
            return value.ToString( "X" );
        }
    }
}
