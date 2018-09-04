using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Books.Data.Migrations
{
    public partial class status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BorrowDate",
                table: "BooksBorrowerses");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "BooksBorrowerses");

            migrationBuilder.DropColumn(
                name: "ReturnDate",
                table: "BooksBorrowerses");

            migrationBuilder.AddColumn<DateTime>(
                name: "BorrowDate",
                table: "Status",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnDate",
                table: "Status",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BorrowDate",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "ReturnDate",
                table: "Status");

            migrationBuilder.AddColumn<DateTime>(
                name: "BorrowDate",
                table: "BooksBorrowerses",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "BooksBorrowerses",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnDate",
                table: "BooksBorrowerses",
                nullable: true);
        }
    }
}
