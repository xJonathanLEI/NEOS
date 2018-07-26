using System;
using Newtonsoft.Json;
using NEOS.EOS;

namespace NEOS.RPC.Responses
{
    public class GetActionsResponse
    {
        [JsonProperty("actions")]
        public ActionInfo[] Actions { get; set; }
    }
}