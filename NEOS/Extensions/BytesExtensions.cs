using System.Text;

namespace NEOS.Extensions
{
    public static class BytesExtensions
    {
        public static string ToHex(this byte[] input, bool prefix = true, int offset = 0, int length = -1)
        {
            StringBuilder result = new StringBuilder();
            if (prefix)
                result.Append("0x");

            int endIndex = length == -1 ? input.Length - offset : offset + length;

            for (int i = offset; i < endIndex; i++)
                result.Append(input[i].ToString("x2"));

            return result.ToString();
        }
    }
}