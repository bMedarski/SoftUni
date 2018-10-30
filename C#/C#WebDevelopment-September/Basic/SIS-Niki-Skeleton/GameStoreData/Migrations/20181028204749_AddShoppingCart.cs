using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStoreData.Migrations
{
    public partial class AddShoppingCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Games",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_UserId1",
                table: "Games",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Users_UserId1",
                table: "Games",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Users_UserId1",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_UserId1",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Games");
        }
    }
}
