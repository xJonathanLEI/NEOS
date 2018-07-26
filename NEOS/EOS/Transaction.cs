using System;
using Newtonsoft.Json;

namespace NEOS.EOS
{
    public class Transaction
    {
        [JsonProperty("expiration")]
        public DateTime Expiration { get; set; }
        [JsonProperty("ref_block_num")]
        public ulong RefBlockNum { get; set; }
        [JsonProperty("ref_block_prefix")]
        public ulong RefBlockPrefix { get; set; }
        [JsonProperty("max_net_usage_words")]
        public ulong MaxNetUsageWords { get; set; }
        [JsonProperty("max_cpu_usage_ms")]
        public ulong MaxCpuUsageMs { get; set; }
        [JsonProperty("delay_sec")]
        public ulong DelaySec { get; set; }
        [JsonProperty("context_free_actions")]
        public object[] ContextFreeActions { get; set; }
        [JsonProperty("actions")]
        public Action[] Actions { get; set; }
    }
}