using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Efcore.Migrations
{
    /// <inheritdoc />
    public partial class firstmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Market",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarketName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Market", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BarcodeNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MarketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Market_MarketId",
                        column: x => x.MarketId,
                        principalTable: "Market",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Market",
                columns: new[] { "Id", "MarketName" },
                values: new object[] { 1, "Test Market" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BarcodeNumber", "MarketId", "Price", "ProductName" },
                values: new object[,]
                {
                    { "PROD-652D25BE", "8690504087038", 1, 9.90m, "Ülker Can pare" },
                    { "PROD-B4019871", "8690504111030", 1, 12.90m, "Ülker muzlu rondo" },
                    { "PROD-E8A02162", "8690504008002", 1, 10.90m, "Ülker çoko prens" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_MarketId",
                table: "Product",
                column: "MarketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Market");
        }
    }
}
