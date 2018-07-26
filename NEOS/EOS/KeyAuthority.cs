using Newtonsoft.Json;

namespace NEOS.EOS
{
    public class KeyAuthority
    {
        [JsonProperty("key")]
        public string Key { get; set; }
        [JsonProperty("weight")]
        public ulong Weight { get; set; }
    }
}