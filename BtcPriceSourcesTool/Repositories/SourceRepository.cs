using BtcPriceSourcesTool.Contracts;
using BtcPriceSourcesTool.Models;
using Microsoft.EntityFrameworkCore;

namespace BtcPriceSourcesTool.Repositories
{
    public class SourceRepository : ISourceRepository
    {
        private BtcPriceSourcesDbContext ctx;

        public SourceRepository()
        {
            ctx = ConfigureDbContext.Context;
        }

        public void Dispose()
        {
            try
            {
                GC.Collect();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Source>> GetAll()
        {

            return ctx.Sources.ToList();
        }


        public async Task<Source> GetById(int id)
        {
            try
            {
                return ctx.Sources.Where(s => s.SourceId == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
