using Microsoft.EntityFrameworkCore.Migrations;

namespace MyPlace.Migrations
{
    public partial class AddBookingUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rents_Bookings_BookingId",
                table: "Rents");

            migrationBuilder.DropIndex(
                name: "IX_Rents_BookingId",
                table: "Rents");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Rents");

            migrationBuilder.CreateTable(
                name: "BookingRent",
                columns: table => new
                {
                    bookingsId = table.Column<int>(type: "int", nullable: false),
                    rentsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingRent", x => new { x.bookingsId, x.rentsID });
                    table.ForeignKey(
                        name: "FK_BookingRent_Bookings_bookingsId",
                        column: x => x.bookingsId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingRent_Rents_rentsID",
                        column: x => x.rentsID,
                        principalTable: "Rents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingRent_rentsID",
                table: "BookingRent",
                column: "rentsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingRent");

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Rents",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rents_BookingId",
                table: "Rents",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rents_Bookings_BookingId",
                table: "Rents",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
