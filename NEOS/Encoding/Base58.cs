using System;
using System.Numerics;
using NEOS.Extensions;

namespace NEOS.Encoding
{
    public class Base58
    {
        private static string SYMBOL_CHART = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz";
        private const int SYMBOL_COUNT = 58;

        public static string Encode(string data)
        {
            return Encode(data.ToBytes());
        }

        public static string Encode(byte[] data)
        {
            string result = "";

            // System.Numerics.BigInteger uses little-endian
            byte[] littleEndianData = new byte[data.Length + 1];
            Array.Copy(data, 0, littleEndianData, 1, data.Length);
            Array.Reverse(littleEndianData);
            BigInteger value = new BigInteger(littleEndianData);

            // Base58 encode
            while (value > 0)
            {
                BigInteger quotient = value / SYMBOL_COUNT;
                BigInteger remainder = value - quotient * SYMBOL_COUNT;
                result = SYMBOL_CHART[(int)remainder] + result;
                value = quotient;
            }

            // Counts number of leading zeros
            for (int i = 0; i < data.Length; i++)
                if (data[i] == 0)
                    result = SYMBOL_CHART[0] + result;
                else
                    break;

            return result;
        }

        public static byte[] Decode(string encoded)
        {
            // Counts leading zeros
            int leadingZeros = 0;
            for (int i = 0; i < encoded.Length; i++)
                if (encoded[i] == SYMBOL_CHART[0])
                    leadingZeros++;
                else
                    break;

            // Converts into bytes
            BigInteger value = 0;
            BigInteger order = 1;
            for (int i = encoded.Length - 1; i >= leadingZeros; i--)
            {
                value += SYMBOL_CHART.IndexOf(encoded[i]) * order;
                order *= SYMBOL_COUNT;
            }
            byte[] valueBytes = value.ToByteArray();
            Array.Reverse(valueBytes);

            // Handles leading zeros
            int bytesToAdd;
            if (leadingZeros == 0)
                bytesToAdd = valueBytes[0] == 0 ? -1 : 0;
            else
                bytesToAdd = valueBytes[0] == 0 ? leadingZeros - 1 : leadingZeros;
            byte[] completeData;
            if (bytesToAdd == 0)
                completeData = valueBytes;
            else
            {
                completeData = new byte[valueBytes.Length + bytesToAdd];
                if (bytesToAdd > 0)
                    Array.Copy(valueBytes, 0, completeData, bytesToAdd, valueBytes.Length);
                else
                    Array.Copy(valueBytes, -bytesToAdd, completeData, 0, completeData.Length);
            }

            return completeData;
        }
    }
}