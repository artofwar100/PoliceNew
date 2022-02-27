using Microsoft.EntityFrameworkCore.Migrations;

namespace PoliceNew.Data.Migrations
{
    public partial class departmentofficeroneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Officers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Officers_DepartmentId",
                table: "Officers",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Officers_Departments_DepartmentId",
                table: "Officers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Officers_Departments_DepartmentId",
                table: "Officers");

            migrationBuilder.DropIndex(
                name: "IX_Officers_DepartmentId",
                table: "Officers");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Officers");
        }
    }
}
