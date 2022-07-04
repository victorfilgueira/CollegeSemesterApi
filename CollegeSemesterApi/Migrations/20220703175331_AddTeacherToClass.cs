using Microsoft.EntityFrameworkCore.Migrations;

namespace CollegeSemesterApi.Migrations
{
    public partial class AddTeacherToClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TeacherId",
                table: "Classes",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Classes_TeacherId",
                table: "Classes",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Teachers_TeacherId",
                table: "Classes",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Teachers_TeacherId",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Classes_TeacherId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Classes");
        }
    }
}
