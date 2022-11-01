using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rds_test.Migrations
{
    public partial class AddFieldsAndUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "suggestion",
                keyColumn: "title",
                keyValue: null,
                column: "title",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "suggestion",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateOnly>(
                name: "deadline",
                table: "suggestion",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "pic_after",
                table: "suggestion",
                type: "longblob",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "pic_before",
                table: "suggestion",
                type: "longblob",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "timeframe",
                table: "suggestion",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "deadline",
                table: "suggestion");

            migrationBuilder.DropColumn(
                name: "pic_after",
                table: "suggestion");

            migrationBuilder.DropColumn(
                name: "pic_before",
                table: "suggestion");

            migrationBuilder.DropColumn(
                name: "timeframe",
                table: "suggestion");

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "suggestion",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
