using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStoreData.Migrations
{
    public partial class LazyLoading12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Games",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Games");
        }
    }
}
