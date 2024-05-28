using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_grade_app.Migrations
{
    /// <inheritdoc />
    public partial class subject_enrolmentxxx : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SubjectEnrolment_SectionId",
                table: "SubjectEnrolment",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectEnrolment_SubjectId",
                table: "SubjectEnrolment",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectEnrolment_Sections_SectionId",
                table: "SubjectEnrolment",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectEnrolment_Subjects_SubjectId",
                table: "SubjectEnrolment",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectEnrolment_Sections_SectionId",
                table: "SubjectEnrolment");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectEnrolment_Subjects_SubjectId",
                table: "SubjectEnrolment");

            migrationBuilder.DropIndex(
                name: "IX_SubjectEnrolment_SectionId",
                table: "SubjectEnrolment");

            migrationBuilder.DropIndex(
                name: "IX_SubjectEnrolment_SubjectId",
                table: "SubjectEnrolment");
        }
    }
}
