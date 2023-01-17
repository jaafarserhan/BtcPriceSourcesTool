using BtcPriceSourcesTool.Models;
using Microsoft.EntityFrameworkCore;

namespace BtcPriceSourcesTool
{
    public class ConfigureDbContext
    {
        public static BtcPriceSourcesDbContext Context
        {
            get
            {
                var builder = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json");
                var config = builder.Build();
                var context = new DbContextOptionsBuilder<BtcPriceSourcesDbContext>()
                    .UseSqlite(config.GetConnectionString("DefaultConnection")
                    );
                return new BtcPriceSourcesDbContext(context.Options);
            }
        }
    }
}
