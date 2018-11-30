using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Eventures.Data.Migrations
{
    public partial class order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventuresOrders",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    OrderedOn = table.Column<DateTime>(nullable: false),
                    CustomerId = table.Column<string>(nullable: true),
                    EventId = table.Column<string>(nullable: true),
                    TicketsCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventuresOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventuresOrders_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventuresOrders_EventuresEvents_EventId",
                        column: x => x.EventId,
                        principalTable: "EventuresEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventuresOrders_CustomerId",
                table: "EventuresOrders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_EventuresOrders_EventId",
                table: "EventuresOrders",
                column: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventuresOrders");
        }
    }
}
