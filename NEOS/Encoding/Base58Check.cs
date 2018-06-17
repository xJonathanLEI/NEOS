using System;
using System.Numerics;
using System.Security.Cryptography;
using NEOS.Exceptions;
using NEOS.Extensions;

namespace NEOS.Encoding
{
    public class Base58Check
    {
        private static string SYMBOL_CHART = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz";
        private const int CHECK_CODE_LENGTH = 4;
        private const int SYMBOL_COUNT = 58;
        private const int DEFAULT_VERSION_LENGTH = 1;

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

        public static Base58CheckData Decode(string encoded, int versionLength = DEFAULT_VERSION_LENGTH)
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

            // Verifies check code
            using (var sha256 = SHA256.Create())
            {
                byte[] checkHash = sha256.ComputeHash(sha256.ComputeHash(completeData, 0, completeData.Length - CHECK_CODE_LENGTH));
                for (int i = 0; i < CHECK_CODE_LENGTH; i++)
                    if (checkHash[i] != completeData[completeData.Length - CHECK_CODE_LENGTH + i])
                        throw new CheckCodeException();
            }

            // Splits data into version and payload
            byte[] version = new byte[versionLength];
            byte[] payload = new byte[completeData.Length - versionLength - CHECK_CODE_LENGTH];
            Array.Copy(completeData, 0, version, 0, versionLength);
            Array.Copy(completeData, versionLength, payload, 0, payload.Length);

            return new Base58CheckData(version, payload);
        }
    }
}
