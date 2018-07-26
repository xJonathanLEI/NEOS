using System.Numerics;
using Newtonsoft.Json;

namespace NEOS.EOS
{
    public class ResourceLimit
    {
        [JsonProperty("used")]
        public BigInteger Used { get; set; }
        [JsonProperty("available")]
        public BigInteger Available { get; set; }
        [JsonProperty("max")]
        public BigInteger Max { get; set; }
    }
}