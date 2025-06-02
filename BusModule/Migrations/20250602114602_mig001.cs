using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusModule.Migrations
{
    /// <inheritdoc />
    public partial class mig001 : Migration
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
                table: "BusRoutes",
                columns: new[] { "Id", "EndPoint", "EndTime", "RouteName", "StartPoint", "StartTime" },
                values: new object[,]
                {
                    { 1, "Area 1", new TimeSpan(0, 8, 30, 0, 0), "Route A", "School", new TimeSpan(0, 7, 30, 0, 0) },
                    { 2, "Area 2", new TimeSpan(0, 8, 45, 0, 0), "Route B", "School", new TimeSpan(0, 7, 45, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "BusTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Primary" },
                    { 2, "Kindergarten" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FullName", "Grade" },
                values: new object[] { 1, "Ali Ahmed", "Grade 3" });

            migrationBuilder.InsertData(
                table: "Buses",
                columns: new[] { "Id", "BusCategoryId", "BusNumber", "BusRouteId", "BusTypeId", "Capacity", "DriverId", "Fees", "IsCapacityRestricted" },
                values: new object[] { 1, 2, "BUS-101", 1, 1, 30, 10, 150.00m, true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BusCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BusRoutes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BusTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BusCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BusRoutes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BusTypes",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
