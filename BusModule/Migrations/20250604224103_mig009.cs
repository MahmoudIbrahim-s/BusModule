using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusModule.Migrations
{
    /// <inheritdoc />
    public partial class mig009 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EncryptedEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HashedPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Buses",
                columns: new[] { "Id", "BusCategoryId", "BusNumber", "BusRouteId", "BusTypeId", "Capacity", "DriverId", "Fees", "IsCapacityRestricted" },
                values: new object[] { 10, 2, "BUS-101", 1, 1, 30, 10, 150.00m, true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.InsertData(
                table: "Buses",
                columns: new[] { "Id", "BusCategoryId", "BusNumber", "BusRouteId", "BusTypeId", "Capacity", "DriverId", "Fees", "IsCapacityRestricted" },
                values: new object[] { 1, 2, "BUS-101", 1, 1, 30, 10, 150.00m, true });
        }
    }
}
