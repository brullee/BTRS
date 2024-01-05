using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTRS.Migrations
{
    public partial class gg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_busTrip_admin_adminID",
                table: "busTrip");

            migrationBuilder.RenameColumn(
                name: "adminID",
                table: "busTrip",
                newName: "AdminID");

            migrationBuilder.RenameIndex(
                name: "IX_busTrip_adminID",
                table: "busTrip",
                newName: "IX_busTrip_AdminID");

            migrationBuilder.AddForeignKey(
                name: "FK_busTrip_admin_AdminID",
                table: "busTrip",
                column: "AdminID",
                principalTable: "admin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_busTrip_admin_AdminID",
                table: "busTrip");

            migrationBuilder.RenameColumn(
                name: "AdminID",
                table: "busTrip",
                newName: "adminID");

            migrationBuilder.RenameIndex(
                name: "IX_busTrip_AdminID",
                table: "busTrip",
                newName: "IX_busTrip_adminID");

            migrationBuilder.AddForeignKey(
                name: "FK_busTrip_admin_adminID",
                table: "busTrip",
                column: "adminID",
                principalTable: "admin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
