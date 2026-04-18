using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SlctdChecklist.Migrations
{
    /// <inheritdoc />
    public partial class Restructure1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SegmentShiftTask_Tasks_TasksToDoId",
                table: "SegmentShiftTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "ShiftTask");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ShiftTask",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShiftTask",
                table: "ShiftTask",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CompletionRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Done = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletionRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompletionRecords_ShiftTask_Id",
                        column: x => x.Id,
                        principalTable: "ShiftTask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_SegmentShiftTask_ShiftTask_TasksToDoId",
                table: "SegmentShiftTask",
                column: "TasksToDoId",
                principalTable: "ShiftTask",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SegmentShiftTask_ShiftTask_TasksToDoId",
                table: "SegmentShiftTask");

            migrationBuilder.DropTable(
                name: "CompletionRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShiftTask",
                table: "ShiftTask");

            migrationBuilder.RenameTable(
                name: "ShiftTask",
                newName: "Tasks");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Tasks",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SegmentShiftTask_Tasks_TasksToDoId",
                table: "SegmentShiftTask",
                column: "TasksToDoId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
