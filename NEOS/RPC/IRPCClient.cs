using System.Threading.Tasks;
using NEOS.RPC.Responses;

namespace NEOS.RPC
{
    public interface IRPCClient
    {
        Task<GetInfoResponse> GetInfoAsync();
        Task<GetBlockResponse> GetBlockAsync(ulong blockNum);
        Task<GetBlockResponse> GetBlockAsync(string blockId);
        Task<GetAccountResponse> GetAccountAsync(string accountName);
    }
}