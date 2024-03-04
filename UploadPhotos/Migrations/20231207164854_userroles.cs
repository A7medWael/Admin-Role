using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UploadPhotos.Migrations
{
    /// <inheritdoc />
    public partial class userroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4bcafa8c-4aed-43a3-8499-89414d857fb6", "53319645-70f5-4a7c-a447-02bc676fb5f5", "User", "user" },
                    { "b53b06a1-7eca-4afd-ab0d-cf923b5d43c6", "e376a9e6-0894-4d17-b4fc-37628757dbed", "Admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4bcafa8c-4aed-43a3-8499-89414d857fb6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b53b06a1-7eca-4afd-ab0d-cf923b5d43c6");
        }
    }
}
