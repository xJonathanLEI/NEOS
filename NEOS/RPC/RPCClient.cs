using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NEOS.RPC.Responses;

namespace NEOS.RPC
{
    public class RPCClient : IRPCClient
    {
        public string HttpEndpoint { get; }
        public string ChainId { get; }

        private string keyProvider;

        public RPCClient(string httpEndpoint, string chainId, string keyProvider)
        {
            this.HttpEndpoint = httpEndpoint;
            this.ChainId = chainId;
            this.keyProvider = keyProvider;
        }

        public async Task<GetInfoResponse> GetInfo()
        {
            return await SendRequest<GetInfoResponse>("/v1/chain/get_info", HttpMethod.Post);
        }

        private async Task<T> SendRequest<T>(string path, HttpMethod method)
        {
            using (var hc = new HttpClient())
            {
                var hrm = new HttpRequestMessage(method, $"{this.HttpEndpoint}{path}");
                var response = await hc.SendAsync(hrm);
                string content = await response.Content.ReadAsStringAsync();
                var resultObj = JsonConvert.DeserializeObject<T>(content);

                return resultObj;
            }
        }
    }
}