using Newtonsoft.Json;

namespace NEOS.EOS
{
    public class ActionReceipt
    {
        [JsonProperty("receiver")]
        public string Receiver { get; set; }
        [JsonProperty("act_digest")]
        public string ActDigest { get; set; }
        [JsonProperty("global_sequence")]
        public ulong GlobalSequence { get; set; }
        [JsonProperty("recv_sequence")]
        public ulong RecvSequance { get; set; }
        [JsonProperty("auth_sequence")]
        public object[][] AuthSequence { get; set; }
        [JsonProperty("code_sequence")]
        public ulong CodeSequence { get; set; }
        [JsonProperty("abi_sequence")]
        public ulong AbiSequence { get; set; }
    }
}