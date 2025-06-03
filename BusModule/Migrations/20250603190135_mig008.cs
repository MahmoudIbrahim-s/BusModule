using Microsoft.EntityFrameworkCore.Migrations;



#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusModule.Migrations
{
    /// <inheritdoc />
    public partial class mig008 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "FullName", "PasswordHash", "Role" },
                values: new object[,]
                {
                    { 10, "John@example.com", "John Doe", "123456", "Driver" },
                    { 11, "Jane@example.com", "Jane Smith", "123456", "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buses_DriverId",
                table: "Buses",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buses_Employees_DriverId",
                table: "Buses",
                column: "DriverId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buses_Employees_DriverId",
                table: "Buses");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Buses_DriverId",
                table: "Buses");
        }
    }
}
