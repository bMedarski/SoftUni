using Microsoft.EntityFrameworkCore.Migrations;

namespace Eventures.Data.Migrations
{
    public partial class ucn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UniqueCitizenNumber",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UniqueCitizenNumber",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
