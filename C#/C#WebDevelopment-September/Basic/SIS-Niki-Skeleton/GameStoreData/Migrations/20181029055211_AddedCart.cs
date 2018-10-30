using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStoreData.Migrations
{
    public partial class AddedCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Users_UserId1",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "Games",
                newName: "CartId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_UserId1",
                table: "Games",
                newName: "IX_Games_CartId");

            migrationBuilder.AddColumn<string>(
                name: "CartId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cart_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_UserId",
                table: "Cart",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Cart_CartId",
                table: "Games",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Cart_CartId",
                table: "Games");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "Games",
                newName: "UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_Games_CartId",
                table: "Games",
                newName: "IX_Games_UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Users_UserId1",
                table: "Games",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
