using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BtcPriceSourcesTool.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sources",
                columns: table => new
                {
                    SourceId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SourceName = table.Column<string>(type: "TEXT", nullable: false),
                    SourceURI = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sources", x => x.SourceId);
                });

            migrationBuilder.CreateTable(
                name: "BtcPriceResponses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Response = table.Column<string>(type: "TEXT", nullable: false),
                    SourceId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BtcPriceResponses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BtcPriceResponses_Sources_SourceId",
                        column: x => x.SourceId,
                        principalTable: "Sources",
                        principalColumn: "SourceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Sources",
                columns: new[] { "SourceId", "SourceName", "SourceURI" },
                values: new object[,]
                {
                    { 1, "Bitstamp", "https://www.bitstamp.net/api/v2/ticker/btcusd" },
                    { 2, "Bitfinex", "https://api.bitfinex.com/v1/pubticker/btcusd" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BtcPriceResponses_SourceId",
                table: "BtcPriceResponses",
                column: "SourceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BtcPriceResponses");

            migrationBuilder.DropTable(
                name: "Sources");
        }
    }
}
