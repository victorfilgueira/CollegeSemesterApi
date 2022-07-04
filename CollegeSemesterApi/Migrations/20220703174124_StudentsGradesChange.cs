using Microsoft.EntityFrameworkCore.Migrations;

namespace CollegeSemesterApi.Migrations
{
    public partial class StudentsGradesChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "pFinal",
                table: "Students",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<float>(
                name: "p3",
                table: "Students",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<float>(
                name: "p2",
                table: "Students",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<float>(
                name: "p1",
                table: "Students",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "pFinal",
                table: "Students",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "p3",
                table: "Students",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "p2",
                table: "Students",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "p1",
                table: "Students",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);
        }
    }
}
