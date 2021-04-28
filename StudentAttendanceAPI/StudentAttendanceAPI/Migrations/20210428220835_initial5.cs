using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentAttendanceAPI.Migrations
{
    public partial class initial5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbStudentRegisters",
                columns: table => new
                {
                    StudentRegisterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    present = table.Column<bool>(type: "bit", nullable: false),
                    TbStudentStudentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbStudentRegisters", x => x.StudentRegisterId);
                    table.ForeignKey(
                        name: "FK_TbStudentRegisters_TbStudent_TbStudentStudentId",
                        column: x => x.TbStudentStudentId,
                        principalTable: "TbStudent",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbStudentRegisters_TbStudentStudentId",
                table: "TbStudentRegisters",
                column: "TbStudentStudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbStudentRegisters");
        }
    }
}
