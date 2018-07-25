using System.Threading.Tasks;
using NEOS.RPC.Responses;

namespace NEOS.RPC
{
    public interface IRPCClient
    {
        Task<GetInfoResponse> GetInfo();
    }
}