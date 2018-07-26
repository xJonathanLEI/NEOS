using Newtonsoft.Json;

namespace NEOS.EOS
{
    public class Permission
    {
        [JsonProperty("perm_name")]
        public string Name { get; set; }
        [JsonProperty("parent")]
        public string Parent { get; set; }
        [JsonProperty("required_auth")]
        public Authority RequiredAuth { get; set; }
    }
}