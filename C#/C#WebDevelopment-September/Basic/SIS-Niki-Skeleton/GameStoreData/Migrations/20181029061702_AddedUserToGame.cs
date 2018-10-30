using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStoreData.Migrations
{
    public partial class AddedUserToGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Cart_CartId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Users_UserId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_CartId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_UserId",
                table: "Games");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Games",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CartId",
                table: "Games",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CartsGames",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CartId = table.Column<int>(nullable: false),
                    GameId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartsGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartsGames_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartsGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersGames",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    GameId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersGames_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartsGames_CartId",
                table: "CartsGames",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartsGames_GameId",
                table: "CartsGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersGames_GameId",
                table: "UsersGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersGames_UserId",
                table: "UsersGames",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartsGames");

            migrationBuilder.DropTable(
                name: "UsersGames");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Games",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CartId",
                table: "Games",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_CartId",
                table: "Games",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_UserId",
                table: "Games",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Cart_CartId",
                table: "Games",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Users_UserId",
                table: "Games",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
