﻿// <auto-generated />
using BtcPriceSourcesTool.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BtcPriceSourcesTool.Migrations
{
    [DbContext(typeof(BtcPriceSourcesDbContext))]
    partial class BtcPriceSourcesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("BtcPriceSourcesTool.Models.BtcPriceResponse", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Response")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SourceId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("SourceId");

                    b.ToTable("BtcPriceResponses", (string)null);
                });

            modelBuilder.Entity("BtcPriceSourcesTool.Models.Source", b =>
                {
                    b.Property<int>("SourceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("SourceName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SourceURI")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("SourceId");

                    b.ToTable("Sources", (string)null);

                    b.HasData(
                        new
                        {
                            SourceId = 1,
                            SourceName = "Bitstamp",
                            SourceURI = "https://www.bitstamp.net/api/v2/ticker/btcusd"
                        },
                        new
                        {
                            SourceId = 2,
                            SourceName = "Bitfinex",
                            SourceURI = "https://api.bitfinex.com/v1/pubticker/btcusd"
                        });
                });

            modelBuilder.Entity("BtcPriceSourcesTool.Models.BtcPriceResponse", b =>
                {
                    b.HasOne("BtcPriceSourcesTool.Models.Source", "Source")
                        .WithMany("BtcPriceResponses")
                        .HasForeignKey("SourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Source");
                });

            modelBuilder.Entity("BtcPriceSourcesTool.Models.Source", b =>
                {
                    b.Navigation("BtcPriceResponses");
                });
#pragma warning restore 612, 618
        }
    }
}
