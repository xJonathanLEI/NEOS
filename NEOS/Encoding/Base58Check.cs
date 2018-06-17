using System;
using System.Numerics;
using System.Security.Cryptography;
using NEOS.Exceptions;
using NEOS.Extensions;

namespace NEOS.Encoding
{
    public class Base58Check
    {
        private const int CHECK_CODE_LENGTH = 4;
        private const int DEFAULT_VERSION_LENGTH = 1;

        public static string Encode(string version, string payload)
        {
            return Encode(version.ToBytes(), payload.ToBytes());
        }

        public static string Encode(byte[] version, byte[] payload)
        {
            // Concatenates version bytes with payload
            byte[] concatenated = new byte[version.Length + payload.Length + CHECK_CODE_LENGTH];
            Array.Copy(version, 0, concatenated, 0, version.Length);
            Array.Copy(payload, 0, concatenated, version.Length, payload.Length);

            // Adds checkcode
            using (var sha256 = SHA256.Create())
                Array.Copy(sha256.ComputeHash(sha256.ComputeHash(concatenated, 0, version.Length + payload.Length)), 0, concatenated, version.Length + payload.Length, CHECK_CODE_LENGTH);

            return Base58.Encode(concatenated);
        }

        public static Base58CheckData Decode(string encoded, int versionLength = DEFAULT_VERSION_LENGTH)
        {
            byte[] completeData = Base58.Decode(encoded);

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
