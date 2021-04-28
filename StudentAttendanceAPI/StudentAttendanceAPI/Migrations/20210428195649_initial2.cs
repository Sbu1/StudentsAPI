using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentAttendanceAPI.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ClassName",
                table: "TbClass",
                type: "nvarchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "TbStudent",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(6)", nullable: true),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    ParentCellNumber = table.Column<int>(type: "int", nullable: false),
                    ParentEmail = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    ClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbStudent", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_TbStudent_TbClass_ClassId",
                        column: x => x.ClassId,
                        principalTable: "TbClass",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbStudent_ClassId",
                table: "TbStudent",
                column: "ClassId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbStudent");

            migrationBuilder.AlterColumn<string>(
                name: "ClassName",
                table: "TbClass",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldNullable: true);
        }
    }
}
