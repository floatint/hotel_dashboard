using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelDashboard.Data.Migrations
{
    public partial class Clientchanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Client_RoomId",
                table: "Client",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Rooms_RoomId",
                table: "Client",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_Rooms_RoomId",
                table: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Client_RoomId",
                table: "Client");
        }
    }
}
