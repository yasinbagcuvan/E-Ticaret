using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class dbset1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RowNum = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_categories_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    İlanBasligi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kilometre = table.Column<int>(type: "int", nullable: false),
                    CikisYili = table.Column<int>(type: "int", nullable: false),
                    Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MotorHacmi = table.Column<short>(type: "smallint", nullable: false),
                    MotorGücü = table.Column<short>(type: "smallint", nullable: false),
                    Sehir = table.Column<int>(type: "int", nullable: false),
                    Yakit = table.Column<int>(type: "int", nullable: false),
                    Vites = table.Column<int>(type: "int", nullable: false),
                    AracDurumu = table.Column<int>(type: "int", nullable: false),
                    KasaTipi = table.Column<int>(type: "int", nullable: false),
                    Cekis = table.Column<int>(type: "int", nullable: false),
                    Renk = table.Column<int>(type: "int", nullable: false),
                    Garanti = table.Column<int>(type: "int", nullable: false),
                    AgirHasarKayitli = table.Column<int>(type: "int", nullable: false),
                    PlakaUyruk = table.Column<int>(type: "int", nullable: false),
                    Kimden = table.Column<int>(type: "int", nullable: false),
                    Takasli = table.Column<int>(type: "int", nullable: false),
                    Boyali = table.Column<int>(type: "int", nullable: false),
                    Degisen = table.Column<int>(type: "int", nullable: false),
                    RowNum = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_products_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_products_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "productsImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    RowNum = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productsImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_productsImages_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_productsImages_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c240173e-d9c6-4957-997e-f3928ecd2851", "AQAAAAIAAYagAAAAEMtAHQPgUN2xcY8KtodtNGyPZxWctaeFfSZlFsBTt5KF5sZAeBK73B+GWWTnv6zr/Q==", "cfedf007-f834-454c-ac4c-f7f152d07691" });

            migrationBuilder.CreateIndex(
                name: "IX_categories_AppUserId",
                table: "categories",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_products_AppUserId",
                table: "products",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_products_CategoryId",
                table: "products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_productsImages_AppUserId",
                table: "productsImages",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_productsImages_ProductId",
                table: "productsImages",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productsImages");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6b688d0b-378b-476d-9074-e2a49c47c48e", "AQAAAAIAAYagAAAAEPnT0Z8uSBzaEGxyZc8usKpYBsbGRy55WlxtWGrvz9thAa0/t9/1zDHjUGvbWXSyMA==", "84500d5b-2002-45b2-994f-50ad9f4880ba" });
        }
    }
}
