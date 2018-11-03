using Microsoft.EntityFrameworkCore.Migrations;

namespace TorshiaData.Migrations
{
    public partial class TaskSector : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskSector_Sectors_SectorId",
                table: "TaskSector");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskSector_Tasks_TaskId",
                table: "TaskSector");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskSector",
                table: "TaskSector");

            migrationBuilder.RenameTable(
                name: "TaskSector",
                newName: "TaskSectors");

            migrationBuilder.RenameIndex(
                name: "IX_TaskSector_TaskId",
                table: "TaskSectors",
                newName: "IX_TaskSectors_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskSector_SectorId",
                table: "TaskSectors",
                newName: "IX_TaskSectors_SectorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskSectors",
                table: "TaskSectors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskSectors_Sectors_SectorId",
                table: "TaskSectors",
                column: "SectorId",
                principalTable: "Sectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskSectors_Tasks_TaskId",
                table: "TaskSectors",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskSectors_Sectors_SectorId",
                table: "TaskSectors");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskSectors_Tasks_TaskId",
                table: "TaskSectors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskSectors",
                table: "TaskSectors");

            migrationBuilder.RenameTable(
                name: "TaskSectors",
                newName: "TaskSector");

            migrationBuilder.RenameIndex(
                name: "IX_TaskSectors_TaskId",
                table: "TaskSector",
                newName: "IX_TaskSector_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskSectors_SectorId",
                table: "TaskSector",
                newName: "IX_TaskSector_SectorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskSector",
                table: "TaskSector",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskSector_Sectors_SectorId",
                table: "TaskSector",
                column: "SectorId",
                principalTable: "Sectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskSector_Tasks_TaskId",
                table: "TaskSector",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
