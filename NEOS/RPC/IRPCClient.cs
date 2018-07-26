using System.Threading.Tasks;
using NEOS.RPC.Responses;

namespace NEOS.RPC
{
    public interface IRPCClient
    {
        /* Chain API */

        Task<GetInfoResponse> GetInfoAsync();
        Task<GetBlockResponse> GetBlockAsync(ulong blockNum);
        Task<GetBlockResponse> GetBlockAsync(string blockId);
        Task<GetAccountResponse> GetAccountAsync(string accountName);

        /* History API */
        Task<GetActionsResponse> GetActionsAsync(int position, int offset, string accountName);
    }
}