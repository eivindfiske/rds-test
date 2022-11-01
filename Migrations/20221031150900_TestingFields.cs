using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rds_test.Migrations
{
    public partial class TestingFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "pdsa_act",
                table: "suggestion",
                type: "varchar(500)",
                maxLength: 500,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "pdsa_do",
                table: "suggestion",
                type: "varchar(500)",
                maxLength: 500,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "pdsa_plan",
                table: "suggestion",
                type: "varchar(500)",
                maxLength: 500,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "pdsa_study",
                table: "suggestion",
                type: "varchar(500)",
                maxLength: 500,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "resdept",
                table: "suggestion",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "responsible",
                table: "suggestion",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "suggestion",
                type: "varchar(1)",
                maxLength: 1,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pdsa_act",
                table: "suggestion");

            migrationBuilder.DropColumn(
                name: "pdsa_do",
                table: "suggestion");

            migrationBuilder.DropColumn(
                name: "pdsa_plan",
                table: "suggestion");

            migrationBuilder.DropColumn(
                name: "pdsa_study",
                table: "suggestion");

            migrationBuilder.DropColumn(
                name: "resdept",
                table: "suggestion");

            migrationBuilder.DropColumn(
                name: "responsible",
                table: "suggestion");

            migrationBuilder.DropColumn(
                name: "status",
                table: "suggestion");
        }
    }
}
