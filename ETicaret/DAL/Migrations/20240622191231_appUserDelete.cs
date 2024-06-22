using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class appUserDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categories_AspNetUsers_AppUserId",
                table: "categories");

            migrationBuilder.DropForeignKey(
                name: "FK_products_AspNetUsers_AppUserId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_productsImages_AspNetUsers_AppUserId",
                table: "productsImages");

            migrationBuilder.DropIndex(
                name: "IX_productsImages_AppUserId",
                table: "productsImages");

            migrationBuilder.DropIndex(
                name: "IX_products_AppUserId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_categories_AppUserId",
                table: "categories");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7e3b5f34-0245-41ce-98f5-0ba5c62d006a", "AQAAAAIAAYagAAAAECErRqGaPqdGH/80CMf0mjk0Waq+y9IQeSYAY9goCG7ecFHCAitNbKycsbwbGUJVBA==", "2f45e02b-2ee0-4bb3-92c1-45cee0303120" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c240173e-d9c6-4957-997e-f3928ecd2851", "AQAAAAIAAYagAAAAEMtAHQPgUN2xcY8KtodtNGyPZxWctaeFfSZlFsBTt5KF5sZAeBK73B+GWWTnv6zr/Q==", "cfedf007-f834-454c-ac4c-f7f152d07691" });

            migrationBuilder.CreateIndex(
                name: "IX_productsImages_AppUserId",
                table: "productsImages",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_products_AppUserId",
                table: "products",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_categories_AppUserId",
                table: "categories",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_categories_AspNetUsers_AppUserId",
                table: "categories",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_AspNetUsers_AppUserId",
                table: "products",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_productsImages_AspNetUsers_AppUserId",
                table: "productsImages",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
