using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class DbSets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6b688d0b-378b-476d-9074-e2a49c47c48e", "AQAAAAIAAYagAAAAEPnT0Z8uSBzaEGxyZc8usKpYBsbGRy55WlxtWGrvz9thAa0/t9/1zDHjUGvbWXSyMA==", "84500d5b-2002-45b2-994f-50ad9f4880ba" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b8ab1e76-e83f-4bb9-bc45-d08c064f0b88", "AQAAAAIAAYagAAAAEARjbr8cCOK4MWNUGE3/HiaMhrvmr5V6eAYC79BtN7D9AP2Ny9yMbJWMQDiEl3KV7g==", "5d0397d7-30a6-49c8-b6fd-dbfb2ce2b181" });
        }
    }
}
