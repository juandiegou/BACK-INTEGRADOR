using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Student : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discount_Student_StudentModelId",
                table: "Discount");

            migrationBuilder.DropForeignKey(
                name: "FK_Expense_Cohort_CohortModelId",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectModel_RegistrationModel_RegistrationModelId",
                table: "SubjectModel");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectModel_Teacher_TeacherId",
                table: "SubjectModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Program_ProgramModelId",
                table: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_SubjectModel_TeacherId",
                table: "SubjectModel");

            migrationBuilder.DropIndex(
                name: "IX_Discount_StudentModelId",
                table: "Discount");

            migrationBuilder.DropColumn(
                name: "StudentModelId",
                table: "Discount");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "SubjectModel",
                newName: "TeacherModel");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Discount",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateIndex(
                name: "IX_SubjectModel_TeacherModel",
                table: "SubjectModel",
                column: "TeacherModel",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Discount_Student_Id",
                table: "Discount",
                column: "Id",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_Cohort_CohortModelId",
                table: "Expense",
                column: "CohortModelId",
                principalTable: "Cohort",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectModel_RegistrationModel_RegistrationModelId",
                table: "SubjectModel",
                column: "RegistrationModelId",
                principalTable: "RegistrationModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectModel_Teacher_TeacherModel",
                table: "SubjectModel",
                column: "TeacherModel",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Program_ProgramModelId",
                table: "Teacher",
                column: "ProgramModelId",
                principalTable: "Program",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discount_Student_Id",
                table: "Discount");

            migrationBuilder.DropForeignKey(
                name: "FK_Expense_Cohort_CohortModelId",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectModel_RegistrationModel_RegistrationModelId",
                table: "SubjectModel");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectModel_Teacher_TeacherModel",
                table: "SubjectModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Program_ProgramModelId",
                table: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_SubjectModel_TeacherModel",
                table: "SubjectModel");

            migrationBuilder.RenameColumn(
                name: "TeacherModel",
                table: "SubjectModel",
                newName: "TeacherId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Discount",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "StudentModelId",
                table: "Discount",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubjectModel_TeacherId",
                table: "SubjectModel",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Discount_StudentModelId",
                table: "Discount",
                column: "StudentModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Discount_Student_StudentModelId",
                table: "Discount",
                column: "StudentModelId",
                principalTable: "Student",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_Cohort_CohortModelId",
                table: "Expense",
                column: "CohortModelId",
                principalTable: "Cohort",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectModel_RegistrationModel_RegistrationModelId",
                table: "SubjectModel",
                column: "RegistrationModelId",
                principalTable: "RegistrationModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectModel_Teacher_TeacherId",
                table: "SubjectModel",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Program_ProgramModelId",
                table: "Teacher",
                column: "ProgramModelId",
                principalTable: "Program",
                principalColumn: "Id");
        }
    }
}
