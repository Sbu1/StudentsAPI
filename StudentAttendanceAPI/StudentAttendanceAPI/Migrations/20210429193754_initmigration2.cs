using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentAttendanceAPI.Migrations
{
    public partial class initmigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TbStudentRegisters",
                table: "TbStudentRegisters");

            migrationBuilder.DropIndex(
                name: "IX_TbStudentRegisters_StudentId",
                table: "TbStudentRegisters");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TbStudentRegisters",
                table: "TbStudentRegisters",
                columns: new[] { "StudentId", "Date" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TbStudentRegisters",
                table: "TbStudentRegisters");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TbStudentRegisters",
                table: "TbStudentRegisters",
                column: "StudentRegisterId");

            migrationBuilder.CreateIndex(
                name: "IX_TbStudentRegisters_StudentId",
                table: "TbStudentRegisters",
                column: "StudentId");
        }
    }
}
