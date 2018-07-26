using Newtonsoft.Json;

namespace NEOS.EOS
{
    public class Action
    {
        [JsonProperty("account")]
        public string Account { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("authorization")]
        public Authorization[] Authorization { get; set; }
        [JsonProperty("data")]
        public object data { get; set; }
        [JsonProperty("hex_data")]
        public string HexData { get; set; }
    }
}