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

        public RPCClient(string httpEndpoint)
        {
            this.HttpEndpoint = httpEndpoint;
        }

        public async Task<GetInfoResponse> GetInfoAsync()
        {
            return await SendRequest<GetInfoResponse>("/v1/chain/get_info", HttpMethod.Post);
        }

        public async Task<GetBlockResponse> GetBlockAsync(ulong blockNum)
        {
            return await SendRequest<GetBlockResponse>("/v1/chain/get_block", HttpMethod.Post, new { block_num_or_id = blockNum });
        }

        public async Task<GetBlockResponse> GetBlockAsync(string blockId)
        {
            return await SendRequest<GetBlockResponse>("/v1/chain/get_block", HttpMethod.Post, new { block_num_or_id = blockId });
        }

        public async Task<GetAccountResponse> GetAccountAsync(string accountName)
        {
            return await SendRequest<GetAccountResponse>("/v1/chain/get_account", HttpMethod.Post, new { account_name = accountName });
        }

        private async Task<T> SendRequest<T>(string path, HttpMethod method, object body = null)
        {
            using (var hc = new HttpClient())
            {
                var hrm = new HttpRequestMessage(method, $"{this.HttpEndpoint}{path}");

                if (body != null)
                    hrm.Content = new StringContent(JsonConvert.SerializeObject(body), System.Text.Encoding.UTF8, "application/json");

                var response = await hc.SendAsync(hrm);
                string content = await response.Content.ReadAsStringAsync();
                var resultObj = JsonConvert.DeserializeObject<T>(content);

                System.Console.WriteLine(content);

                return resultObj;
            }
        }
    }
}