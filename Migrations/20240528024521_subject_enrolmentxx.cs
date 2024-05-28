using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_grade_app.Migrations
{
    /// <inheritdoc />
    public partial class subject_enrolmentxx : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentActivity");

            migrationBuilder.DropTable(
                name: "StudentGrade");

            migrationBuilder.DropTable(
                name: "GradeSheets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GradeSheets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeSheets", x => x.Id);
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
                    table.ForeignKey(
                        name: "FK_StudentGrade_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentActivity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActivityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentGradeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Term = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentActivity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentActivity_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentActivity_StudentGrade_StudentGradeId",
                        column: x => x.StudentGradeId,
                        principalTable: "StudentGrade",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_StudentGrade_StudentId",
                table: "StudentGrade",
                column: "StudentId");
        }
    }
}
