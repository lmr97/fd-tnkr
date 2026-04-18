using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SlctdChecklist.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSegementName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SegmentShiftTask_TaskSegments_ParentSegmentsId",
                table: "SegmentShiftTask");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskSegments_Checklists_ChecklistId",
                table: "TaskSegments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskSegments",
                table: "TaskSegments");

            migrationBuilder.RenameTable(
                name: "TaskSegments",
                newName: "Segments");

            migrationBuilder.RenameIndex(
                name: "IX_TaskSegments_ChecklistId",
                table: "Segments",
                newName: "IX_Segments_ChecklistId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Segments",
                table: "Segments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Segments_Checklists_ChecklistId",
                table: "Segments",
                column: "ChecklistId",
                principalTable: "Checklists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SegmentShiftTask_Segments_ParentSegmentsId",
                table: "SegmentShiftTask",
                column: "ParentSegmentsId",
                principalTable: "Segments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Segments_Checklists_ChecklistId",
                table: "Segments");

            migrationBuilder.DropForeignKey(
                name: "FK_SegmentShiftTask_Segments_ParentSegmentsId",
                table: "SegmentShiftTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Segments",
                table: "Segments");

            migrationBuilder.RenameTable(
                name: "Segments",
                newName: "TaskSegments");

            migrationBuilder.RenameIndex(
                name: "IX_Segments_ChecklistId",
                table: "TaskSegments",
                newName: "IX_TaskSegments_ChecklistId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskSegments",
                table: "TaskSegments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SegmentShiftTask_TaskSegments_ParentSegmentsId",
                table: "SegmentShiftTask",
                column: "ParentSegmentsId",
                principalTable: "TaskSegments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskSegments_Checklists_ChecklistId",
                table: "TaskSegments",
                column: "ChecklistId",
                principalTable: "Checklists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
