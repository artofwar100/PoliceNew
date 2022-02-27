using Microsoft.EntityFrameworkCore.Migrations;

namespace PoliceNew.Data.Migrations
{
    public partial class nullabledepartmentId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Officers_Departments_DepartmentId",
                table: "Officers");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Officers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Officers_Departments_DepartmentId",
                table: "Officers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Officers_Departments_DepartmentId",
                table: "Officers");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Officers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Officers_Departments_DepartmentId",
                table: "Officers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
