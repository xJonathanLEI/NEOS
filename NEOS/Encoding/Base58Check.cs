using System;
using System.Text;
using System.Numerics;
using System.Security.Cryptography;
using NEOS.Extensions;

namespace NEOS.Encoding
{
    public class Base58Check
    {
        private static string SYMBOL_CHART = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz";
        private const int CHECK_CODE_LENGTH = 4;
        private const int SYMBOL_COUNT = 58;

        public static string Encode(string version, string payload)
        {
            return Encode(version.ToBytes(), payload.ToBytes());
        }

        public static string Encode(byte[] version, byte[] payload)
        {
            string result = "";

            // Concatenates version bytes with payload
            byte[] concatenated = new byte[version.Length + payload.Length + CHECK_CODE_LENGTH + 1];
            Array.Copy(version, 0, concatenated, 1, version.Length);
            Array.Copy(payload, 0, concatenated, 1 + version.Length, payload.Length);

            // Adds checkcode
            using (var sha256 = SHA256.Create())
                Array.Copy(sha256.ComputeHash(sha256.ComputeHash(concatenated, 1, version.Length + payload.Length)), 0, concatenated, 1 + version.Length + payload.Length, CHECK_CODE_LENGTH);

            // System.Numerics.BigInteger uses little-endian
            Array.Reverse(concatenated);
            BigInteger value = new BigInteger(concatenated);

            // Base58 encode
            while (value > 0)
            {
                BigInteger quotient = value / SYMBOL_COUNT;
                BigInteger remainder = value - quotient * SYMBOL_COUNT;
                result = SYMBOL_CHART[(int)remainder] + result;
                value = quotient;
            }

            // Counts number of leading zeros
            for (int i = concatenated.Length - 2; i >= 0; i--)
                if (concatenated[i] == 0)
                    result = SYMBOL_CHART[0] + result;
                else
                    break;

            return result.ToString();
        }
    }
}
