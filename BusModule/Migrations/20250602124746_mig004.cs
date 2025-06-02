using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusModule.Migrations
{
    /// <inheritdoc />
    public partial class mig004 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BusCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "One Way" },
                    { 2, "Two Way" }
                });

            migrationBuilder.InsertData(
                table: "BusTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Primary" },
                    { 2, "Kindergarten" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BusCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BusCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BusTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BusTypes",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
