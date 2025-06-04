using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusModule.Migrations
{
    /// <inheritdoc />
    public partial class mig010 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Fees",
                table: "Buses",
                type: "decimal(10,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Fees",
                table: "Buses",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,4)");
        }
    }
}
