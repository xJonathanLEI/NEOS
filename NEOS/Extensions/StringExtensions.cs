using System;
using System.Globalization;

namespace NEOS.Extensions
{
    internal static class StringExtensions
    {
        private const int HEX = 16;

        public static byte[] ToBytes(this string input, int radix = HEX)
        {
            if (radix == HEX)
            {
                return HexToBytes(input);
            }
            else
            {
                throw new ArgumentException($"Invalid radix: {radix}");
            }
        }

        private static byte[] HexToBytes(string input)
        {
            if (input.StartsWith("0x"))
                input = input.Remove(0, 2);
            if (input.Length % 2 != 0)
                input = "0" + input;
            byte[] ret = new byte[input.Length / 2];
            for (int i = 0; i < ret.Length; i++)
                ret[i] = byte.Parse(input.Substring(i * 2, 2), NumberStyles.HexNumber);
            return ret;
        }
    }
}