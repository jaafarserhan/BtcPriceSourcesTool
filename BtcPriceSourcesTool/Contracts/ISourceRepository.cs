using BtcPriceSourcesTool.Models;

namespace BtcPriceSourcesTool.Contracts
{
    public interface ISourceRepository 
    {
        Task<List<Source>> GetAll();

        Task<Source> GetById(int id);
    }
}
