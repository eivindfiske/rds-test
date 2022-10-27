using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rds_test.Migrations
{
    public partial class KeyUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_emp_team",
                table: "emp",
                column: "team");

            migrationBuilder.AddForeignKey(
                name: "FK_emp_dept_team",
                table: "emp",
                column: "team",
                principalTable: "dept",
                principalColumn: "team",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_emp_dept_team",
                table: "emp");

            migrationBuilder.DropIndex(
                name: "IX_emp_team",
                table: "emp");
        }
    }
}
