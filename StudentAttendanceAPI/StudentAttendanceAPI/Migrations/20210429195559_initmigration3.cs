using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentAttendanceAPI.Migrations
{
    public partial class initmigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "TbStudentRegisters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TbStudentRegisters_ClassId",
                table: "TbStudentRegisters",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbStudentRegisters_TbClass_ClassId",
                table: "TbStudentRegisters",
                column: "ClassId",
                principalTable: "TbClass",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbStudentRegisters_TbClass_ClassId",
                table: "TbStudentRegisters");

            migrationBuilder.DropIndex(
                name: "IX_TbStudentRegisters_ClassId",
                table: "TbStudentRegisters");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "TbStudentRegisters");
        }
    }
}
