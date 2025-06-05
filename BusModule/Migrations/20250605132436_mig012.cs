using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusModule.Migrations
{
    /// <inheritdoc />
    public partial class mig012 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HashedPassword",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "EncryptedEmail",
                table: "Users",
                newName: "Email");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "EmployeeId", "Password", "Role", "StudentId" },
                values: new object[,]
                {
                    { 1, "ali@student.com", null, "123456", "Student", 1 },
                    { 2, "salma@student.com", null, "654321", "Student", 2 },
                    { 3, "john@driver.com", 10, "driver123", "Driver", null },
                    { 4, "jane@admin.com", 11, "admin123", "Admin", null }
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

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "HashedPassword");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "EncryptedEmail");
        }
    }
}
