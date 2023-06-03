using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopping2.Migrations
{
    /// <inheritdoc />
    public partial class AddSaleAndSaleDetailsEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_temporalSales_AspNetUsers_UserId",
                table: "temporalSales");

            migrationBuilder.DropForeignKey(
                name: "FK_temporalSales_Products_ProductId",
                table: "temporalSales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_temporalSales",
                table: "temporalSales");

            migrationBuilder.RenameTable(
                name: "temporalSales",
                newName: "TemporalSales");

            migrationBuilder.RenameIndex(
                name: "IX_temporalSales_UserId",
                table: "TemporalSales",
                newName: "IX_TemporalSales_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_temporalSales_ProductId",
                table: "TemporalSales",
                newName: "IX_TemporalSales_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TemporalSales",
                table: "TemporalSales",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "saleDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleId = table.Column<int>(type: "int", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_saleDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_saleDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_saleDetails_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_saleDetails_ProductId",
                table: "saleDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_saleDetails_SaleId",
                table: "saleDetails",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_UserId",
                table: "Sales",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TemporalSales_AspNetUsers_UserId",
                table: "TemporalSales",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TemporalSales_Products_ProductId",
                table: "TemporalSales",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TemporalSales_AspNetUsers_UserId",
                table: "TemporalSales");

            migrationBuilder.DropForeignKey(
                name: "FK_TemporalSales_Products_ProductId",
                table: "TemporalSales");

            migrationBuilder.DropTable(
                name: "saleDetails");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TemporalSales",
                table: "TemporalSales");

            migrationBuilder.RenameTable(
                name: "TemporalSales",
                newName: "temporalSales");

            migrationBuilder.RenameIndex(
                name: "IX_TemporalSales_UserId",
                table: "temporalSales",
                newName: "IX_temporalSales_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TemporalSales_ProductId",
                table: "temporalSales",
                newName: "IX_temporalSales_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_temporalSales",
                table: "temporalSales",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_temporalSales_AspNetUsers_UserId",
                table: "temporalSales",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_temporalSales_Products_ProductId",
                table: "temporalSales",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
