using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SlctdChecklist.Migrations
{
    /// <inheritdoc />
    public partial class DistinctSubmissionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Segments_Checklists_ChecklistId",
                table: "Segments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Checklists",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "Employee",
                table: "Checklists");

            migrationBuilder.RenameTable(
                name: "Checklists",
                newName: "Checklist");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Checklist",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Checklist",
                table: "Checklist",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ChecklistSubmissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Employee = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChecklistSubmissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChecklistSubmissions_Checklist_Id",
                        column: x => x.Id,
                        principalTable: "Checklist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Segments_Checklist_ChecklistId",
                table: "Segments",
                column: "ChecklistId",
                principalTable: "Checklist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Segments_Checklist_ChecklistId",
                table: "Segments");

            migrationBuilder.DropTable(
                name: "ChecklistSubmissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Checklist",
                table: "Checklist");

            migrationBuilder.RenameTable(
                name: "Checklist",
                newName: "Checklists");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Checklists",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "Date",
                table: "Checklists",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Checklists",
                type: "TEXT",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Employee",
                table: "Checklists",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Checklists",
                table: "Checklists",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Segments_Checklists_ChecklistId",
                table: "Segments",
                column: "ChecklistId",
                principalTable: "Checklists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
