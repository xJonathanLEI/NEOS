using System;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto.EC;
using NEOS.EOS;

namespace NEOS.Key
{
    public class PubKey
    {
        public bool IsCompressed { get { return data.Length == COMPRESSED_LENGTH; } }

        private byte[] data;

        private const int UNCOMPRESSED_LENGTH = 65;
        private const int COMPRESSED_LENGTH = 33;
        private const int COOR_LENGTH = 32;

        private const byte EVEN_PREFIX = 2;
        private const byte ODD_PREFIX = 3;
        private const byte UNCOMPRESSED_PREFIX = 4;

        private const string CURVE_NAME = "secp256k1";

        private static X9ECParameters CURVE_PARS = CustomNamedCurves.GetByName(CURVE_NAME);

        public PubKey(byte[] data)
        {
            if (data.Length != UNCOMPRESSED_LENGTH && data.Length != COMPRESSED_LENGTH)
                throw new ArgumentException($"Invalid public key length {data.Length}");

            this.data = new byte[data.Length];
            Array.Copy(data, 0, this.data, 0, data.Length);
        }

        public byte[] GetEncoded()
        {
            return data;
        }

        public EOSAddress GetEOSAddress()
        {
            if (IsCompressed)
                return new EOSAddress(data);
            return new EOSAddress(Compress().data);
        }

        public PubKey Compress()
        {
            if (IsCompressed)
                return new PubKey(data);

            byte[] newKey = new byte[COMPRESSED_LENGTH];
            newKey[0] = data[data.Length - 1] % 2 == 0 ? EVEN_PREFIX : ODD_PREFIX;
            Array.Copy(data, 1, newKey, 1, COOR_LENGTH);

            return new PubKey(newKey);
        }

        public PubKey Decompress()
        {
            if (!IsCompressed)
                return new PubKey(data);

            var point = CURVE_PARS.Curve.DecodePoint(data).Normalize();
            byte[] newKey = new byte[UNCOMPRESSED_LENGTH];
            newKey[0] = UNCOMPRESSED_PREFIX;
            Array.Copy(point.XCoord.ToBigInteger().ToByteArrayUnsigned(), 0, newKey, 1, COOR_LENGTH);
            Array.Copy(point.YCoord.ToBigInteger().ToByteArrayUnsigned(), 0, newKey, 1 + COOR_LENGTH, COOR_LENGTH);

            return new PubKey(newKey);
        }
    }
}