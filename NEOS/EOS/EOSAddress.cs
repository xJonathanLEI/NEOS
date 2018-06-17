using System;
using Org.BouncyCastle.Crypto.Digests;
using NEOS.Encoding;
using NEOS.Extensions;

namespace NEOS.EOS
{
    public class EOSAddress
    {
        public string AddressString
        {
            get
            {
                if (_addressString == null)
                {
                    // Computes check code
                    var ripemd160 = new Org.BouncyCastle.Crypto.Digests.RipeMD160Digest();
                    ripemd160.BlockUpdate(compressedKeyData, 0, compressedKeyData.Length);
                    byte[] checkHash = new byte[20];
                    ripemd160.DoFinal(checkHash, 0);

                    // Encodes result
                    byte[] complete = new byte[compressedKeyData.Length + CHECK_CODE_LENGTH];
                    Array.Copy(compressedKeyData, 0, complete, 0, compressedKeyData.Length);
                    Array.Copy(checkHash, 0, complete, compressedKeyData.Length, CHECK_CODE_LENGTH);
                    _addressString = $"{ADDRESS_PREFIX}{Base58.Encode(complete)}";
                }
                return _addressString;
            }
        }

        private byte[] compressedKeyData;
        private string _addressString = null;

        private const string ADDRESS_PREFIX = "EOS";
        private const int KEY_LENGTH = 33;
        private const int CHECK_CODE_LENGTH = 4;

        public EOSAddress(byte[] compressedKeyData)
        {
            if (compressedKeyData.Length != KEY_LENGTH)
                throw new Exception($"Compressed key must be {KEY_LENGTH} bytes");

            this.compressedKeyData = new byte[compressedKeyData.Length];
            Array.Copy(compressedKeyData, 0, this.compressedKeyData, 0, compressedKeyData.Length);
        }

        public EOSAddress(string encodedAddress)
        {
            if (!encodedAddress.StartsWith(ADDRESS_PREFIX))
                throw new ArgumentException($"Invalid address format. Must start with {ADDRESS_PREFIX}");
            encodedAddress = encodedAddress.Remove(0, ADDRESS_PREFIX.Length);

            this.compressedKeyData = new byte[KEY_LENGTH];
            Array.Copy(Base58.Decode(encodedAddress), 0, compressedKeyData, 0, KEY_LENGTH);
        }
    }
}