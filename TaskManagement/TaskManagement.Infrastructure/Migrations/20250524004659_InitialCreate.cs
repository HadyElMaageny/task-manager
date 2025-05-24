using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskItem_User_AssignedUserId",
                        column: x => x.AssignedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "LastName", "Password", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 24, 0, 46, 58, 560, DateTimeKind.Utc).AddTicks(9528), "admin@example.com", "System", "Admin", "Admin@123", new DateTime(2025, 5, 24, 0, 46, 58, 560, DateTimeKind.Utc).AddTicks(9530), "admin" },
                    { 2L, new DateTime(2025, 5, 24, 0, 46, 58, 560, DateTimeKind.Utc).AddTicks(9535), "john.doe@example.com", "John", "Doe", "John@123", new DateTime(2025, 5, 24, 0, 46, 58, 560, DateTimeKind.Utc).AddTicks(9535), "johndoe" }
                });

            migrationBuilder.InsertData(
                table: "TaskItems",
                columns: new[] { "Id", "AssignedUserId", "CreatedAt", "Description", "EndDate", "IsCompleted", "StartDate", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2025, 5, 24, 0, 46, 58, 560, DateTimeKind.Utc).AddTicks(9609), "Set up the initial project structure", new DateTime(2025, 5, 27, 0, 46, 58, 560, DateTimeKind.Utc).AddTicks(9609), false, new DateTime(2025, 5, 22, 0, 46, 58, 560, DateTimeKind.Utc).AddTicks(9604), "Initialize project", new DateTime(2025, 5, 24, 0, 46, 58, 560, DateTimeKind.Utc).AddTicks(9610) },
                    { 2L, 2L, new DateTime(2025, 5, 24, 0, 46, 58, 560, DateTimeKind.Utc).AddTicks(9612), "Design the database schema", new DateTime(2025, 5, 29, 0, 46, 58, 560, DateTimeKind.Utc).AddTicks(9612), false, new DateTime(2025, 5, 23, 0, 46, 58, 560, DateTimeKind.Utc).AddTicks(9612), "Database design", new DateTime(2025, 5, 24, 0, 46, 58, 560, DateTimeKind.Utc).AddTicks(9613) },
                    { 3L, 1L, new DateTime(2025, 5, 24, 0, 46, 58, 560, DateTimeKind.Utc).AddTicks(9614), "Set up user authentication and authorization", new DateTime(2025, 5, 31, 0, 46, 58, 560, DateTimeKind.Utc).AddTicks(9614), false, new DateTime(2025, 5, 24, 0, 46, 58, 560, DateTimeKind.Utc).AddTicks(9614), "Implement authentication", new DateTime(2025, 5, 24, 0, 46, 58, 560, DateTimeKind.Utc).AddTicks(9615) },
                    { 4L, 2L, new DateTime(2025, 5, 24, 0, 46, 58, 560, DateTimeKind.Utc).AddTicks(9620), "Develop the necessary API endpoints for the application", new DateTime(2025, 6, 3, 0, 46, 58, 560, DateTimeKind.Utc).AddTicks(9619), false, new DateTime(2025, 5, 25, 0, 46, 58, 560, DateTimeKind.Utc).AddTicks(9619), "Create API endpoints", new DateTime(2025, 5, 24, 0, 46, 58, 560, DateTimeKind.Utc).AddTicks(9620) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_AssignedUserId",
                table: "TaskItems",
                column: "AssignedUserId");
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
