using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SlctdChecklist.Migrations
{
    /// <inheritdoc />
    public partial class LinkSegmentsToChecklist4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChecklistSubmissions_Checklist_Id",
                table: "ChecklistSubmissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Segments_Checklist_ChecklistId",
                table: "Segments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Checklist",
                table: "Checklist");

            migrationBuilder.RenameTable(
                name: "Checklist",
                newName: "Checklists");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Checklists",
                table: "Checklists",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChecklistSubmissions_Checklists_Id",
                table: "ChecklistSubmissions",
                column: "Id",
                principalTable: "Checklists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Segments_Checklists_ChecklistId",
                table: "Segments",
                column: "ChecklistId",
                principalTable: "Checklists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChecklistSubmissions_Checklists_Id",
                table: "ChecklistSubmissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Segments_Checklists_ChecklistId",
                table: "Segments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Checklists",
                table: "Checklists");

            migrationBuilder.RenameTable(
                name: "Checklists",
                newName: "Checklist");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Checklist",
                table: "Checklist",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChecklistSubmissions_Checklist_Id",
                table: "ChecklistSubmissions",
                column: "Id",
                principalTable: "Checklist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Segments_Checklist_ChecklistId",
                table: "Segments",
                column: "ChecklistId",
                principalTable: "Checklist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
