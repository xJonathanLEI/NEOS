using System;
using Newtonsoft.Json;

namespace NEOS.EOS
{
    public class ActionInfo
    {
        [JsonProperty("global_action_seq")]
        public ulong GlobalActionSeq { get; set; }
        [JsonProperty("account_action_seq")]
        public ulong AccountActionSeq { get; set; }
        [JsonProperty("block_num")]
        public ulong BlockNum { get; set; }
        [JsonProperty("block_time")]
        public DateTime BlockTime { get; set; }
        [JsonProperty("action_trace")]
        public ActionTrace ActionTrace { get; set; }
    }
}