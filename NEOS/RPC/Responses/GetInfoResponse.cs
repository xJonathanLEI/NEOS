using System;
using Newtonsoft.Json;

namespace NEOS.RPC.Responses
{
    public class GetInfoResponse
    {
        [JsonProperty("server_version")]
        public string ServerVersion { get; set; }
        [JsonProperty("chain_id")]
        public string ChainId { get; set; }
        [JsonProperty("head_block_num")]
        public ulong HeadBlockNum { get; set; }
        [JsonProperty("last_irreversible_block_num")]
        public ulong LastIrreversibleBlockNum { get; set; }
        [JsonProperty("last_irreversible_block_id")]
        public string LastIrreversibleBlockId { get; set; }
        [JsonProperty("head_block_id")]
        public string HeadBlockId { get; set; }
        [JsonProperty("head_block_time")]
        public DateTime HeadBlockTime { get; set; }
        [JsonProperty("head_block_producer")]
        public string HeadBlockProducer { get; set; }
        [JsonProperty("virtual_block_cpu_limit")]
        public long VirtualBlockCpuLimit { get; set; }
        [JsonProperty("virtual_block_net_limit")]
        public long VirtualBlockNetLimit { get; set; }
        [JsonProperty("block_cpu_limit")]
        public long BlockCpuLimit { get; set; }
        [JsonProperty("block_net_limit")]
        public long BlockNetLimit { get; set; }
    }
}