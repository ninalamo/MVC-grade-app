using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_grade_app.Migrations
{
    /// <inheritdoc />
    public partial class gradesheetadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GradeSheets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeSheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GradeSheets_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentGrade",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GradeSheetId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentGrade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentGrade_GradeSheets_GradeSheetId",
                        column: x => x.GradeSheetId,
                        principalTable: "GradeSheets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudentActivity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Term = table.Column<int>(type: "int", nullable: false),
                    ActivityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentGradeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentActivity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentActivity_Activity_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentActivity_StudentGrade_StudentGradeId",
                        column: x => x.StudentGradeId,
                        principalTable: "StudentGrade",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GradeSheets_SectionId",
                table: "GradeSheets",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentActivity_ActivityId",
                table: "StudentActivity",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentActivity_StudentGradeId",
                table: "StudentActivity",
                column: "StudentGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGrade_GradeSheetId",
                table: "StudentGrade",
                column: "GradeSheetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentActivity");

            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "StudentGrade");

            migrationBuilder.DropTable(
                name: "GradeSheets");
        }
    }
}
