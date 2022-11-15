using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rds_test.Migrations
{
    public partial class ImageUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "pic_after_data",
                table: "suggestion",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "pic_before_data",
                table: "suggestion",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pic_after_data",
                table: "suggestion");

            migrationBuilder.DropColumn(
                name: "pic_before_data",
                table: "suggestion");
        }
    }
}
