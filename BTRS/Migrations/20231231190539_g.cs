using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTRS.Migrations
{
    public partial class g : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_busTrip_bus_busID",
                table: "busTrip");

            migrationBuilder.DropIndex(
                name: "IX_busTrip_busID",
                table: "busTrip");

            migrationBuilder.DropColumn(
                name: "busID",
                table: "busTrip");

            migrationBuilder.CreateTable(
                name: "Bus_busTrips",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusId = table.Column<int>(type: "int", nullable: false),
                    TripId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bus_busTrips", x => x.id);
                    table.ForeignKey(
                        name: "FK_Bus_busTrips_bus_BusId",
                        column: x => x.BusId,
                        principalTable: "bus",
                        principalColumn: "BusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bus_busTrips_busTrip_TripId",
                        column: x => x.TripId,
                        principalTable: "busTrip",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bus_busTrips_BusId",
                table: "Bus_busTrips",
                column: "BusId");

            migrationBuilder.CreateIndex(
                name: "IX_Bus_busTrips_TripId",
                table: "Bus_busTrips",
                column: "TripId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bus_busTrips");

            migrationBuilder.AddColumn<int>(
                name: "busID",
                table: "busTrip",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_busTrip_busID",
                table: "busTrip",
                column: "busID");

            migrationBuilder.AddForeignKey(
                name: "FK_busTrip_bus_busID",
                table: "busTrip",
                column: "busID",
                principalTable: "bus",
                principalColumn: "BusId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
