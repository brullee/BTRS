using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTRS.Migrations
{
    public partial class n : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bus_busTrips_bus_BusId",
                table: "Bus_busTrips");

            migrationBuilder.DropForeignKey(
                name: "FK_Bus_busTrips_busTrip_TripId",
                table: "Bus_busTrips");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bus_busTrips",
                table: "Bus_busTrips");

            migrationBuilder.RenameTable(
                name: "Bus_busTrips",
                newName: "bus_busTrips");

            migrationBuilder.RenameIndex(
                name: "IX_Bus_busTrips_TripId",
                table: "bus_busTrips",
                newName: "IX_bus_busTrips_TripId");

            migrationBuilder.RenameIndex(
                name: "IX_Bus_busTrips_BusId",
                table: "bus_busTrips",
                newName: "IX_bus_busTrips_BusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bus_busTrips",
                table: "bus_busTrips",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_bus_busTrips_bus_BusId",
                table: "bus_busTrips",
                column: "BusId",
                principalTable: "bus",
                principalColumn: "BusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_bus_busTrips_busTrip_TripId",
                table: "bus_busTrips",
                column: "TripId",
                principalTable: "busTrip",
                principalColumn: "TripId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bus_busTrips_bus_BusId",
                table: "bus_busTrips");

            migrationBuilder.DropForeignKey(
                name: "FK_bus_busTrips_busTrip_TripId",
                table: "bus_busTrips");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bus_busTrips",
                table: "bus_busTrips");

            migrationBuilder.RenameTable(
                name: "bus_busTrips",
                newName: "Bus_busTrips");

            migrationBuilder.RenameIndex(
                name: "IX_bus_busTrips_TripId",
                table: "Bus_busTrips",
                newName: "IX_Bus_busTrips_TripId");

            migrationBuilder.RenameIndex(
                name: "IX_bus_busTrips_BusId",
                table: "Bus_busTrips",
                newName: "IX_Bus_busTrips_BusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bus_busTrips",
                table: "Bus_busTrips",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bus_busTrips_bus_BusId",
                table: "Bus_busTrips",
                column: "BusId",
                principalTable: "bus",
                principalColumn: "BusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bus_busTrips_busTrip_TripId",
                table: "Bus_busTrips",
                column: "TripId",
                principalTable: "busTrip",
                principalColumn: "TripId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
