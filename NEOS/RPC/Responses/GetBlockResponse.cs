using System;
using Newtonsoft.Json;
using NEOS.EOS;

namespace NEOS.RPC.Responses
{
    public class GetBlockResponse
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }
        [JsonProperty("producer")]
        public string Producer { get; set; }
        [JsonProperty("confirmed")]
        public int Confirmed { get; set; }
        [JsonProperty("previous")]
        public string Previous { get; set; }
        [JsonProperty("transaction_mroot")]
        public string TransactionMroot { get; set; }
        [JsonProperty("action_mroot")]
        public string ActionMroot { get; set; }
        [JsonProperty("schedule_version")]
        public int ScheduleVersion { get; set; }
        [JsonProperty("new_producers")]
        public object NewProducers { get; set; }
        [JsonProperty("header_extensions")]
        public object[] HeaderExtensions { get; set; }
        [JsonProperty("producer_signature")]
        public string ProducerSignature { get; set; }
        [JsonProperty("transactions")]
        public TransactionReceipt[] Transactions { get; set; }
        [JsonProperty("block_extensions")]
        public object[] BlockExtensions { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("block_num")]
        public ulong BlockNum { get; set; }
        [JsonProperty("ref_block_prefix")]
        public ulong RefBlockPrefix { get; set; }
    }
}