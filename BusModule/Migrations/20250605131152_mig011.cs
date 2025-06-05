using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusModule.Migrations
{
    /// <inheritdoc />
    public partial class mig011 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "StudentId");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_EmployeeId",
                table: "Users",
                column: "EmployeeId",
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StudentId",
                table: "Users",
                column: "StudentId",
                unique: true,
                filter: "[StudentId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Employees_EmployeeId",
                table: "Users",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Students_StudentId",
                table: "Users",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Employees_EmployeeId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Students_StudentId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_EmployeeId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_StudentId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Users",
                newName: "UserId");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Email", "PasswordHash" },
                values: new object[] { "John@example.com", "123456" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Email", "PasswordHash" },
                values: new object[] { "Jane@example.com", "123456" });
        }
    }
}
