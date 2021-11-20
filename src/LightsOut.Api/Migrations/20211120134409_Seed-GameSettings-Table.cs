using Microsoft.EntityFrameworkCore.Migrations;

namespace LightsOut.Api.Migrations
{
    public partial class SeedGameSettingsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GameSettings",
                columns: new[] { "Id", "BoardSize", "Name" },
                values: new object[] { 1, 5, "5 x 5" });

            migrationBuilder.InsertData(
                table: "GameSettings",
                columns: new[] { "Id", "BoardSize", "Name" },
                values: new object[] { 2, 8, "8 x 8" });

            migrationBuilder.InsertData(
                table: "GameSettings",
                columns: new[] { "Id", "BoardSize", "Name" },
                values: new object[] { 3, 10, "10 x 10" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GameSettings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GameSettings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GameSettings",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
