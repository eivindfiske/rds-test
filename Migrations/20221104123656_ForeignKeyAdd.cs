using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rds_test.Migrations
{
    public partial class ForeignKeyAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "emp_num",
                table: "suggestion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_suggestion_emp_num",
                table: "suggestion",
                column: "emp_num");

            migrationBuilder.AddForeignKey(
                name: "FK_suggestion_emp_emp_num",
                table: "suggestion",
                column: "emp_num",
                principalTable: "emp",
                principalColumn: "emp_num",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_suggestion_emp_emp_num",
                table: "suggestion");

            migrationBuilder.DropIndex(
                name: "IX_suggestion_emp_num",
                table: "suggestion");

            migrationBuilder.DropColumn(
                name: "emp_num",
                table: "suggestion");
        }
    }
}
