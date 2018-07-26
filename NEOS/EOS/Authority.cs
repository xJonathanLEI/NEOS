using Newtonsoft.Json;

namespace NEOS.EOS
{
    public class Authority
    {
        [JsonProperty("threshold")]
        public ulong Threshold { get; set; }
        [JsonProperty("keys")]
        public KeyAuthority[] Keys { get; set; }
        [JsonProperty("accounts")]
        public AccountAuthority[] Accounts { get; set; }
        [JsonProperty("waits")]
        public object[] Waits { get; set; }
    }
}