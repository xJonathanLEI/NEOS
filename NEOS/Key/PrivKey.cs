using System;
using NEOS.Extensions;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto.EC;

namespace NEOS.Key
{
    public class PrivKey
    {
        public byte[] Data { get; }

        private const int KEY_LENGTH = 32;

        private const string CURVE_NAME = "secp256k1";

        private static X9ECParameters CURVE_PARS = CustomNamedCurves.GetByName(CURVE_NAME);

        public PrivKey(byte[] data, int offset = 0)
        {
            Data = new byte[KEY_LENGTH];
            Array.Copy(data, 0, Data, offset, KEY_LENGTH);
        }

        public PubKey GetPubKey(bool compressed = true)
        {
            PubKey uncompressedKey = new PubKey(CURVE_PARS.G.Multiply(new BigInteger(1, Data)).GetEncoded());
            if (!compressed)
                return uncompressedKey;
            return uncompressedKey.Compress();
        }

        public override string ToString()
        {
            return Data.ToHex();
        }
    }
}