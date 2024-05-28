using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_grade_app.Migrations
{
    /// <inheritdoc />
    public partial class subject_enrolment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GradeSheets_Sections_SectionId",
                table: "GradeSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudentSubjects_StudentSubjectId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_StudentSubjectId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_GradeSheets_SectionId",
                table: "GradeSheets");

            migrationBuilder.DropColumn(
                name: "StudentSubjectId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "GradeSheets");

            migrationBuilder.AddColumn<Guid>(
                name: "StudentId",
                table: "StudentSubjects",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "SubjectEnrolment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectEnrolment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectEnrolment_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjects_StudentId",
                table: "StudentSubjects",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectEnrolment_StudentId",
                table: "SubjectEnrolment",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjects_Students_StudentId",
                table: "StudentSubjects",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjects_Students_StudentId",
                table: "StudentSubjects");

            migrationBuilder.DropTable(
                name: "SubjectEnrolment");

            migrationBuilder.DropIndex(
                name: "IX_StudentSubjects_StudentId",
                table: "StudentSubjects");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "StudentSubjects");

            migrationBuilder.AddColumn<Guid>(
                name: "StudentSubjectId",
                table: "Students",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SectionId",
                table: "GradeSheets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentSubjectId",
                table: "Students",
                column: "StudentSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeSheets_SectionId",
                table: "GradeSheets",
                column: "SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_GradeSheets_Sections_SectionId",
                table: "GradeSheets",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_StudentSubjects_StudentSubjectId",
                table: "Students",
                column: "StudentSubjectId",
                principalTable: "StudentSubjects",
                principalColumn: "Id");
        }
    }
}
