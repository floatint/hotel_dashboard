using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelDashboard.Data.Migrations
{
    public partial class RoomStatuschanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_RoomStatus_StatusId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_StatusId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Rooms");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "RoomStatus",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RoomStatus_RoomId",
                table: "RoomStatus",
                column: "RoomId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomStatus_Rooms_RoomId",
                table: "RoomStatus",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomStatus_Rooms_RoomId",
                table: "RoomStatus");

            migrationBuilder.DropIndex(
                name: "IX_RoomStatus_RoomId",
                table: "RoomStatus");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "RoomStatus");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Rooms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_StatusId",
                table: "Rooms",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_RoomStatus_StatusId",
                table: "Rooms",
                column: "StatusId",
                principalTable: "RoomStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
