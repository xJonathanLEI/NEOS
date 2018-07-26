using Newtonsoft.Json;

namespace NEOS.EOS
{
    public class Authorization
    {
        [JsonProperty("actor")]
        public string Actor { get; set; }
        [JsonProperty("permission")]
        public string Permission { get; set; }
    }
}