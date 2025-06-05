using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusModule.Migrations
{
    /// <inheritdoc />
    public partial class mig014 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "EmployeeId", "Password", "Role", "StudentId" },
                values: new object[] { "john@driver.com", 10, "driver123", "Driver", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "EmployeeId", "Password", "Role", "StudentId" },
                values: new object[] { "jane@admin.com", 11, "admin123", "Admin", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "EmployeeId", "Password", "Role", "StudentId" },
                values: new object[,]
                {
                    { 1, "ali@student.com", null, "123456", "Student", 1 },
                    { 2, "salma@student.com", null, "654321", "Student", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "EmployeeId", "Password", "Role", "StudentId" },
                values: new object[] { "ali@student.com", null, "123456", "Student", 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "EmployeeId", "Password", "Role", "StudentId" },
                values: new object[] { "salma@student.com", null, "654321", "Student", 2 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "EmployeeId", "Password", "Role", "StudentId" },
                values: new object[,]
                {
                    { 5, "john@driver.com", 10, "driver123", "Driver", null },
                    { 6, "jane@admin.com", 11, "admin123", "Admin", null }
                });
        }
    }
}
