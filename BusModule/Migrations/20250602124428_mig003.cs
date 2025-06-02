using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusModule.Migrations
{
    /// <inheritdoc />
    public partial class mig003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BusCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BusCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BusTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BusTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FullName", "Grade" },
                values: new object[] { 2, "Salma Ibrahim", "Grade 4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "BusCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "One Way" },
                    { 3, "Two Way" }
                });

            migrationBuilder.InsertData(
                table: "BusTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "Primary" },
                    { 3, "Kindergarten" }
                });
        }
    }
}
