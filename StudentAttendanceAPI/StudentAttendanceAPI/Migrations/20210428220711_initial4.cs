using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentAttendanceAPI.Migrations
{
    public partial class initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "TbClass",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TbClass_UserName",
                table: "TbClass",
                column: "UserName");

            migrationBuilder.AddForeignKey(
                name: "FK_TbClass_AspNetUsers_UserName",
                table: "TbClass",
                column: "UserName",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbClass_AspNetUsers_UserName",
                table: "TbClass");

            migrationBuilder.DropIndex(
                name: "IX_TbClass_UserName",
                table: "TbClass");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "TbClass");
        }
    }
}
