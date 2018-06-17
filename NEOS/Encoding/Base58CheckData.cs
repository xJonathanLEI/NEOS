using System;
using System.Linq;
using NEOS.Extensions;

namespace NEOS.Encoding
{
    public class Base58CheckData
    {
        public byte[] Version { get; }
        public byte[] Payload { get; }

        public Base58CheckData(string version, string payload) : this(version.ToBytes(), payload.ToBytes()) { }

        public Base58CheckData(byte[] version, byte[] payload)
        {
            this.Version = version;
            this.Payload = payload;
        }

        public override string ToString()
        {
            return $"{{Version = {this.Version.ToHex()}, Payload = {this.Payload.ToHex()}}}";
        }

        public override int GetHashCode()
        {
            return this.Version.GetHashCode() / 2 + this.Payload.GetHashCode() / 2;
        }

        public override bool Equals(object obj)
        {
            if (obj is Base58CheckData data)
                return data.Version.SequenceEqual(this.Version) && data.Payload.SequenceEqual(this.Payload);
            else
                return false;
        }
    }
}