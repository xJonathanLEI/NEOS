using Newtonsoft.Json;
using NEOS.Constants;

namespace NEOS.EOS
{
    public class TransactionReceipt
    {
        [JsonProperty("status")]
        public TransactionStatus Status { get; set; }
        [JsonProperty("cpu_usage_us")]
        public ulong CpuUsageUs { get; set; }
        [JsonProperty("net_usage_words")]
        public ulong NetUsageWords { get; set; }
        [JsonProperty("trx")]
        public TransactionInfo Trx { get; set; }
    }
}