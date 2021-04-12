using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalog.Persistence.Database.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Catalog");

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Catalog",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                schema: "Catalog",
                columns: table => new
                {
                    ProducInStockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.ProducInStockId);
                    table.ForeignKey(
                        name: "FK_Stocks_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Catalog",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Description for Product 1", "Product 1", 292m },
                    { 73, "Description for Product 73", "Product 73", 681m },
                    { 72, "Description for Product 72", "Product 72", 752m },
                    { 71, "Description for Product 71", "Product 71", 273m },
                    { 70, "Description for Product 70", "Product 70", 213m },
                    { 69, "Description for Product 69", "Product 69", 377m },
                    { 68, "Description for Product 68", "Product 68", 649m },
                    { 67, "Description for Product 67", "Product 67", 358m },
                    { 66, "Description for Product 66", "Product 66", 816m },
                    { 65, "Description for Product 65", "Product 65", 388m },
                    { 64, "Description for Product 64", "Product 64", 682m },
                    { 63, "Description for Product 63", "Product 63", 153m },
                    { 62, "Description for Product 62", "Product 62", 851m },
                    { 61, "Description for Product 61", "Product 61", 186m },
                    { 60, "Description for Product 60", "Product 60", 895m },
                    { 59, "Description for Product 59", "Product 59", 435m },
                    { 58, "Description for Product 58", "Product 58", 489m },
                    { 57, "Description for Product 57", "Product 57", 796m },
                    { 56, "Description for Product 56", "Product 56", 823m },
                    { 55, "Description for Product 55", "Product 55", 713m },
                    { 54, "Description for Product 54", "Product 54", 150m },
                    { 53, "Description for Product 53", "Product 53", 967m },
                    { 74, "Description for Product 74", "Product 74", 608m },
                    { 52, "Description for Product 52", "Product 52", 590m },
                    { 75, "Description for Product 75", "Product 75", 879m },
                    { 77, "Description for Product 77", "Product 77", 288m },
                    { 98, "Description for Product 98", "Product 98", 598m },
                    { 97, "Description for Product 97", "Product 97", 846m },
                    { 96, "Description for Product 96", "Product 96", 908m },
                    { 95, "Description for Product 95", "Product 95", 459m },
                    { 94, "Description for Product 94", "Product 94", 914m },
                    { 93, "Description for Product 93", "Product 93", 406m },
                    { 92, "Description for Product 92", "Product 92", 866m },
                    { 91, "Description for Product 91", "Product 91", 872m },
                    { 90, "Description for Product 90", "Product 90", 188m },
                    { 89, "Description for Product 89", "Product 89", 468m },
                    { 88, "Description for Product 88", "Product 88", 461m },
                    { 87, "Description for Product 87", "Product 87", 994m },
                    { 86, "Description for Product 86", "Product 86", 925m },
                    { 85, "Description for Product 85", "Product 85", 124m },
                    { 84, "Description for Product 84", "Product 84", 764m },
                    { 83, "Description for Product 83", "Product 83", 982m }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 82, "Description for Product 82", "Product 82", 914m },
                    { 81, "Description for Product 81", "Product 81", 850m },
                    { 80, "Description for Product 80", "Product 80", 979m },
                    { 79, "Description for Product 79", "Product 79", 582m },
                    { 78, "Description for Product 78", "Product 78", 456m },
                    { 76, "Description for Product 76", "Product 76", 126m },
                    { 51, "Description for Product 51", "Product 51", 744m },
                    { 50, "Description for Product 50", "Product 50", 839m },
                    { 49, "Description for Product 49", "Product 49", 358m },
                    { 22, "Description for Product 22", "Product 22", 469m },
                    { 21, "Description for Product 21", "Product 21", 926m },
                    { 20, "Description for Product 20", "Product 20", 639m },
                    { 19, "Description for Product 19", "Product 19", 153m },
                    { 18, "Description for Product 18", "Product 18", 491m },
                    { 17, "Description for Product 17", "Product 17", 495m },
                    { 16, "Description for Product 16", "Product 16", 530m },
                    { 15, "Description for Product 15", "Product 15", 782m },
                    { 14, "Description for Product 14", "Product 14", 289m },
                    { 13, "Description for Product 13", "Product 13", 731m },
                    { 12, "Description for Product 12", "Product 12", 770m },
                    { 11, "Description for Product 11", "Product 11", 778m },
                    { 10, "Description for Product 10", "Product 10", 804m },
                    { 9, "Description for Product 9", "Product 9", 451m },
                    { 8, "Description for Product 8", "Product 8", 656m },
                    { 7, "Description for Product 7", "Product 7", 192m },
                    { 6, "Description for Product 6", "Product 6", 824m },
                    { 5, "Description for Product 5", "Product 5", 778m },
                    { 4, "Description for Product 4", "Product 4", 244m },
                    { 3, "Description for Product 3", "Product 3", 496m },
                    { 2, "Description for Product 2", "Product 2", 343m },
                    { 23, "Description for Product 23", "Product 23", 546m },
                    { 24, "Description for Product 24", "Product 24", 107m },
                    { 25, "Description for Product 25", "Product 25", 808m },
                    { 26, "Description for Product 26", "Product 26", 883m },
                    { 48, "Description for Product 48", "Product 48", 824m },
                    { 47, "Description for Product 47", "Product 47", 132m },
                    { 46, "Description for Product 46", "Product 46", 829m },
                    { 45, "Description for Product 45", "Product 45", 524m },
                    { 44, "Description for Product 44", "Product 44", 190m },
                    { 43, "Description for Product 43", "Product 43", 280m },
                    { 42, "Description for Product 42", "Product 42", 900m },
                    { 41, "Description for Product 41", "Product 41", 759m }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 40, "Description for Product 40", "Product 40", 545m },
                    { 39, "Description for Product 39", "Product 39", 810m },
                    { 99, "Description for Product 99", "Product 99", 802m },
                    { 38, "Description for Product 38", "Product 38", 742m },
                    { 36, "Description for Product 36", "Product 36", 668m },
                    { 35, "Description for Product 35", "Product 35", 912m },
                    { 34, "Description for Product 34", "Product 34", 182m },
                    { 33, "Description for Product 33", "Product 33", 511m },
                    { 32, "Description for Product 32", "Product 32", 962m },
                    { 31, "Description for Product 31", "Product 31", 516m },
                    { 30, "Description for Product 30", "Product 30", 768m },
                    { 29, "Description for Product 29", "Product 29", 603m },
                    { 28, "Description for Product 28", "Product 28", 341m },
                    { 27, "Description for Product 27", "Product 27", 738m },
                    { 37, "Description for Product 37", "Product 37", 356m },
                    { 100, "Description for Product 100", "Product 100", 708m }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Stocks",
                columns: new[] { "ProducInStockId", "ProductId", "Stock" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 73, 73, 13 },
                    { 72, 72, 19 },
                    { 71, 71, 7 },
                    { 70, 70, 13 },
                    { 69, 69, 16 },
                    { 68, 68, 10 },
                    { 67, 67, 12 },
                    { 66, 66, 17 },
                    { 65, 65, 13 },
                    { 64, 64, 3 },
                    { 63, 63, 11 },
                    { 62, 62, 3 },
                    { 61, 61, 6 },
                    { 60, 60, 4 },
                    { 59, 59, 12 },
                    { 58, 58, 3 },
                    { 57, 57, 9 },
                    { 56, 56, 18 },
                    { 55, 55, 9 },
                    { 54, 54, 19 },
                    { 53, 53, 4 },
                    { 74, 74, 12 },
                    { 52, 52, 4 },
                    { 75, 75, 5 },
                    { 77, 77, 16 },
                    { 98, 98, 4 },
                    { 97, 97, 12 },
                    { 96, 96, 17 },
                    { 95, 95, 7 },
                    { 94, 94, 7 },
                    { 93, 93, 8 },
                    { 92, 92, 9 },
                    { 91, 91, 18 },
                    { 90, 90, 0 },
                    { 89, 89, 6 },
                    { 88, 88, 14 },
                    { 87, 87, 3 },
                    { 86, 86, 15 },
                    { 85, 85, 18 },
                    { 84, 84, 9 },
                    { 83, 83, 14 }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Stocks",
                columns: new[] { "ProducInStockId", "ProductId", "Stock" },
                values: new object[,]
                {
                    { 82, 82, 8 },
                    { 81, 81, 13 },
                    { 80, 80, 16 },
                    { 79, 79, 2 },
                    { 78, 78, 1 },
                    { 76, 76, 15 },
                    { 51, 51, 16 },
                    { 50, 50, 12 },
                    { 49, 49, 12 },
                    { 22, 22, 4 },
                    { 21, 21, 19 },
                    { 20, 20, 7 },
                    { 19, 19, 6 },
                    { 18, 18, 5 },
                    { 17, 17, 0 },
                    { 16, 16, 1 },
                    { 15, 15, 1 },
                    { 14, 14, 15 },
                    { 13, 13, 5 },
                    { 12, 12, 5 },
                    { 11, 11, 5 },
                    { 10, 10, 13 },
                    { 9, 9, 18 },
                    { 8, 8, 13 },
                    { 7, 7, 11 },
                    { 6, 6, 15 },
                    { 5, 5, 10 },
                    { 4, 4, 18 },
                    { 3, 3, 4 },
                    { 2, 2, 19 },
                    { 23, 23, 9 },
                    { 24, 24, 0 },
                    { 25, 25, 5 },
                    { 26, 26, 5 },
                    { 48, 48, 19 },
                    { 47, 47, 12 },
                    { 46, 46, 9 },
                    { 45, 45, 18 },
                    { 44, 44, 8 },
                    { 43, 43, 8 },
                    { 42, 42, 4 },
                    { 41, 41, 1 }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Stocks",
                columns: new[] { "ProducInStockId", "ProductId", "Stock" },
                values: new object[,]
                {
                    { 40, 40, 13 },
                    { 39, 39, 12 },
                    { 99, 99, 14 },
                    { 38, 38, 1 },
                    { 36, 36, 7 },
                    { 35, 35, 19 },
                    { 34, 34, 15 },
                    { 33, 33, 13 },
                    { 32, 32, 8 },
                    { 31, 31, 0 },
                    { 30, 30, 15 },
                    { 29, 29, 1 },
                    { 28, 28, 7 },
                    { 27, 27, 8 },
                    { 37, 37, 13 },
                    { 100, 100, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductId",
                schema: "Catalog",
                table: "Products",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductId",
                schema: "Catalog",
                table: "Stocks",
                column: "ProductId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "Catalog");
        }
    }
}
