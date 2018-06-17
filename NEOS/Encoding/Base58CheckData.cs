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
    }
}