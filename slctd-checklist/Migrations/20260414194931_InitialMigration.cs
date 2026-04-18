using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SlctdChecklist.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Checklists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Shift = table.Column<int>(type: "INTEGER", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", maxLength: 21, nullable: false),
                    Employee = table.Column<string>(type: "TEXT", nullable: true),
                    Date = table.Column<DateOnly>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checklists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ShortName = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskSegments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartBy = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    DueBy = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    ChecklistId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskSegments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskSegments_Checklists_ChecklistId",
                        column: x => x.ChecklistId,
                        principalTable: "Checklists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SegmentShiftTask",
                columns: table => new
                {
                    ParentSegmentsId = table.Column<int>(type: "INTEGER", nullable: false),
                    TasksToDoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SegmentShiftTask", x => new { x.ParentSegmentsId, x.TasksToDoId });
                    table.ForeignKey(
                        name: "FK_SegmentShiftTask_TaskSegments_ParentSegmentsId",
                        column: x => x.ParentSegmentsId,
                        principalTable: "TaskSegments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SegmentShiftTask_Tasks_TasksToDoId",
                        column: x => x.TasksToDoId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SegmentShiftTask_TasksToDoId",
                table: "SegmentShiftTask",
                column: "TasksToDoId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskSegments_ChecklistId",
                table: "TaskSegments",
                column: "ChecklistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SegmentShiftTask");

            migrationBuilder.DropTable(
                name: "TaskSegments");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Checklists");
        }
    }
}
