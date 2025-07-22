using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blogb.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "Hash", "LastName", "Salt" },
                values: new object[] { 2, "kubrakilic@outlook.com", "Kubra", "dfhkhsdskdfffgfjgfjgkdfhjgkdf/=", "Kilic", "1234" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
