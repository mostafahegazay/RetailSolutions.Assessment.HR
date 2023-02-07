using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RetailSolutions.Assessment.HR.Migrations
{
    /// <inheritdoc />
    public partial class addentitiesTracking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppShift",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    ShiftType = table.Column<int>(type: "INTEGER", nullable: false),
                    FromTime = table.Column<string>(type: "TEXT", nullable: true),
                    ToTime = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppShift", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppTimeLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FromTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ToTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ExtraProperties = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatorId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppTimeLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppTimeLog_AbpUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppTimeLog_CreatorId",
                table: "AppTimeLog",
                column: "CreatorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppShift");

            migrationBuilder.DropTable(
                name: "AppTimeLog");
        }
    }
}
