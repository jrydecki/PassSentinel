using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassSentinel
{
    public static class Util
    {
        public static string Decode(byte[] input)
        {
            return Encoding.ASCII.GetString(input);
        } // end Decode

        public static byte[] Encode(string input)
        {
            return Encoding.ASCII.GetBytes(input);
        } // end Encode

    } // end class
}
