using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStoreData.Migrations
{
    public partial class LazyLoading1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Games");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Games",
                nullable: false,
                defaultValue: 0);
        }
    }
}
