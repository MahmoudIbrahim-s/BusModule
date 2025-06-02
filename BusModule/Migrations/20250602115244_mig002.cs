using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusModule.Migrations
{
    /// <inheritdoc />
    public partial class mig002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BusCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BusTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "BusCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "One Way");

            migrationBuilder.InsertData(
                table: "BusCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Two Way" });

            migrationBuilder.UpdateData(
                table: "BusTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Primary");

            migrationBuilder.InsertData(
                table: "BusTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Kindergarten" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BusCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BusTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "BusCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Two Way");

            migrationBuilder.InsertData(
                table: "BusCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "One Way" });

            migrationBuilder.UpdateData(
                table: "BusTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Kindergarten");

            migrationBuilder.InsertData(
                table: "BusTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Primary" });
        }
    }
}
