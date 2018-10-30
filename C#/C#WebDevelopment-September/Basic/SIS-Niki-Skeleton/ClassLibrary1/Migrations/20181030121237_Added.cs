using Microsoft.EntityFrameworkCore.Migrations;

namespace GameSoreDataNew.Migrations
{
    public partial class Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartGame_Carts_CartId",
                table: "CartGame");

            migrationBuilder.DropForeignKey(
                name: "FK_CartGame_Games_GameId",
                table: "CartGame");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGame_Games_GameId",
                table: "UserGame");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGame_Users_UserId",
                table: "UserGame");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGame",
                table: "UserGame");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartGame",
                table: "CartGame");

            migrationBuilder.RenameTable(
                name: "UserGame",
                newName: "UserGames");

            migrationBuilder.RenameTable(
                name: "CartGame",
                newName: "CartGames");

            migrationBuilder.RenameIndex(
                name: "IX_UserGame_UserId",
                table: "UserGames",
                newName: "IX_UserGames_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserGame_GameId",
                table: "UserGames",
                newName: "IX_UserGames_GameId");

            migrationBuilder.RenameIndex(
                name: "IX_CartGame_GameId",
                table: "CartGames",
                newName: "IX_CartGames_GameId");

            migrationBuilder.RenameIndex(
                name: "IX_CartGame_CartId",
                table: "CartGames",
                newName: "IX_CartGames_CartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGames",
                table: "UserGames",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartGames",
                table: "CartGames",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartGames_Carts_CartId",
                table: "CartGames",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartGames_Games_GameId",
                table: "CartGames",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGames_Games_GameId",
                table: "UserGames",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGames_Users_UserId",
                table: "UserGames",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartGames_Carts_CartId",
                table: "CartGames");

            migrationBuilder.DropForeignKey(
                name: "FK_CartGames_Games_GameId",
                table: "CartGames");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGames_Games_GameId",
                table: "UserGames");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGames_Users_UserId",
                table: "UserGames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGames",
                table: "UserGames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartGames",
                table: "CartGames");

            migrationBuilder.RenameTable(
                name: "UserGames",
                newName: "UserGame");

            migrationBuilder.RenameTable(
                name: "CartGames",
                newName: "CartGame");

            migrationBuilder.RenameIndex(
                name: "IX_UserGames_UserId",
                table: "UserGame",
                newName: "IX_UserGame_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserGames_GameId",
                table: "UserGame",
                newName: "IX_UserGame_GameId");

            migrationBuilder.RenameIndex(
                name: "IX_CartGames_GameId",
                table: "CartGame",
                newName: "IX_CartGame_GameId");

            migrationBuilder.RenameIndex(
                name: "IX_CartGames_CartId",
                table: "CartGame",
                newName: "IX_CartGame_CartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGame",
                table: "UserGame",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartGame",
                table: "CartGame",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartGame_Carts_CartId",
                table: "CartGame",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartGame_Games_GameId",
                table: "CartGame",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGame_Games_GameId",
                table: "UserGame",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGame_Users_UserId",
                table: "UserGame",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
