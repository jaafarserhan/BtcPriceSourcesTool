using BtcPriceSourcesTool.Models;

namespace BtcPriceSourcesTool.Contracts
{
    public interface IBtcPriceResponseRepository
    {
        Task<List<BtcPriceResponse>> GetBtcHistoryBySourceId(int SourceID);
        Task<BtcPriceResponse> GetBtcPriceBySourceId(int SourceID);
    }
}
