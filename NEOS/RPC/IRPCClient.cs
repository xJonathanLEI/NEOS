using System.Threading.Tasks;
using NEOS.RPC.Responses;

namespace NEOS.RPC
{
    public interface IRPCClient
    {
        Task<GetInfoResponse> GetInfo();
        Task<GetBlockResponse> GetBlock(ulong blockNum);
        Task<GetBlockResponse> GetBlock(string blockId);
    }
}