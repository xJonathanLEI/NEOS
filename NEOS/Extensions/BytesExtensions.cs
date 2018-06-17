using System.Text;

namespace NEOS.Extensions
{
    public static class BytesExtensions
    {
        public static string ToHex(this byte[] input, bool prefix = true)
        {
            StringBuilder result = new StringBuilder();
            if (prefix)
                result.Append("0x");

            foreach (byte b in input)
                result.Append(b.ToString("x2"));

            return result.ToString();
        }
    }
}