using Newtonsoft.Json;

namespace NEOS.EOS
{
    public class AccountAuthority
    {
        [JsonProperty("permission")]
        public Authorization Permission { get; set; }
        [JsonProperty("weight")]
        public ulong Weight { get; set; }
    }
}