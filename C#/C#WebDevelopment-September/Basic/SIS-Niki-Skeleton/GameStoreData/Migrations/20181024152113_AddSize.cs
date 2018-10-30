using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStoreData.Migrations
{
    public partial class AddSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Size",
                table: "Games",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "Games");
        }
    }
}
