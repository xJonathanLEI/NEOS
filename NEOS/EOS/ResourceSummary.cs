using Newtonsoft.Json;

namespace NEOS.EOS
{
    public class ResourceSummary
    {
        [JsonProperty("owner")]
        public string Owner { get; set; }
        [JsonProperty("net_weight")]
        public string NetWeight { get; set; }
        [JsonProperty("cpu_weight")]
        public string CpuWeight { get; set; }
        [JsonProperty("ram_bytes")]
        public ulong RamBytes { get; set; }
    }
}