using Microsoft.EntityFrameworkCore;

namespace BtcPriceSourcesTool.Models
{
    public class BtcPriceSourcesDbContext :DbContext
    {
        public BtcPriceSourcesDbContext(DbContextOptions<BtcPriceSourcesDbContext> options)
                   : base(options)
        {

        }

        public DbSet<Source> Sources { get; set; }
        public DbSet<BtcPriceResponse> BtcPriceResponses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=BtcPriceSourcesToolDb.db");
            SQLitePCL.Batteries.Init();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Source>().ToTable("Sources");
            modelBuilder.Entity<BtcPriceResponse>().ToTable("BtcPriceResponses");

            modelBuilder.Entity<Source>().HasData(
        new Source { SourceId = 1, SourceName = "Bitstamp", SourceURI = "https://www.bitstamp.net/api/v2/ticker/btcusd" },
        new Source { SourceId = 2, SourceName = "Bitfinex", SourceURI = "https://api.bitfinex.com/v1/pubticker/btcusd" });

        }
    }
}