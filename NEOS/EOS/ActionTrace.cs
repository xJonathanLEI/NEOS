using System;
using Newtonsoft.Json;

namespace NEOS.EOS
{
    public class ActionTrace
    {
        [JsonProperty("receipt")]
        public ActionReceipt Receipt { get; set; }
        [JsonProperty("act")]
        public Action Act { get; set; }
        [JsonProperty("elapsed")]
        public ulong Elapsed { get; set; }
        [JsonProperty("cpu_usage")]
        public ulong CpuUsage { get; set; }
        [JsonProperty("console")]
        public string Console { get; set; }
        [JsonProperty("total_cpu_usage")]
        public ulong TotalCpuUsage { get; set; }
        [JsonProperty("trx_id")]
        public string TrxId { get; set; }
        [JsonProperty("inline_traces")]
        public ActionTrace[] InlineTraces { get; set; }
    }
}