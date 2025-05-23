using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignedUserId = table.Column<long>(type: "bigint", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    AssignedUserNavId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskItems_Users_AssignedUserNavId",
                        column: x => x.AssignedUserNavId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "TaskItems",
                columns: new[] { "Id", "AssignedUserId", "AssignedUserNavId", "CreatedAt", "DeletedAt", "Description", "EndDate", "IsCompleted", "IsDeleted", "StartDate", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, 1L, null, new DateTime(2025, 5, 21, 20, 42, 51, 735, DateTimeKind.Utc).AddTicks(9229), null, "Set up the initial project structure", new DateTime(2025, 5, 24, 20, 42, 51, 735, DateTimeKind.Utc).AddTicks(9229), false, false, new DateTime(2025, 5, 19, 20, 42, 51, 735, DateTimeKind.Utc).AddTicks(9218), "Initialize project", new DateTime(2025, 5, 21, 20, 42, 51, 735, DateTimeKind.Utc).AddTicks(9230) },
                    { 2L, 2L, null, new DateTime(2025, 5, 21, 20, 42, 51, 735, DateTimeKind.Utc).AddTicks(9233), null, "Design the database schema", new DateTime(2025, 5, 26, 20, 42, 51, 735, DateTimeKind.Utc).AddTicks(9233), false, false, new DateTime(2025, 5, 20, 20, 42, 51, 735, DateTimeKind.Utc).AddTicks(9232), "Database design", new DateTime(2025, 5, 21, 20, 42, 51, 735, DateTimeKind.Utc).AddTicks(9233) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Email", "FirstName", "IsDeleted", "LastName", "Password", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 21, 20, 42, 51, 735, DateTimeKind.Utc).AddTicks(9133), null, "admin@example.com", "System", false, "Admin", "Admin@123", new DateTime(2025, 5, 21, 20, 42, 51, 735, DateTimeKind.Utc).AddTicks(9134), "admin" },
                    { 2L, new DateTime(2025, 5, 21, 20, 42, 51, 735, DateTimeKind.Utc).AddTicks(9139), null, "john.doe@example.com", "John", false, "Doe", "John@123", new DateTime(2025, 5, 21, 20, 42, 51, 735, DateTimeKind.Utc).AddTicks(9139), "johndoe" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_AssignedUserNavId",
                table: "TaskItems",
                column: "AssignedUserNavId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskItems");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
