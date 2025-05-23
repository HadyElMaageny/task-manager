using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsersAndTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "EndDate", "StartDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 21, 20, 43, 5, 941, DateTimeKind.Utc).AddTicks(2098), new DateTime(2025, 5, 24, 20, 43, 5, 941, DateTimeKind.Utc).AddTicks(2098), new DateTime(2025, 5, 19, 20, 43, 5, 941, DateTimeKind.Utc).AddTicks(2089), new DateTime(2025, 5, 21, 20, 43, 5, 941, DateTimeKind.Utc).AddTicks(2099) });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "EndDate", "StartDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 21, 20, 43, 5, 941, DateTimeKind.Utc).AddTicks(2104), new DateTime(2025, 5, 26, 20, 43, 5, 941, DateTimeKind.Utc).AddTicks(2103), new DateTime(2025, 5, 20, 20, 43, 5, 941, DateTimeKind.Utc).AddTicks(2103), new DateTime(2025, 5, 21, 20, 43, 5, 941, DateTimeKind.Utc).AddTicks(2104) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 21, 20, 43, 5, 941, DateTimeKind.Utc).AddTicks(1960), new DateTime(2025, 5, 21, 20, 43, 5, 941, DateTimeKind.Utc).AddTicks(1962) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 21, 20, 43, 5, 941, DateTimeKind.Utc).AddTicks(1966), new DateTime(2025, 5, 21, 20, 43, 5, 941, DateTimeKind.Utc).AddTicks(1967) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "EndDate", "StartDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 21, 20, 42, 51, 735, DateTimeKind.Utc).AddTicks(9229), new DateTime(2025, 5, 24, 20, 42, 51, 735, DateTimeKind.Utc).AddTicks(9229), new DateTime(2025, 5, 19, 20, 42, 51, 735, DateTimeKind.Utc).AddTicks(9218), new DateTime(2025, 5, 21, 20, 42, 51, 735, DateTimeKind.Utc).AddTicks(9230) });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "EndDate", "StartDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 21, 20, 42, 51, 735, DateTimeKind.Utc).AddTicks(9233), new DateTime(2025, 5, 26, 20, 42, 51, 735, DateTimeKind.Utc).AddTicks(9233), new DateTime(2025, 5, 20, 20, 42, 51, 735, DateTimeKind.Utc).AddTicks(9232), new DateTime(2025, 5, 21, 20, 42, 51, 735, DateTimeKind.Utc).AddTicks(9233) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 21, 20, 42, 51, 735, DateTimeKind.Utc).AddTicks(9133), new DateTime(2025, 5, 21, 20, 42, 51, 735, DateTimeKind.Utc).AddTicks(9134) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 21, 20, 42, 51, 735, DateTimeKind.Utc).AddTicks(9139), new DateTime(2025, 5, 21, 20, 42, 51, 735, DateTimeKind.Utc).AddTicks(9139) });
        }
    }
}
