using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rds_test.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "applicationUseremp_num",
                table: "suggestion",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_suggestion_applicationUseremp_num",
                table: "suggestion",
                column: "applicationUseremp_num");

            migrationBuilder.AddForeignKey(
                name: "FK_suggestion_AspNetUsers_applicationUseremp_num",
                table: "suggestion",
                column: "applicationUseremp_num",
                principalTable: "AspNetUsers",
                principalColumn: "emp_num",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_suggestion_AspNetUsers_applicationUseremp_num",
                table: "suggestion");

            migrationBuilder.DropIndex(
                name: "IX_suggestion_applicationUseremp_num",
                table: "suggestion");

            migrationBuilder.DropColumn(
                name: "applicationUseremp_num",
                table: "suggestion");
        }
    }
}
