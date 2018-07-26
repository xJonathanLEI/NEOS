using Newtonsoft.Json;

namespace NEOS.EOS
{
    public class TransactionInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("signatures")]
        public string[] Signatures { get; set; }
        [JsonProperty("compression")]
        public string Compression { get; set; }
        [JsonProperty("packed_context_free_data")]
        public string PackedContextFreeData { get; set; }
        [JsonProperty("context_free_data")]
        public object[] ContextFreeData { get; set; }
        [JsonProperty("packed_trx")]
        public string PackedTrx { get; set; }
        [JsonProperty("transaction")]
        public Transaction Transaction { get; set; }
    }
}