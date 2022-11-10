using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rds_test.Migrations
{
    public partial class TestDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "deadline",
                table: "suggestion",
                type: "Date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "deadline",
                table: "suggestion",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "Date",
                oldNullable: true);
        }
    }
}
