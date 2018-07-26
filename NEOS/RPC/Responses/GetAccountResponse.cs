using System;
using Newtonsoft.Json;
using NEOS.EOS;

namespace NEOS.RPC.Responses
{
    public class GetAccountResponse
    {
        [JsonProperty("account_name")]
        public string AccountName { get; set; }
        [JsonProperty("head_block_num")]
        public ulong HeadBlockNum { get; set; }
        [JsonProperty("head_block_time")]
        public DateTime HeadBlockTime { get; set; }
        [JsonProperty("privileged")]
        public bool Privileged { get; set; }
        [JsonProperty("last_code_update")]
        public DateTime LastCodeUpdate { get; set; }
        [JsonProperty("created")]
        public DateTime Created { get; set; }
        [JsonProperty("ram_quota")]
        public ulong RamQuota { get; set; }
        [JsonProperty("net_weight")]
        public ulong NetWeight { get; set; }
        [JsonProperty("cpu_weight")]
        public ulong CpuWeight { get; set; }
        [JsonProperty("net_limit")]
        public ResourceLimit NetLimit { get; set; }
        [JsonProperty("cpu_limit")]
        public ResourceLimit CpuLimit { get; set; }
        [JsonProperty("ram_usage")]
        public ulong RamUsage { get; set; }
        [JsonProperty("permissions")]
        public Permission[] Permissions { get; set; }
        [JsonProperty("total_resources")]
        public ResourceSummary TotalResources { get; set; }
        [JsonProperty("self_delegated_bandwidth")]
        public object SelfDelegatedBandwidth { get; set; }
        [JsonProperty("refund_request")]
        public object RefundRequest { get; set; }
        [JsonProperty("voter_info")]
        public object VoterInfo { get; set; }
    }
}